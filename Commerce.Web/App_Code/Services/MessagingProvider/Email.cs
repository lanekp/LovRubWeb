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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Net.Mail;
using SubSonic;

namespace Commerce.Messaging {

  /// <summary>
  /// A Persistable class that uses Generics to store it's state
  /// in the database. This class maps to the CSK_Messaging_Mailer table.
  /// </summary>
  public class Email : ActiveRecord<Email> {

    #region .ctors
    /// <summary>
    /// Sets the static Table property from our Base class. This property tells
    /// the base class how to create the CRUD queries, etc.
    /// </summary>
    void SetSQLProps() {

      if (Schema == null) {
        Schema = Query.BuildTableSchema("CSK_Messaging_Mailer");

      }

    }

    public static TableSchema.Table GetTableSchema() {
      //instance an object to make sure
      //the table schema has been created
      Email item = new Email();
      return Email.Schema;
    }

    public Email() {
      SetSQLProps();
      this.MarkNew();
    }
    public Email(int mailerID) {
      SetSQLProps();
      base.LoadByKey(mailerID);

    }

    #endregion

    #region Public Props
    [XmlAttribute("MailerID")]
    public int MailerID {
      get {
        return int.Parse(this.GetColumnValue("mailerID").ToString());
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("mailerID", value);

      }
    }
    [XmlAttribute("MailerName")]
    public string MailerName {
      get {
        return this.GetColumnValue("mailerName").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("mailerName", value);

      }
    }
    [XmlAttribute("ToList")]
    public string ToList {
      get {
        return this.GetColumnValue("toList").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("toList", value);

      }
    }
    [XmlAttribute("CcList")]
    public string CcList {
      get {
        return this.GetColumnValue("ccList").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("ccList", value);

      }
    }
    [XmlAttribute("FromName")]
    public string FromName {
      get {
        return this.GetColumnValue("fromName").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("fromName", value);

      }
    }
    [XmlAttribute("FromEmail")]
    public string FromEmail {
      get {
        return this.GetColumnValue("fromEmail").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("fromEmail", value);

      }
    }
    [XmlAttribute("Subject")]
    public string Subject {
      get {
        return this.GetColumnValue("subject").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("subject", value);

      }
    }
    [XmlAttribute("MessageBody")]
    public string MessageBody {
      get {
        return this.GetColumnValue("messageBody").ToString();
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("messageBody", value);

      }
    }
    [XmlAttribute("IsHTML")]
    public bool IsHTML {
      get {
        return bool.Parse(this.GetColumnValue("isHTML").ToString());
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("isHTML", value);

      }
    }

    [XmlAttribute("IsSystemMailer")]
    public bool IsSystemMailer {
      get {
        return bool.Parse(this.GetColumnValue("isSystemMailer").ToString());
      }
      set {
        this.MarkDirty();
        this.SetColumnValue("isSystemMailer", value);

      }
    }


    #endregion

    #region Mail Service Bits

    public static bool SendEmail(int mailerID, string appendText) {
      Email mailer = new Email(mailerID);
      mailer.MessageBody += appendText;
      return SendEmail(mailer);
    }
    public static bool SendEmail(string sTo, int mailerID) {
      Email mailer = new Email(mailerID);

      if (sTo != string.Empty)
        mailer.ToList = sTo;

      return SendEmail(mailer);
    }
    public static bool SendEmail(int mailerID) {
      return SendEmail("", mailerID);
    }
    public static bool SendEmail(Email mailer) {
      System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
      using (System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage()) {
        bool bOut = false;
        if (!String.IsNullOrEmpty(mailer.ToList)) {
          string[] toList = mailer.ToList.Split(';');
          foreach (string to in toList) {
            message.To.Add(new MailAddress(to));
          }
        }
        if (!String.IsNullOrEmpty(mailer.CcList)) {
          string[] ccList = mailer.CcList.Split(';');
          foreach (string cc in ccList) {
            message.CC.Add(new MailAddress(cc));
          }
        }

        message.Subject = mailer.Subject;
        message.IsBodyHtml = mailer.IsHTML;
        message.Body = mailer.MessageBody;
        try {
          client.Send(message);
          //TODO: CMC - log this
          bOut = true;
        }
        catch (System.Net.Mail.SmtpException x) 
        {
          LovRubLogger.LogException(x); // KPL added 04/10/08
          throw x;
          //TODO: CMC - Log Exception, Do we really want to throw this back up the stack?
          //throw new Exception("Email not sent: " + x.Message + "; message details: " + message.ToString());
          //log this
        }
        return bOut;
      }
    }

    #endregion

  }
}
