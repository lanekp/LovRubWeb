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
using System.Globalization;
/// <summary>
/// Summary description for Currency
/// </summary>
public partial class Currency {

  private int currencyDecimals;
  private CultureInfo cultureInfo = null;

  public Currency() {
    cultureInfo = CultureInfo.CurrentCulture;
    currencyDecimals = cultureInfo.NumberFormat.CurrencyDecimalDigits;
  }

  public Currency(string name) {
    //TODO: CMC - Fix this up.
    //Validator.ValidateStringArgumentIsNotNullOrEmptyString(name, "name");
    cultureInfo = new CultureInfo(name);
    currencyDecimals = cultureInfo.NumberFormat.CurrencyDecimalDigits;
  }

  public Currency(CultureInfo culture) {
    //Validator.ValidateObjectType(culture, typeof(CultureInfo));
    cultureInfo = culture;
    currencyDecimals = culture.NumberFormat.CurrencyDecimalDigits;
  }

  public int CurrencyDecimals {
    get {
      return currencyDecimals;
    }
  }
}
