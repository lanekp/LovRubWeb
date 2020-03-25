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
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for PayPalServiceUtility
/// </summary>
public partial class PayPalServiceUtility {
  
  public PayPalServiceUtility() {

  }

  /// <summary>
  /// Gets the PayPal API version number.
  /// </summary>
  /// <value>The PayPal API version number.</value>
  public static string PayPalAPIVersionNumber {
    get {
      return "3.2"; // This is located in PayPalSvc.wsdl (ex: ns:version="3.2")
    }
  }

  /// <summary>
  /// Gets the pay pal service endpoint. Defined at https://www.paypal.com/IntegrationCenter/ic_api-reference.html
  /// </summary>
  /// <param name="useSandbox">if set to <c>true</c> [use sandbox].</param>
  /// <param name="useSOAP">if set to <c>true</c> [use SOAP].</param>
  /// <param name="useSignature">if set to <c>true</c> [use signature].</param>
  /// <returns></returns>
  public static string GetPayPalServiceEndpoint(bool isLive, bool useSOAP, bool useSignature) {
    string endPoint = string.Empty;
    if(!isLive) { //SANDBOX
      //Signature vs. Certificate does not matter in the Sandbox.
      if(useSOAP) {
        endPoint = "https://api.sandbox.paypal.com/2.0/";
      }
      else {
        endPoint = "https://api.sandbox.paypal.com/nvp/";
      }
    }
    else { //PRODUCTION
      if(useSOAP) { //SOAP API
        if(useSignature) {
          endPoint = "https://api-3t.paypal.com/2.0/";
        }
        else { //Certificate
          endPoint = "https://api.paypal.com/2.0/";
        }
      }
      else { //Name-Value Pair API
        if(useSignature) {
          endPoint = "https://api-3t.paypal.com/nvp";
        }
        else { //Certificate
          endPoint = "https://api.paypal.com/nvp/";
        }
      }
    }
    return endPoint;
  }
}
