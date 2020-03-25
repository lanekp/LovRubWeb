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
using System.Collections.Generic;
using SubSonic;

public partial class Admin_Admin_CouponTypes : System.Web.UI.Page {
  protected void Page_Load(object sender, EventArgs e) {
    if (!Page.IsPostBack) {
      BindCouponTypes();
    }
  }
  private void BindCouponTypes() {
    //Dictionary<int, Commerce.Promotions.CouponType> couponTypeList =
    //Commerce.Promotions.CouponType.GetAllCouponTypes(true);
    Query q = new Query("CSK_CouponTypes");
    dg.DataSource = q.ExecuteReader();//couponTypeList.Values;
    dg.DataBind();

  }

  protected void dg_ItemCommand(object source, DataGridCommandEventArgs e) {
    switch (e.CommandName) {
      case "EditCouponType":
        int couponTypeId;
        if (int.TryParse(e.CommandArgument.ToString(), out couponTypeId)) {
          EditCouponType(couponTypeId);
        }
        break;
      default:
        break;
    }
  }
  private void EditCouponType(int couponTypeId) {
    Commerce.Promotions.CouponType selectedCouponType =
        Commerce.Promotions.CouponType.GetCouponType(couponTypeId);
    lblID.Text = selectedCouponType.CouponTypeID.ToString();
    txtDescription.Text = selectedCouponType.Description;
    txtClassName.Text = selectedCouponType.CouponClassType.FullName;
    couponTypeEditPanel.Visible = true;
  }

  private void NewCouponType() {
    lblID.Text = "";
    txtDescription.Text = "";
    txtClassName.Text = "";
    couponTypeEditPanel.Visible = true;

  }
  protected void btnSave_Click(object sender, EventArgs e) {
    if (!Page.IsValid) {
      //no save ... exit.  
      return;
    }
    string classTypeName = BuildFullClassName();

    try {
      if (!String.IsNullOrEmpty(lblID.Text)) {
        //Edit on the coupon type.  
        int couponTypeId;
        if (int.TryParse(lblID.Text, out couponTypeId)) {
          Commerce.Promotions.CouponType selectedCouponType =
              Commerce.Promotions.CouponType.GetCouponType(couponTypeId);
          selectedCouponType.Description = txtDescription.Text;
          selectedCouponType.CouponClassType = System.Web.Compilation.BuildManager.GetType(classTypeName, true);
          selectedCouponType.Save();
        }
      }
      else {
        //this is a new coupon type.  
        Commerce.Promotions.CouponType couponType =
            new Commerce.Promotions.CouponType(
                -1, txtDescription.Text.Trim(), classTypeName);
        couponType.Save();
      }
      lblMessage.ForeColor = System.Drawing.Color.LightSteelBlue;
      lblMessage.Text = "Coupon Type Saved";
      couponTypeEditPanel.Visible = false;
      BindCouponTypes();
    }
    catch (Exception ex) {
      lblMessage.ForeColor = System.Drawing.Color.Red;
      lblMessage.Text = "Save failed<br/>" + ex.Message;

    }
  }
  protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args) {
    CustomValidator validator = (CustomValidator)source;
    args.IsValid = false;
    try {
      string fullClassName = BuildFullClassName();
      System.Type classType = System.Web.Compilation.BuildManager.GetType(fullClassName, true);
      //now that we have the type, make sure it has the proper base class.  
      if (classType.IsSubclassOf(typeof(Commerce.Promotions.Coupon))) {
        args.IsValid = true;
      }
      else {
        validator.ErrorMessage = "The specified class does not inherit from Commerce.Promotions.Coupon";
      }
    }
    catch (TypeLoadException tlx) {
      validator.ErrorMessage = "The class could not be loaded. " + tlx.Message;

    }
    catch (ArgumentException argEx) {
      validator.ErrorMessage = "The type name specified is invalid. " + argEx.Message;

    }
    catch (Exception) {
      validator.ErrorMessage = "An unspecified error occured while loading the type";
    }

  }
  protected string BuildFullClassName() {
    return BuildFullClassName(txtClassName.Text.Trim());
  }
  protected string BuildFullClassName(string className) {
    return className;
  }
  protected void btnNewCouponType_Click(object sender, EventArgs e) {
    NewCouponType();
  }
}
