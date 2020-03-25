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
using SubSonic;

public partial class Admin_Admin_Coupons : System.Web.UI.Page {
  protected void Page_Load(object sender, EventArgs e) {
    if (!Page.IsPostBack) {
      BindCoupons();
      ddlCouponTypes.DataSource = new Query("CSK_CouponTypes").ExecuteReader();
      ddlCouponTypes.DataBind();
    }
    if (ViewState["CouponEditing"] != null) {
      string couponCode = (string)ViewState["CouponEditing"];
      LoadCouponEditor(couponCode);
    }
    if (ViewState["NewCouponType"] != null) {
      int newCouponTypeId = (int)ViewState["NewCouponType"];
      CouponType newCouponType = CouponType.GetCouponType(newCouponTypeId);
      LoadNewCouponEditor(newCouponType);
    }
  }

  private void BindCoupons() {
    dg.DataSource = new Query("vCoupons").ExecuteReader();
    dg.DataBind();
  }
  protected void dg_ItemCommand(object source, DataGridCommandEventArgs e) {
    if (e.CommandName == "EditCoupon") {
      editCouponPanel.Controls.Clear();
      editCouponPanel.Visible = true;
      string couponCode = e.CommandArgument.ToString();
      LoadCouponEditor(couponCode);
    }
  }

  private void LoadCouponEditor(string couponCode) {
    Coupon cpn = Coupon.GetCoupon(couponCode);
    ViewState["NewCouponType"] = null;
    ViewState["CouponEditing"] = couponCode;
    string editorControlPath = String.Format("~/Admin/CouponEditors/" +
        cpn.CouponType.CouponClassType.FullName.Replace(".", "_") + ".ascx");
    ICouponEditor editorControl = (ICouponEditor)Page.LoadControl(editorControlPath);
    editorControl.EditCoupon(cpn);

    editorControl.CouponSaved += new EventHandler<EventArgs>(editorControl_CouponSaved);

    editCouponPanel.Controls.Add((Control)editorControl);
  }
  protected void createCoupon_Click(object sender, EventArgs e) {
    ViewState["CouponEditing"] = null;
    editCouponPanel.Controls.Clear();
    editCouponPanel.Visible = true;

    CouponType newCouponType =
        CouponType.GetCouponType(int.Parse(ddlCouponTypes.SelectedValue));
    LoadNewCouponEditor(newCouponType);

  }
  private void LoadNewCouponEditor(CouponType newCouponType) {
    ViewState["NewCouponType"] = newCouponType.CouponTypeID;
    string editorControlPath = String.Format("~/Admin/CouponEditors/" +
        newCouponType.CouponClassType.FullName.Replace(".", "_") + ".ascx");
    ICouponEditor editorControl = (ICouponEditor)Page.LoadControl(editorControlPath);
    editorControl.NewCoupon(newCouponType);

    editorControl.CouponSaved += new EventHandler<EventArgs>(editorControl_CouponSaved);
    editCouponPanel.Controls.Add((Control)editorControl);

  }

  void editorControl_CouponSaved(object sender, EventArgs e) {
    {
      editCouponPanel.Visible = false;
      ViewState["NewCouponType"] = null;
      ViewState["CouponEditing"] = null;
      BindCoupons();
    };
  }
}
