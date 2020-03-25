<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Basket.aspx.cs"
  Inherits="Basket" Title="Your Shopping Cart" %>

<%@ Register Src="Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc4" %>
<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc2" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc1" %>
<%@ Register Src="Modules/RecentCategories.ascx" TagName="RecentCategories" TagPrefix="uc2" %>
<%@ Register Src="Modules/RecentProductsViewed.ascx" TagName="RecentProductsViewed"
  TagPrefix="uc3" %>
<%@ Register Src="Modules/Products/ProductSummaryDisplay.ascx" TagName="ProductSummaryDisplay"
  TagPrefix="uc1" %>
  <%@ Register Src="Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div id="centercontent">
<table width="733" bgcolor="black" border="0" align="center" cellpadding="8" cellspacing="0">
    <tr >
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

    <table bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="7" cellspacing="0">
    <tr>
        <td colspan="3" align="center">
            <h4>Your Shopping Cart:<asp:Label ID="lblSubtotal" runat="server"></asp:Label></h4>
        </td>
    </tr>
      <asp:Repeater ID="rptBasket" runat="server" OnItemCommand="DeleteItem">
        <ItemTemplate>
          <tr>
            <td colspan="3">&nbsp;</td>
          </tr>
          <tr style="background-color:#3A3A3C">
            <td align="center" colspan="3">
                <span class="productNameBasket">
                    <%#Eval("productName") %>
                </span>
                <!-- <a href="LRProducts2.aspx"><%#Eval("productName") %></a> -->
            </td>
          </tr>
        <tr>
            <td rowspan="3">
              <img src='<%#Eval("imageFile")%>'/><br />
              <div class="smalltext">
                Added on <%#DateTime.Parse(Eval("createdOn").ToString()).ToShortDateString() %>
              </div>
            </td>
            <td>
              <div class="smallTextBasket">
                <ew:NumericBox ID="txtQuantity" runat="server" Width="30px" Text='<%#Eval("quantity") %>'></ew:NumericBox>
                @
                <%#decimal.Parse(Eval("pricePaid").ToString()).ToString("C") %>
                =
                <%#decimal.Parse(Eval("lineTotal").ToString()).ToString("C") %>
              </div>
              <div class="smallTextBasket10">
               <br />Usually ships in <%#Eval("shippingEstimate") %>
              </div>
              <asp:Label ID="lblProductID" runat="server" Visible="false" Text='<%#Eval("productID") %>'></asp:Label>
              <asp:Label ID="lblSelectedAtts" runat="server" Text='<%#Eval("attributes") %>'></asp:Label>
              </div>
            </td>
            <td>
                <asp:Panel ID="pnlCheckout" runat="server">
                    <div class="coreboxtop"></div>
                    <div class="coreboxheader">Ready To Buy?</div>
                    <div class="coreboxbody">
                      Checkout is quick and simple!
                      <hr />
                      <asp:HyperLink ID="lnkCheckout" runat="server" NavigateUrl="~/Checkout.aspx" SkinID="Checkout">[lnkCheckout]</asp:HyperLink>
                    </div>
                    <div class="coreboxbottom"></div>
                    <br class="clear" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="btnUpdate" runat="server" 
                    Height="26" 
                    Width="181"
                    CommandName="AdjustBasket" 
                    ImageURL="images/order_r9_c8.gif"
                    AlternateText="Re-calculate the items in your Cart" 
                />
            </td>
            <td>
                <asp:ImageButton ID="btnDelete" runat="server" 
                    Height="26" 
                    Width="183"
                    CommandName="DeleteButton"
                    ImageURL="images/order_r9_c15.gif"
                    AlternateText="Remove Item from your Cart" 
                />
            </td>
        </tr>
        </ItemTemplate>
      </asp:Repeater>        
    
    </table>
    <!-- 
    <asp:Panel ID="pnlExpressCheckout" runat="server">
      <div class="sectionheader">
        Shortcut for PayPal Users</div>
      <div class="tenpixspacer">
      </div>
      <table width="500">
        <tr>
          <td width="200">
            <asp:ImageButton ID="imgPayPal" runat="server" ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif"
              OnClick="imgPayPal_Click" CausesValidation="False" /></td>
          <td class="smalltext">
            Save Time. Checkout Securely. Pay without sharing your financial information.</td>
        </tr>
        <tr>
          <td colspan="2">
            <br />
            <asp:Label ID="lblPPErr" runat="server" ForeColor="Maroon"></asp:Label><br />
            <uc5:ResultMessage ID="ResultMessage1" runat="server" />            
          </td>
            
        </tr>
      </table>
      <div class="twentypixspacer">
    </asp:Panel>
    -->
<!--
    <asp:Panel ID="pnlCheckout" runat="server">
      <div id="rightcontent">
        <div class="coreboxtop">
        </div>
        <div class="coreboxheader">
          Ready To Buy?</div>
        <div class="coreboxbody">
          Checkout is quick and simple!
          <hr />
          <asp:HyperLink ID="lnkCheckout" runat="server" NavigateUrl="~/Checkout.aspx" SkinID="Checkout">[lnkCheckout]</asp:HyperLink>
        </div>
        <div class="coreboxbottom">
        </div>
        <br class="clear" />
      </div>
    </asp:Panel>
-->    
    <asp:Panel ID="pnlNada" runat="server">
      <h4>There's nothing in your cart !</h4>
      <!--
      <h5>We have lots of cool things you might be interested in checking out though....</h5>
      <asp:DataList ID="dtProducts" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
        <ItemTemplate>
          <uc1:ProductSummaryDisplay ID="ProductSummaryDisplay1" runat="server" ProductName='<%#Eval("ProductName") %>'
            ImageFile='<%#Eval("ImageFile") %>' ProductID='<%#Eval("ProductID") %>' OurPrice='<%#Eval("OurPrice") %>'
            RetailPrice='<%#Eval("RetailPrice") %>' ShippingEstimate='<%#Eval("ShippingEstimate") %>'
            Rating='<%#Eval("Rating") %>' SKU='<%#Eval("SKU") %>' ProductGUID='<%#Eval("ProductGUID")%>' />
        </ItemTemplate>
      </asp:DataList>
      -->
    </asp:Panel>
  </div>
</asp:Content>
