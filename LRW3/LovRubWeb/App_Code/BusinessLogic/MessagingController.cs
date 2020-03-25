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
using Commerce.Common;
using Commerce.Messaging;

/// <summary>
/// Summary description for MessagingController
/// </summary>
public static class MessagingController {
  /// <summary>
  /// This method can be used for all kinds of fun things - like dropping an EDI x12 document, or an
  /// XML message for BizTalk. For instance, you can serialize down an order simply by using
  /// order.ToXML(), put that string into a document (it's well-formatted XML already), and 
  /// drop it on an FTP server.
  /// </summary>
  /// <param name="absoluteFilePath">The path to the file to send</param>
  /// <param name="ftpServerUrl">should be something like ftp://servername.com/directory</param>
  /// <param name="userName">FTP username</param>
  /// <param name="password">FTP password</param>
  public static void SendFTP(string absoluteFilePath, string ftpServerUrl, string userName, string password) {
    FTPClient.PutFile(absoluteFilePath,
        ftpServerUrl, userName, password);
  }

  public enum Message : int {
    OrderReceived_Merchant = 1,
    OrderReceived_Customer = 2,
    ShippingNotification_Customer = 3,
    OrderCancellation_Customer = 4,
    OrderRefund_Customer = 5
  }

  /// <summary>
  /// This method will send a message to the shop owner, notifying them of a new order
  /// </summary>
  /// <param name="order">The order itself</param>
  /// <returns></returns>
  public static bool SendOrderReceived_Merchant(Order order) {
    bool bOut = false;

    //get the mailer from the DB
    int mailerID = Convert.ToInt16(Message.OrderReceived_Merchant);
    Email mailer = new Email(mailerID);

    string template = mailer.MessageBody;
    if (template.Length > 0) {
      //run the tag replacements
      template = ReplaceConstantsInMessage(order, template, mailer);
      //setup the mailer
      mailer.MessageBody = template;
      mailer.ToList = mailer.ToList;
      mailer.CcList = mailer.CcList;

      //send it off!
      bOut = Email.SendEmail(mailer);
    }
    return bOut;
  }

  /// <summary>
  /// This is an overriden method of the Mailer class. The default message in the DB is going
  /// to be overwritten with a nicely formatted HTML message stored in the EmailTemplates
  /// Directory. Feel free to change as needed.
  /// </summary>
  /// <param name="order">The order to send out the mailer for.</param>
  /// <returns></returns>
  public static bool SendOrderReceived_Customer(Order order) {
    bool bOut = SendMailToCustomer(order, Message.OrderReceived_Customer);
    return bOut;
  }

  public static bool SendShippingNotification_Customer(Order order) {
    bool bOut = SendMailToCustomer(order, Message.ShippingNotification_Customer);
    return bOut;
  }

  public static bool SendOrderCancellation_Customer(Order order) {
    bool bOut = SendMailToCustomer(order, Message.OrderCancellation_Customer);
    return bOut;
  }

  public static bool SendOrderRefund_Customer(Order order) {
    bool bOut = SendMailToCustomer(order, Message.OrderRefund_Customer);
    return bOut;
  }

  private static bool SendMailToCustomer(Order order, Message message) {
    bool bOut = false;

    //get the mailer from the DB
    Email mailer = new Email(Convert.ToInt32(message));

    string template = mailer.MessageBody;
    if (template.Length > 0) {
      //run the tag replacements
      template = ReplaceConstantsInMessage(order, template, mailer);
      //setup the mailer
      mailer.MessageBody = template;
      mailer.ToList = order.Email;
      mailer.CcList = mailer.CcList;

      //send it off!
      bOut = Email.SendEmail(mailer);
    }
    return bOut;
  }

  /// <summary>
  /// run some tag replacements. First with the name
  /// </summary>
  /// <param name="template"></param>
  /// <returns></returns>
  static string ReplaceConstantsInMessage(Order order, string template, Email mailer) {
    if (string.IsNullOrEmpty(template)) {
      return string.Empty;
    }
    template = template.Replace("#NAME#", order.FirstName + " " + order.LastName);

    //ordernumber
    template = template.Replace("#ORDERNUMBER#", order.OrderNumber);

    //order date
    template = template.Replace("#ORDERDATE#", order.OrderDate.ToShortDateString());

    //now date
    template = template.Replace("#DATE#", DateTime.Now.ToShortDateString());

    //now date
    template = template.Replace("#TRACKINGNUMBER#", order.ShippingTrackingNumber);

    // full order info
    template = template.Replace("#ORDER#", order.ToHtml());

    //tagline
    template = template.Replace("#TAGLINE#", ConfigurationManager.AppSettings["tagLine"]);

    //links
    template = template.Replace("#ADMINPRODUCTLINK#", Utility.GetSiteRoot() + "/admin/admin_orders.aspx?id=" + order.OrderID);

    template = template.Replace("#SITELINK#", Utility.GetSiteRoot());

    template = template.Replace("#STOREEMAIL#", "<a href='mailto:" + mailer.FromEmail + "'>" + mailer.FromEmail + "</a>");

    return template;
  }
}
