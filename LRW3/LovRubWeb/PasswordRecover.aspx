<%@ Page Language="C#" MasterPageFile="~/scheckout.master" AutoEventWireup="true" CodeFile="PasswordRecover.aspx.cs" Inherits="PasswordRecover" Title="Recover Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="leftcontent"></div>
<div id="centercontent">
   <h4>
        Recover Your Password</h4>
    <p>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
            <FailureTextStyle CssClass="errorbox" />
            <TitleTextStyle CssClass="sectionheader" />
            <InstructionTextStyle CssClass="plainbox" />
            <LabelStyle CssClass="checkoutlabel" />

        </asp:PasswordRecovery>
        &nbsp;</p>
</div>
<div id="rightcontent"></div>
</asp:Content>

