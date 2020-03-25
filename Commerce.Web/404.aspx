<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="404.aspx.cs" Inherits="_404" Title="Untitled Page" %>

<%@ Register Src="Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc6" %>
<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>
<%@ Register Src="Modules/RecentCategories.ascx" TagName="RecentCategories" TagPrefix="uc2" %>
<%@ Register Src="Modules/RecentProductsViewed.ascx" TagName="RecentProductsViewed"
    TagPrefix="uc3" %>
<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc1" %>
<%@ Register Src="Modules/Products/ProductSummaryDisplay.ascx" TagName="ProductSummaryDisplay" TagPrefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div id="leftcontent">
        <uc6:MainNavigation ID="MainNavigation1" runat="server" />
    </div>
    <div id="centercontent"> 
    <h4>Oops! The Page you are looking for doesn't exist!</h4>
    
    
    <br />
    <uc5:Paragraph ID="Paragraph1" runat="server" ContentName="404Middle"/>
    <br />
        <asp:DataList ID="dtProducts" runat="server"  RepeatColumns="3" RepeatDirection="Horizontal">
    <ItemTemplate>
    <uc1:ProductSummaryDisplay ID="ProductSummaryDisplay1" runat="server" 
        ProductName='<%#Eval("ProductName") %>'
        ImageFile='<%#Eval("ImageFile") %>'
        ProductID='<%#Eval("ProductID") %>'
        OurPrice='<%#Eval("OurPrice") %>'
        RetailPrice='<%#Eval("RetailPrice") %>'
        ShippingEstimate='<%#Eval("ShippingEstimate") %>'
        Rating='<%#Eval("Rating") %>'
        SKU='<%#Eval("SKU") %>'
   />
    </ItemTemplate>
    </asp:DataList>

    </div> 
    <div id="rightcontent">
        <uc4:AdContainer id="AdContainer1" runat="server" BoxPlacement="Right" >
        </uc4:AdContainer>
    </div>

</asp:Content>

