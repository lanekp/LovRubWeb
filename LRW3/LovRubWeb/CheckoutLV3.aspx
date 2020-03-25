<%@Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="CheckoutLV3.aspx.cs"
  Inherits="CheckoutLV3" Title="Checkout" %>

<%@ Register Src="Modules/Checkout/PaymentBox.ascx" TagName="PaymentBox" TagPrefix="uc6" %>
<%@ Register Src="Modules/AddressEntry.ascx" TagName="AddressEntry" TagPrefix="uc2" %>
<%@ Register Src="Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc5" %>
<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>
<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc3" %>
<%@ Register Src="Modules/AcceptedPayment.ascx" TagName="AcceptedPayment" TagPrefix="uc7" %>
<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="ucMH" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphMastHead" runat="server">
    <ucMH:MastHead id="MastHead1" runat="server"/>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://www.lovrub.com/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://www.lovrub.com/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://www.lovrub.com/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://www.lovrub.com/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://www.lovrub.com/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://www.lovrub.com/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://www.lovrub.com/HottestNews.aspx">Hottest News</asp:HyperLink></li>
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    
    <ul class="submenu">
		<li class="large">Sexual Enhancement Gels
			<ul>
                <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="http://www.lovrub.com/Products/His.aspx">For Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="http://www.lovrub.com/Products/Hers.aspx">For Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/Products/LipLov.aspx">LipLov</asp:HyperLink></li>		
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        
        <li><asp:HyperLink runat="server" NavigateUrl="http://www.lovrub.com/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>        
    </ul>
	
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="cphContent" runat="Server">

<div class="checkoutCol">    
<!-- <div class="imagedContent" style="padding-bottom:200px;"> -->

<!-- <h1 class="pagetitle">Checkout</h1> -->
    
