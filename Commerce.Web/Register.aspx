<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Login" Title="Commerce Starter Kit Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="leftcontent"></div>
    
    
    <div id="centercontent">
    
        <table align="center" class="logtable">
            <tr>
                <td class="loginheader">Register
                </td>
            </tr>
            <tr>
                <td class="logincell">
                    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CreateUserButtonText="Continue" ContinueDestinationPageUrl="~/default.aspx" CancelDestinationPageUrl="~/default.aspx">
                        <WizardSteps>
                            <asp:CreateUserWizardStep runat="server">
                            </asp:CreateUserWizardStep>
                            <asp:CompleteWizardStep runat="server">
                            </asp:CompleteWizardStep>
                        </WizardSteps>
                    </asp:CreateUserWizard>
                
                </td>
              
            </tr>
        
        </table>
    
    </div>
</asp:Content>

