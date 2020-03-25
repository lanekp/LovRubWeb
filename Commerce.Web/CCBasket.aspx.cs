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
using Commerce.PayPal;

public partial class CCBasket : System.Web.UI.Page {
  protected Order currentOrder = null;

  protected DataSet ds;
  
  protected void Page_Load(object sender, EventArgs e) 
  {
    pnlNada.Visible = false;
    if(!Page.IsPostBack) 
    {
      BindBasket();
    }
  }
  void BindBasket() {

    int orderID = OrderController.GetCartOrderID();
    //Order currentOrder = null;
    if(orderID != 0) 
    {
      currentOrder = OrderController.GetOrder(orderID);

      //Load up the no_image_available.gif image in the event there is no ImageFile
      OrderItemCollection orderItemCollection = currentOrder.Items;
      foreach(OrderItem currentItem in orderItemCollection) 
      {
        if((currentItem.ImageFile == null) || (currentItem.ImageFile.Length == 0)) 
        {
          currentItem.ImageFile = "images/ProductImages/no_image_available.gif";
        }
      }
      //Bind it up
      rptBasket.DataSource = currentOrder.Items;
      rptBasket.DataBind();

      if(rptBasket.Items.Count == 0)
        HideBits();

      lblSubtotal.Text = currentOrder.CalculateSubTotal().ToString("c");
        if (!SiteConfig.UsePayPalExpressCheckout) 
        {
            pnlExpressCheckout.Visible = false;
        }
    }
    else {
      HideBits();
    }

  }

  void rptBasket_ItemDataBound(object sender, RepeaterItemEventArgs e) {
    throw new Exception("The method or operation is not implemented.");

  }


  void HideBits() {
    //btnAdjust.Visible = false;
    pnlExpressCheckout.Visible = false;
    pnlCheckout.Visible = false;
    lblSubtotal.Visible = false;
    pnlNada.Visible = true;

    //give them something to look at, other than a blank page ;)
    dtProducts.DataSource = ProductController.GetMostPopular();
    dtProducts.DataBind();

  }
  protected void DeleteItem(object sender, RepeaterCommandEventArgs e) {

      string s2 = e.CommandName;
      if (s2.Equals("AdjustBasket"))
      {
          TextBox txtQ = null;
          Label lblProductID = null;
          Label lblSelectedAtts = null;
          int productID = 0;
          int newQuantity = 0;
          string selectedAtts = "";
          int orderID = OrderController.GetCartOrderID();

          foreach (RepeaterItem item in rptBasket.Items)
          {
              txtQ = (TextBox)item.FindControl("txtQuantity");
              lblSelectedAtts = (Label)item.FindControl("lblSelectedAtts");
              lblProductID = (Label)item.FindControl("lblProductID");
              if (txtQ != null && lblProductID != null)
              {
                  productID = int.Parse(lblProductID.Text);
                  if (int.TryParse(txtQ.Text, out newQuantity))
                  {
                      if (newQuantity > 0)
                      {
                          selectedAtts = lblSelectedAtts.Text;
                          OrderController.AdjustQuantity(orderID, productID, selectedAtts, newQuantity);
                      }
                      else
                      {
                          //OrderController.RemoveItem(productID, selectedAtts); // KPL 06/08/08
                          OrderController.RemoveCallCenterItem(productID, selectedAtts);
                      }
                  }
              }
          }
          Response.Redirect("CCBasket.aspx", false);
      }
      if (s2.Equals("DeleteButton"))
      {
          Label lblProductID = (Label)e.Item.FindControl("lblProductID");
          Label lblSelectedAtts = (Label)e.Item.FindControl("lblSelectedAtts");
          if (lblProductID != null && lblSelectedAtts != null)
          {
              //OrderController.RemoveItem(int.Parse(lblProductID.Text), lblSelectedAtts.Text);
              OrderController.RemoveCallCenterItem(int.Parse(lblProductID.Text), lblSelectedAtts.Text);
          }
          Response.Redirect("CCBasket.aspx", false);
      }

/*
    Label lblProductID = (Label)e.Item.FindControl("lblProductID");
    Label lblSelectedAtts = (Label)e.Item.FindControl("lblSelectedAtts");
    if(lblProductID != null && lblSelectedAtts != null) {
      OrderController.RemoveItem(int.Parse(lblProductID.Text), lblSelectedAtts.Text);
    }
    Response.Redirect("CCBasket.aspx", false);
 */
  }

