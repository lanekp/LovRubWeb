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
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using Commerce.Common;

public partial class PDTHandler : System.Web.UI.Page
{
    void Page_Load(object sender, EventArgs e)
    {

        //###############################################################################
        //  Page Validators
        //###############################################################################

        //your transaction ID can be null/empty if your account is not validated, verified, if
        //your business email is wrong, your PDT id is wrong, or PayPal's just having a bad day
        TestCondition.IsNotNull(Request.QueryString["tx"], "No TransactionID - Invalid");
        TestCondition.IsNotNull(Request.QueryString["cm"], "No TransactionID - Invalid");

        //##############################################################################
        
        
        string ppTX = Request.QueryString["tx"].ToString();
        string sOrderID = Request.QueryString["cm"].ToString();

        string pdtResponse = GetPDT(ppTX);
        //all we need at this point is the SUCCESS flag
        if (pdtResponse.StartsWith("SUCCESS"))
        {

            string sAmount = GetPDTValue(pdtResponse, "mc_gross");

            //make sure the totals add up
            try
            {
                //make sure to unencode it
                sOrderID = Server.UrlDecode(sOrderID);
                Order order = OrderController.GetOrder(sOrderID);

                if (order != null) {

                    //commit the order
                    OrderController.CommitStandardOrder(order, ppTX, decimal.Parse(sAmount));


                    //send off to the receipt page
                    Response.Redirect("../receipt.aspx?t=" + sOrderID, true);

                } else {
                    Response.Write("Can't find the order");
                }

            }
            catch (Exception x)
            {
                Response.Write("Invalid Order: " + x.Message);
            }

        }
        else
        {
            Response.Write("PDT Failure: " + pdtResponse);
        }

        

    }
    string GetPDTValue(string pdt, string key) {
        
        string[] keys = pdt.Split('\n');
        string thisVal = "";
        string thisKey="";
        foreach (string s in keys) {
            string[] bits = s.Split('=');
            if (bits.Length > 1) {
                thisVal = bits[1];
                thisKey = bits[0];
                if (thisKey.ToLower().Equals(key))
                    break;
            }
        }
        return thisVal;


    }
    string GetPDT(string transactionID)
    {

        string sOut = "";
        string PDTID = "";
        PDTID = SiteConfig.PayPalPDTID;

        string sCmd = "_notify-synch";

        string serverURL = "";
        if (SiteConfig.UsePPStandardSandbox)
        {
            serverURL = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        }
        else
        {
            serverURL = "https://www.paypal.com/cgi-bin/webscr"; ;

        }


        try
        {
            string strFormValues = Request.Form.ToString();
            string strNewValue;
            string strResponse;

            // Create the request back
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverURL);

            // Set values for the request back
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            strNewValue = strFormValues + "&cmd=_notify-synch&at=" + PDTID + "&tx=" + transactionID;
            req.ContentLength = strNewValue.Length;

            // Write the request back IPN strings
            StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
            stOut.Write(strNewValue);
            stOut.Close();

            // Do the request to PayPal and get the response
            StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
            strResponse = stIn.ReadToEnd();

            stIn.Close();
            sOut = Server.UrlDecode(strResponse);


        }
        catch (Exception x)
        {
        }
        return sOut;

    }
}
