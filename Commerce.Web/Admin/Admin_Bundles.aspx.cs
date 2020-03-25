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

public partial class Admin_Admin_Bundles : System.Web.UI.Page {
  private void Page_Load(object sender, System.EventArgs e) {
    if (!Page.IsPostBack)
      LoadGrid();
  }

  #region Grid Functions

  void LoadGrid() {
    ToggleGrid(true);
    dg.DataSource = Bundle.FetchAll();
    dg.DataBind();
  }

  void ToggleGrid(bool show) {
    pnlGrid.Visible = show;
    pnlEdit.Visible = !show;
  }


  #endregion

  #region Add Loader
  void LoadAddForm() {
    lblID.Visible = false;
    LoadDropDowns(-1);
    btnDelete.Visible = false;
    btnSave.Text = "Add";
    ToggleGrid(false);
  }

  #endregion
  void LoadDropDowns(int bundleId) {
    Utility.LoadListItems(ddlAddProductID.Items,
        Bundle.GetAvailableProducts(bundleId),
        "productName", "productID", "", true);

  }
  #region Editor Loader
  void LoadEditor(int editId) {
    //load the drops
    ToggleGrid(false);
    btnDelete.Visible = true;
    btnDelete.Attributes.Add("onclick", "return CheckDelete();");
    btnSave.Text = "Update";

    //load the rest

    //called in LoadEditData
    //lblID.Text = editId.ToString();
    //LoadDropDowns(editId);
    LoadEditData(editId);
    LoadProducts(editId);
  }
  void LoadProducts(int editId) {
    rptProducts.DataSource = Bundle.GetSelectedProducts(editId);
    rptProducts.DataBind();

  }
  void LoadEditData(int editId) {
    Bundle bundle = new Bundle(editId);

    LoadDropDowns(editId);
    lblID.Text = editId.ToString();
    txtBundleName.Text = bundle.BundleName;
    txtDiscountPercent.Text = bundle.DiscountPercent.ToString();
    txtDescription.Text = bundle.Description;
  }
  #endregion


  #region Event Handlers

  protected void GridEdit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {
    //the id is the second column
    string sEditID = e.Item.Cells[1].Text;
    LoadEditor(int.Parse(sEditID));
  }

  protected void btnAdd_Click(object sender, System.EventArgs e) {
    LoadAddForm();
  }

  protected void btnDelete_Click(object sender, EventArgs e) {

    PromotionService.DeleteBundle(int.Parse(lblID.Text));
    Response.Redirect(Request.Url.PathAndQuery, false);
  }

  protected void btnSave_Click(object sender, System.EventArgs e) {
    bool isError = false;
    bool isAdd = false;
    Bundle bundle = null;
    if (lblID.Text != string.Empty) {
      bundle = new Bundle(int.Parse(lblID.Text));
    }
    else {
      bundle = new Bundle();
      isAdd = true;
    }

    bundle.BundleName = txtBundleName.Text;
    bundle.Description = txtDescription.Text;
    bundle.DiscountPercent = int.Parse(txtDiscountPercent.Text);

    //save it up
    bundle.Save(Utility.GetUserName());

    //if this is an add, reload the page with the edit id
    if (isAdd) {
      this.LoadEditor(bundle.BundleID);
    }
    //else send back to list
    else {
      Response.Redirect(Request.Url.PathAndQuery, false);
    }
  }
  #endregion

  #region Error Handling
  void ThrowError(string message) {
    uResult.ShowFail(message);
  }


  #endregion
  protected void btnAddProduct_Click(object sender, EventArgs e) {
    int bundleId = int.Parse(lblID.Text);
    Bundle.AddProduct(bundleId, int.Parse(ddlAddProductID.SelectedValue));
    this.LoadDropDowns(bundleId);
    this.LoadProducts(bundleId);
  }

  protected void DeleteBundle(object sender, RepeaterCommandEventArgs e) {
    Label lblProductID = (Label)e.Item.FindControl("lblProductID");
    if (lblProductID != null) {
      string productID = lblProductID.Text;
      int bundleId = int.Parse(lblID.Text);
      Bundle.RemoveProduct(bundleId, int.Parse(productID));
      this.LoadDropDowns(bundleId);
      this.LoadProducts(bundleId);
    }
  }
}
