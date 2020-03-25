<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="MyAccount.aspx.cs"
    Inherits="MyAccount" Title="My Account" %>
<%@ Register Src="~/Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="~/Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc1" %>
<%@ Register Src="~/Modules/AddressEdit.ascx" TagName="AddressEdit" TagPrefix="uc2" %>
<%@ Register Src="~/Modules/ManageUser.ascx" TagName="UserManager" TagPrefix="uc3" %>
<%@ Register Src="Modules/RecentCategories.ascx" TagName="RecentCategories" TagPrefix="uc7" %>
<%@ Register Src="Modules/RecentProductsViewed.ascx" TagName="RecentProductsViewed"
    TagPrefix="uc8" %>

<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc9" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="leftcontent">
    <%if (RecentCategories1.GetCount() > 0 && RecentProductsViewed1.GetCount() > 0)  { %>
        <uc8:RecentProductsViewed ID="RecentProductsViewed1" runat="server" />
    <br />
        <uc7:RecentCategories ID="RecentCategories1" runat="server" />
    <%} %>
    <br />
    <uc9:CatalogList id="CatalogList1" runat="server" />
    </div>
    <div id="centercontent"> 
    <div class="box">
        <h2>
            My Account</h2>
        <uc5:Paragraph ID="Paragraph1" runat="server" ContentName="MyAccountTop" />
        <uc3:UserManager ID="ManageUser" runat="server" />
    </div>
    <div class="spacer">
        &nbsp;</div>
    <div class="box">
    <h2>Order History</h2>
    <asp:HyperLink runat="server" ID="lnkGotoOrders" NavigateUrl="~/myorders.aspx" Text="Click here to view your order history" />
    </div>
    <div class="spacer">
        &nbsp;</div>
    <div class="box">
        <uc2:AddressEdit ID="addShipping" runat="server" UseAddressBook="true" />
    </div>
    </div>
</asp:Content>
