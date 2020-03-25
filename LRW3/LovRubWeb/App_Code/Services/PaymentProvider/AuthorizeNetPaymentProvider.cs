#region dCPL Version 1.1.1
/*
The contents of this file are subject to the dashCommerce Public License
Version 1.1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.dashcommerce.org

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is dashCommerce.

The Initial Developer of the Original Code is Mettle Systems LLC.
Portions created by Mettle Systems LLC are Copyright (C) 2007. All Rights Reserved.
*/
#endregion
 
using System;
using System.Xml;  //KPL 
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.IO;
using Commerce.Common; // OrderNote


namespace Commerce.Providers
{
    public class AuthorizeNetPaymentProvider:PaymentProvider
    {
        string strMaleItemCode = "LRM1";
        string strFemaleItemCode = "LRW1";
        string sDiscountMaleItemCode = "LRMCC1";
        string sDiscountFemaleItemCode = "LRWCC1";
        string sMassageGelItemCode = "DFDF";
        string sHHValentineItemCode = "LRHHVAL";
        string sFemaleValentineItemCode = "LRFEMALEVAL";
        string sMaleValentineItemCode = "LRMALEVAL";
        string sLipLovItemCode = "LRLL";
        string sDiscountLipLovItemCode = "LRLLCC1";

        string sRLG6ItemCode = "RLG6";
        string sRLG6DiscountItemCode = "RLG6CC1";
        string sSurvivalItemCode = "LRSURV";
        string sChocBDItemCode = "LRCHOCDB";
        string sCherryBDItemCode = "LRCHERDB";

        decimal dFemaleUnitPrice = 0, dMaleUnitPrice = 0, dRLG6UnitPrice = 0, dValentinePrice = 0, dLipLovUnitPrice = 0;
        decimal dFemaleDiscountPrice, dMaleDiscountPrice = 0, dRLG6DiscountPrice = 0, dLipLovDiscountPrice = 0;
        decimal dSurvivalUnitPrice = 0;
        decimal dChocDBUnitPrice = 0;
        decimal dCherDBUnitPrice = 0;
        
        //properties
        #region Passed-in Props
        string serviceUserName = "";
        string servicePassword = "";
        string transactionKey = "";
        string serverURL = "";
        string currencyCode = "USD";
        #endregion

        #region Provider specific behaviors

        public override void Initialize(string name, NameValueCollection config)
        {

            // Verify that config isn't null
            if (config == null)
                throw new ArgumentNullException("config");
           
            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
            {
                config.Remove("name");
                config.Add("name",
                    "AuthorizeNetPaymentProvider");
            }            
            // Add a default "description" attribute to config if the
            // attribute doesn't exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description",
                    "Authorize.Net Payment Provider");
            }
            base.Initialize(name, config);

            serviceUserName = config["serviceUserName"].ToString();
            if (String.IsNullOrEmpty(serviceUserName))
                throw new ProviderException("Empty Authorize.Net Username value");
            config.Remove("serviceUserName");

            servicePassword = config["servicePassword"].ToString();
            if (String.IsNullOrEmpty(servicePassword))
                throw new ProviderException("Empty Authorize.Net Password value");
            config.Remove("servicePassword");

            transactionKey = config["transactionKey"].ToString();
            if (String.IsNullOrEmpty(transactionKey))
                throw new ProviderException("Empty Transaction Key value");
            config.Remove("transactionKey");

            serverURL = config["serverURL"].ToString();
            if (String.IsNullOrEmpty(serverURL))
                throw new ProviderException("Empty Server URL value");
            config.Remove("serverURL");

