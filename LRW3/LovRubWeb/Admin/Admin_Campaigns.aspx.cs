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
using System.Data.SqlClient;
using Commerce.Promotions;
using SubSonic;

public partial class Admin_Admin_Campaigns : System.Web.UI.Page {

  private void Page_Load(object sender, System.EventArgs e) {
    if (!Page.IsPostBack)
      LoadGrid();
  }

#region Grid Functions
  void LoadGrid() {
    ToggleGrid(true);
    dg.DataSource = Campaign.FetchAll(OrderBy.Asc("campaignName"));
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
    LoadDropDowns();
    btnDelete.Visible = false;
    btnSave.Text = "Add";
    ToggleGrid(false);
  }

  #endregion
  void LoadDropDowns() {

  }
  #region Editor Loader
  void LoadEditor(string editID) {
    //load the drops
    ToggleGrid(false);
    btnDelete.Visible = true;
    btnDelete.Attributes.Add("onclick", "return CheckDelete();");
    btnSave.Text = "Update";

    //load the rest
    LoadDropDowns();
    LoadEditData(editID);
    lblID.Text = editID;
  }

  void LoadEditData(string editID) {
    Campaign campaign = new Campaign(int.Parse(editID));
    LoadDropDowns();
    lblID.Text = editID;
    txtCampaign.Text = campaign.CampaignName;
    txtDescription.Text = campaign.Description;
    txtObjective.Text = campaign.Objective;
    txtRevenueGoal.Text = campaign.RevenueGoal.ToString();
    txtInventoryGoal.Text = campaign.InventoryGoal.ToString();
    txtDateEnd.SelectedDate = campaign.DateEnd;
    chkIsActive.Checked = campaign.IsActive;
  }
  #endregion


  #region Event Handlers

  protected void GridEdit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e) {
    //the id is the second column
    string sEditID = e.Item.Cells[1].Text;
    LoadEditor(sEditID);
  }

  protected void btnAdd_Click(object sender, System.EventArgs e) {
    LoadAddForm();
  }
  protected void btnDelete_Click(object sender, EventArgs e) {
    Campaign.Delete(int.Parse(lblID.Text));
    Response.Redirect(Request.Url.PathAndQuery, false);

  }
  protected void btnSave_Click(object sender, System.EventArgs e) {
    bool isError = false;
    Campaign campaign = null;
    if (lblID.Text != string.Empty) {
      campaign = new Campaign(int.Parse(lblID.Text));
    }
    else {
      campaign = new Campaign();

    }

    campaign.CampaignName = txtCampaign.Text.Trim();
    campaign.DateEnd = txtDateEnd.SelectedDate;
    campaign.Description = txtDescription.Text.Trim();
    int inventoryGoal = 0;
    int.TryParse(txtInventoryGoal.Text.Trim(), out inventoryGoal);
    campaign.InventoryGoal = inventoryGoal;
    campaign.IsActive = chkIsActive.Checked;
    campaign.Objective = txtObjective.Text.Trim();
    decimal revenueGoal = 0;
    decimal.TryParse(txtRevenueGoal.Text.Trim(), out revenueGoal);
    campaign.RevenueGoal = revenueGoal;
    campaign.Save(Utility.GetUserName());
    Response.Redirect(Request.Url.PathAndQuery, false);
  }
  #endregion

  #region Error Handling
  void ThrowError(string message) {
    uResult.ShowFail(message);
  }


  #endregion
}
