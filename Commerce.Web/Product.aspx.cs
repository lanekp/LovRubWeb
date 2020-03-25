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
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Commerce.Common;
using Commerce.Promotions;

public partial class _Product : System.Web.UI.Page {

	protected int productID;
	protected string productSku;
	protected Guid productGUID;

    /////////////////////////////////
    // Change for QtyDiscount
    //private Commerce.Common.Product product = null;
    protected Commerce.Common.Product product = null;
    /////////////////////////////////

	protected ProductDiscount discount;

	protected void Page_Load(object sender, EventArgs e) {

		//###############################################################################
		//  Page Validators - these must be implemented or they will be redirected
		//###############################################################################
		try {
            string sProductGUID = Utility.GetParameter("guid");
            productID = Utility.GetIntParameter("id");
			productSku = Utility.GetParameter("n");

            if (sProductGUID != string.Empty) {
                productGUID = new Guid(sProductGUID);
				product = ProductController.GetProductDeepByGUID(productGUID);
			}else if(productID != 0) {
				product = ProductController.GetProductDeep(productID);
			}
			else if(productSku != string.Empty) {
				product = ProductController.GetProductDeep(productSku);
			}

			//make sure we have a product
			TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

			//set the page variables
			productID = product.ProductID;
			productSku = product.Sku;
		}
		catch(Exception ex) {

            //throw ex;
            //ExceptionPolicy.HandleException(ex, "Application Exception");
			Response.Redirect(Page.ResolveUrl("~/ExceptionPage.aspx"), false);
		}
		//##############################################################################

		//load the product ratings

		BindProductInfo();
		//TickStats(); KPL
	}

	void BindProductInfo() {
        /////////////////////////////////
        // Change for QtyDiscount
        discount = PromotionService.SetProductPricing(product);
        ProductTopDisplay1.discount = discount;
        /////////////////////////////////

		ProductTopDisplay1.product = product;

		//set the ratings
		//this was passed in 

		BundleDisplay1.product = product;
		ReviewDisplay1.product = product;
		FeedBackDisplay1.ProductID = product.ProductID;
		FeedBackDisplay1.ProductName = product.ProductName;
		FeedBackDisplay1.InitialRating = Convert.ToDouble(product.Rating);
		ProductDescriptorDisplay1.DescriptorList = product.Descriptors;
		this.Title = product.ProductName;

        /////////////////////////////////
        // Change for QtyDiscount
        this.QtyDiscountDisplay();
	}

	void TickStats() {
		//track this
		Commerce.Stats.Tracker.Add(Commerce.Stats.BehaviorType.BrowsingProduct, product.Sku);
	}

	protected decimal ParseAdjustedPrice(string selection) {
		decimal dOut = 0;
		string sOut = "";

		//This will be redone  for 2.0 Release. It's Kantona's fault.

		if(selection.IndexOf("(add") > 0 || selection.IndexOf("(subtract") > 0) {
			sOut = selection.Substring(selection.IndexOf("("), selection.IndexOf(")") - selection.IndexOf("("));
			sOut = sOut.Replace("(", "").Replace(")", "").Trim().Replace("add", "").Replace("subtract", "");

			//strip the currency symbol
			sOut = sOut.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "");

			//thanks to Jon_ProLogic for this :)
			decimal.TryParse(sOut, out dOut);
			if(selection.IndexOf("subtract") > 0)
				dOut = 0 - dOut;
		}
		return dOut;
	}
	
	protected void AddToCart_Click(object sender, EventArgs e) {

		if(txtAddQty.Text != string.Empty) {
			int qty = 0;
			int.TryParse(txtAddQty.Text, out qty);
			if(qty > 0) {
				try {

					string promoCode = "";

					//add the item to the current order and redirect them to
					//the add page
					product.Quantity = int.Parse(txtAddQty.Text);
					//product.SelectedAttributes=selectedAtts;
					product.PromoCode = promoCode;

					//pull the atribute selection from the User Control "ProductTopDisplay"
					//which in turn pulls the bits from ProductAttributeDisplay.
					product.SelectedAttributes = ProductTopDisplay1.SelectedAttributes;
          decimal savedDiscountPrice = 0;
					if(product.SelectedAttributes != null) {
						//if there is a price adjustment
						//apply it here. It's possible that they could have chosen multiple adjustments
						//so.... just add them up!
						foreach(Commerce.Common.Attribute att in product.SelectedAttributes) {
							foreach(AttributeSelection sel in att.Selections) {
                if(sel.PriceAdjustment != 0)
                  savedDiscountPrice += savedDiscountPrice = -sel.PriceAdjustment;
							}
						}
					}
          product.DiscountAmount = savedDiscountPrice;
					OrderController.AddItem(product);

					//This behavior is by design 
					//See http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemwebhttpresponseclassendtopic.asp
					Response.Redirect("additemresult.aspx", false);

				}
				catch(Exception ex) {
          if(ExceptionPolicy.HandleException(ex, "Application Exception")) {
            throw;
          }
				}
			}
		}
	}

    /////////////////////////////////
    // Change for QtyDiscount
    private void QtyDiscountDisplay()
    {
        QtyDiscountCollection discounts = QtyDiscountCollection.GetByProductID(product.ProductID);
        if (discounts.Count > 0)
        {
            System.Text.StringBuilder display = new System.Text.StringBuilder();
            System.Text.StringBuilder format = new System.Text.StringBuilder();

            format.AppendLine("<tr>");
            format.AppendLine("    <td bgcolor=\"#F1F1F1\" style=\"padding:6px; border-bottom:1px solid #cccccc; border-right:1px solid #cccccc;\">{0}+</td>");
            format.AppendLine("    <td bgcolor=\"whitesmoke\" style=\"padding:6px; border-bottom:1px solid #cccccc; border-right:1px solid #cccccc;\">{1}{2}</td>");
            format.AppendLine("    <td class=\"price\" style=\"padding:6px; border-bottom:1px solid #cccccc; text-align:right;\"><b>{3}</b></td>");
            format.AppendLine("</tr>");

            string rowFormat = format.ToString();
            foreach (QtyDiscount disc in discounts)
            {
                if (disc.IsActive)
                {
                    if (disc.IsPercent)
                    {
                        if (disc.Discount > (100 * product.YouSavePercent))
                        {
                            decimal priceWithQtyDiscount = decimal.Round(product.RetailPrice * ((100 - disc.Discount) / 100), 2, MidpointRounding.ToEven);
                            display.AppendFormat(rowFormat, disc.Quantity.ToString(), disc.Discount.ToString(), "%", priceWithQtyDiscount.ToString("c"));
                        }
                    }
                    else
                    {
                        if (disc.Discount > product.YouSavePrice)
                        {
                            decimal priceWithQtyDiscount = decimal.Round(product.RetailPrice - disc.Discount, 2);
                            display.AppendFormat(rowFormat, disc.Quantity.ToString() , "-" + disc.Discount.ToString(), "$", priceWithQtyDiscount.ToString("c"));
                        }
                    }
                }
            }

            if (display.Length > 0)
            {
                pnlQtyDiscounts.Visible = true;
                litQtyDiscounts.Text = display.ToString();
            }
        }
    }
    /////////////////////////////////
}