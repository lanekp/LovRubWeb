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

public partial class Admin_Admin_Product_Details : System.Web.UI.Page {
    int productID = 0;
    protected void Page_Load(object sender, EventArgs e) {
        productID = Utility.GetIntParameter("id");
        if (!Page.IsPostBack) {
            if(productID!=0)
                LoadEditor();
            TogglePanel(pnlMain);
        }

    }

    #region Add Loader
    void LoadAddForm() {
        LoadDropDowns();
        btnDelete.Visible = false;
        btnSave.Text = "Add";
        lblProductName.Text = "Add a New Product";
    }

    #endregion
    void LoadDropDowns() {
        Utility.LoadListItems(ddlManufacturerID.Items, Lookups.GetList("CSK_Store_Manufacturer"), "manufacturer", "manufacturerid", "", true);
        Utility.LoadListItems(ddlStatusID.Items, Lookups.GetList("CSK_Store_ProductStatus"), "status", "statusid", "", true);
        Utility.LoadListItems(ddlProductTypeID.Items, Lookups.GetList("CSK_Store_ProductType"), "producttype", "producttypeid", "", true);
        Utility.LoadListItems(ddlShippingTypeID.Items, Lookups.GetList("CSK_Store_ShippingType"), "shippingtype", "shippingtypeid", "", true);
        Utility.LoadListItems(ddlShipEstimateID.Items, Lookups.GetList("CSK_Store_ShippingEstimate"), "shippingestimate", "shipestimateid", "", true);
        Utility.LoadListItems(ddlTaxTypeID.Items, Lookups.GetList("CSK_Tax_Type"), "taxtype", "taxtypeid", "", true);
		Utility.LoadListItems(ddlCurrencyCodeID.Items, Lookups.GetList("CSK_Util_Currency"), "code", "code", ConfigurationManager.AppSettings["defaultCurrency"], true);

    }

    #region Editor Loader
    void LoadEditor() {
        //load the drops
        btnDelete.Visible = true;
        btnDelete.Attributes.Add("onclick", "return CheckDelete();");
        btnSave.Text = "Update";
        //load the rest
        LoadDropDowns();
        LoadEditData();
        lblID.Text = productID.ToString();

        //load up the images
        LoadImages();
        LoadCategories();
        //LoadCatList();
        LoadCrossProducts();
        LoadDescriptors();
        LoadQtyDiscounts();
    }
    void LoadDescriptors()
    {
        ProductDescriptors1.ProductID = productID;
    }

    void LoadCategories() {
        ProductCategories1.LoadCategories(productID);
    }
    void LoadCrossProducts() {
        ProductCrossSells1.LoadCrossProducts(productID);
    }

    void LoadQtyDiscounts()
    {
        ProductQtyDiscounts1.LoadControl();
    }

    void LoadImages() {
        ProductImages1.LoadImages(productID);

    }


    void LoadEditData() {
        Commerce.Common.Product product = new Commerce.Common.Product(productID);
        ProductAttributes1.LoadAttributes(product);
        LoadDropDowns();

        //Page Title ... 
        this.Title = "Product Details: " + product.ProductName;

        lblID.Text = productID.ToString();
        txtSku.Text = product.Sku;
        txtProductName.Text = product.ProductName;
        lblProductName.Text = product.ProductName;
        txtShortDescription.Text = product.ShortDescription;
        
        ddlManufacturerID.SelectedValue = product.ManufacturerID.ToString();
        ddlStatusID.SelectedValue = Convert.ToInt16(product.Status).ToString();
        ddlProductTypeID.SelectedValue = Convert.ToInt16(product.ProductType).ToString();
        ddlShippingTypeID.SelectedValue = Convert.ToInt16(product.ShippingType).ToString();
        ddlShipEstimateID.SelectedValue = product.ShipEstimateID.ToString();
        ddlTaxTypeID.SelectedValue = product.TaxTypeID.ToString();
        
        txtStockLocation.Text = product.StockLocation;
        product.OurPrice = Math.Round(product.OurPrice,2);
        product.RetailPrice = Math.Round(product.RetailPrice, 2);
       
        txtOurPrice.Text = product.OurPrice.ToString();
        txtRetailPrice.Text = product.RetailPrice.ToString();
        
        
        txtWeight.Text = product.Weight.ToString();
		ddlCurrencyCodeID.SelectedValue = product.CurrencyCode.ToString();
        txtUnitOfMeasure.Text = product.UnitOfMeasure;
        txtAdminComments.Text = product.AdminComments;
        txtLength.Text = product.Length.ToString();
        txtHeight.Text = product.Height.ToString();
        txtWidth.Text = product.Width.ToString();
        txtDimensionUnit.Text = product.DimensionUnit;
        txtListOrder.Text = product.ListOrder.ToString();
    }
    #endregion


