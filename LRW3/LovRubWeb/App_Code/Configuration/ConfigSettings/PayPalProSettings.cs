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
/// Summary description for PayPalProSettings
/// </summary>
public class PayPalProSettings : ConfigurationSection {

  [ConfigurationProperty("apiUserName", DefaultValue = "")]
  public string APIUserName {
    get {
      return (string)base["apiUserName"];
    }
    set {
      base["apiUserName"] = value;
    }
  }
  [ConfigurationProperty("apiPassword", DefaultValue = "")]
  public string APIPassword {
    get {
      return (string)base["apiPassword"];
    }
    set {
      base["apiPassword"] = value;
    }
  }

  [ConfigurationProperty("signature", DefaultValue = "")]
  public string Signature {
    get {
      return (string)base["signature"];
    }
    set {
      base["signature"] = value;
    }
  }

  //[ConfigurationProperty("merchantId", DefaultValue = "")]
  //public string MerchantId {
  //  get {
  //    return (string)base["merchantId"];
  //  }
  //  set {
  //    base["merchantId"] = value;
  //  }
  //}

  //[ConfigurationProperty("defaultCurrencyCode", DefaultValue = "USD")]
  //public string DefaultCurrencyCode {
  //  get {
  //    return (string)base["defaultCurrencyCode"];
  //  }
  //  set {
  //    base["defaultCurrencyCode"] = value;
  //  }
  //}

  [ConfigurationProperty("isActive", DefaultValue = "false")]
  public bool IsActive {
    get {
      return (bool)base["isActive"];
    }
    set {
      base["isActive"] = value;
    }
  }
  
  [ConfigurationProperty("isLive", DefaultValue = "false")]
  public bool IsLive {
    get {
      return (bool)base["isLive"];
    }
    set {
      base["isLive"] = value;
    }
  }

}
