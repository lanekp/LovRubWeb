<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="CheckoutPPStandard.aspx.cs" Inherits="CheckoutPPStandard" Title="PayPal Checkout" %>

<%@ Register Src="Modules/AddressEntry.ascx" TagName="AddressEntry" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div id="centercontent">
        <img src="images/paypal_logo.gif" />
        <h4>Checkout with PayPal</h4>
        <asp:Wizard ID="Wizard1" runat="server" DisplaySideBar="False" OnActiveStepChanged="StepChanged" ActiveStepIndex="2">
            <WizardSteps>
                <asp:WizardStep runat="server" Title="Enter Shipping Info">
                   <div class="sectionheader">Enter Shipping Address</div><br />
                   <uc1:AddressEntry ID="AddressEntry1" runat="server" />
                </asp:WizardStep>
                <asp:WizardStep runat="server" Title="Select Shipping">
                <div class="sectionheader">Select Shipping</div><br />
                    <asp:RadioButtonList ID="radShipChoices" runat="server" BorderStyle="None" AutoPostBack="True" OnSelectedIndexChanged="radShipChoices_SelectedIndexChanged"></asp:RadioButtonList><br />
                </asp:WizardStep>
                <asp:WizardStep ID="WizardStep1" runat="server" Title="Finalize">
                    <div class="sectionheader">Confirm Your Order</div><br />
                   <div class=plainbox>
                    You are about to be redirected to PayPal.com to purchase this order. 
                    Once payment is completed, please be sure to let PayPal redirect you 
                    back to this site. When PayPal redirects you, they send along your transaction 
                    information which we need in order to complete and reconcile your payment.
                    </div>
                    <br />
                    <center>
                       <asp:Button ID=btnContinue runat=server Text="Finish" OnClick="btnContinue_Click"/><br />
                    </center>                
        </asp:WizardStep>
            </WizardSteps>
            <FinishNavigationTemplate></FinishNavigationTemplate>
        </asp:Wizard>
        <div class="sectionheader">
            <br />
            Order Summary</div>
        <br />
        <div>
            <asp:Label ID="lblSummary" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>