            currencyCode = config["currencyCode"].ToString();
            if (String.IsNullOrEmpty(currencyCode))
                throw new ProviderException("Empty Currency Code value");
            config.Remove("currencyCode");

        
        }

        public override string Name
        {
            get
            {
                return null;
            }
        }
        #endregion

        public override Commerce.Common.Transaction Charge(Commerce.Common.Order order)
        {
            //string sOut = "";
            decimal dTotal = order.OrderTotal;
            int roundTo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalDigits;
            dTotal = Math.Round(dTotal, roundTo);

            //make sure that the ExpMonth has a leading 0
            string sExpMonth = order.CreditCardExpireMonth.ToString();
            if (order.CreditCardExpireMonth < 10)
                sExpMonth = "0" + sExpMonth;

            bool useTestServer = serverURL.IndexOf("test") >= 0;

            String strPost = "x_login=" + serviceUserName +
                "&x_tran_key=" + transactionKey +
                "&x_method=CC" +
                "&x_type=AUTH_CAPTURE" +  // KPL uncommented out 09/11/09
                //"&x_type=AUTH_ONLY" +       // KPL commented 09/11/09
                "&x_amount=" + dTotal.ToString() +
                "&x_delim_data=TRUE" +
                "&x_delim_char=|" +
                "&x_relay_response=FALSE" +
                "&x_card_num=" + order.CreditCardNumber +
                "&x_exp_date=" + sExpMonth + order.CreditCardExpireYear.ToString() +
                "&x_version=3.1" +
                //the following is optional however it's good to have for records
                "&x_first_name=" + order.BillingAddress.FirstName +
                "&x_last_name=" + order.BillingAddress.LastName +
                "&x_address=" + order.BillingAddress.Address1 +
                "&x_city=" + order.BillingAddress.City +
                "&x_state=" + order.BillingAddress.StateOrRegion +
                "&x_zip=" + order.BillingAddress.Zip +
                "&x_currency_code=" + currencyCode +
                "&x_country=" + order.BillingAddress.Country +
                "&x_card_code=" + order.CreditCardSecurityNumber;

            //you can set this up to send you an email if you like
            //by adding this: 
            //&x_merchant_email=me@email.com

            //you can also have them send you customer an email
            //&x_email=mycustomer@email.com&x_email_customer=TRUE

            if (useTestServer)
                strPost += "&x_test_request=TRUE";

            //*******************************************************
            // Post to AUTHORIZE.NET and get response.
            //*******************************************************
            Commerce.Common.Transaction trans = new Commerce.Common.Transaction();
            WebClient wc = new WebClient();
            try
            {
                byte[] response = wc.UploadData(serverURL, System.Text.ASCIIEncoding.UTF8.GetBytes(strPost));
                String result = System.Text.ASCIIEncoding.UTF8.GetString(response);
                string[] lines = result.Split('|');

                //the response flag is the first item
                //1=success, 2=declined, 3=error
                string sFlag = lines[0];

                if (sFlag == "1")
                {
                    trans.GatewayResponse = lines[37];
                    trans.AuthorizationCode = lines[4];

                    //return the transactionID
                    trans.GatewayResponse = result;
                }
                else if (sFlag == "2")
                {
                    trans.GatewayResponse = lines[3];
                    throw new Exception("Declined: " + lines[3]);
                }
                else
                {
                    trans.GatewayResponse = lines[3];
                    throw new Exception("Error: " + lines[3]);
                }
            }
            catch (Exception e)
            {
                LovRubLogger.LogException( e, strPost );
                throw e;
            }
            /* we got rid of OM! 11/26
            // Call OrderMotion to submit order to them.
            string strKeycode = "";
            GetKeyCode(order, out strKeycode);
            *** END we got rid of OM! 11/26 **/
/*************** Commented out for new price change KPL 09/20/08
            if (strKeycode.Equals("CALLCENTER") ) // Added for new CallCenter KPL 06/06/08
                CallCenterOrderMotion(order, trans.AuthorizationCode, trans.TransactionID);
            else
                OrderMotion(order, trans.AuthorizationCode, trans.TransactionID);
 ****************/

            /******************** Commented out cuz we're leaving OM.            
                        CallCenterOrderMotion(order, trans.AuthorizationCode, trans.TransactionID);
            ********************/ 
            return trans;
        }

        /************************************************************
        * CallCenterGetTotalBottlesOrdered()
         * determine total quantity ordered
         * get nFullMaleQty
         * get nDiscountMaleQty
         * get nFullFemaleQty
         * get nDiscountFemaleQty
         * get nFreeBottle
         *******************/
        public void CallCenterGetTotalBottlesOrdered(Commerce.Common.Order order,
                                                     out int nTotalQty,
                                                     out int nFullMaleQty,
                                                     out int nDiscountMaleQty,
                                                     out int nFullFemaleQty,
                                                     out int nDiscountFemaleQty,
                                                     out int nRL6FullQty,
                                                     out int nRLG6DiscountQty,
                                                     out int nHHValQty,
                                                     out int nFemaleValQty,
                                                     out int nMaleValQty,
                                                     out int nFreeQty,
                                                     out int nLipLovFullQty,
                                                     out int nLipLovDiscountQty,
                                                     out int nSurvivalFullQty )
        {
            int nIndex = 0;

            nFreeQty = 0;
            nTotalQty = 0;
            nFullMaleQty = 0;
            nDiscountMaleQty = 0;
            nFullFemaleQty = 0;
            nDiscountFemaleQty = 0;
            nRL6FullQty = 0;
            nRLG6DiscountQty = 0;
            nFemaleValQty = nMaleValQty = 0;
            nHHValQty = 0;

            nLipLovFullQty = 0;
            nLipLovDiscountQty = 0;
            nSurvivalFullQty = 0;

            int nItems = order.Items.Count;
            for (nIndex = 0; nIndex < nItems; nIndex++)
            {
                if ("LRM1" == order.Items[nIndex].Sku)
                {
                    nFullMaleQty = (int)order.Items[nIndex].Quantity;
                    dMaleUnitPrice = order.Items[nIndex].PricePaid;
                }

                if ("LRSURV" == order.Items[nIndex].Sku)
                {
                    nSurvivalFullQty = (int)order.Items[nIndex].Quantity;
                    dSurvivalUnitPrice = order.Items[nIndex].PricePaid;
                }

                
                if ("LRW1" == order.Items[nIndex].Sku)
                {
                    nFullFemaleQty = order.Items[nIndex].Quantity;
                    dFemaleUnitPrice = order.Items[nIndex].PricePaid;
                }

                if ("RLG6" == order.Items[nIndex].Sku)
                {
                    nRL6FullQty = order.Items[nIndex].Quantity;
                    dRLG6UnitPrice = order.Items[nIndex].PricePaid;
                }

                if ("LRLL" == order.Items[nIndex].Sku)
                {
                    nLipLovFullQty = order.Items[nIndex].Quantity;
                    dLipLovUnitPrice = order.Items[nIndex].PricePaid;
                }


                if ("RLG6CC1" == order.Items[nIndex].Sku)
                {
                    nRLG6DiscountQty = order.Items[nIndex].Quantity;
                    dRLG6DiscountPrice = order.Items[nIndex].PricePaid;
                }


                if ("LRMCC1" == order.Items[nIndex].Sku)
                {
                    nDiscountMaleQty = order.Items[nIndex].Quantity;
                    dMaleDiscountPrice = order.Items[nIndex].PricePaid;
                }
                if ("LRWCC1" == order.Items[nIndex].Sku)
                {
                    nDiscountFemaleQty = order.Items[nIndex].Quantity;
                    dFemaleDiscountPrice = order.Items[nIndex].PricePaid;
                }

                if ("LRLLCC1" == order.Items[nIndex].Sku)
                {
                    nLipLovDiscountQty = order.Items[nIndex].Quantity;
                    dLipLovDiscountPrice = order.Items[nIndex].PricePaid;
                }


                if ("DFDF" == order.Items[nIndex].Sku)
                {
                    nFreeQty = order.Items[nIndex].Quantity;
                }


                // Valentine's Day Gifts
                if (("LRHHVAL" == order.Items[nIndex].Sku))
                {
                    nHHValQty += order.Items[nIndex].Quantity;
                    dValentinePrice = order.Items[nIndex].PricePaid;
                }

                if (("LRFEMALEVAL" == order.Items[nIndex].Sku))
                {
                    nFemaleValQty += order.Items[nIndex].Quantity;
                    dValentinePrice = order.Items[nIndex].PricePaid;
                }

                if (("LRMALEVAL" == order.Items[nIndex].Sku))
                {
                    nMaleValQty += order.Items[nIndex].Quantity;
                    dValentinePrice = order.Items[nIndex].PricePaid;
                }
            }

            nTotalQty = nFullMaleQty +
                        nDiscountMaleQty +
                        nFullFemaleQty +
                        nDiscountFemaleQty +
                        nRL6FullQty +
                        nRLG6DiscountQty +
                        nHHValQty +
                        nMaleValQty +
                        nFemaleValQty +
                        nFreeQty +
                        nLipLovFullQty +
                        nLipLovDiscountQty;
        }

        //************************************************************
        //
        //GetTotalBottlesOrdered()
        //
        //************************************************************
        public void GetTotalBottlesOrdered( Commerce.Common.Order order, out int nTotalQty, 
                                                                         out int nMaleQty, 
                                                                         out int nFemaleQty,
                                                                         out int nRLQty)
        {
            int nIndex =0;
            nTotalQty = 0;
            nMaleQty = 0;
            nFemaleQty = 0;
            nRLQty = 0;

            // determine total qty ordered
            int nItems = order.Items.Count;
            for (nIndex = 0; nIndex < nItems; nIndex++)
            {
                if (("LRFreeMale" != order.Items[nIndex].Sku) && ("LRFreeFemale" != order.Items[nIndex].Sku))
                    nTotalQty += order.Items[nIndex].Quantity;
            }

            // determine how many male
            // determine how many female
            for (nIndex = 0; nIndex < nItems; nIndex++)
            {
                if (strMaleItemCode == order.Items[nIndex].Sku)
                {
                    nMaleQty += order.Items[nIndex].Quantity;
                    dMaleUnitPrice = order.Items[nIndex].PricePaid;

                }

                if (strFemaleItemCode == order.Items[nIndex].Sku)
                {
                    nFemaleQty += order.Items[nIndex].Quantity;
                    dFemaleUnitPrice = order.Items[nIndex].PricePaid;
                }

                if (sRLG6ItemCode == order.Items[nIndex].Sku)
                {
                    nRLQty += order.Items[nIndex].Quantity;
                    dRLG6UnitPrice = order.Items[nIndex].PricePaid;
                }
            }
        }


        //************************************************************
        //
        // GetFreeBottleQty
        //
        //************************************************************
