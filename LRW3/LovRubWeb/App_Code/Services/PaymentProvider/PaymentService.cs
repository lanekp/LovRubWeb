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
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web;
using System.Web.Caching;
using System.Data;
using Commerce.Providers;
using System.Text.RegularExpressions;
using Commerce.Common;

namespace Commerce.Providers
{
    public class PaymentService
    {
        #region Provider-specific bits
        private static PaymentProvider _provider = null;
        private static object _lock = new object();

        public PaymentProvider Provider
        {
            get { return _provider; }
        }

        static PaymentProvider Instance
        {
            get
            {
                LoadProvider();
                return _provider;
            }
        }
        private static void LoadProvider()
        {
            // Avoid claiming lock if providers are already loaded
            if (_provider == null)
            {
                lock (_lock)
                {
                    // Do this again to make sure _provider is still null
                    if (_provider == null)
                    {
                        // Get a reference to the <PaymentService> section
                        PaymentServiceSection section = (PaymentServiceSection)
                            WebConfigurationManager.GetSection
                            ("PaymentService");

                        // Load registered providers and point _provider
                        // to the default provider

                        //since this is a CC provider, we only want one
                        //so no collections for providers.
                        //however feel free to change this as needed.
                        _provider = (PaymentProvider)ProvidersHelper.InstantiateProvider(section.Providers[0], typeof(PaymentProvider));

                        if (_provider == null)
                            throw new ProviderException
                                ("Unable to load default PaymentProvider");
                    }
                }
            }
        }
        #endregion

        #region Methods

            #region Gateway Charger

            public static Commerce.Common.Transaction RunCharge(Commerce.Common.Order order){

                //validations
                //CCNumber
                TestCondition.IsTrue(IsValidCardType(order.CreditCardNumber, order.CreditCardType),"Invalid Credit Card Number");

                //current expiration
                DateTime expDate = new DateTime(order.CreditCardExpireYear,order.CreditCardExpireMonth, 28);
                TestCondition.IsTrue(expDate >= DateTime.Today, "This credit card appears to be expired");
                
                //amount>0
                TestCondition.IsGreaterThanZero(order.OrderTotal, "Charge amount cannot be 0 or less");

                Commerce.Common.Transaction result=Instance.Charge(order);
                
                
                result.TransactionDate = DateTime.UtcNow;
                result.Amount = order.OrderTotal;
                
                return result;
            }

            //Many thanks to Paul Ingles for this Code
            //http://www.codeproject.com/aspnet/creditcardvalidator.asp
            //Modified by Spook, 3/2006
            public static bool IsValidCardType(string cardNumber, Commerce.Common.CreditCardType CardType) {
                bool bOut = false;
                
                
                // AMEX -- 34 or 37 -- 15 length
                if ((Regex.IsMatch(cardNumber, "^(34|37)"))
                     && ((CardType==Commerce.Common.CreditCardType.Amex)))
                    bOut= 15 == cardNumber.Length;


                // MasterCard -- 51 through 55 -- 16 length
                else if ((Regex.IsMatch(cardNumber, "^(51|52|53|54|55)")) &&
                          ((CardType==Commerce.Common.CreditCardType.MasterCard)))
                    bOut= 16 == cardNumber.Length;

                // VISA -- 4 -- 13 and 16 length
                else if ((Regex.IsMatch(cardNumber, "^(4)")) &&
                          ((CardType==Commerce.Common.CreditCardType.VISA)))
                    bOut= 13 == cardNumber.Length || 16 == cardNumber.Length;

                // Discover -- 6011 -- 16 length
                else if ((Regex.IsMatch(cardNumber, "^(6011)")) &&
                         ((CardType==Commerce.Common.CreditCardType.Discover)))
                    bOut= 16 == cardNumber.Length;

                return bOut;
            }

            /// <summary>
            /// Runs a refund for the passed in order, and returns a verification 
            /// string. An exception will be thrown if there is an error.
            /// </summary>
            /// <param name="order"></param>
            /// <returns></returns>
            public static string Refund(Commerce.Common.Order order)
            {
                //validations

                //there has to be an initial payment
                if (order.Transactions.Count == 0)
                    throw new Exception("This order has no existing transactions; please be sure the transactions are loaded for this order. Cannot refund");


                string sOut =Instance.Refund(order);
                
                return sOut;
            }

            #endregion

        #endregion
    }


}
