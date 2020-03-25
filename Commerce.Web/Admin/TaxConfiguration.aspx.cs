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
using Commerce.Providers;
using Commerce.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.Configuration;


public partial class _Config_TaxConfiguration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            pnlRealTime.Visible = false;
            //btnLoadRates.Visible = false;
        }
    }
    protected string GetCurrentService()
    {
        // Get the current configuration file.
        System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        Commerce.Providers.TaxServiceSection section = (TaxServiceSection)config.GetSection("TaxService");
        return section.DefaultProvider;

    }

    protected void btnRealTime_Click(object sender, EventArgs e)
    {
        pnlRealTime.Visible = true;
        decimal dRate = TaxService.GetUSTaxRate(txtZip.Text);

        Label lblRLRate = new Label();
        lblRLRate.Text = "<font color=goldenrond>Rate for " + txtZip.Text + "</font>: <b>" + dRate.ToString("p")+"</b>";
        pnlRealTime.Controls.Add(lblRLRate);
    }

    void SetConfig(string providerName)
    {
        //load up the ConfigSection
        ProviderSettings settings = new ProviderSettings();

        // Get the current configuration file.
        System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(Request.ApplicationPath);
        Commerce.Providers.TaxServiceSection section = (TaxServiceSection)config.GetSection("TaxService");

        section.Providers.Clear();

        //apply the settings based on the provider
        switch (providerName)
        {
            case "StrikeIronTaxProvider":
                section.DefaultProvider = "StrikeIronTaxProvider";
                settings.Name = "StrikeIronTaxProvider";
                settings.Parameters.Add("type", "Commerce.Providers.StrikeIronTaxProvider");
                settings.Parameters.Add("serviceKey", txtSIKey.Text);
                section.Providers.Add(settings);
                break;
            case "FlatRateTaxProvider":
                section.DefaultProvider = "FlatRateTaxProvider";
                settings.Name = "FlatRateTaxProvider";
                settings.Parameters.Add("type", "Commerce.Providers.FlatRateTaxProvider");
                settings.Parameters.Add("connectionStringName", "CommerceTemplate");
                section.Providers.Add(settings);
                break;
            case "ZeroTaxRateProvider":
                section.DefaultProvider = "ZeroTaxRateProvider";
                settings.Name = "ZeroTaxRateProvider";
                settings.Parameters.Add("type", "Commerce.Providers.ZeroTaxRateProvider");
                section.Providers.Add(settings);
                break;
        }
        try
        {
            config.Save();
        }
        catch
        {
           ResultMessage1.ShowFail("Cannot write to the Web.Config file; in order to have the application update the configuration, you have to allow write access to the ASNET account (or NETWORK SERVICE) and make sure the file is not marked as Read Only");
        }

    }
    protected void btnZero_Click(object sender, EventArgs e)
    {
        SetConfig("ZeroTaxRateProvider");
    }
    protected void btnFlat_Click(object sender, EventArgs e)
    {
        SetConfig("FlatRateTaxProvider");

    }
    protected void btnStrikeIron_Click(object sender, EventArgs e)
    {
        SetConfig("StrikeIronTaxProvider");

    }
}