/*************************************************
        public void GetFreeBottleQty( Commerce.Common.Order order, 
                                      int nTotalQty, 
                                      int nMaleQty,
                                      int nFemaleQty,
                                  out int nFreeBottles, 
                                  out int nFreeMale, 
                                  out int nFreeFemale )
        {

            nFreeFemale = 0;
            nFreeMale = 0;
            nFreeBottles = 0;
            String strKeycode = "";

            GetKeyCode(order, out strKeycode);
            if ( strKeycode.Equals("") )
                throw new Exception("Empty OM Keycode value"); 

            if (strKeycode.Equals("CALLCENTER"))
            //if ("CALLCENTER" == order.SpecialInstructions)
            { 
                // count the # of free items in cart: nFreeBottles
                // determine total qty ordered
                // count the # of free male items in cart: nFreeMale
                // count the # of free female items in cart: nFreeFemale
                int nIndex = 0;
                int nItems = order.Items.Count;
                for (nIndex = 0; nIndex < nItems; nIndex++)
                {
                    if (("LRFreeMale" == order.Items[nIndex].Sku))
                        {
                            nFreeMale++;
                            nFreeBottles++;
                        }
                    if (("LRFreeFemale" == order.Items[nIndex].Sku))
                        {
                            nFreeFemale++;
                            nFreeBottles++;
                        }
                }
                return;
            }

            
            // determine how many free bottles to send
            if (nTotalQty < 3)
                nFreeBottles = 0;
            else
                nFreeBottles = (nTotalQty / 3);

            // determine whether free s/b M or F
            if (1 == nFreeBottles)
            { // if all ordered were male then free one s/b male
                if (nMaleQty == nTotalQty)
                    nFreeMale = 1;
                // if all ordered were female then free one s/b female
                if (nFemaleQty == nTotalQty)
                    nFreeFemale = 1;
                // if male was ordered more than female, send male.
                if (nMaleQty > nFemaleQty)
                    nFreeMale = 1;
                else
                    // if female was ordered more than male, send female.
                    nFreeFemale = 1;
            }
            if (2 == nFreeBottles)
            {
                // if all ordered were equally male and female, then all s/b split
                if (nMaleQty == nFemaleQty)
                {
                    nFreeMale = 1;
                    nFreeFemale = 1;
                }
                // if all ordered were male, then all free s/b male
                if (nMaleQty == nTotalQty)
                    nFreeMale = nFreeBottles;

                // if all ordered were female, then all free s/b female
                if (nFemaleQty == nTotalQty)
                    nFreeFemale = nFreeBottles;

                // if order was mix, the split the freebies 
                if (nMaleQty != nFemaleQty)
                {
                    nFreeMale = 1;
                    nFreeFemale = 1;
                }
            }

            if (3 == nFreeBottles)
            {
                // if all ordered were male, then all free s/b male
                if (nMaleQty == nTotalQty)
                    nFreeMale = nFreeBottles;

                // if all ordered were female, then all free s/b female
                if (nFemaleQty == nTotalQty)
                    nFreeFemale = nFreeBottles;

                // if order was mix, the split the freebies 
                if ((nMaleQty > nFemaleQty) && (nFemaleQty != 0))
                {
                    nFreeMale = 2;
                    nFreeFemale = 1;
                }
                if ((nFemaleQty > nMaleQty) && (nMaleQty != 0))
                {
                    nFreeMale = 1;
                    nFreeFemale = 2;
                }
            }
            // keep it simple here.
            if (4 == nFreeBottles)
            {
                nFreeMale = 2;
                nFreeFemale = 2;
            }
        }
 *************************/

        public void GetKeyCode(Commerce.Common.Order order, out String sKey)
        {
            sKey = "";
            // get OrderMotion keycode
            OrderNoteCollection noteCollection = order.Notes;
            int nCount = noteCollection.Count;
            if (nCount > 0)
            {
                OrderNote note = noteCollection[0];
                sKey = note.Note;
            }
            else
                throw new Exception("No OM Keycode provided");
        }



