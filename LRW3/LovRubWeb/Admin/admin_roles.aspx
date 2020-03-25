<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="admin_roles.aspx.cs" Inherits="AdminUsers_admin_roles" Title="Roles Administration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">
    <h4>Role Administration</h4>

    <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="false" 
        DataSourceID="allRolesDataSource" 
        EmptyDataText="There are no matching roles in the system." 
        Font-Italic="False">
        <Columns>
            <asp:TemplateField HeaderText="Role Name" ItemStyle-Width="200">
                <ItemTemplate>
                    <%# Container.DataItem %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" id="linkButton1" text="Delete" commandname="delete" CommandArgument='<%# Container.DataItem %>' forecolor="black" oncommand="LinkButtonClick" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataRowStyle Font-Italic="True" />
    </asp:GridView>
    
    <br />
    
    <div>
        <table>
            <tr>
                <td>
                    <asp:TextBox ID="txtRoleName" runat="server" ValidationGroup="new" CssClass="adminlabel"/>
                    <asp:Button runat="server" id="linkButton2" text="Add" commandname="add" forecolor="black" oncommand="LinkButtonClick" ValidationGroup="new" CssClass="frmbutton" />
                    <asp:RequiredFieldValidator ID="RoleNameRequiredFieldValidator" runat="server" ControlToValidate="txtRoleName" Display="Dynamic" EnableClientScript="true" ValidationGroup="new">required</asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </div>
    
    <asp:ObjectDataSource ID="allRolesDataSource" runat="server"
        SelectMethod="GetAllRoles"
        TypeName="System.Web.Security.Roles" >
    </asp:ObjectDataSource>
</div>

</asp:Content>

