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
using System.Web.Configuration;
using System.Net.Configuration;

public partial class Admin_mailconfiguration : System.Web.UI.Page {

  Configuration config;
  SmtpSection smtpSection;

  protected void Page_Load(object sender, EventArgs e) {
    try {
      config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
      smtpSection = config.GetSection("system.net/mailSettings/smtp") as SmtpSection;
      if (!Page.IsPostBack) {
        if (smtpSection != null) {
          txtFrom.Text = smtpSection.From.Trim();
          txtHost.Text = smtpSection.Network.Host.Trim();
          txtUserName.Text = smtpSection.Network.UserName.Trim();
          txtPassword.Text = smtpSection.Network.Password.Trim();
          txtPort.Text = smtpSection.Network.Port.ToString().Trim();
        }
      }
    }
    catch (Exception ex) {
      throw;
    }


  }
  protected void btnSave_Click(object sender, EventArgs e) {
    if (config != null) {
      if (smtpSection != null) {
        try {
          smtpSection.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
          smtpSection.From = txtFrom.Text.Trim();
          smtpSection.Network.Host = txtHost.Text.Trim();
          smtpSection.Network.UserName = txtUserName.Text.Trim();
          smtpSection.Network.Password = txtPassword.Text.Trim();
          int port = 25;
          int.TryParse(txtPort.Text.Trim(), out port);
          smtpSection.Network.Port = port;
          config.Save();
          result.ShowSuccess("Mail Configuration Saved.");
        }
        catch (Exception ex) {
          result.ShowFail(ex.Message);
        }
      }
    }
  }
}