/***************************************** Commented out 09/11/09 cuz dropping OM
        //************************************************************
        //
        // CallCenterOrderMotion
        //
        //************************************************************
        public void CallCenterOrderMotion(Commerce.Common.Order order, String strAuthCode, int nTransID)
        {
            int nIndex = 0;
            String strKeycode = "";
            int nFreeQty = 0;
            int nLineItems, nFullMaleQty, nDiscountMaleQty, nFullFemaleQty, nDiscountFemaleQty = 0;
            int nRL6FullQty, nRLG6DiscountQty, nRLFreeQty = 0;
            int nHHValQty, nFemaleValQty, nMaleValQty = 0;
            int nLipLovFullQty, nLipLovDiscountQty = 0;
            int nSurvivalFullQty = 0;

            // get OrderMotion keycode
            GetKeyCode(order, out strKeycode);

            // Determine qty of each item ordered.
            CallCenterGetTotalBottlesOrdered(order, 
                                             out nLineItems,
                                             out nFullMaleQty,
                                             out nDiscountMaleQty,
                                             out nFullFemaleQty,
                                             out nDiscountFemaleQty,
                                             out nRL6FullQty,
                                             out nRLG6DiscountQty,
                                             out nHHValQty,
                                             out nFemaleValQty,
                                             out nMaleValQty,
                                             out nFreeQty,
                                             out nLipLovFullQty,
                                             out nLipLovDiscountQty,
                                             out nSurvivalFullQty);
            
            //*********************************
            // generate OrderDetails line items
            //*********************************
            // Populate XML file
            String strPost = "";
            strPost = "<?xml version=\"1.0\"?>" +

            "<UDOARequest version=\"2.00\">" +
            "<UDIParameter>" +
                "<Parameter key=\"HTTPBizID\">" +
                "jRfJIJtOgVGWQpJNyPVJhqvwNndjkjkTNuVXUhlScTEueBSeLvaFgjVVgSjQuuBQuPHhgKBYcQTnmEMhfFhwkaJAmExnCdhrvrVolebsqlQqtxmMhPfiDXMFieRpojHVYOgjNHUwgPUpeltQwAUdGQZwdgwLqNkFbxuhneNuiVuhIggLFpEybMjqfLRfoKQQiiAyENJDdbXiaKeOHPJXFNADyQnBVcfOYgMOjvAfXYNKYqjhKrDhRVIrmQnCLil" +
                "</Parameter>" +
                "<Parameter key=\"Keycode\">" + strKeycode + "</Parameter>" +
                "<Parameter key=\"VerifyFlag\">False</Parameter>" +
                "<Parameter key=\"QueueFlag\">True</Parameter>" +
            "</UDIParameter>" +
            "<Header>" +
                // OrderDate should be in form "CCYY-MM-DD hh:mm"
                // It isn't necessary so to start I'll leave it out.
                //"<OrderDate>2003-04-01 22:15:10</OrderDate>" +
            "<OriginType>3</OriginType>" +
            "<OrderID>" + order.OrderNumber + "</OrderID>" +
            "<StoreCode/>" +
            "</Header>" +

        "<Customer>" +
            "<Address type=\"BillTo\">" +
                "<TitleCode>0</TitleCode>" +
                "<Company/>" +
                "<Firstname>" + order.BillingAddress.FirstName + "</Firstname>" +
                "<Lastname>" + order.BillingAddress.LastName + "</Lastname>" +
                "<Address1>" + order.BillingAddress.Address1 + "</Address1>" +
                "<Address2>" + order.BillingAddress.Address2 + "</Address2>" +
                "<City>" + order.BillingAddress.City + "</City>" +
                "<State>" + order.BillingAddress.StateOrRegion + "</State>" +
                "<ZIP>" + order.BillingAddress.Zip + "</ZIP>" +
                "<TLD>" + order.BillingAddress.Country + "</TLD>" +
                "<PhoneNumber/>" +
                "<Email>" + order.BillingAddress.Email + "</Email>" +
            "</Address>" +
            "<FlagData>" +
                "<Flag name=\"DoNotMail\">True</Flag>" +
                "<Flag name=\"DoNotCall\">True</Flag>" +
                "<Flag name=\"DoNotEmail\">True</Flag>" +
            "</FlagData>" +
        "</Customer>" +

        "<ShippingInformation>" +
            "<Address type=\"ShipTo\">" +
                "<TitleCode>0</TitleCode>" +
                "<Firstname>" + order.ShippingAddress.FirstName + "</Firstname>" +
                "<Lastname>" + order.ShippingAddress.LastName + "</Lastname>" +
                "<Address1>" + order.ShippingAddress.Address1 + "</Address1>" +
                "<Address2>" + order.ShippingAddress.Address2 + "</Address2>" +
                "<City>" + order.ShippingAddress.City + "</City>" +
                "<State>" + order.ShippingAddress.StateOrRegion + "</State>" +
                "<ZIP>" + order.ShippingAddress.Zip + "</ZIP>" +
                "<TLD>" + order.ShippingAddress.Country + "</TLD>" +
            "</Address>" +
                //"<MethodName> + "1st Class US Mail" + "</MethodName>" +
            "<MethodCode>2</MethodCode>" +
            "<ShippingAmount>" + order.ShippingAmount + "</ShippingAmount>" +
            "<HandlingAmount>0.0</HandlingAmount>" +
            "<SpecialInstructions>" + order.SpecialInstructions + "</SpecialInstructions>" +
        "</ShippingInformation>" +

        "<Payment type=\"1\">" +
            "<CardNumber>" + order.CreditCardNumber + "</CardNumber>" +
            "<CardVerification>" + order.CreditCardSecurityNumber + "</CardVerification>" +
            "<CardExpDateMonth>" + order.CreditCardExpireMonth + "</CardExpDateMonth>" +
            "<CardExpDateYear>" + order.CreditCardExpireYear + "</CardExpDateYear>" +
                // CardStatus 11 means 'already authorized'.
            "<CardStatus>11</CardStatus>" +
            "<CardAuthCode>" + strAuthCode + "</CardAuthCode>" +
                //"<CardTransactionID>" + strTransID + "</CardTransactionID>" +
        "</Payment>";

            string strOrderDetail = "<OrderDetail>";
            nIndex = 1;
            // Generate Full Price Male line item.
            if (nFullMaleQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + strMaleItemCode + "</ItemCode>" +
                        "<Quantity>" + nFullMaleQty + "</Quantity>" +
                        "<UnitPrice>" + dMaleUnitPrice + "</UnitPrice>" +
                    "</LineItem>";
                nIndex++;
            }

            // Generate Discount Male line items
            if (nDiscountMaleQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sDiscountMaleItemCode + "</ItemCode>" +
                        "<Quantity>" + nDiscountMaleQty + "</Quantity>" +
                        "<UnitPrice>" + dMaleDiscountPrice + "</UnitPrice>" +
                    "</LineItem>";
                nIndex++;
            }
            
            // Generate Full Price Female line item.
            if (nFullFemaleQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + strFemaleItemCode + "</ItemCode>" +
                        "<Quantity>" + nFullFemaleQty + "</Quantity>" +
                        "<UnitPrice>" + dFemaleUnitPrice + "</UnitPrice>" +
                    "</LineItem>";
                nIndex++;
            }
            
            // generate Discount Female line items
            if (nDiscountFemaleQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sDiscountFemaleItemCode + "</ItemCode>" +
                        "<Quantity>" + nDiscountFemaleQty + "</Quantity>" +
                        "<UnitPrice>" + dFemaleDiscountPrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nRL6FullQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sRLG6ItemCode + "</ItemCode>" +
                        "<Quantity>" + nRL6FullQty + "</Quantity>" +
                        "<UnitPrice>" + dRLG6UnitPrice + "</UnitPrice>" +
                    "</LineItem>";
                nIndex++;
            }

            // generate Discount RubLov 6oz line items
            if (nRLG6DiscountQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sRLG6DiscountItemCode + "</ItemCode>" +
                        "<Quantity>" + nRLG6DiscountQty + "</Quantity>" +
                        "<UnitPrice>" + dRLG6DiscountPrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }


            // generate Free Massage Gel line items
            if (nFreeQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sMassageGelItemCode + "</ItemCode>" +
                        "<Quantity>1</Quantity>" +
                        "<UnitPrice>0.0</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nHHValQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sHHValentineItemCode + "</ItemCode>" +
                        "<Quantity>1</Quantity>" +
                        "<UnitPrice>" + dValentinePrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nFemaleValQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sFemaleValentineItemCode + "</ItemCode>" +
                        "<Quantity>1</Quantity>" +
                        "<UnitPrice>" + dValentinePrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nMaleValQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sMaleValentineItemCode + "</ItemCode>" +
                        "<Quantity>1</Quantity>" +
                        "<UnitPrice>" + dValentinePrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nLipLovFullQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sLipLovItemCode + "</ItemCode>" +
                        "<Quantity>1</Quantity>" +
                        "<UnitPrice>" + dLipLovUnitPrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nLipLovDiscountQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sDiscountLipLovItemCode + "</ItemCode>" +
                        "<Quantity>" + nLipLovDiscountQty + "</Quantity>" +
                        "<UnitPrice>" + dLipLovDiscountPrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }

            if (nSurvivalFullQty > 0)
            {
                strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                        "<ItemCode>" + sSurvivalItemCode + "</ItemCode>" +
                        "<Quantity>" + nSurvivalFullQty + "</Quantity>" +
                        "<UnitPrice>" + dSurvivalUnitPrice + "</UnitPrice>" +
                    "</LineItem>";

                nIndex++;
            }


            strOrderDetail += "</OrderDetail>";

            strOrderDetail += "<Check><TotalAmount>" + order.OrderTotal + "</TotalAmount></Check>";

            strPost += strOrderDetail + "</UDOARequest>";

            //********************************************
            // Post to OrderMotion
            //********************************************
            StreamWriter myWriter = null;
            String strOMServerURL = "https://members.ordermotion.com/hdde/xml/udi.asp";
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strOMServerURL);
            objRequest.Method = "POST";
            objRequest.ContentLength = strPost.Length;
            objRequest.ContentType = "text/xml";

            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(strPost);
            }
            catch (Exception e)
            {
                LovRubLogger.LogException(e); // KPL 04/05/08
                throw e;
            }
            finally
            {
                myWriter.Close();
            }

            Commerce.Common.Transaction trans = new Commerce.Common.Transaction();
            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            try
            {
                XmlReader reader = XmlReader.Create((Stream)objResponse.GetResponseStream());
                reader.MoveToContent();
                while (reader.Read())
                {
                    if (XmlNodeType.Element == reader.NodeType)
                    {
                        if (reader.Name.Equals("Success"))
                        {
                            reader.Read();
                            if (false == reader.Value.Equals("1"))
                            {   // failure;
                                throw new Exception("OM Failure:<Success>= " + reader.Value);
                            }
                        }
                        if (reader.Name.Equals("ErrorData"))
                        {
                            reader.Read();
                            if (false == reader.Value.Equals("\n"))
                            {   // failure;
                                throw new Exception("OM Failure:<ErrorData>= " + reader.Value);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                LovRubLogger.LogException(e); // KPL 04/05/08
                throw e;
            }

        }
***************************************** Commented out 09/11/09 cuz dropping OM **/


