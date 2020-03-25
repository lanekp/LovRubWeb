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

public partial class IPNHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string ppTX = Request.Form["txn_id"].ToString();
        string sOrderID = Request.Form["custom"].ToString();
        string sAmount = Request.Form["mc_gross"].ToString();

        //all we need at this point is the SUCCESS flag
        if (VerifyIPN()) {
            
            //get the amount
            if (sAmount != string.Empty) {
                sOrderID = Server.UrlDecode(sOrderID);
                Order order = OrderController.GetOrder(sOrderID);
                
                //get the amount from the IPN
                decimal dPaidFor = decimal.Parse(sAmount);

                //commit the order
                OrderController.CommitStandardOrder(order,ppTX, decimal.Parse(sAmount));

            }
        }

    }
    bool VerifyIPN() {
        string strFormValues = Request.Form.ToString();
        string strNewValue;
        string strResponse;
        string serverURL = "";

        if (SiteConfig.UsePPStandardSandbox)
        {
            serverURL = "https://www.sandbox.paypal.com/cgi-bin/webscr";
        } else {
            serverURL = "https://www.paypal.com/cgi-bin/webscr"; ;
            //serverURL="http://www.eliteweaver.co.uk/cgi-bin/webscr ";
        }
        // Create the request back
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(serverURL);

        // Set values for the request back
        req.Method = "POST";
        req.ContentType = "application/x-www-form-urlencoded";
        strNewValue = strFormValues + "&cmd=_notify-validate";
        req.ContentLength = strNewValue.Length;

        // Write the request back IPN strings
        StreamWriter stOut = new StreamWriter(req.GetRequestStream(), System.Text.Encoding.ASCII);
        stOut.Write(strNewValue);
        stOut.Close();

        // Do the request to PayPal and get the response
        StreamReader stIn = new StreamReader(req.GetResponse().GetResponseStream());
        strResponse = stIn.ReadToEnd();
        stIn.Close();


        // Confirm whether the IPN was VERIFIED or INVALID. If INVALID, just ignore the IPN
        return strResponse == "VERIFIED";
        
    }

}
