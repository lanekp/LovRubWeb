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

public partial class Admin_Admin_Product_Add : System.Web.UI.Page {

	protected void Page_Load(object sender, EventArgs e) {
		if(!Page.IsPostBack) {
			LoadDropDowns();
		}
	}

	protected void btnSave_Click(object sender, EventArgs e) {
		//Thanks Herman (osi_ni) for portions of this code
		if(Page.IsValid) {

			try {
				int manufacturerId = 0;
				int.TryParse(ddlManufacturerID.SelectedValue, out manufacturerId);
				int statusId = 0;
				int.TryParse(ddlStatusID.SelectedValue, out statusId);
				int productTypeId = 0;
				int.TryParse(ddlProductTypeID.SelectedValue, out productTypeId);
				int shippingTypeId = 0;
				int.TryParse(ddlShippingTypeID.SelectedValue, out shippingTypeId);
				int shipEstimateId = 0;
				int.TryParse(ddlShipEstimateID.SelectedValue, out shipEstimateId);
				int taxTypeId = 0;
				int.TryParse(ddlTaxTypeID.SelectedValue, out taxTypeId);
				decimal ourPrice = 0;
				decimal.TryParse(txtOurPrice.Text.Trim(), out ourPrice);
				decimal retailPrice = 0;
				decimal.TryParse(txtRetailPrice.Text.Trim(), out retailPrice);
				decimal weight = 0;
				decimal.TryParse(txtWeight.Text.Trim(), out weight);
				decimal length = 0;
				decimal.TryParse(txtLength.Text.Trim(), out length);
				decimal height = 0;
				decimal.TryParse(txtHeight.Text.Trim(), out height);
				decimal width = 0;
				decimal.TryParse(txtWidth.Text.Trim(), out width);
				int listOrder = 0;
				int.TryParse(txtListOrder.Text.Trim(), out listOrder);

				Commerce.Common.Product product = new Commerce.Common.Product();

				product.Sku = txtSku.Text.Trim();
				product.ProductName = txtProductName.Text.Trim();
				product.ShortDescription = txtShortDescription.Text.Trim();
				product.OurPrice = ourPrice;
				product.RetailPrice = retailPrice;
				product.ManufacturerID = manufacturerId;
				product.Status = (ProductStatus)statusId;
				product.ProductType = (ProductType)productTypeId;
				product.ShippingType = (ShippingType)shippingTypeId;
				product.ShipEstimateID = shipEstimateId;
				product.TaxTypeID = taxTypeId;
				product.StockLocation = txtStockLocation.Text.Trim();
				product.Weight = weight;
				product.CurrencyCode = ddlCurrencyCodeID.SelectedValue.Trim();
				product.UnitOfMeasure = txtUnitOfMeasure.Text.Trim();
				product.AdminComments = txtAdminComments.Text.Trim();
				product.Length = length;
				product.Height = height;
				product.Width = width;
				product.DimensionUnit = txtDimensionUnit.Text.Trim();
				product.ListOrder = listOrder;
				//default this to avoid division errors
				product.TotalRatingVotes = 1;
				product.RatingSum = 4;


				//save it up and redirect
				product.Save(Utility.GetUserName());
				//send to the detail page
				Response.Redirect("admin_product_details.aspx?id=" + product.ProductID.ToString(), false);
			}
			catch(Exception x) {
				ResultMessage1.ShowFail(x.Message);
			}
		}
	}

	void LoadDropDowns() {
		Utility.LoadListItems(ddlManufacturerID.Items, Lookups.GetList("CSK_Store_Manufacturer"), "manufacturer", "manufacturerid", "", true);
		Utility.LoadListItems(ddlStatusID.Items, Lookups.GetList("CSK_Store_ProductStatus"), "status", "statusid", "", true);
		Utility.LoadListItems(ddlProductTypeID.Items, Lookups.GetList("CSK_Store_ProductType"), "producttype", "producttypeid", "", true);
		Utility.LoadListItems(ddlShippingTypeID.Items, Lookups.GetList("CSK_Store_ShippingType"), "shippingtype", "shippingtypeid", "", true);
		Utility.LoadListItems(ddlShipEstimateID.Items, Lookups.GetList("CSK_Store_ShippingEstimate"), "shippingestimate", "shipestimateid", "", true);
		Utility.LoadListItems(ddlTaxTypeID.Items, Lookups.GetList("CSK_Tax_Type"), "taxtype", "taxtypeid", "", true);
		Utility.LoadListItems(ddlCurrencyCodeID.Items, Lookups.GetList("CSK_Util_Currency"), "code", "code", ConfigurationManager.AppSettings["defaultCurrency"], true);
	}

	protected void btnQuickMan_Click(object sender, EventArgs e) {
		if(txtQuickMan.Text.Trim().Length > 0) {
			Lookups.QuickAdd("CSK_Store_Manufacturer", "manufacturer", txtQuickMan.Text.Trim());
			txtQuickMan.Text = "";
			this.LoadDropDowns();
			ddlManufacturerID.SelectedIndex = ddlManufacturerID.Items.Count - 1;
		}
	}
}
