<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="MyOrders.aspx.cs" Inherits="MyOrders" Title="My Orders" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>
<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/RecentCategories.ascx" TagName="RecentCategories" TagPrefix="uc2" %>
<%@ Register Src="Modules/RecentProductsViewed.ascx" TagName="RecentProductsViewed"
    TagPrefix="uc3" %>

<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="leftcontent">
    <%if (RecentCategories1.GetCount() > 0 && RecentProductsViewed1.GetCount() > 0)  { %>
        <uc3:RecentProductsViewed ID="RecentProductsViewed1" runat="server" />
    <br />
        <uc2:RecentCategories ID="RecentCategories1" runat="server" />
    <%} %>
    <br />
    <uc1:CatalogList id="CatalogList1" runat="server">
    </uc1:CatalogList>
    </div>
    <div id="centercontent"> 

        <h4>My Orders</h4>
        <uc5:Paragraph ID="Paragraph1" runat="server" ContentName="MyOrdersTop"/>
        <br />
        <table >
            <tr class="sectionheader">
                <td>Order Number</td>
                <td>Date</td>
                <td align="right">Amount</td>
            </tr>
            <asp:Repeater ID="rptMyOrders" runat="server">
                <ItemTemplate>
            <tr class="plainbox">
											<td><a class="sidemenulink" href="receipt.aspx?t=<%# Eval("orderGUID") %>"><%# Eval("orderNumber")%></a></td>
                <td><%# Eval("orderDate") %></td>
											<td align="right"><%# Convert.ToDouble(Eval("orderTotal")).ToString("c")%></td>
               
            </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div id="rightcontent">
        <uc4:AdContainer id="AdContainer1" runat="server" BoxPlacement="Right" >
        </uc4:AdContainer>
    </div>
</asp:Content>

