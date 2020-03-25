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
using System.Collections.Generic;

public partial class Modules_Products_BundleDisplay : System.Web.UI.UserControl
{

    public Commerce.Common.Product product;
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void AddBundle(object sender, EventArgs e)
    {
        decimal discountPercent = 0;
        decimal discountAmount = 0;
        decimal price = 0;
        int productID = 0;
        int bundleID = 0;
        Commerce.Common.Product prod = null;
        List<BundleItem> list=PromotionService.GetBundleByProduct(product.ProductID);

        foreach (Commerce.Promotions.BundleItem bundleItem in list)
        {
            discountPercent = Convert.ToDecimal(bundleItem.DiscountPercent);
            price = bundleItem.OurPrice;
            discountAmount = price * discountPercent / 100;
            productID = bundleItem.ProductID;
            bundleID = bundleItem.BundleID;
            
            prod = new Commerce.Common.Product(productID);
            prod.ImageFile = prod.DefaultImage;
            prod.Quantity = 1;
            prod.DiscountAmount = discountAmount;
            prod.PromoCode = "BUNDLE:" + bundleID.ToString();
            OrderController.AddItem(prod);
        }
				Response.Redirect("additemresult.aspx", false);

    }
    protected List<BundleItem> GetBundle()
    {
        //get the bundles from the PromoService
        return PromotionService.GetBundleByProduct(product.ProductID);
    }

}
