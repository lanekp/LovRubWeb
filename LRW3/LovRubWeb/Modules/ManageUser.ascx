<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManageUser.ascx.cs" Inherits="Modules_ManageUser" %>
<asp:Panel ID="pnlUserOV" runat="server">
    <table>
        <tr>
            <td style="width: 142px; height: 22px">
                User Name:
            </td>
            <td style="width: 400px; height: 22px">
                <asp:Label ID="lblUserName" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Password:
            </td>
            <td style="width: 400px">
                <asp:LinkButton ID="lnkPasswordChange" runat="server" Text="[Change Password]" OnClick="lnkPasswordChange_Click" CausesValidation="False" />
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Email Address:
            </td>
            <td style="width: 400px">
                <asp:Label ID="lblEmailAddr" runat="server" />
                <asp:LinkButton ID="lnkUpdateEmail" runat="server" Text="[update]" CausesValidation="false" OnClick="lnkUpdateEmail_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="width: 142px">
                Security Question:
            </td>
            <td style="width: 400px">
                <asp:Label ID="lblQuestion" runat="server" />
                <asp:LinkButton ID="lnkChangeQuestion" runat="server" Text="[change]" CausesValidation="False" OnClick="lnkChangeQuestion_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlChangePassword" runat="server" Visible="false">
    <asp:ChangePassword ID="ChangePassword1" runat="server" OnCancelButtonClick="HidePassPanel"
        OnContinueButtonClick="HidePassPanel">
        <CancelButtonStyle CssClass="button" />
        <ContinueButtonStyle CssClass="button" />
        <ChangePasswordButtonStyle CssClass="button" />
    </asp:ChangePassword>
</asp:Panel>
<asp:Panel ID="pnlSecQuestion" runat="server" Visible="false" Width="550px">
    <h3>Change Security Question</h3>
    <table>
        <tr>
            <td style="width: 129px">
                Password:
            </td>
            <td style="width: 256px">
                <asp:TextBox ID="txtCurPass" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCurPass" ErrorMessage="Required"
                    ID="Requiredfieldvalidator1"></asp:RequiredFieldValidator>
                    <br /><span style="font:xsmall italic">**verify your current password, this is used to prevent unautorized account changes**</span>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Security Question:
            </td>
            <td style="width: 256px">
                <asp:TextBox ID="txtSecQuest" TextMode="SingleLine" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSecQuest" ErrorMessage="Required"
                    ID="Requiredfieldvalidator2"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 129px">
                Security Answer:
            </td>
            <td style="width: 256px">
                <asp:TextBox ID="txtSecAnswer" TextMode="SingleLine" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtSecAnswer" ErrorMessage="Required"
                    ID="Requiredfieldvalidator3"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="lblSQresult" runat="server"></asp:Label>
                <br />
                <asp:Button ID="btnContinueSQ" CssClass="button" runat="server" Text="Continue" CausesValidation="False" OnClick="btnCancelSQ_Click" />
            </td>
        </tr>
        <tr>
        <td style="text-align: center" colspan="2">&nbsp;<asp:Button ID="btnCancelSQ" runat="server" CssClass="button" Text="Cancel" CausesValidation="False" OnClick="btnCancelSQ_Click" />&nbsp;
            <asp:Button ID="btnSaveSQ" runat="server" CssClass="button" Text="Save" OnClick="btnSaveSQ_Click" />
        </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pnlEmailEdit" runat="server" Visible="false" Width="548px">
        <h3>Update Email Address</h3>
        <table>
        <tr>
            <td style="width: 113px">
                Password:
            </td>
            <td style="width: 274px">
                <asp:TextBox ID="txtEmailPass" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailPass" ErrorMessage="Required"
                    ID="Requiredfieldvalidator4"></asp:RequiredFieldValidator>
                    <br /><span style="font:xsmall italic">**verify your current password, this is used to prevent unautorized account changes**</span>
            </td>
        </tr>
        <tr>
            <td style="width: 113px">
                Email Address:
            </td>
            <td style="width: 274px">
                <asp:TextBox ID="txtEmailAddr" TextMode="SingleLine" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddr" ErrorMessage="Required"
                    ID="Requiredfieldvalidator5"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 113px">
                Re-enter Email:
            </td>
            <td style="width: 274px">
                <asp:TextBox ID="txtEmailAddr2" TextMode="SingleLine" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailAddr2" ErrorMessage="Required"
                    ID="Requiredfieldvalidator6"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Email Address Does Not Match!" ControlToCompare="txtEmailAddr2" ControlToValidate="txtEmailAddr" Type="String" ></asp:CompareValidator>
                <asp:Label ID="lblEmailResult" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
        <td style="text-align: center; height: 21px;" colspan="2">&nbsp;<asp:Button ID="btnCancelE" runat="server" CssClass="button" Text="Cancel" CausesValidation="False" OnClick="btnCancelSQ_Click" />&nbsp;
            <asp:Button ID="btnSaveE" runat="server" CssClass="button" Text="Save" OnClick="btnSaveE_Click" />
        </td>
        </tr>
    </table>
</asp:Panel>