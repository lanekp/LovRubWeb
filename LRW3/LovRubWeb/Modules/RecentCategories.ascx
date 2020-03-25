<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecentCategories.ascx.cs" Inherits="Modules_RecentCategories" %>
<!-- Recent Categories -->
<asp:Panel ID="pnlCats" runat="server">
<div class="browsebox">
<asp:Image ID="imgRecentHeader" runat="server" SkinID="HeadersRecentCategories" />
<br />   
<asp:Repeater ID="rptRecentCats" runat="server">
    <ItemTemplate>
        <div>
        <a href="<%#Utility.GetRewriterUrl("catalog",Eval("categoryGUID").ToString(),"") %>" class="subcategory"><%#Eval("categoryName")%></a><br/>
        </div>
    </ItemTemplate>
</asp:Repeater>
</div>
</asp:Panel>
<!-- End Recent Categories -->
