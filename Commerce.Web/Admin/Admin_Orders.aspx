<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Orders.aspx.cs" Inherits="Admin_Admin_Orders" Title="Orders Administration" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
    <div id="centercontent">

        <h4>Orders</h4>
        <table>
            <tr>
                <td class="adminlabel">
                    User Name</td>
                <td class="adminitem">
                <asp:TextBox ID="txtName" runat="server" Width="160px"></asp:TextBox>
                </td>
           </tr>
            <tr>
                <td class="adminlabel">
                    Order Number</td>
                <td class="adminitem">
                    <asp:TextBox ID="txtOrderNumber" runat="server" Width="160px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="adminlabel" valign="top">Date Range</td>
                <td class="adminitem">
                    Between<br />
                    <ew:calendarpopup id="calStart" runat="server"></ew:calendarpopup>
                    <br />
                    And<br />
                    <ew:calendarpopup id="calEnd" runat="server"></ew:calendarpopup>
                    &nbsp;<br />
                
                </td>
           </tr>
           <tr>
                <td colspan="2"><asp:Button ID="btnDates" runat="server" Text="Go" OnClick="btnDates_Click" CssClass="frmbutton" /></td>
           </tr>
        </table>
            
            
        <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <a href='admin_orders_details.aspx?id=<%# Eval("orderID") %>'>View Order</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="orderDate" HeaderText="Date" />
                <asp:BoundField DataField="firstName" HeaderText="First" />
                <asp:BoundField DataField="lastName" HeaderText="Last" />
                <asp:BoundField DataField="orderStatus" HeaderText="Status" />
                <asp:BoundField DataField="subtotalAmount" DataFormatString="{0:c}" HeaderText="Subtotal"
                    HtmlEncode="False" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                <asp:BoundField DataField="taxAmount" DataFormatString="{0:c}" HeaderText="Tax"
                    HtmlEncode="False" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                <asp:BoundField DataField="shippingAmount" DataFormatString="{0:c}" HeaderText="Shipping"
                    HtmlEncode="False" ><ItemStyle HorizontalAlign="Right" /></asp:BoundField>
                <asp:BoundField DataField="payments" DataFormatString="{0:c}" HeaderText="Payments"   HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>

</div>
</asp:Content>

