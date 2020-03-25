<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="BasketLV3.aspx.cs"
  Inherits="BasketLV3" Title="Your Shopping Cart" %>

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
<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="ucMH" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMastHead" runat="server">
    <ucMH:MastHead id="MastHead1" runat="server"/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    
    <ul class="submenu">
		<li class="large">Sexual Enhancement Gels
		    <ul>
                <li><asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Products/His.aspx">For Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Products/Hers.aspx">For Her</asp:HyperLink></li>				
		    </ul></li>

		<li><asp:HyperLink runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>		
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>        		        
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box for your Personal Lubricants"></asp:HyperLink></li>        
    </ul>
	
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="server">

    <!-- <div class="righticol" style="background: url(images/bi-contactus.jpg) no-repeat top right;"> -->
        <div class="ctrcol">    
        <div class="imagedContent" style="padding-bottom:200px;">
        <!-- <h1 class="pagetitle">Your Shopping Cart</h1> -->

    <table border="0" align="center" cellpadding="7" cellspacing="0">
    <tr>
        <td colspan="3" align="center">
            
            <h1 class="pagetitle">Your Shopping Cart:<asp:Label ID="lblSubtotal" runat="server"></asp:Label></h1>
        </td>
    </tr>
      <asp:Repeater ID="rptBasket" runat="server" OnItemCommand="DeleteItem">
        <ItemTemplate>
          <tr>
            <td colspan="3">&nbsp;</td>
          </tr>
          <!-- <tr style="background-color:#3A3A3C"> -->
          <tr style="background-color:#c50505">
            <td align="center" colspan="3">
                <span class="productNameBasket">
                    <%#Eval("productName") %>
                </span>
            </td>
          </tr>
        <tr>
            <td rowspan="3">
              <img src='<%#Eval("imageFile")%>' alt="" /><br />
              <div class="smalltext">
                Added on <%#DateTime.Parse(Eval("createdOn").ToString()).ToShortDateString() %>
              </div>
            </td>
            <td>
              <div class="smallTextBasket">
                <ew:NumericBox ID="txtQuantity" runat="server" Width="30px" Text='<%#Eval("quantity") %>'>
                </ew:NumericBox>
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
                        <% 
                            AddFreeItemToCart();
                        %>                      
                            <asp:HyperLink ID="lnkCheckout1" 
                                         runat="server" 
                                         NavigateUrl="~/CheckoutLV3.aspx"
                                         ImageUrl="~/images/button-proceedcheckout.gif">
                            </asp:HyperLink>                      
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
    </div>


</asp:Content>
