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
using Commerce.Promotions;
public partial class Admin_CouponEditors_Commerce_Promotions_PercentOffCoupon : System.Web.UI.UserControl, ICouponEditor {
  protected void Page_Load(object sender, EventArgs e) {

  }

  protected void OnCouponSaved() {
    if (CouponSaved != null) {
      CouponSaved(this, new EventArgs());
    }
  }


  #region ICouponEditor Members

  public event EventHandler<EventArgs> CouponSaved;

  public void NewCoupon(Commerce.Promotions.CouponType cpnType) {
    btnGenerate.Visible = true;
    ViewState["CouponTypeId"] = cpnType.CouponTypeID;
    ViewState["IsNew"] = true;
  }

  public void EditCoupon(Coupon couponToEdit) {
    btnGenerate.Visible = false;
    Commerce.Promotions.PercentOffCoupon pctCoupon =
        (Commerce.Promotions.PercentOffCoupon)couponToEdit;
    ViewState["CouponTypeId"] = pctCoupon.CouponType.CouponTypeID;
    ViewState["IsNew"] = false;
    this.txtCouponCode.Text = pctCoupon.CouponCode;
    txtCouponCode.ReadOnly = true;
    if (pctCoupon.ExpirationDate.HasValue) {
      this.txtExpirationDate.Text = String.Format("{0:d}", pctCoupon.ExpirationDate.Value);
    }
    chkIsSingleUse.Checked = pctCoupon.IsSingleUse;
    lblNumUses.Text = pctCoupon.NumberOfUses.ToString();
    txtDiscount.Text = pctCoupon.PercentOff.ToString();
  }

  #endregion

  protected void btnGenerate_Click(object sender, EventArgs e) {
    txtCouponCode.Text = Commerce.Promotions.Coupon.GenerateCouponCode();
  }

  protected void btnSave_Click(object sender, EventArgs e) {
    if ((bool)ViewState["IsNew"]) {
      PercentOffCoupon pctOffCoupon = new PercentOffCoupon(
          txtCouponCode.Text, CouponType.GetCouponType((int)ViewState["CouponTypeId"]));
      FillCouponValiues(pctOffCoupon);
    }
    else {
      PercentOffCoupon pctOffCoupon =
          (PercentOffCoupon)Coupon.GetCoupon(txtCouponCode.Text);
      FillCouponValiues(pctOffCoupon);
    }
  }

  private void FillCouponValiues(PercentOffCoupon pctOffCoupon) {
    if (!String.IsNullOrEmpty(txtExpirationDate.PostedDate)) {
      pctOffCoupon.ExpirationDate = txtExpirationDate.SelectedDate;
    }
    else {
      pctOffCoupon.ExpirationDate = null;
    }
    pctOffCoupon.IsSingleUse = chkIsSingleUse.Checked;
    pctOffCoupon.PercentOff = int.Parse(txtDiscount.Text);
    pctOffCoupon.SaveCoupon();
    OnCouponSaved();
  }

  protected void btnDelete_Click(object sender, EventArgs e) {
    SubSonic.Query q = new SubSonic.Query("CSK_Coupons");
    q.QueryType = SubSonic.QueryType.Delete;
    q.AddWhere("couponCode", txtCouponCode.Text);
    q.Execute();
    Response.Redirect(Request.Url.PathAndQuery, true);
  }
}
