<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Catalog.aspx.cs" Inherits="Catalog" Title="Catalog" %>

<%@ Register Src="Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc4" %>
<%@ Register Src="Modules/Products/ProductSummaryDisplay.ascx" TagName="ProductSummaryDisplay" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="leftcontent">
    <uc4:MainNavigation ID="MainNavigation1" runat="server" />
    <div class="twentypixspacer"></div>
    <center>
        <a href="<%=Page.ResolveUrl("~/affiliatefeed.aspx") %>?catid=<%=categoryID.ToString()%>" target="_blank"><img src="<%=Page.ResolveUrl("images/rss.jpg") %>" /></a>
    
    </center>
</div> 
<div id="centercontentwide">
<h5><a href="<%=Page.ResolveUrl("~/default.aspx") %>">Home</a> >> <asp:Label ID="lblBreadCrumb" runat="server"></asp:Label>
</h5>
    <asp:Image ID="imgHead" runat="server" /><br />
    <asp:Label ID="lblDescription" runat="server"></asp:Label>
    <table width="100%" border="0">
        <tr>
            <td>
                <asp:DataList ID="dtProducts" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <uc1:ProductSummaryDisplay ID="ProductSummaryDisplay1" runat="server" ProductName='<%#Eval("ProductName") %>'
                            ImageFile='<%#Eval("ImageFile") %>' ProductID='<%#Eval("ProductID") %>' OurPrice='<%#Eval("OurPrice") %>'
                            RetailPrice='<%#Eval("RetailPrice") %>' ShippingEstimate='<%#Eval("ShippingEstimate") %>'
                            Rating='<%#Eval("Rating") %>' SKU='<%#Eval("SKU") %>' ProductGUID='<%#Eval("ProductGUID") %>' />
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td style="width:150px">
                <h5>
                    <asp:Label ID="lblSubHead" runat="server"></asp:Label></h5>
                <div>
                    <asp:Repeater ID="rptSubs" runat="server">
                        <ItemTemplate>
                            <!--
                
                  <a href="catalog.aspx?cid=<%#Eval("categoryid") %>" class="subcategory"><%#Eval("categoryName") %></a><br/>
                -->
                            <a href="<%#Utility.GetRewriterUrl("catalog", Eval("categoryGUID").ToString(),"") %>"
                                class="subcategory">
                                <%#Eval("categoryName") %>
                            </a>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <h5 class="shaded">
                    Narrow By Brand</h5>
                <div>
                    <asp:Repeater ID="rptManList" runat="server">
                        <ItemTemplate>
                            <a href="<%#Utility.GetRewriterUrl("catalog",categoryGUID, "&m="+Eval("manufacturerID").ToString()) %>"
                                class="subcategory">
                                <%#Eval("manufacturer")%>
                            </a>
                            <br />
                            <!--
              <a href="catalog.aspx?cid=<%=categoryID.ToString()%>&m=<%#Eval("manufacturerID") %>" class="subcategory"><%#Eval("manufacturer") %></a><br/>
              -->
                        </ItemTemplate>
                        <FooterTemplate>
                            <!--
               <a href="catalog.aspx?cid=<%=categoryID.ToString()%>" class="subcategory">Show All</a>
               -->
                            <a href="<%#Utility.GetRewriterUrl("catalog", categoryGUID, "") %>" class="subcategory">
                                Show All</a><br />
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <br />
                <h5 class="shaded">
                    Narrow By Price</h5>
                <div>
                    <asp:Repeater ID="rptPriceRanges" runat="server">
                        <ItemTemplate>
                            <a href="<%#Utility.GetRewriterUrl("catalog", categoryGUID, "&ps="+Eval("lowRange").ToString()+"&pe="+Eval("hiRange").ToString()) %>"
                                class="subcategory">
                                <%#Convert.ToDecimal(Eval("lowRange")).ToString("C") %>
                                -
                                <%#Convert.ToDecimal(Eval("hiRange")).ToString("C")%>
                            </a></a><br />
                            <!--
              <a href="catalog.aspx?cid=<%=categoryID.ToString()%>&ps=<%#Eval("lowRange")%>&pe=<%#Eval("hiRange")%>"
              class="subcategory"><%#Convert.ToDecimal(Eval("lowRange")).ToString("C") %> - <%#Convert.ToDecimal(Eval("hiRange")).ToString("C")%></a><br/>
                -->
                        </ItemTemplate>
                        <FooterTemplate>
                            <a href="<%#Utility.GetRewriterUrl("catalog", categoryGUID, "") %>" class="subcategory">
                                Show All</a><br />
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </td>
        </tr>
    </table>
    </div>  
</asp:Content>

