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

public partial class Modules_MiniCart : System.Web.UI.UserControl
{
    protected Order currentOrder;
    protected void Page_Load(object sender, EventArgs e)
    {
        //currentOrder = OrderController.GetCurrentOrder();

				OrderItemCollection orderItemCollection = OrderController.GetCartItems();
				foreach(OrderItem currentItem in orderItemCollection) {
					if((currentItem.ImageFile == null) || (currentItem.ImageFile.Length == 0)) {
						currentItem.ImageFile = "images/ProductImages/no_image_available_small.gif";
					}
				}

				rptBasket.DataSource = orderItemCollection;
        rptBasket.DataBind();

        decimal dTotal = 0;
				foreach(OrderItem item in orderItemCollection)
        {
            dTotal += item.LineTotal;
        }

        lblSubtotal.Text = dTotal.ToString("c");
    }
    protected void DeleteItem(object sender, RepeaterCommandEventArgs e)
    {
        Label lblProductID = (Label)e.Item.FindControl("lblProductID");
        Label lblSelectedAtts = (Label)e.Item.FindControl("lblSelectedAtts");

        if (lblProductID != null && lblSelectedAtts!=null)
        {
            OrderController.RemoveItem(int.Parse(lblProductID.Text));
        }
				Response.Redirect("Basket.aspx", false);
    }
}
