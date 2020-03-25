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

public partial class Admin_Admin_Orders_Details : System.Web.UI.Page {
  protected Commerce.Common.Order order;

  protected void Page_Load(object sender, EventArgs e) {

    if (!Page.IsPostBack) {
      LoadOrder();
      if (order != null) {
        this.Page.Title = "Order Details: " + order.OrderNumber;
      }
      else {
        lblOrderNumber.Text = "Invalid Order";
      }
    }

  }
  void LoadOrder() {
    int orderID = Utility.GetIntParameter("id");
    if (orderID != 0) {
      order = OrderController.GetOrder(orderID);

      gTransactions.DataSource = order.Transactions;
      gTransactions.DataBind();
      LoadNotes();
      LoadDropDowns();
      lblOrderID.Text = order.OrderID.ToString();
      lblOrderNumber.Text = order.OrderNumber;
    }
  }
  void LoadNotes() {
    gNotes.DataSource = order.Notes;
    gNotes.DataBind();
  }
  void LoadDropDowns() {
    Utility.LoadListItems(ddlStatusID.Items, Lookups.GetList("CSK_Store_OrderStatus"),
        "OrderStatus", "orderStatusID", Convert.ToInt16(order.OrderStatus).ToString(), true);
  }
  protected void btnSetShipped_Click(object sender, EventArgs e) {
    if (txtTrackingNumber.Text.Trim().Length > 0) {
      try {
        LoadOrder();
        order.OrderStatus = OrderStatus.ShippedToCustomer;
        order.ShippingTrackingNumber = txtTrackingNumber.Text.Trim();
        order.Save(Utility.GetUserName());
        uShipResult.ShowSuccess("Order Set as shipped. Your customer will receive an email notifying them of the shipment.");
      }
      catch (Exception x) {
        uResult.ShowFail(x.Message);
      }
    }
    //reload the order. Hate to call it twice but there's not much we can
    //do bout that.
    LoadOrder();
    MessagingController.SendShippingNotification_Customer(order);
  }
  protected void btnRefund_Click(object sender, EventArgs e) {

  }
  protected void btnAddNote_Click(object sender, EventArgs e) {

  }
  protected void btnCancelOrder_Click(object sender, EventArgs e) {

  }
  protected void btnSetStatus_Click(object sender, EventArgs e) {
    int statusID = int.Parse(ddlStatusID.SelectedValue);
    LoadOrder();
    order.OrderStatus = (OrderStatus)statusID;
    order.Save(Utility.GetUserName());
    Response.Redirect(Request.Url.PathAndQuery, false);
  }
  protected void btnAddNote_Click1(object sender, EventArgs e) {
    if (txtAddNote.Text.Trim().Length > 0) {
      try {
        OrderNote note = new OrderNote();
        note.OrderID = int.Parse(lblOrderID.Text);
        note.OrderStatus = ddlStatusID.SelectedItem.Text;
        note.Note = txtAddNote.Text;
        note.Save(Utility.GetUserName());
        LoadOrder();
        txtAddNote.Text = string.Empty;
      }
      catch (Exception ex) {
        uResult.ShowFail(ex.Message);
      }
    }
  }
  void RefundOrder() {
    bool haveError = false;
    if (order == null)
      LoadOrder();

    try {
      OrderController.Refund(order);
      uResultRefund.ShowSuccess("Order Refunded");
    }
    catch (Exception x) {
      uResultRefund.ShowFail(x.Message);
    }

    if (!haveError) {
      LoadOrder();
      MessagingController.SendOrderRefund_Customer(order);
    }

  }
  protected void btnCancelOrder_Click1(object sender, EventArgs e) {
    LoadOrder();
    OrderController.CancelOrder(order, txtCancelReason.Text);
    MessagingController.SendOrderCancellation_Customer(order);
    if (chkRefundCancelledOrder.Checked) {
      //refund the order
      RefundOrder();
    }
    Response.Redirect(Request.Url.PathAndQuery, false);
  }
  protected void btnRefund_Click1(object sender, EventArgs e) {
    RefundOrder();
  }
}
