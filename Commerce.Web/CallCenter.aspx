<%@ Page Language="C#" MasterPageFile="~/CCMaster.master" AutoEventWireup="true" CodeFile="CallCenter.aspx.cs" Inherits="CallCenter" Title="Call Center" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table bgcolor="white">
        <tr>
            <td colspan="2">
                <div class="defaultClickHere17">
                    <fieldset style="border-color:#CCCCCC; padding-top:5px; padding-bottom:5px">
                        &nbsp;&nbsp;1 for $19.95<br /><br />
                        &nbsp;&nbsp;Get 2nd tube for $9.99<br /><br />
                        &nbsp;&nbsp;That's 2 tubes for a total of $29.94<br /><br />
                        &nbsp;&nbsp;(Each additional tube is also $9.99)<br />
                        &nbsp;&nbsp;Also, a free tube of RubLov Massage Gel<br />
                        
                        &nbsp;&nbsp;(if desired)with each order of 2 tubes or more.<br />
                    </fieldset>
                </div>
            
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal Text="Enter Male Quantity:" ID="Literal2" runat="server"></asp:Literal>
            </td>
            <td>
                <ew:NumericBox ID="txtMaleQty" runat="server" Width="30px" Text="0"></ew:NumericBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="lblFemaleQty" Text="Enter Female Quantity:" runat="server"></asp:Literal>
            </td>
            <td>
                <ew:NumericBox ID="txtFemaleQty" runat="server" Width="30px" Text="0"></ew:NumericBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="CalcBtn" runat="server" Text="Next >>>" OnClick="CalcBtn_Click" />
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td colspan="2">
               <div class="defaultClickHere17">
                    <asp:Literal ID="lblStatusMsg" runat="server"></asp:Literal>
               </div>                    
            </td>
        </tr>   
        <tr>
            <td>
                <asp:Literal Text="Send Customer Free RubLov Massage Gel? (check box):" ID="lblFreeMaleQty" Visible="false" runat="server"></asp:Literal>
            </td>
            <td>
                &nbsp;<asp:CheckBox ID="CheckBox1" Checked="false" Visible="false" runat="server" /></td>
        </tr>
        <tr>
            <td style="height: 21px">
            </td>
            <td style="height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="SubmitBtn" Visible="false" runat="server" Text="Submit" OnClick="Submit_Click" />
            </td>
        </tr>
       
    </table>

</asp:Content>

