<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Campaigns.aspx.cs" Inherits="Admin_Admin_Campaigns" Title="Campaigns Administration" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@	Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1"%>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">

        <h4>Campaigns</h4>

		<asp:panel id="pnlGrid" runat="server">

		<asp:datagrid id="dg" runat="server" Width="90%" CellPadding="3" GridLines="None" DESIGNTIMEDRAGDROP="23"
			BorderColor="White" BorderWidth="0px" BorderStyle="Solid" BackColor="White" AutoGenerateColumns="False"
			AllowSorting="True" ForeColor="Black" Font-Names="Verdana" Font-Size="8pt" OnEditCommand="GridEdit">
			<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="Gainsboro"></SelectedItemStyle>
			<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
			<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
			<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="LightSteelBlue"></HeaderStyle>
			<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="CampaignID"  HeaderText="CampaignID"  Visible=false></asp:BoundColumn>
						<asp:BoundColumn DataField="CampaignName"  DataFormatString="{0:c}"  HeaderText="Campaign" ></asp:BoundColumn>
						<asp:BoundColumn DataField="RevenueGoal"  HeaderText="RevenueGoal" ></asp:BoundColumn>
						<asp:BoundColumn DataField="InventoryGoal"  HeaderText="InventoryGoal" ></asp:BoundColumn>
						<asp:BoundColumn DataField="DateEnd"  HeaderText="DateEnd" ></asp:BoundColumn>
						<asp:BoundColumn DataField="IsActive"  HeaderText="IsActive" ></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
				</asp:datagrid>
				<br />
				<asp:button id="cmdAdd"  runat="server" OnClick="btnAdd_Click" CausesValidation="False" Text="Add" CssClass="frmbutton" ></asp:button>
			</asp:panel>
			<asp:panel id="pnlEdit" Runat="server">
			<uc1:ResultMessage ID="uResult" runat="server" Visible="false" EnableViewState="false" />	
			<asp:ValidationSummary runat="server" ID="vsResultMessage" DisplayMode="List" ShowSummary="true"
				HeaderText="Page Errors:" CssClass="adminitem" />	
			<table class="admintable" cellpadding="5" cellspacing="0">
				<tr id="trID" runat="server">
					<td class="adminlabel">ID</td>
					<td class="adminitem"><asp:label id="lblID" runat="server" /></td>
				</tr>
				<tr>
					<td class="adminlabel">Campaign Name</td>
					<td class="adminitem">
						<asp:textbox id="txtCampaign" runat="server" Width="394px"></asp:textbox><asp:RequiredFieldValidator
							ID="rfvCampaign" runat="server" ControlToValidate="txtCampaign" ErrorMessage="Campaign Name is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">Description</td>
					<td class="adminitem">
						<asp:textbox id="txtDescription" runat="server" Width="394px" ></asp:textbox><asp:RequiredFieldValidator
							ID="rfvDescription" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">Objective</td>
					<td class="adminitem">
						<asp:textbox id="txtObjective" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Revenue Goal</td>
					<td class="adminitem">
						<ew:NumericBox ID="txtRevenueGoal" runat="server" width="60px" DecimalPlaces="2"></ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvRevenueGoal" runat="server" ControlToValidate="txtRevenueGoal" ErrorMessage="Revenue Goal is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Inventory Goal</td>
					<td class="adminitem">
						<ew:NumericBox ID="txtInventoryGoal" runat="server" width="59px"></ew:NumericBox><asp:RequiredFieldValidator
							ID="rfvInventoryGoal" runat="server" ControlToValidate="txtInventoryGoal" ErrorMessage="Inventory Goal is required."
							Text="*">
						</asp:RequiredFieldValidator>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">DateCreated</td>
					<td class="adminitem">
					    <ew:CalendarPopup ID="txtDateCreated" runat="server">
					    </ew:CalendarPopup>

					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">DateEnd</td>
					<td class="adminitem">
					    <ew:CalendarPopup ID="txtDateEnd" runat="server">
					    </ew:CalendarPopup>

					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">IsActive</td>
					<td class="adminitem">
						<asp:CheckBox id="chkIsActive" runat="server" />
					</td>
				</tr>
				
					
				<tr>
					<td>
					<asp:Button id="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton" ></asp:Button>&nbsp;
					<input type="button" onclick="location.href='<%=Request.Url.PathAndQuery%>'" value="Return" class="frmbutton">
					</td>
					
					<td align="right"><asp:Button id="btnDelete" runat="server" CausesValidation="False" Text="Delete" OnClick="btnDelete_Click" CssClass="frmbutton" ></asp:Button></td>
				</tr>

			</table>
			</asp:panel>
			<script>
			function CheckDelete(){
					
				return confirm("Delete this record? This action cannot be undone...");

			}

			</script>
</div>
</asp:Content>

