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

public partial class Modules_Products_ProductTopDisplay : System.Web.UI.UserControl
{
    public Commerce.Common.Product product;
    // Change for Volume Discount
    //protected ProductDiscount discount;
    public ProductDiscount discount;

    private Commerce.Common.Attributes selectedAttributes;

    public Commerce.Common.Attributes SelectedAttributes
    {
        get { return attList.SelectedAttributes; }
    }
	

    protected void Page_Load(object sender, EventArgs e)
    {
        pRating.DisplayValue = (double)product.Rating;

        if (product != null)
        {
            // Change for Volume Discount
            //discount = PromotionService.SetProductPricing(product);
            attList.Product = product;
        }
        attList.Product = product;

    }

}
