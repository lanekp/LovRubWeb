<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaymentBox.ascx.cs" Inherits="Modules_Checkout_PaymentBox" %>
<div class="sectionheader">
  Payment Method</div>
<!-- <table bgcolor="3A3A3C" width="733" cellpadding="0"> -->
<table width="585" cellpadding="0">
  <tr>
    <td class="smalltext" style="width: 200px">
      Credit Card Type
    </td>
    <td>
      <asp:DropDownList ID="ddlCCType" runat="server" OnSelectedIndexChanged="toggleCreditCardInfo" AutoPostBack="true">
        <asp:ListItem Value="0" Selected="true">MasterCard</asp:ListItem>
        <asp:ListItem Value="1">Visa</asp:ListItem>
        <asp:ListItem Value="2">AMEX</asp:ListItem>
        <asp:ListItem Value="3">Discover</asp:ListItem>
      </asp:DropDownList>
    </td>
  </tr>
  <asp:Panel ID="pnlCreditCardInfo" runat="server">
    <tr>
      <td class="smalltext" style="width: 200px">Credit Card Number (no spaces)</td>
      <td>
        <asp:TextBox runat="server" ID="txtCCNumber" Width="276px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCCNumber"
          ErrorMessage="Required"></asp:RequiredFieldValidator>
      </td>
    </tr>
    <tr>
    </tr>
    <tr>
      <td class="smalltext" style="width: 200px">
        Security Code</td>
      <td>
        <asp:TextBox runat="server" ID="txtCCAuthCode" Width="38px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCCAuthCode"
          ErrorMessage="Required"></asp:RequiredFieldValidator></td>
    </tr>
    <tr>
      <td class="smalltext" style="width: 200px">
        Expiration</td>
      <td>
        <asp:DropDownList ID="ddlExpMonth" runat="server" Width="49px">
          <asp:ListItem Value="1">01</asp:ListItem>
          <asp:ListItem Value="2">02</asp:ListItem>
          <asp:ListItem Value="3">03</asp:ListItem>
          <asp:ListItem Value="4">04</asp:ListItem>
          <asp:ListItem Value="5">05</asp:ListItem>
          <asp:ListItem Value="6">06</asp:ListItem>
          <asp:ListItem Value="7">07</asp:ListItem>
          <asp:ListItem Value="8">08</asp:ListItem>
          <asp:ListItem Value="9">09</asp:ListItem>
          <asp:ListItem Value="10">10</asp:ListItem>
          <asp:ListItem Value="11">11</asp:ListItem>
          <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>&nbsp;
        <asp:DropDownList ID="ddlExpYear" runat="server" Width="73px">
        </asp:DropDownList></td>
    </tr>
  </asp:Panel>
</table>
