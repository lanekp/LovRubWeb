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
/// Summary description for PayPalStandardSettings
/// </summary>
public class PayPalStandardSettings:ConfigurationSection
{
    [ConfigurationProperty("isActive",
        DefaultValue = false)]
    public bool IsActive
    {
        get { return (bool)base["isActive"]; }
        set { base["isActive"] = value; }
    }
    [ConfigurationProperty("useSandbox",
        DefaultValue = true)]
    public bool UseSandbox
    {
        get { return (bool)base["useSandbox"]; }
        set { base["useSandbox"] = value; }
    }
    [StringValidator(MinLength = 5)]
    [ConfigurationProperty("businessEmail",
       DefaultValue = "me@business.com")]
    public string BusinessEmail
    {
        get { return (string)base["businessEmail"]; }
        set { base["businessEmail"] = value; }
    }
    [ConfigurationProperty("PDTID",
       DefaultValue = "")]
    public string PDTID
    {
        get { return (string)base["PDTID"]; }
        set { base["PDTID"] = value; }
    }

}