/***************************** Commented out 09/11/09 KPL
        //************************************************************
        //
        // OrderMotion
        //
        //************************************************************
        public void OrderMotion( Commerce.Common.Order order,  String strAuthCode, int nTransID )
        {
            int nTotalQty = 0, nIndex = 0, nFreeBottles = 0, nFreeMale = 0, nFreeFemale = 0;
            int nMaleQty = 0, nFemaleQty = 0, nRLQty = 0;
            String strKeycode = "";
            
            // get OrderMotion keycode
            GetKeyCode( order, out strKeycode );
            
            //********************************************
            // determine total quantity ordered. dont count the free bottles, if this is CCtr order.
            // determine how many male
            // determine how many female
            // GetTotalBottlesOrdered( out nTotalQty, out nMaleQty, out nFemaleQty )

            // determine how many free bottles to send
            // determine how many male or female bottles to send
            // (if CCtr order, the free bottles are already in 'order' object. so set variables accordingly)

            // GetFreeBottleQty( int nTotalQty, out int nFreeBottles, out int nFreeMale, out int nFreeFemale )
            //********************************************
            GetTotalBottlesOrdered( order, out nTotalQty, out nMaleQty, out nFemaleQty, out nRLQty);
                        //*********************************
                        // generate OrderDetails line items
                        //*********************************
                        // determine total # of line items
                        int nLineItems = 0;
                        if (nMaleQty > 0)
                            nLineItems++;
                        if (nFemaleQty >0)
                            nLineItems++;
                        if (nFreeFemale >0)
                            nLineItems++;
                        if (nFreeMale > 0)
                            nLineItems++;
                        // END determine total # of line items
            
                        // Populate XML file
                        String strPost = "";
                        strPost = "<?xml version=\"1.0\"?>" +

                        "<UDOARequest version=\"2.00\">" +
                        "<UDIParameter>" +
                            "<Parameter key=\"HTTPBizID\">" + 
                            "jRfJIJtOgVGWQpJNyPVJhqvwNndjkjkTNuVXUhlScTEueBSeLvaFgjVVgSjQuuBQuPHhgKBYcQTnmEMhfFhwkaJAmExnCdhrvrVolebsqlQqtxmMhPfiDXMFieRpojHVYOgjNHUwgPUpeltQwAUdGQZwdgwLqNkFbxuhneNuiVuhIggLFpEybMjqfLRfoKQQiiAyENJDdbXiaKeOHPJXFNADyQnBVcfOYgMOjvAfXYNKYqjhKrDhRVIrmQnCLil" +
                            "</Parameter>" +
                            "<Parameter key=\"Keycode\">" + strKeycode + "</Parameter>" +
                            "<Parameter key=\"VerifyFlag\">False</Parameter>" +
                            "<Parameter key=\"QueueFlag\">True</Parameter>" +
                        "</UDIParameter>" +
                        "<Header>" +
                            // OrderDate should be in form "CCYY-MM-DD hh:mm"
                            // It isn't necessary so to start I'll leave it out.
                            //"<OrderDate>2003-04-01 22:15:10</OrderDate>" +
                        "<OriginType>3</OriginType>" +
                        "<OrderID>" + order.OrderNumber + "</OrderID>" + 
                        "<StoreCode/>" +
                        "</Header>" +

                    "<Customer>" +
                        "<Address type=\"BillTo\">" +
                            "<TitleCode>0</TitleCode>" +
                            "<Company/>" +
                            "<Firstname>" + order.BillingAddress.FirstName + "</Firstname>" +
                            "<Lastname>" + order.BillingAddress.LastName + "</Lastname>" +
                            "<Address1>" + order.BillingAddress.Address1 + "</Address1>" +
                            "<Address2>" + order.BillingAddress.Address2 + "</Address2>" +
                            "<City>" + order.BillingAddress.City + "</City>" +
                            "<State>" + order.BillingAddress.StateOrRegion + "</State>" +
                            "<ZIP>" + order.BillingAddress.Zip + "</ZIP>" +
                            "<TLD>" + order.BillingAddress.Country + "</TLD>" +
                            "<PhoneNumber/>" +
                            "<Email>" + order.BillingAddress.Email + "</Email>" +
                        "</Address>" +
                        "<FlagData>" +
                            "<Flag name=\"DoNotMail\">True</Flag>" +
                            "<Flag name=\"DoNotCall\">True</Flag>" +
                            "<Flag name=\"DoNotEmail\">True</Flag>" +
                        "</FlagData>" +
                    "</Customer>" +

                    "<ShippingInformation>" +
                        "<Address type=\"ShipTo\">" +
                            "<TitleCode>0</TitleCode>" +
                            "<Firstname>" + order.ShippingAddress.FirstName + "</Firstname>" +
                            "<Lastname>" + order.ShippingAddress.LastName + "</Lastname>" +
                            "<Address1>" + order.ShippingAddress.Address1 + "</Address1>" +
                            "<Address2>" + order.ShippingAddress.Address2 + "</Address2>" +
                            "<City>" + order.ShippingAddress.City + "</City>" +
                            "<State>" + order.ShippingAddress.StateOrRegion + "</State>" +
                            "<ZIP>" + order.ShippingAddress.Zip + "</ZIP>" +
                            "<TLD>" + order.ShippingAddress.Country + "</TLD>" +
                        "</Address>" +
                        //"<MethodName> + "1st Class US Mail" + "</MethodName>" +
                        "<MethodCode>2</MethodCode>" +
                        "<ShippingAmount>" + order.ShippingAmount + "</ShippingAmount>" +
                        "<HandlingAmount>0.0</HandlingAmount>" +
                        "<SpecialInstructions>" + order.SpecialInstructions + "</SpecialInstructions>" +
                    "</ShippingInformation>" +

                    "<Payment type=\"1\">" +
                        "<CardNumber>" + order.CreditCardNumber + "</CardNumber>" +
                        "<CardVerification>" + order.CreditCardSecurityNumber + "</CardVerification>" +
                        "<CardExpDateMonth>" + order.CreditCardExpireMonth + "</CardExpDateMonth>" +
                        "<CardExpDateYear>" + order.CreditCardExpireYear + "</CardExpDateYear>" +
                                // CardStatus 11 means 'already authorized'.
                        "<CardStatus>11</CardStatus>" +
                        "<CardAuthCode>" + strAuthCode + "</CardAuthCode>" +
                                //"<CardTransactionID>" + strTransID + "</CardTransactionID>" +
                    "</Payment>"; 

                        //**********************
                        // Orderdetail goes here
                        //**********************
                        String strOrderDetail = "<OrderDetail>";
                        nIndex = 1;
                        if (nMaleQty > 0)
                        {
                            strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                                    "<ItemCode>" + strMaleItemCode + "</ItemCode>" +
                                    "<Quantity>" + nMaleQty + "</Quantity>" +
                                    "<UnitPrice>" + dMaleUnitPrice + "</UnitPrice>" +
                                "</LineItem>";
                            nIndex++;
                        }

                        // Generate free Male line items
                        if (nFreeMale > 0)
                        {
                            strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                                    "<ItemCode>" + strMaleItemCode + "</ItemCode>" +
                                    "<Quantity>" + nFreeMale + "</Quantity>" +
                                    "<UnitPrice>0.0</UnitPrice>" +
                                "</LineItem>";

                            nIndex++;
                        }

                        // generate Female line items
                        if (nFemaleQty > 0)
                        {
                            strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                                    "<ItemCode>" + strFemaleItemCode + "</ItemCode>" +
                                    "<Quantity>" + nFemaleQty + "</Quantity>" +
                                    "<UnitPrice>" + dFemaleUnitPrice + "</UnitPrice>" +
                                "</LineItem>";

                            nIndex++;
                        }

                        // generate free Female line items
                        if (nFreeFemale > 0)
                        {
                            strOrderDetail += "<LineItem lineNumber=\"" + nIndex + "\">" +
                                    "<ItemCode>" + strFemaleItemCode + "</ItemCode>" +
                                    "<Quantity>" + nFreeFemale + "</Quantity>" +
                                    "<UnitPrice>0.0</UnitPrice>" +
                            "</LineItem>";
                        }

                        strOrderDetail += "</OrderDetail>";

                        strOrderDetail += "<Check><TotalAmount>" + order.OrderTotal + "</TotalAmount></Check>";

                        strPost += strOrderDetail + "</UDOARequest>";

                        //********************************************
                        // Post to OrderMotion
                        //********************************************
                        StreamWriter myWriter = null;
                        String strOMServerURL = "https://members.ordermotion.com/hdde/xml/udi.asp";
                        HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(strOMServerURL);
                        objRequest.Method = "POST";
                        objRequest.ContentLength = strPost.Length;
                        objRequest.ContentType = "text/xml";

                        try
                        {
                            myWriter = new StreamWriter(objRequest.GetRequestStream());
                            myWriter.Write(strPost);
                        }
                        catch (Exception e)
                        {
                            LovRubLogger.LogException(e); // KPL 04/05/08
                            throw e;
                        }
                        finally
                        {
                            myWriter.Close();
                        }

                        Commerce.Common.Transaction trans = new Commerce.Common.Transaction();
                        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
                        try
                        {
                            XmlReader reader = XmlReader.Create((Stream)objResponse.GetResponseStream());
                            reader.MoveToContent();
                            while (reader.Read())
                            {
                                if (XmlNodeType.Element == reader.NodeType)
                                {
                                    if (reader.Name.Equals("Success"))
                                    {
                                        reader.Read();
                                        if (false == reader.Value.Equals("1"))
                                        {   // failure;
                                            throw new Exception("OM Failure:<Success>= " + reader.Value);
                                        }
                                    }
                                    if (reader.Name.Equals("ErrorData"))
                                    {
                                        reader.Read();
                                        if (false == reader.Value.Equals("\n"))
                                        {   // failure;
                                            throw new Exception("OM Failure:<ErrorData>= " + reader.Value);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            LovRubLogger.LogException(e); // KPL 04/05/08
                            throw e;
                        }

        }
***************************** Commented out 09/11/09 KPL */

        public override string Refund(Commerce.Common.Order order)
        {
            throw new Exception("This method not enabled for Authorize.NET");
        }
    }
}