    #region Event Handlers

    protected void btnCancel_Click(object sender, System.EventArgs e) {
			Response.Redirect(Request.Url.PathAndQuery, false);
    }


    protected void cmdAdd_Click(object sender, System.EventArgs e) {
        LoadAddForm();
    }
    protected void btnDelete_Click(object sender, EventArgs e) {
        //Commerce.Common.Product.Delete(int.Parse(lblID.Text));
        ProductController.DeletePermanent(int.Parse(lblID.Text));
				Response.Redirect("admin_products.aspx", false);
    }
    protected void btnSave_Click(object sender, System.EventArgs e) {

        Commerce.Common.Product product = null;
        if (lblID.Text != string.Empty)
        {
            product = new Commerce.Common.Product(int.Parse(lblID.Text));
        }
        else
        {
            product = new Commerce.Common.Product();
        }
        product.AdminComments = txtAdminComments.Text;
		product.CurrencyCode = ddlCurrencyCodeID.SelectedValue.Trim();
        product.DimensionUnit = txtDimensionUnit.Text;

        product.ProductName = txtProductName.Text;
        product.ShortDescription = txtShortDescription.Text;
        product.Sku = txtSku.Text;
        product.StockLocation = txtStockLocation.Text;
        product.Status = (ProductStatus)int.Parse(ddlStatusID.SelectedValue);
        product.ShippingType = (ShippingType)int.Parse(ddlShippingTypeID.SelectedValue);
        product.ProductType = (ProductType)int.Parse(ddlProductTypeID.SelectedValue);
        product.UnitOfMeasure = txtUnitOfMeasure.Text;
        product.ManufacturerID = int.Parse(ddlManufacturerID.SelectedValue);
        product.ShipEstimateID = int.Parse(ddlShipEstimateID.SelectedValue);
        product.TaxTypeID = int.Parse(ddlTaxTypeID.SelectedValue);

        int parsedInt = 0;
        decimal parsedDec = 0;

        int.TryParse(txtListOrder.Text, out parsedInt);
        product.ListOrder = parsedInt;

        decimal.TryParse(txtOurPrice.Text, out parsedDec);
        product.OurPrice = decimal.Parse(txtOurPrice.Text);

        decimal.TryParse(txtRetailPrice.Text, out parsedDec);
        product.RetailPrice = parsedDec;

        decimal.TryParse(txtHeight.Text, out parsedDec);
        product.Height = parsedDec;
        
        decimal.TryParse(txtLength.Text, out parsedDec);
        product.Length = parsedDec;
        
        decimal.TryParse(txtWeight.Text, out parsedDec);
        product.Weight = parsedDec;
        
        
        decimal.TryParse(txtWidth.Text, out parsedDec);
        product.Width = parsedDec;

        
        try {
            product.Save(Utility.GetUserName());
            ResultMessage1.ShowSuccess("Update Successful");
        } catch (Exception x) {
            ThrowError(x.Message);
        }

    }
    #endregion

    #region Error Handling
    void ThrowError(string message) {
        ResultMessage1.ShowFail(message);
    }


    #endregion


 
    protected void btnQuickMan_Click(object sender, EventArgs e) {
        if (txtQuickMan.Text.Trim() != string.Empty)
        {
            Lookups.QuickAdd("CSK_Store_Manufacturer", "manufacturer", txtQuickMan.Text);
            txtQuickMan.Text = "";
            this.LoadDropDowns();
            ddlManufacturerID.SelectedIndex = ddlManufacturerID.Items.Count - 1;

        }
    }

    
    void TogglePanelsOff()
    {
        pnlMain.Visible = false;
        pnlImages.Visible = false;
        pnlCross.Visible = false;
        pnlCategories.Visible = false;
        pnlCategories.Visible = false;
        pnlDescriptions.Visible = false;
        pnlAtts.Visible = false;
        pnlDiscount.Visible = false;
    }
    void TogglePanel(Panel pnl)
    {
        TogglePanelsOff();
        pnl.Visible = true;
    }
    protected void lnkMain_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlMain);
    }
    protected void lnkCat_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlCategories);

    }
    protected void lnkAtt_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlAtts);
       

    }
    protected void lnkImages_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlImages);

    }
    protected void lnkCross_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlCross);

    }
    protected void lnkDesc_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlDescriptions);
    }

    protected void lnkDiscount_Click(object sender, EventArgs e)
    {
        TogglePanel(pnlDiscount);
    }
}
