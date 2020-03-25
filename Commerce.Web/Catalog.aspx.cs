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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

public partial class Catalog : System.Web.UI.Page
{
    protected string thisLink = "";
    protected string categoryName = "";
    protected int categoryID = 0;
	protected string categoryGUID = string.Empty;
    DataSet ds = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        
        //this page can be accessed using a CategoryID (cid)
        //or by categoryName using the UrlRewriter

        categoryID = Utility.GetIntParameter("cid");
        categoryName = Utility.GetParameter("n");
		categoryGUID = Utility.GetParameter("guid");
        
        if (!Page.IsPostBack)
            LoadData();
        

        //###############################################################################
        //  Page Validators - these must be implemented or they will be redirected
        //###############################################################################
        try
        {
            TestCondition.IsTrue(ds.Tables.Count == 6, "Invalid Query");
            TestCondition.IsTrue(ds.Tables[0].Rows.Count > 0, "Invalid Query");
        }
        catch(Exception ex)
        {
			ExceptionPolicy.HandleException(ex, "Application Exception");
			Response.Redirect(Page.ResolveUrl("~/ExceptionPage.aspx"), false);
        }
        //##############################################################################

        //track this
        LoadPage();
        //TickStats(); KPL 



    }
    void TickStats()
    {
        //add to viewer
        Commerce.Stats.Tracker.Add(Commerce.Stats.BehaviorType.BrowsingCategory, categoryID);

    }

    void LoadData()
    {
        //this page will bounce if the dataset didn't fire properly

        if (categoryName != string.Empty)
        {
            ds = CategoryController.GetPageByName(categoryName);
            thisLink = Page.ResolveUrl("~/catalog/" + categoryName + ".aspx");
        }
        else if (categoryID != 0)
        {
            ds = CategoryController.GetPageByID(categoryID);

        }
		else if(categoryGUID != string.Empty) {
			ds = CategoryController.GetPageByGUID(categoryGUID);
            thisLink = Page.ResolveUrl("~/catalog/" + categoryGUID + ".aspx");
        }

    }

    void LoadPage()
    {
        if (ds != null) {
            categoryID = (int)ds.Tables[0].Rows[0]["categoryID"];
            categoryName = ds.Tables[0].Rows[0]["categoryName"].ToString();

            BindCategoryInfo();
            BindProductList();
            BindSubs();
            BindPriceList();
            BindManList();
            LoadCrumbs();
        }

    }
    void BindCategoryInfo()
    {
        Category category = new Category();
        category.Load(ds.Tables[0]);

        lblSubHead.Text = category.CategoryName;

        if (category.ImageFile != string.Empty)
        {
            imgHead.ImageUrl = category.ImageFile;
        }
        else
        {
            imgHead.Visible = false;
        }
        lblDescription.Text = category.LongDescription;

    }
    void BindProductList()
    {
        
        //the product list is effected by 2 things
        //if it's a straight cateogry view or
        //a "Narrow By" view
        int manID = Utility.GetIntParameter("m");
        string sPriceStart = Utility.GetParameter("ps");
        string sPriceEnd = Utility.GetParameter("pe");
        decimal priceStart = 0;
        decimal priceEnd = 0;

        if (sPriceStart != string.Empty)
            priceStart = decimal.Parse(sPriceStart);


        if (sPriceEnd != string.Empty)
            priceEnd = decimal.Parse(sPriceEnd);

        //if the manufacturer or the price range was sent in
        //grab the reader and use it to populate the product list
        if (manID > 0)
        {
            dtProducts.DataSource = ProductController.GetByManufacturerID(categoryID,manID);
        }
        else if (priceStart >= 0 && priceEnd > 0)
        {

            dtProducts.DataSource = ProductController.GetByPriceRange(categoryID, priceStart, priceEnd);

        }
        else
        {
            dtProducts.DataSource = ds.Tables[4];

        }


        dtProducts.DataBind();
    }
    void BindSubs()
    {
        rptSubs.DataSource = ds.Tables[1];
        rptSubs.DataBind();

    }
    void BindPriceList()
    {
        rptPriceRanges.DataSource = ds.Tables[3];
        rptPriceRanges.DataBind();

    }
    void BindManList(){
                
        rptManList.DataSource = ds.Tables[2];
        rptManList.DataBind();
    }
    void LoadCrumbs()
    {
        DataRow dr;
        int lastCount = 0;
        for (int i = 0; i < ds.Tables[5].Rows.Count - 1; i++)
        {
            dr = ds.Tables[5].Rows[i];
            //lblBreadCrumb.Text += " <a href='" + Page.ResolveUrl("~/catalog/") + dr["Category"].ToString() + ".aspx'>" + dr["Category"] + "</a> >>> ";
            lblBreadCrumb.Text += " <a href='" + Utility.GetRewriterUrl("catalog", dr["CategoryGUID"].ToString(), "") + "'>" + dr["Category"] + "</a> >>> ";
            lastCount++;

        }
        lblBreadCrumb.Text += ds.Tables[5].Rows[lastCount]["Category"].ToString();

    }
}
