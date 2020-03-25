<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MiniCart.ascx.cs" Inherits="Modules_MiniCart" %>
<table>
<asp:Repeater ID="rptBasket" runat="server" OnItemCommand="DeleteItem">
    <ItemTemplate>
                
            <tr>
                <td><img src='<%#Eval("imageFile")%>'  width="40" /></td>
                <td>
                 <div class="smalltext"><b>Added on <%#DateTime.Parse(Eval("modifiedOn").ToString()).ToShortDateString() %></b></div>
                </td>
                <!--
                <td>
                <asp:ImageButton ID="imgRemove" runat="server" ImageUrl="~/images/icons/delete.gif" />
                </td>
                -->
            </tr>
            <tr>
                <td colspan="2">
                    <span class="defaultText">
                        <a href="LRProducts2.aspx"><%#Eval("productName") %></a>
                    </span>
                    <br />
                    <div class="ourprice">
                        <%#Eval("quantity") %> @ <%#decimal.Parse(Eval("pricePaid").ToString()).ToString("C") %>
                    </div>
                    <asp:Label ID="lblProductID" runat="server" Visible="false" Text='<%#Eval("productID") %>'></asp:Label>
                    <asp:Label ID="lblSelectedAtts" runat="server" Visible="false" Text='<%#Eval("attributes") %>'></asp:Label>
                                
                </td>
            </tr>

    </ItemTemplate>
</asp:Repeater>
</table>
<hr />
<div>
    <b><span class="defaultTextBlack">
        Subtotal: <asp:Label ID="lblSubtotal" runat="server"></asp:Label>
    </span></b>
</div>