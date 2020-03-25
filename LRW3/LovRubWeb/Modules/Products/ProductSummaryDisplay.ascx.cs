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

public partial class Modules_ProductSummaryDisplay : System.Web.UI.UserControl
{

    public string ProductName;
    public string SKU;
    public string ProductID;
    public string ShortDescription;
    public string Features;
    public decimal OurPrice;
    public decimal RetailPrice;
    public string ImageFile;
    public string ShippingEstimate;
    public string Rating;
		public string ProductGUID;

    protected void Page_Load(object sender, EventArgs e)
    {
        sr1.DisplayValue = Convert.ToDouble(Rating);
    }

    protected decimal GetDiscountedPrice()
    {
        decimal dOut=OurPrice;
        
        //get the adjusted price from the Promo service
        ProductDiscount discount = PromotionService.GetProductDiscount(int.Parse(ProductID));

        if (discount != null)
            dOut = discount.DiscountedPrice;

        return dOut;
           
    }
    protected void AddToCart_Click(object sender, ImageClickEventArgs e)
    {
        Commerce.Common.Product prod = new Commerce.Common.Product(ProductID);
        prod.Quantity = 1;
        OrderController.AddItem(prod);
				Response.Redirect("~/AddItemResult.aspx", false);
    }
}
