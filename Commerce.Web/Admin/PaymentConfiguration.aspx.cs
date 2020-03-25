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
using System.Web.Configuration;

public partial class Admin_PaymentConfiguration : System.Web.UI.Page {
  protected void Page_Load(object sender, EventArgs e) {
    if (!Page.IsPostBack) {
      LoadCurrencyType();
      LoadSettings();
    }
  }
  void LoadSettings() {
    //general settings
    ddlLogin.SelectedValue = SiteConfig.RequireLogin;
    ddlCurrencyType.SelectedValue = Enum.GetName(typeof(Commerce.Common.CurrencyCode), SiteConfig.CurrencyCode);

    //standard
    chkUsePPStandard.Checked = SiteConfig.UsePayPalPaymentsStandard;
    chkUsePPStandardSandbox.Checked = SiteConfig.UsePPStandardSandbox;
    txtBusinessEmail.Text = SiteConfig.BusinessEmail;
    txtPDTID.Text = SiteConfig.PayPalPDTID;

    //pro settings
    chkUsePPPro.Checked = SiteConfig.UsePayPalExpressCheckout;
    chkUsePPSandbox.Checked = SiteConfig.UsePPProSandbox;
    txtPPAPIAccount.Text = SiteConfig.PayPalAPIUserName;
    txtPPAPIPassword.Text = SiteConfig.PayPalAPIPassword;
    txtPPAPISignature.Text = SiteConfig.PayPalAPISignature;

    //CC Bits
    chkAcceptCC.Checked = SiteConfig.AcceptCreditCards;

    //get the provider, if there is one, and set the boxes
    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    Commerce.Providers.PaymentServiceSection section = (Commerce.Providers.PaymentServiceSection)config.GetSection("PaymentService");

    if (section.Providers.Count > 0) {
      if (section.Providers[0].Name == "PayPalPaymentProvider") {

      }
      else {
        txtCCKey.Text = section.Providers[0].Parameters["transactionKey"].ToString();
        txtCCPassword.Text = section.Providers[0].Parameters["servicePassword"].ToString();
        txtCCUrl.Text = section.Providers[0].Parameters["serverURL"].ToString();
        txtCCUserName.Text = section.Providers[0].Parameters["serviceUserName"].ToString();
      }
    }
  }
  void LoadCurrencyType() {
    ddlCurrencyType.DataSource = Enum.GetNames(typeof(Commerce.Common.CurrencyCode));
    ddlCurrencyType.DataBind();
    ddlCurrencyType.SelectedValue = "USD";
  }
  protected void btnSetGeneral_Click(object sender, EventArgs e) {
    // Get the current configuration file.
    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    GeneralSettings section = (GeneralSettings)config.GetSection("GeneralSettings");
    try {
      if (section != null) {
        section.CurrencyCode = ddlCurrencyType.SelectedValue;
        section.LoginRequirement = ddlLogin.SelectedValue;
        config.Save();
        ResultMessage1.ShowSuccess("General Settings Saved");
      }
      else {
        throw new Exception("There is no GeneralSettings section in the Web.Config");
      }
    }
    catch (Exception x) {
      ResultMessage1.ShowFail(x.Message);
    }

  }
  protected void btnSetPPStandard_Click(object sender, EventArgs e) {
    // Get the current configuration file.
    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    PayPalStandardSettings section = (PayPalStandardSettings)config.GetSection("PayPalStandardSettings");
    try {
      if (section != null) {
        section.UseSandbox = chkUsePPStandardSandbox.Checked;
        section.BusinessEmail = txtBusinessEmail.Text;
        section.PDTID = txtPDTID.Text;
        section.IsActive = chkUsePPStandard.Checked;
        config.Save();
        ResultMessage2.ShowSuccess("PayPal Standard Settings Saved");
      }
      else {
        throw new Exception("There is no PayPalStandardSettings section in the Web.Config");
      }
    }
    catch (Exception x) {
      ResultMessage2.ShowFail("Cannot write to the Web.Config file; in order to have the application update the configuration, you have to allow write access to the ASNET account (or NETWORK SERVICE) and make sure the file is not marked as Read Only");
    }
  }
  protected void btnSetPPPro_Click(object sender, EventArgs e) {
    // Get the current configuration file.
    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    PayPalProSettings section = (PayPalProSettings)config.GetSection("PayPalProSettings");
    try {
      if (section != null) {
        section.APIPassword = txtPPAPIPassword.Text.Trim();
        section.APIUserName = txtPPAPIAccount.Text.Trim();
        section.Signature = txtPPAPISignature.Text.Trim();
        section.IsLive = !chkUsePPSandbox.Checked;
        section.IsActive = chkUsePPPro.Checked;
        config.Save();
        ResultMessage3.ShowSuccess("PayPal Pro Settings Saved");

      }
      else {
        throw new Exception("There is no PayPalProSettings section in the Web.Config");
      }
    }
    catch (Exception x) {
      ResultMessage3.ShowFail("Cannot write to the Web.Config file; in order to have the application update the configuration, you have to allow write access to the ASNET account (or NETWORK SERVICE) and make sure the file is not marked as Read Only");
    }
  }
  protected void btnSetCC_Click(object sender, EventArgs e) {

    // Get the current configuration file.
    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
    Commerce.Providers.PaymentServiceSection section = (Commerce.Providers.PaymentServiceSection)config.GetSection("PaymentService");

    //load up the ConfigSection
    ProviderSettings settings = new ProviderSettings();
    try {
      string userName = txtCCUserName.Text;
      string password = txtCCPassword.Text;
      string key = txtCCKey.Text;
      string providerName = ddlCCProvider.SelectedValue;

      section.AcceptCreditCards = chkAcceptCC.Checked;
      //section.CurrencyCode = ddlCurrencyType.SelectedValue;
      section.Providers.Clear();
      //apply the settings based on the provider
      if (providerName == "PayPalPaymentProvider") {
        section.DefaultProvider = "PayPalPaymentProvider";
        settings.Name = "PayPalPaymentProvider";
        settings.Parameters.Add("type", "Commerce.Providers.PayPalPaymentProvider");
        settings.Parameters.Add("apiUserName", txtPPAPIAccount.Text.Trim());
        settings.Parameters.Add("apiPassword", txtPPAPIPassword.Text.Trim());
        settings.Parameters.Add("signature", txtPPAPISignature.Text.Trim());
        bool isLive = !chkUsePPSandbox.Checked;
        settings.Parameters.Add("isLive", isLive.ToString());
        section.Providers.Add(settings);
      }
      else {
        section.DefaultProvider = providerName;
        settings.Name = providerName;
        settings.Parameters.Add("type", "Commerce.Providers." + providerName);
        settings.Parameters.Add("serviceUserName", txtPPAPIAccount.Text);
        settings.Parameters.Add("servicePassword", txtPPAPIPassword.Text);
        settings.Parameters.Add("transactionKey", txtCCKey.Text);
        settings.Parameters.Add("serverURL", txtCCUrl.Text);
        settings.Parameters.Add("currencyCode", ddlCurrencyType.SelectedValue);
        section.Providers.Add(settings);

      }
      config.Save();
      ResultMessage5.ShowSuccess("Credit Card Settings Saved");
    }
    catch (Exception x) {
      ResultMessage5.ShowFail("Cannot write to the Web.Config file; in order to have the application update the configuration, you have to allow write access to the ASNET account (or NETWORK SERVICE) and make sure the file is not marked as Read Only");
    }
  }
}