<!-- <table bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="5" cellspacing="0"> -->
<table border="0" align="center" cellpadding="5" cellspacing="0">
    <tr><td align="center"><h1 class="pagetitle">Checkout</h1></td></tr>
    <tr>
        <td><div class="checkoutParagraph">
                <uc5:Paragraph ID="Paragraph1" runat="server" ContentName="CheckoutTopLeft" />
            </div>
        </td>
    </tr>
        
    <tr>
        <td>
    <asp:UpdatePanel ID="WizUpdatePanel" runat="server" UpdateMode="Conditional">
      <ContentTemplate>
        <!--
        <asp:Panel ID="pnlPPStandard" runat="server">
        </asp:Panel>
        <br />
        -->        
        <asp:Wizard ID="wizCheckout" 
                    runat="server" 
                    ActiveStepIndex="0" 
                    CancelDestinationPageUrl="~/BasketLV3.aspx"
                    DisplayCancelButton="false" 
                    DisplaySideBar="false" 
                    Width="585" 
                    OnActiveStepChanged="Step_Changed">
          <WizardSteps>
            <asp:WizardStep runat="server" Title="Enter Shipping Info">
              <table border="0" align="center" cellpadding="0" cellspacing="0">              
                <tr>
                  <td align="right">
                      <span class="selected">Shipping >></span>
                    </td>
                  <td align="center">
                   <span class="notselected">Billing >></span>
                    </td>
                  <td align="left">
                    <span class="notselected">Confirmation</span>
                  </td>
                </tr>
              </table>
              <br />
              <uc2:AddressEntry ID="addShipping" runat="server" UseAddressBook="false" />
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Billing">
              <!-- <table bgcolor="3A3A3C" width="733" border="0" align="center" cellpadding="0" cellspacing="0"> -->
              <table border="0" align="center" cellpadding="0" cellspacing="0">              
                <tr>
                  <td align="right">
                     <asp:LinkButton ID="lbShipping" runat="server" Text="Shipping >>" OnClick="lbShipping_Click" CssClass="notselected"></asp:LinkButton>
                  </td>
                  <td align="center">
                      <span class="selected">Billing >></span>
                  </td>
                  <td align="left">
                       <span class="notselected">Confirmation</span>
                  </td>
                </tr>
              </table>
              <br />
              <uc6:PaymentBox ID="PaymentBox1" runat="server"></uc6:PaymentBox>
              <br />
              <div class="sectionheader">Billing Address</div>
              <uc2:AddressEntry ID="addBilling" runat="server" UseAddressBook="false" />
            </asp:WizardStep>
            <asp:WizardStep ID="wizConfirm" runat="server" Title="Confirm And Submit Your Order">
              <asp:Panel ID="pnlFinalHeadNav" runat="server">
                <!-- <table bgcolor="3A3A3C" cellpadding="4"> -->
                <!-- <table bgcolor="3A3A3C" width="733" border="0" align="center" cellpadding="0" cellspacing="0"> -->
                <table border="0" align="center" cellpadding="0" cellspacing="0">                
                  <tr>
                    <td align="right">
                     <asp:LinkButton ID="lbShipping1" runat="server" Text="Shipping >>" OnClick="lbShipping_Click" CssClass="notselected"></asp:LinkButton>
                      </td>
                    <td align="center">
                     <asp:LinkButton ID="lbBilling" runat="server" Text="Billing >>" OnClick="lbBilling_Click" CssClass="notselected"></asp:LinkButton></td>
                    <td align="left">
                          <span class="selected">Confirmation</span>
                    </td>
                  </tr>
                </table>
              </asp:Panel>
              <asp:Panel ID="pnlReceipt" runat="server" Visible="false">
                <!-- <table bgcolor="3A3A3C" width="733"> -->
                <table>
                  <tr>
                    <td>
                      <h4>Order <%=currentOrder.OrderNumber %> Is Complete!</h4>
                      <br />
                      <div class="checkoutParagraph">
                          Status: 
                            <b>
                              <%=Utility.ParseCamelToProper(Enum.GetName(typeof(Commerce.Common.OrderStatus), currentOrder.OrderStatus)) %>
                            </b>
                          <br />
                          <br />
                          Please keep this number handy as we'll ask you for it should you need to return
                          your items.
                        </div>                          
                    </td>
                  </tr>
                </table>
              </asp:Panel>
        
              <br />
              <!-- <table bgcolor="3A3A3C" width="733"> -->
              <table>
                <tr>
                  <td>
                    <div class="sectionheader">Ship To:</div>
                    <div class="checkoutParagraph">
                        <asp:Label ID="lblShipTo" runat="server"></asp:Label>
                    </div>
                  </td>
                  <td>
                    <div class="sectionheader">Bill To:</div>
                    <div class="checkoutParagraph">
                        <asp:Label ID="lblBillTo" runat="server"></asp:Label>
                    </div>                        
                  </td>
                </tr>
              </table>
              <div class="twentypixspacer"></div>
              <div class="sectionheader">Payment Summary</div>
              <div class="checkoutParagraph">
                <asp:Label ID="lblPaySummary" runat="server"></asp:Label>
              </div>
              <!-- <div class="twentypixspacer"></div> --> <!-- KPL commented 12/2307 -->
              <!-- <div class="sectionheader">Shipping Options</div> --> <!-- KPL commented 12/2307 -->
                <asp:RadioButtonList ID="radShipChoices" 
                    runat="server" 
                    AutoPostBack="True" 
                    OnSelectedIndexChanged="radShipChoices_SelectedIndexChanged"
                    BorderStyle="None">
              </asp:RadioButtonList>

              <div class="twentypixspacer"></div>
              
              <asp:Panel ID="pnlCoupons" runat="server">
                    <div class="sectionheader">Coupons</div>
                    
                    Enter Coupon Code:<asp:TextBox ID="couponCode" runat="server" EnableViewState="False"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                        runat="server" 
                        ControlToValidate="couponCode"
                        ErrorMessage="Please enter a coupon code." 
                        ValidationGroup="coupon">*
                    </asp:RequiredFieldValidator>
                    <asp:Button ID="applyCoupon" 
                        runat="server" 
                        Text="Apply" 
                        OnClick="applyCoupon_Click"
                        ValidationGroup="coupon" 
                    />
                    <br />
                    <asp:Label ID="couponMessage" 
                        runat="server" 
                        EnableViewState="False" 
                        Font-Bold="True"
                        Text="Label" 
                        Visible="False">
                    </asp:Label>
              </asp:Panel>
              <div class="twentypixspacer"></div>
              <div class="sectionheader">Order Items:</div>
              <div class="checkoutParagraph">
                <asp:Label ID="lblOrderItems" runat="server"></asp:Label>
              </div>                
            </asp:WizardStep>
          </WizardSteps>
          <FinishNavigationTemplate></FinishNavigationTemplate>
          <StartNavigationTemplate></StartNavigationTemplate>
          <StepNavigationTemplate></StepNavigationTemplate>
        </asp:Wizard>
        <asp:Panel ID="pnlNav" runat="server">
          <br />
          <!-- <table bgcolor="3A3A3C" width="733"> -->
          <table width="585">
            <tr>
              <td align="center">
                <asp:Button ID="btnPrev" runat="server" Visible="false" OnClick="btnPrev_Click" />
                <asp:Button ID="btnNext" runat="server" Text="Billing >>" OnClick="btnNext_Click" />
              </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlComplete" runat="server" Visible="false">
          <!-- <table bgcolor="3A3A3C" width="733"> -->
          <table width="585">
            <tr>
              <td style="height: 60px;">
                <uc5:ResultMessage ID="ResultMessage1" runat="server" />
              </td>
              <td align="center">
                <asp:Button ID="btnComplete" 
                            runat="server" 
                            Text="Place Your Order" 
                            OnClick="btnComplete_Click"
                            CausesValidation="false" />
              </td>
            </tr>
          </table>
        </asp:Panel>
      </ContentTemplate>
    </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:UpdateProgress ID="uProgress" runat="server">
              <ProgressTemplate>
                <div class="loadingbox">
                  <img src="images/spinner.gif" align="absmiddle" />
                        &nbsp;&nbsp;
                        <asp:Label ID="lblProgress" runat="server">Processing...</asp:Label>
                </div>
              </ProgressTemplate>
            </asp:UpdateProgress>
        </td>
    </tr>    
</table>    
    
</div>
<!-- </div> -->
  
</asp:Content>
