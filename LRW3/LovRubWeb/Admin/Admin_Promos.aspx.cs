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
using Commerce.Common;

public partial class Admin_Admin_Promos : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e) {

        string promoID = Utility.GetParameter("p");
        if (!Page.IsPostBack) {
            if (promoID == string.Empty) {
                LoadGrid();
            } else {
                LoadEditor(promoID);
            }
        }

    }
    #region Grid Functions
    void LoadGrid() {


        ToggleGrid(true);


        dg.DataSource = Commerce.Promotions.Promo.FetchAll();
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
        ddlCampaignID.DataSource=Commerce.Promotions.Campaign.FetchAll();
        ddlCampaignID.DataTextField="campaignName";
        ddlCampaignID.DataValueField="campaignid";
        ddlCampaignID.DataBind();

        if (lblID.Text != string.Empty) {
            //this isn't a drop-down, but belongs here.
            DataSet ds = Commerce.Promotions.Promo.GetProductList(int.Parse(lblID.Text));

            chkProducts.DataSource = ds.Tables[1];
            chkProducts.DataTextField = "productName";
            chkProducts.DataValueField = "productID";
            chkProducts.DataBind();

            int listProductID = 0;
            int selectedProductID = 0;
            foreach (ListItem l in chkProducts.Items) {
                listProductID = int.Parse(l.Value);
                foreach (DataRow dr in ds.Tables[0].Rows) {
                    selectedProductID = (int)dr["productID"];
                    if (selectedProductID == listProductID) {
                        l.Selected = true;
                        break;
                    }
                }
            }
            ds.Dispose();
        }
    }
    #region Editor Loader
    void LoadEditor(string editID) {
        //load the drops
        ToggleGrid(false);
        btnDelete.Visible = true;
        btnDelete.Attributes.Add("onclick", "return CheckDelete();");
        btnSave.Text = "Update";

        //load the rest
        lblID.Text = editID;
        LoadEditData(editID);
        LoadDropDowns();
    }

    void LoadEditData(string editID) {
        Commerce.Promotions.Promo promo = new Promo(int.Parse(editID));
        LoadDropDowns();
        lblID.Text = editID;
        ddlCampaignID.SelectedValue = promo.CampaignID.ToString();
        txtPromoCode.Text = promo.PromoCode;
        txtTitle.Text = promo.Title;
        txtDescription.Text = promo.Description;
        txtDiscount.Text = promo.Discount.ToString();

        txtQtyThreshold.Text = promo.QtyThreshold.ToString();
        txtInventoryGoal.Text = promo.InventoryGoal.ToString();
        txtRevenueGoal.Text = promo.RevenueGoal.ToString();
        txtDateCreated.SelectedDate = promo.CreatedOn;
        txtDateEnd.SelectedDate = promo.DateEnd;
        chkIsActive.Checked = promo.IsActive;
    }
    #endregion

    #region DB Methods
    void Delete() {

        bool isError = false;
        try {
            Promo.RemoveProducts(int.Parse(lblID.Text));
            Promo.Delete(int.Parse(lblID.Text));
        } catch (Exception x) {
            isError = true;
            ThrowError(x.Message);
        }
        if (!isError)
			Response.Redirect("admin_promos.aspx", false);

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
        this.Delete();
    }
    void SaveProducts() {
        int promoID = int.Parse(lblID.Text);
        Utility.SaveManyToMany("promoID",promoID,"CSK_Promo_Product_Promo_Map", "productID", chkProducts.Items);
        
    }
    protected void btnSave_Click(object sender, System.EventArgs e) {
        bool isError = false;
        bool isAdd = false;
        Commerce.Promotions.Promo promo = null;
        if (lblID.Text != string.Empty)
        {
            promo = new Promo(int.Parse(lblID.Text));
        }
        else
        {
            promo = new Promo();
            isAdd = true;
        }

        promo.Discount = decimal.Parse(txtDiscount.Text);
        promo.CampaignID = int.Parse(ddlCampaignID.SelectedValue);
        promo.DateEnd = txtDateEnd.SelectedDate;
        promo.Description = txtDescription.Text;
        
        promo.InventoryGoal = int.Parse(txtInventoryGoal.Text);
        promo.IsActive = chkIsActive.Checked;
        promo.PromoCode = txtPromoCode.Text;
        promo.QtyThreshold = int.Parse(txtQtyThreshold.Text);
        promo.RevenueGoal = decimal.Parse(txtRevenueGoal.Text);
        promo.Title = txtTitle.Text;

        try {
            promo.Save(Utility.GetUserName());
            if(lblID.Text!=string.Empty)
                SaveProducts();
            uResult.ShowSuccess("Promotion Saved");
            PromotionService.ResetPromos();
            if (isAdd)
                Response.Redirect("admin_promos.aspx?p=" + promo.PromoID.ToString(), true);
        } catch (Exception x) {
            ThrowError(x.Message);
        }

    }
    #endregion

    #region Error Handling
    void ThrowError(string message) {
        uResult.ShowFail(message);
    }


    #endregion

}
