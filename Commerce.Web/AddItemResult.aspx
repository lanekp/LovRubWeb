<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="AddItemResult.aspx.cs" Inherits="AddItemResult" Title="Item Added" %>

<%@ Register Src="Modules/Products/ProductSummaryDisplay.ascx" TagName="ProductSummaryDisplay"
    TagPrefix="uc6" %>

<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>

<%@ Register Src="Modules/MiniCart.ascx" TagName="MiniCart" TagPrefix="uc1" %>
<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc2" %>
<%@ Register Src="Modules/RecentCategories.ascx" TagName="RecentCategories" TagPrefix="uc2" %>
<%@ Register Src="Modules/RecentProductsViewed.ascx" TagName="RecentProductsViewed" TagPrefix="uc3" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<div id="centercontent">
    <%
        if (drLastAdded != null)
        {
    %>
    
    <table width="733" bgcolor="black" border="0" align="center" cellpadding="8" cellspacing="0">
        <tr>
            <td colspan="5"><a href="default.aspx"><img src="images/lovrubweblogo.gif" border="0" alt="LovRub&#153; Home" /></a></td>
            <td rowspan="3"><img src="images/CouplePhoto4.gif" width="243" height="327" border="0" id="Img1" alt="" /></td>
        </tr>
        <tr>
            <td>
                <table>
                    <tr>
                        <td><a href="LRProducts2.aspx"><img src="images/index_r4_c2.gif" width="138" height="80"  border="0" id="Img2" alt="" /></a></td>
                        <td><a href="faq.aspx"><img src="images/index_r4_c5.gif" width="136" height="80" border="0" id="Img3" alt="" /></a></td>
                        <td><img src="images/index_r4_c8.gif" width="136" height="80" border="0" id="Img4" alt="" /></td>
                    </tr>
                    <tr>
                       <td><a href="reviews.aspx"><img src="images/index_r5_c2.gif" width="138" height="73"  border="0" id="Img5" alt="" /></a></td>
                       <td><a href="LRProducts2.aspx"><img src="images/index_r5_c5.gif" width="136" height="73"   border="0" id="Img6" alt="" /></a></td>
                       <td><a href="HowItWorks.aspx"><img src="images/index_r5_c8.gif" width="136" height="73"  border="0" id="Img7" alt="" /></a></td>
                    </tr>
                </table>
            </td>        
        </tr>
    </table>
    
    <table bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" align="center"><h4>Just Added to your cart:</h4></td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="imgJustAdded" runat="server" />
            </td>
            <td>
                <div class="defaultText">
                    <asp:Label ID="lblJustAddedName" runat="server"></asp:Label><br /><br />
                    <!-- <div>Retail Price: <asp:Label ID="lblJustAddedRetail" runat="server" CssClass="RetailPrice"></asp:Label></div> -->
                    <span class="defaultText"><b>Our Price: </b></span>
                    <asp:Label ID="lblJustAddedOurPrice" runat="server" CssClass="ourprice"></asp:Label>
                    <div>
                        <b>Quantity:</b>&nbsp;<asp:Label ID="lblJustAddedQuantity" runat="server"></asp:Label>
                    </div>
                    <asp:Label ID="lblSelectedAtts" runat="server" Text='<%#Eval("attributes") %>'></asp:Label>
                    <div>
                        <b>Total:</b> <b><asp:Label ID="lblJustAddedLineTotal" runat="server"></asp:Label></b>
                    </div>
                </div>
          </td>
          <td>
              <div class="coreboxtop"></div>
                <div class="coreboxheader"><a href="Basket.aspx">Your Cart</a></div>
                <div class="coreboxbody">
                <div class="tenpixspacer"></div>
                <asp:Hyperlink ID="Hyperlink1" 
                               runat="server" 
                               SkinID="Checkout" 
                               NavigateUrl="~/CCBasket.aspx">
                </asp:Hyperlink>
                <div class="tenpixspacer"></div>
                <uc1:MiniCart id="MiniCart2" runat="server"></uc1:MiniCart>
                <div class="tenpixspacer"></div>
                <asp:Hyperlink ID="Hyperlink2" 
                               runat="server" 
                               SkinID="Checkout" 
                               NavigateUrl="~/CCBasket.aspx">
                </asp:Hyperlink>
            </div>
          </td>
        </tr>

    </table>
    <%
        }else{
    %>
        <h4>Your cart is empty</h4>

    <%
        }
    %>
</div>

</asp:Content>

