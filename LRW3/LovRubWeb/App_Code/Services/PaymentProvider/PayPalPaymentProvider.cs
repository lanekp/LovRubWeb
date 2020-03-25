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
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Text;
using Commerce.Common;
using Commerce.PayPal;

namespace Commerce.Providers {
  public class PayPalPaymentProvider : PaymentProvider {

    private string _apiUserName;
    private string _apiPassword;
    private string _signature;
    private string _merchantId;
    private CurrencyCode _defaultCurrencyCode;
    private bool _isLive = false;
    bool authOnly = false;



    #region Provider specific behaviors

    public override void Initialize(string name, NameValueCollection config) {
      // Verify that config isn't null
      if(config == null)
        throw new ArgumentNullException("config");

      // Assign the provider a default name if it doesn't have one
      if(String.IsNullOrEmpty(name))
        name = "PayPalPaymentProvider";

      // Add a default "description" attribute to config if the
      // attribute doesn't exist or is empty
      if(string.IsNullOrEmpty(config["description"])) {
        config.Remove("description");
        config.Add("description",
            "PayPal Payment Provider");
      }
      base.Initialize(name, config);

      _apiUserName = config["apiUserName"].ToString();
      if(String.IsNullOrEmpty(_apiUserName))
        throw new ProviderException("Empty Paypal API UserName (apiUserName) value");

      _apiPassword = config["apiPassword"].ToString();
      if(String.IsNullOrEmpty(_apiPassword))
        throw new ProviderException("Empty Paypal API Password (apiPassword) value");

      _signature = config["signature"].ToString();
      if(string.IsNullOrEmpty(_signature))
        throw new ProviderException("Empty PayPal API Signature (signature) value.");

      //_merchantId = config["merchantId"].ToString();
      //if(String.IsNullOrEmpty(_merchantId))
      //  throw new ProviderException("Empty Merchant ID value");

      //string defaultCurrencyCode = SiteConfig.CurrencyCode; //config["defaultCurrencyCode"].ToString();
      //if(!Enum.IsDefined(typeof(CurrencyCode), defaultCurrencyCode)) {
      //  throw new ProviderException("defaultCurrencyCode cannot be parsed to type CurrencyCode.");
      //}
      //_defaultCurrencyCode = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), defaultCurrencyCode);
      _defaultCurrencyCode = SiteConfig.CurrencyCode;

      string isLive = config["isLive"].ToString();
      bool isParsed = bool.TryParse(isLive, out _isLive);
      if(!isParsed) {
        throw new ProviderException("isLive cannot be parsed to true or false.");
      }
    }

    #endregion

    public override Commerce.Common.Transaction Charge(Commerce.Common.Order order) {

      //open a call to the API wrapper service
      APIWrapper wrapper = new APIWrapper(_apiUserName, _apiPassword, _signature, 
        _defaultCurrencyCode, _isLive);
 
      Transaction trans = null;

      try {
        trans = wrapper.DoDirectCheckout(order, authOnly);
      }
      catch(Exception x) {
        //Have to catch the PayPal errors; they tend to be nonsense :).
        //if the URL says "localhost" in it, it's a local dev box. Don't show links to PayPal for live sites
        string sUrl = System.Web.HttpContext.Current.Request.UserHostAddress;
        bool isDev = sUrl == "127.0.0.1";
        string sMessage = x.Message;
        if(isDev) {
          sMessage = "This order has been rejected; dashCommerce has detected this site running on localhost and will try to help you solve the problem";
          string encResponse = System.Web.HttpContext.Current.Server.UrlEncode(x.Message.Replace("ERROR: ", ""));

          sMessage += "<br><b>PayPal Message: <i>" + x.Message + "</i></b><Br><Br>";

          //I am sure this list will grow :). These are a catch for the lame PayPal error messages...
          if(x.Message.IndexOf("country and billing address associated with this credit card do not match") > 0) {
            sMessage += "This message usually occurs because the card you're testing with has been used too many time. Try another card (<a href='http://wiki.commercestarterkit.org/index.php?title=Test_CreditCards' target=_blank>you can use our Wiki</a>).";
          }

          if(x.Message.ToLower().Contains("internal error")) {
            sMessage += "PayPal throws this nice error when it can't process a generated credit card number, or when it can't figure out what currency you're using. You can usually retry the order and it will go through; either that or try another card (<a href='http://wiki.commercestarterkit.org/index.php?title=Test_CreditCards' target=_blank>you can use our Wiki</a>).";
          }

          sMessage += "<br><Br><b>More Info</b>: <a href='http://paypal.forums.liveworld.com/search!execute.jspa?q=" + encResponse + "' target=_blank>PayPal Forums</a><br><Br>";

        }
        else {
          sMessage = "PayPal has rejected this transaction: " + x.Message + sUrl;

        }
        throw new Exception(sMessage, x);
      }
      return trans;
    }
    public override string Refund(Commerce.Common.Order order) {
      APIWrapper wrapper = new APIWrapper(_apiUserName, _apiPassword, _signature,
        _defaultCurrencyCode, _isLive);

      //the PayPal transactionID is stored in the auth code
      string transactionID = order.Transactions[0].AuthorizationCode;

      string sResponse = wrapper.RefundTransaction(transactionID, true);

      if(sResponse != "Success") {

        string sMessage = "PayPal has returned an error message for this refund: " + sResponse;
        string encResponse = System.Web.HttpContext.Current.Server.UrlEncode(sResponse);
        if(sMessage.ToLower(System.Globalization.CultureInfo.InvariantCulture).IndexOf("you can not refund this type of transaction (10009)") >= 0)
          sMessage = "PayPal has rejected the refund of this order for one or more reasons (they don't give exact " +
              "reasons). If this is a DirectPay (Credit Card) transaction, PayPal will not refund an order if the card for that order is expired. If this is not a DirectPay order, " +
              "the order is likely too old (greater than 30 days) to be refunded.<br><br>" +
              "<a href='http://paypal.forums.liveworld.com/search!execute.jspa?q=" + encResponse + "' target=_blank>Find out more</a>";

        throw new Exception(sMessage);

      }
      else {
        //PayPal, for some reason, will not return the transactionID
        //this is sort of ridiculous
        //so return a value that means something
        sResponse = order.OrderNumber + "PayPal_REFUND";
      }

      return sResponse;

    }

  }
}
