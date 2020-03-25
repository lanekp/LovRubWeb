<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentProductsViewed.ascx.cs" Inherits="Modules_RecentProductsViewed" %>

<!-- Recent Product Viewed -->
<asp:Panel ID="pnlProd" runat="server">
<div class="browsebox">
<asp:Image ID="imgRecentHeader" runat="server" SkinID="HeadersRecentProducts" />
<table cellpadding="1" cellspacing="1">
<asp:Repeater ID="rptRecentProds" runat="server">
    <ItemTemplate>
    <tr>
        <td>
            <img src="<%#GetImagePath(Eval("defaultImage")) %>" width="40"/>
        </td>
        <td>
            <div><a class="smalltext" href="<%#Utility.GetRewriterUrl("product",Eval("productGUID").ToString(),"") %>">
            <%#Eval("productName") %></a></div>
        </td>
    </tr>
    </ItemTemplate>
</asp:Repeater>
</table>
</div>
</asp:Panel>
<!-- End Recent Product Viewed -->