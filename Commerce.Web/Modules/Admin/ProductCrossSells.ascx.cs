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

public partial class Modules_Admin_ProductCrossSells : System.Web.UI.UserControl {
    protected void Page_Load(object sender, EventArgs e) {

    }

    void LoadProductList(int productID)
    {

        //grab all the products
        ProductCollection prods = ProductController.GetAll();
        ListItem item;
        foreach (Product prod in prods)
        {
					if((prod.DefaultImage == null) || (prod.DefaultImage.Trim().Length == 0)) {
                        item = new ListItem("<img src='" + Page.ResolveUrl("~/images/productimages/no_image_available.gif") + "'  width=50><br><b>" + prod.Sku + "</b>", prod.ProductID.ToString());
					}
					else {
						item = new ListItem("<img src='" + Page.ResolveUrl("../" + prod.DefaultImage) + "' width=50><br><b>" + prod.Sku + "</b>", prod.ProductID.ToString());
					}
            chkProducts.Items.Add(item);
        }

        //now load the cross-products for this product, and check off the
        //bits
        ProductCollection crosses = PromotionService.GetCrossSells(productID);
        foreach (Product cross in crosses)
        {
            foreach (ListItem l in chkProducts.Items)
            {
                if (int.Parse(l.Value) == cross.ProductID)
                    l.Selected = true;
            }
        }

    }


    public void LoadCrossProducts(int productID) {
        lblID.Text = productID.ToString();
        LoadProductList(productID);
    }
    protected void SaveCrossList(object sender, EventArgs e) {
        //first, remove all the cross-sell bits
        int productID=Utility.GetIntParameter("id");
        Product prod = new Product(productID);
        try
        {
            //prod.SaveManyToMany("CSK_Promo_Product_CrossSell_Map", "crossProductID", chkProducts.Items);
            //Utility.SaveManyToMany("CSK_Store_Product", "productID", "CSK_Promo_Product_CrossSell_Map", "crossProductID", chkProducts.Items);
            Utility.SaveManyToMany("productID", productID, "CSK_Promo_Product_CrossSell_Map", "crossProductID", chkProducts.Items);
            ResultMessage1.ShowSuccess("Cross-Sells saved");
            }
        catch (Exception x)
        {
            ResultMessage1.ShowFail(x.Message);

        }
    }
}
