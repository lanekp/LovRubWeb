<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductAttributes.ascx.cs"
	Inherits="Modules_Admin_ProductAttributes" %>
     <table class="admintable">
         <tr>
             <td>
			<h4>
				Attributes</h4>
		</td>
	</tr>
	<tr>
		<td class="adminitem">
			<b>Load this list from a template:</b>
			<asp:DropDownList ID="ddlAttTemplates" runat="server"></asp:DropDownList>
			<asp:Button ID="btnSetTemplate" runat="server" OnClick="btnSetTemplate_Click" Text="Set" CausesValidation="false" />
		</td>
	</tr>
	<tr>
		<td>
                 <asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
                 <table width="650" cellspacing="0">
                     <tr>
                         <td class="adminlabel">
                             Attribute Name</td>
                         <td class="adminitem">
                             <asp:TextBox ID="txtAttributeNew" runat="server" Width="174px"></asp:TextBox>
                             <asp:Button ID="btnSaveAttTemplate" runat="server" OnClick="btnSaveAttTemplate_Click"
                                 Text="Save As Template" CausesValidation="false"/><asp:Label ID="lblTemplateSaved" Text="" runat="server"></asp:Label>
                         </td>
                     </tr>
                      <tr>
                         <td class="adminlabel">
                             Selection Type
                         </td>
                         <td class="adminitem">
						<asp:DropDownList ID="ddlAttNewSelectionType" runat="server" AutoPostBack="True"
							OnSelectedIndexChanged="ddlAttNewSelectionType_SelectedIndexChanged">
                                 <asp:ListItem Value="0">Single Selection List</asp:ListItem>
                                 <asp:ListItem Value="1">Multi-Select</asp:ListItem>
                                 <asp:ListItem Value="2">User Input</asp:ListItem>
                             </asp:DropDownList></td>
                     </tr>                  
                      <tr>
                         <td class="adminlabel">
                             Description</td>
                         <td class="adminitem">
                             <asp:TextBox ID="txtAttNewDesc" runat="server" Height="46px" TextMode="MultiLine"
                                 Width="174px"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td class="adminlabel">
                             Selections<br />
                             <br />
                             You can adjust the price based on the selection. Make sure it's negative for a discount!</td>
                         <td class="adminitem">
                             <asp:Panel ID="pnlSelections" runat="server">
                             <br />
                             <table style="border: 1px dashed gray">
                                 <tr>
                                     <td>
                                         <asp:DataGrid ID="dgSells" runat="server" AutoGenerateColumns="False" OnDeleteCommand="removeSelection"
                                             Width="302px">
                                             <Columns>
                                                 <asp:ButtonColumn CommandName="Delete" Text="Delete"></asp:ButtonColumn>
                                                 <asp:BoundColumn DataField="Value" HeaderText="Selection"></asp:BoundColumn>
                                                 <asp:BoundColumn DataField="priceAdjustment" DataFormatString="{0:c}" HeaderText="Adjustment">
                                                 </asp:BoundColumn>
                                             </Columns>
                                         </asp:DataGrid>
                                     </td>
                                 </tr>
                                 <tr>
                                     <td>
                                         Selection Name<br />
                                         <asp:TextBox ID="txtSelectionAdd" runat="server"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSelectionAdd"
                                             Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
                                 </tr>
                                 <tr>
                                     <td>
                                         Price Adjustment<br />
                                         <asp:TextBox ID="txtPriceAdjustment" runat="server" Width="82px">0</asp:TextBox>
                                         <asp:Button ID="btnAddAtt" runat="server" Text="Add" OnClick="btnAddAtt_Click" />
                                         <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPriceAdjustment"
                                             ErrorMessage="Must be a number" MaximumValue="9999999999" MinimumValue="-99999999"
                                             SetFocusOnError="True" Type="Currency" Display="Dynamic"></asp:RangeValidator>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPriceAdjustment"
                                             Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></td>
                                 </tr>
                             </table>
                             </asp:Panel>
                             <br />
                         </td>
                     </tr>

                 </table>
                 <asp:Button ID="btnAddAttribute" runat="server" Text="Add" OnClick="btnAddAttribute_Click" CssClass="frmbutton"  CausesValidation="false"/>
                 <br />
                 <br />
                 <asp:DataGrid ID="dgAtts" runat="server" Width="650px" AutoGenerateColumns="False"
                     OnDeleteCommand="DeleteAtt">
                     <Columns>
                         <asp:BoundColumn DataField="Name" HeaderText="Attribute"></asp:BoundColumn>
                         <asp:BoundColumn DataField="SelectionList" HeaderText="Selections"></asp:BoundColumn>
                         <asp:BoundColumn DataField="SelectionType" HeaderText="Type"></asp:BoundColumn>
                         <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" Text="Delete"></asp:ButtonColumn>
                     </Columns>
                 </asp:DataGrid>
		</td>
	</tr>
</table>
