<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="mailconfiguration.aspx.cs"
  Inherits="Admin_mailconfiguration" Title="Untitled Page" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" runat="Server">
  <div id="centercontent">
    <h2>
      Mail Configuration</h2>
    <p>
      You can set your email server settings here.</p>
    <div class="sectionoutline">
      <div class="sectionheader">
        Settings</div>
      <br />
      <asp:Label ID="lblFrom" runat="server" Text="From:" /><br />
      <asp:TextBox ID="txtFrom" runat="server" Width="300" /><br /><br />
      <asp:Label ID="lblHost" runat="server" Text="Host:" /><br />
      <asp:TextBox ID="txtHost" runat="server" Width="300" /><br /><br />
      <asp:Label ID="lblUserName" runat="server" Text="UserName:" /><br />
      <asp:TextBox ID="txtUserName" runat="server" Width="300" /><br /><br />
      <asp:Label ID="lblPassword" runat="server" Text="Password:" /><br />
      <asp:TextBox ID="txtPassword" runat="server" Width="300" /><br /><br />
      <asp:Label ID="lblPort" runat="server" Text="Port:" /><br />
      <asp:TextBox ID="txtPort" runat="server" /><br /><br />
      <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" /><br /><br />
      <uc1:ResultMessage ID="result" runat="server" />
      </div>
  </div>
</asp:Content>
