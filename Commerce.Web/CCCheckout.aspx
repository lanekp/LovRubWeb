<%@Page Language="C#" MasterPageFile="~/scheckout.master" AutoEventWireup="true" CodeFile="CCCheckout.aspx.cs"
  Inherits="CCCheckout" Title="CCCheckout" %>

<%@ Register Src="Modules/Checkout/PaymentBox.ascx" TagName="PaymentBox" TagPrefix="uc6" %>
<%@ Register Src="Modules/AddressEntry.ascx" TagName="AddressEntry" TagPrefix="uc2" %>
<%@ Register Src="Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc5" %>
<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>
<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc3" %>
<%@ Register Src="Modules/AcceptedPayment.ascx" TagName="AcceptedPayment" TagPrefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager 
        runat="server" 
        EnablePartialRendering="true" 
        ID="scriptManager">
    </asp:ScriptManager>
  
  
<!-- <div id="centercontent"> -->

<table bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="5" cellspacing="0">
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
                    CancelDestinationPageUrl="Basket.aspx"
                    DisplayCancelButton="false" 
                    DisplaySideBar="false" 
                    Width="650" 
                    OnActiveStepChanged="Step_Changed">
          <WizardSteps>
            <asp:WizardStep runat="server" Title="Enter Shipping Info">
              <!-- <table cellpadding="4"> -->
              <table bgcolor="#3A3A3C" width="733" border="0" align="center" cellpadding="0" cellspacing="0">
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
              <uc2:AddressEntry ID="addShipping" runat="server" UseAddressBook="true" />
            </asp:WizardStep>
            <asp:WizardStep runat="server" Title="Billing">
              <!-- <table bgcolor="3A3A3C" cellpadding="4"> -->
              <table bgcolor="3A3A3C" width="733" border="0" align="center" cellpadding="0" cellspacing="0">
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
              <uc2:AddressEntry ID="addBilling" runat="server" UseAddressBook="true" />
            </asp:WizardStep>
            <asp:WizardStep ID="wizConfirm" runat="server" Title="Confirm And Submit Your Order">
              <asp:Panel ID="pnlFinalHeadNav" runat="server">
                <!-- <table bgcolor="3A3A3C" cellpadding="4"> -->
                <table bgcolor="3A3A3C" width="733" border="0" align="center" cellpadding="0" cellspacing="0">
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
                <table bgcolor="3A3A3C" width="733">
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
              <table bgcolor="3A3A3C" width="733">
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
          <table bgcolor="3A3A3C" width="733">
            <tr>
              <td align="center">
                <asp:Button ID="btnPrev" runat="server" Visible="false" OnClick="btnPrev_Click" />
                <asp:Button ID="btnNext" runat="server" Text="Billing >>" OnClick="btnNext_Click" />
              </td>
            </tr>
          </table>
        </asp:Panel>
        <asp:Panel ID="pnlComplete" runat="server" Visible="false">
          <table bgcolor="3A3A3C" width="733">
            <tr>
              <td style="height: 60px;">
                <uc5:ResultMessage ID="ResultMessage1" runat="server" />
              </td>
              <td align="right">
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
    <table width="733" bgcolor="black" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="14" align="center"><img src="images/BlackLineSpacer.gif" alt="" /></td>
        </tr>
        <tr>
            <td>
                <a href="LRProducts2.aspx"><img src="images/index_r13_c2.gif" width="72" height="26" border="0" id="index_r13_c2" alt="" /></a>
            </td>
           <td><a href="reviews.aspx"><img src="images/index_r13_c4.gif" width="121" height="26" border="0" id="index_r13_c4" alt="" /></a></td>
           <td><a href="faq.aspx"><img src="images/index_r13_c6.gif" width="51" height="26" border="0" id="index_r13_c6" alt="" /></a></td>
           <td><a href="LRProducts2.aspx"><img src="images/index_r13_c7.gif" width="90" height="26" border="0" id="index_r13_c7" alt="" /></a></td>
           <td><img src="images/index_r13_c10.gif" width="70" height="26" border="0" id="index_r13_c10" alt="" /></td>
           <td><a href="HowItWorks.aspx"><img src="images/index_r13_c11.gif" width="107" height="26" border="0" id="index_r13_c11" alt="" /></a></td>
           <td><a href="about.htm"><img src="images/index_r13_c13.gif" width="78" height="26" border="0" id="index_r13_c13" alt="" /></a></td>
           <td><a href="about.htm"><img src="images/index_r13_c14.gif" width="80" height="26" border="0" id="index_r13_c14" alt="" /></a></td>
        </tr>
        <tr>
            <td colspan="14"><img src="images/index_r14_c2.gif" width="669" height="116" border="0" id="index_r14_c2" alt="" /></td>
        </tr>
        <tr >
            <td align="center" colspan="80%">
                <span class="disclaimer"> 
                    Individual results may vary. 
                    These statements have not been evaluated by the Food and Drug Administration. <br />
                    This product is not intended to diagnose, treat, cure, or prevent any disease. 
                </span>                    
            </td>
        </tr>
    </table>
    
  <!-- </div> --> <!-- centercontent -->
  <br />
  <br />
  
  
  
</asp:Content>