    protected void AdjustBasket(object sender, ImageClickEventArgs e) {
    TextBox txtQ = null;
    Label lblProductID = null;
    Label lblSelectedAtts = null;
    int productID = 0;
    int newQuantity = 0;
    string selectedAtts = "";
    int orderID = OrderController.GetCartOrderID();

    foreach(RepeaterItem item in rptBasket.Items) {
      txtQ = (TextBox)item.FindControl("txtQuantity");
      lblSelectedAtts = (Label)item.FindControl("lblSelectedAtts");
      lblProductID = (Label)item.FindControl("lblProductID");
      if(txtQ != null && lblProductID != null) {
        productID = int.Parse(lblProductID.Text);
        if(int.TryParse(txtQ.Text, out newQuantity)) {
          if(newQuantity > 0) {
            selectedAtts = lblSelectedAtts.Text;
            OrderController.AdjustQuantity(orderID, productID, selectedAtts, newQuantity);
          }
          else {
            OrderController.RemoveItem(productID, selectedAtts);
          }
        }
      }
    }
    Response.Redirect("CCBasket.aspx", false);
  }

  protected void imgPayPal_Click(object sender, ImageClickEventArgs e) {
    SetExpressOrder();
  }
  void SetExpressOrder() {
    //use the API to get the SetCheckout response.
    //Then, redirect to PayPal
    //get the wrapper
    APIWrapper wrapper = GetPPWrapper();

    string sEmail = "";
    if(Profile.LastShippingAddress != null) {
      if(Profile.LastShippingAddress.Email != string.Empty) {
        sEmail = Profile.LastShippingAddress.Email;
      }
      else {
        MembershipUserCollection membershipUserCollection = Membership.FindUsersByName(Request.Cookies["shopperID"].Value);
        if(membershipUserCollection.Count > 0) {
          sEmail = membershipUserCollection[Request.Cookies["shopperID"].Value].Email;
        }
      }
    }

    //send them back here for all occassions
    string successURL = Utility.GetSiteRoot() + "/checkout.aspx";
    string failURL = Utility.GetSiteRoot() + "/default.aspx";

    currentOrder = GetCurrentOrder();
    if(currentOrder.Items.Count > 0) {
      string ppToken = wrapper.SetExpressCheckout(sEmail, currentOrder.CalculateSubTotal(),
        successURL, failURL, false, null);
      if(ppToken.ToLower().Contains("error")) {
        lblPPErr.Text = "PayPal has returned an error message: " + ppToken;
      }
      else {
        string sUrl = "https://www.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + ppToken;
        if(!SiteConfig.PayPalAPIIsLive) {
          sUrl = "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + ppToken;
        }

        try {
          Response.Redirect(sUrl, false);
        }
        catch(Exception x) 
        {
            LovRubLogger.LogException(x); // 04/10/08 KPL added
          ResultMessage1.ShowFail(x.Message);
        }
      }

    }
    else {
      Response.Redirect("CCBasket.aspx", false);
    }

  }

  APIWrapper GetPPWrapper() {
    APIWrapper wrapper =
      new APIWrapper(SiteConfig.PayPalAPIUserName, SiteConfig.PayPalAPIPassword,
      SiteConfig.PayPalAPISignature, SiteConfig.CurrencyCode, SiteConfig.PayPalAPIIsLive);
    return wrapper;
  }

  Order GetCurrentOrder() {
    Order result = null;
    if(ViewState["CurrentOrder"] != null) {
      result = (Order)ViewState["CurrentOrder"];
    }
    else {
      result = OrderController.GetCurrentOrder();
    }
    return result;
  }
}
