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
using System.Web.Configuration;
using Commerce.Common;
using Commerce.Providers;
/// <summary>
/// Summary description for SiteConfig
/// </summary>
public static class SiteConfig {
  static GeneralSettings generalSettings;
  static PayPalProSettings ppProSettings;
  static PayPalStandardSettings ppStandardSettings;
  public static PaymentServiceSection CreditCardSettings;
  public static TaxServiceSection TaxServiceSettings;
  static FulfillmentServiceSection shippingSettings;

  public static void Load() {
    // Get the current configuration file.
    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
    generalSettings = (GeneralSettings)config.GetSection("GeneralSettings");
    ppProSettings = (PayPalProSettings)config.GetSection("PayPalProSettings");
    ppStandardSettings = (PayPalStandardSettings)config.GetSection("PayPalStandardSettings");
    CreditCardSettings = (PaymentServiceSection)config.GetSection("PaymentService");
    TaxServiceSettings = (TaxServiceSection)config.GetSection("TaxService");
    shippingSettings = (FulfillmentServiceSection)config.GetSection("FulfillmentService");
  }


  #region Publics
  public static bool AcceptCreditCards {
    get {
      return CreditCardSettings.AcceptCreditCards;
    }
  }

  public static string DimensionUnit {
    get {
      return shippingSettings.DimensionUnit;
    }
  }

  public static string BusinessEmail {
    get {
      return ppStandardSettings.BusinessEmail;
    }
  }

  public static bool RequireShipping {
    get {
      return shippingSettings.UseShipping;
    }
  }

  public static string RequireLogin {
    get {
      return generalSettings.LoginRequirement;
    }
  }

  public static string ShipFromZip {
    get {
      return shippingSettings.ShipFromZip;
    }
  }

  public static bool UsePPStandardSandbox {
    get {
      return ppStandardSettings.UseSandbox;
    }
  }

  public static bool UsePayPalPaymentsStandard {
    get {
      return ppStandardSettings.IsActive;
    }
  }

  public static bool UsePayPalExpressCheckout {
    get {
      return ppProSettings.IsActive;
    }
  }

  public static bool UsePPProSandbox {
    get {
      return !ppProSettings.IsLive;
    }
  }

  public static CurrencyCode CurrencyCode {
    get {
      if (!Enum.IsDefined(typeof(Commerce.Common.CurrencyCode), generalSettings.CurrencyCode)) {
        throw new InvalidOperationException(string.Format("Provided currency code is not a valid Commerce.Common.CurrencyCode. Currency Code: {0}.", generalSettings.CurrencyCode));
      }
      return (CurrencyCode)Enum.Parse(typeof(Commerce.Common.CurrencyCode), generalSettings.CurrencyCode);
    }
  }

  public static string PayPalAPIUserName {
    get {
      return ppProSettings.APIUserName;
    }
  }

  public static string PayPalAPIPassword {
    get {
      return ppProSettings.APIPassword;
    }
  }

  public static string PayPalAPISignature {
    get {
      return ppProSettings.Signature;
    }
  }

  public static bool PayPalAPIIsLive {
    get {
      return ppProSettings.IsLive;
    }
  }

  public static string PayPalPDTID {
    get {
      return ppStandardSettings.PDTID;
    }
  }

  public static decimal ShipPackagingBuffer {
    get {
      return shippingSettings.ShipPackagingBuffer;
    }
  }

  public static string ShipFromCountryCode {
    get {
      return shippingSettings.ShipFromCountryCode;
    }
  }

  public static bool AuthorizeSaleOnly {
    get {
      return generalSettings.AuthorizeSaleOnly;
    }
  }

  #endregion
}
