<%@ Page Language="C#"  Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Orders_Details.aspx.cs" Inherits="Admin_Admin_Orders_Details" Title="Order Details" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<asp:ScriptManager runat="server" EnablePartialRendering="true" ID="scriptManager">
</asp:ScriptManager >

<div id="centercontent">
     <uc1:ResultMessage ID="uResult" runat="server" />
    <h4><a href="admin_orders.aspx">Orders >>> </a>Order Detail: 
    <asp:Label ID="lblOrderNumber" runat="server" ></asp:Label></h4>

<table style="border:1px solid gainsboro" cellspacing="0">
    <tr><td colspan="2" height="30" bgcolor="whitesmoke"><b>Status: <%=Utility.ParseCamelToProper(order.OrderStatus.ToString())%></b></td></tr>
    <tr>
        <td style="background-color:#ffffcc;height:20px" colspan="2"><b>Last Updated By:</b> <%=order.ModifiedBy %> </td>
    </tr>
    <tr>
        <td style="background-color:#ffffcc;height:20px" colspan="2"><b>Last Updated On:</b> <%=order.ModifiedOn %></td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr>
        <td width="50%" valign="top">
            <h5>Bill To:</h5>
            <table>
                <tr>
                    <td valign="top" style="height: 41px">
                    <%=Utility.ToggleHtmlBR(order.BillToAddress,true)%>
                    <br />
                    <b>Email:</b><br />
                    <a href="mailto:<%=order.Email %>"><%=order.Email %></a>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <b>Payment Method</b><br />
                    <%=order.Transactions[0].TransactionType %>
                    </td>
                </tr>                

                <tr>
                    <td>
                        <br />
                        <b>Transaction ID</b><br />
                        <%=order.Transactions[0].AuthorizationCode %>
                    </td>
                </tr>  
                <%if(!string.IsNullOrEmpty(order.CouponCodes)){ %>
                <tr>
                    <td><br />
                        <b>Coupon Used:</b><br />
                         <%=order.CouponCodes%>
                    </td>
                </tr>
                <%} %>             
            </table>
        </td>
        <td valign="top">
            <h5>Ship To:</h5>
             <table>
                    <tr>
                        <td style="width: 166px"><%=Utility.ToggleHtmlBR(order.ShipToAddress,true)%></td>
                    </tr>                   
                    <tr>
                        <td valign="top" style="width: 166px">
                        <br />
                        <b>Shipping Method</b><br />
                        <%=order.ShippingMethod.ToString()%>
                        <br />
                        <br />
                        <b>Shipping Phone</b>
                        <%=order.ShipPhone%>

                        </td>
                    </tr>  
                    <%if (order.ShippingTrackingNumber != string.Empty)
                      { %>
                    <tr>
                        <td>Tracking Number: <%= order.ShippingTrackingNumber%></td>
                    </tr>
                    
                    <%} %>
                    
                    <%if(OrderController.CanShip(order)){%>
                    <tr>
                        <td style="width: 166px"><b>Ship this order</b></td>
                    </tr>
                    <tr>
                        <td style="width: 166px">Enter a tracking number<br />
                            <asp:TextBox ID="txtTrackingNumber" runat="server" TextMode="MultiLine" Height="59px" Width="219px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 166px"><asp:Button ID="btnSetShipped" runat="server" Text="Ship it" OnClick="btnSetShipped_Click" />
                            
                        </td>
                    </tr>
                    <%}%>
                    <tr>
                        <td><uc1:ResultMessage ID="uShipResult" runat="server" /></td>
                    </tr>
            </table>
            
        </td>
    </tr>

    <tr>
        <td colspan="2">
        <h5>Items</h5>
        <%=order.ItemsToString(true) %>
        </td>
    </tr>
  
	<tr>
        <td colspan="2">
        <h5>Transactions</h5>
        <asp:GridView ID="gTransactions" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="TransactionDate" DataFormatString="{0:d}" HeaderText="Date" />
                <asp:BoundField DataField="Amount" DataFormatString="{0:c}" HeaderText="Amount" HtmlEncode="False" />
                <asp:BoundField DataField="TransactionType" HeaderText="Type" />
            </Columns>
        </asp:GridView>
        
        <%if (OrderController.CanRefund(order))
          { %>
        <br />
        <asp:Button ID="btnRefund" runat="server" Text="Refund Transaction" OnClick="btnRefund_Click1"/><br />
        <span class="smalltext">
        You can refund this order and the user's credit card will be refunded.
            <uc1:ResultMessage ID="uResultRefund" runat="server" />
        </span>
        <%} %>
        </td>
    </tr>

	<tr>
        <td colspan="2">
        <asp:UpdatePanel ID="WizUpdatePanel" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>  

        <h5>Notes</h5>
        <asp:GridView ID="gNotes" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="createdOn" DataFormatString="{0:d}" HeaderText="Date" />
                <asp:BoundField DataField="Note" HeaderText="Note" />
                <asp:BoundField DataField="OrderStatus" HeaderText="Status" />
            </Columns>

        </asp:GridView>
        <br />
        <b>Add a Note:</b><br />
            <asp:TextBox ID="txtAddNote" runat="server" TextMode="MultiLine" Height="84px" Width="208px"></asp:TextBox><br />
            <asp:Button ID="btnAddNote" runat="server" Text="Add" OnClick="btnAddNote_Click1" />
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="uProgress" runat="server">
            <ProgressTemplate>
            <div style="width:500px;text-align:center">
                <img src="../images/spinner.gif" align="absmiddle"/>Loading...
            </div>
            </ProgressTemplate>
         </asp:UpdateProgress> 

        </td>
    </tr>
    <%if (OrderController.CanCancel(order))
      { %>
    <tr>
        <td>
        <h5>Order Cancellation</h5>
        You can cancel this order if needed by clicking on the button below.
        Please be sure to enter a reason why this order was cancelled.
        <br /><br />
         <asp:TextBox ID="txtCancelReason" runat="server" TextMode="MultiLine" Height="84px" Width="208px"></asp:TextBox><br />
         <asp:Button ID="btnCancelOrder" runat="server" Text="Cancel Order" OnClick="btnCancelOrder_Click1" />
         <asp:CheckBox ID="chkRefundCancelledOrder" runat="server" Text="Issue Refund?" />
            <br />
            </td>
    </tr>
    <%} %>
    <tr>
        <td>
            <h5>Overrides</h5>
            Change status to:
            <asp:DropDownList ID="ddlStatusID" runat="server">
            </asp:DropDownList>
            <asp:Button ID="btnSetStatus" runat="server" OnClick="btnSetStatus_Click" Text="Set" />
            <asp:Label ID="lblOrderID" runat="server" Visible="False"></asp:Label>
            <uc1:ResultMessage ID="uResStatus" runat="server" />


        </td>
    </tr>
</table>
</div>
<script type="text/ecmascript" >
function CheckRefund(){
		
	return confirm("Refund this transaction? This action cannot be undone...");

}</script>
<br />
<br />
</asp:Content>


