<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductCrossSells.ascx.cs"
	Inherits="Modules_Admin_ProductCrossSells" %>
<%@ Register Src="../ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<table class="admintable">
	<tr><td><h4>Cross-sells</h4></td></tr>
	<tr>
		<td>
       <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
			<table cellpadding="3" cellspacing="0">
              <tr>
                  <td class="adminlabel">
                      Products</td>
                  <td>
						<asp:CheckBoxList ID="chkProducts" runat="server" CellPadding="5" CellSpacing="2"
							RepeatColumns="3" >
                      </asp:CheckBoxList></td>
              </tr>
                <tr>
					<td class="adminlabel" style="height: 24px">
						<asp:Button ID="btnAddCross" runat="server" Text="Save Cross-Sell" OnClick="SaveCrossList" /></td>
                    <td style="height: 24px" >
                        <uc1:ResultMessage ID="ResultMessage1" runat="server" />
                    </td>
                </tr>
            </table>
     </td>
     </tr>
</table>
