<%@ Page Language="C#"  Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/scheckout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" Title="LovRub.com Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div id="leftcontent"></div>
    
    
    <div id="centercontent">
    
        <table align="center" class="logtable">
            <tr>
                <td class="loginheader">Login
                </td>
            </tr>
            <tr>
                <td class="logincell" align="center">
              
                    <asp:Login  ID="Login1" runat="server"
                                PasswordRecoveryText="Forgot Password?" 
                                PasswordRecoveryUrl="~/PasswordRecover.aspx" 
                                CreateUserText="Not Registered?" 
                                CreateUserUrl="Register.aspx"  OnLoginError="OnLoginError"
                                TitleText="" >
                    </asp:Login>
                </td>
                
            </tr>
        
        </table>
    
    </div>
</asp:Content>

