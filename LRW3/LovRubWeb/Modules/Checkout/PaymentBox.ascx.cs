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
using Commerce.Common;

public partial class Modules_Checkout_PaymentBox : System.Web.UI.UserControl {


  private string ccNumber;

  public string CCNumber {
    get {
      return txtCCNumber.Text;
    }
  }
  private int expMonth;

  public int ExpirationMonth {
    get {
      int iOut = 0;
      int.TryParse(ddlExpMonth.SelectedValue, out iOut);
      return iOut;
    }
  }
  private CreditCardType ccType;

  public CreditCardType CCType {
    get {
      return (CreditCardType)int.Parse(ddlCCType.SelectedValue);
    }
  }

  private int expYear;

  public int ExpirationYear {
    get {
      int iOut = 0;
      int.TryParse(ddlExpYear.SelectedValue, out iOut);
      return iOut;
    }
  }
  private string securityCode;

  public string SecurityCode {
    get {
      return txtCCAuthCode.Text;
    }
  }

  protected void Page_Load(object sender, EventArgs e) {
    if (!Page.IsPostBack) {
      #if DEBUG
        ddlCCType.SelectedValue = "1";
	      txtCCNumber.Text = "4111111111111111";
	      txtCCAuthCode.Text = "027";
        SetSelectedMonth();
#endif
        LoadExpirationYear();
    }
  }
  void LoadExpirationYear() {

    if (ddlExpYear != null) {
      for (int i = DateTime.UtcNow.Year; i < DateTime.UtcNow.Year + 6; i++) {
        ddlExpYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
      }
    }
  }

  protected void toggleCreditCardInfo(object sender, EventArgs e) {
    if (ddlCCType.SelectedValue == "4") {
      pnlCreditCardInfo.Visible = false;
    }
    else {
      pnlCreditCardInfo.Visible = true;
    }
  }

  void SetSelectedMonth() {
    int selectedMonth = (DateTime.Now.Month + 1);
    ddlExpMonth.SelectedValue = selectedMonth.ToString();
  }

}
