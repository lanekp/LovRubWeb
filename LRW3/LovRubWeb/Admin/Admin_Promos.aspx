<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Promos.aspx.cs" Inherits="Admin_Admin_Promos" Title="Promotions Administration" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">

        <h4>Promotions</h4>
		<asp:panel id="pnlGrid" runat="server">

		<asp:datagrid id="dg" runat="server" Width="90%" CellPadding="3" GridLines="None"
			BorderColor="White" BorderWidth="0px" BorderStyle="Solid" BackColor="White" AutoGenerateColumns="False"
			AllowSorting="True" ForeColor="Black" Font-Names="Verdana" Font-Size="8pt"  OnEditCommand="GridEdit">
			<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="Gainsboro"></SelectedItemStyle>
			<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
			<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
			<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="LightSteelBlue"></HeaderStyle>
			<Columns>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Update" CancelText="Cancel" EditText="Edit"></asp:EditCommandColumn>
						<asp:BoundColumn DataField="PromoID" HeaderText="PromoID"  Visible="false"></asp:BoundColumn>
						<asp:BoundColumn DataField="PromoCode" HeaderText="PromoCode" ></asp:BoundColumn>
						<asp:BoundColumn DataField="Title" HeaderText="Title" ></asp:BoundColumn>
						<asp:BoundColumn DataField="Description" HeaderText="Description" ></asp:BoundColumn>
						<asp:BoundColumn DataField="CreatedOn" HeaderText="DateCreated" ></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
				</asp:datagrid>
				<br />
				<asp:button id="cmdAdd"  runat="server" OnClick="btnAdd_Click" CausesValidation="False" Text="Add" CssClass="frmbutton"></asp:button>
			</asp:panel>
			<asp:panel id="pnlEdit" Runat="server">
                <uc1:ResultMessage ID="uResult" runat="server"  EnableViewState="false" />	

                <table class="admintable" cellpadding="5" cellspacing="0">
				<tr id="trID" runat="server">
					<td class="adminlabel">ID</td>
					<td class="adminitem"><asp:label id="lblID" runat="server" /></td>
				</tr>
				<tr>
					<td class="adminlabel">
                        Campaign</td>
					<td class="adminitem">
						<asp:DropDownList id="ddlCampaignID" runat="server"></asp:DropDownList>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Promo Code</td>
					<td class="adminitem">
						<asp:textbox id="txtPromoCode" runat="server" ></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">Title</td>
					<td class="adminitem">
						<asp:textbox id="txtTitle" runat="server" Width="400px" ></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">Description</td>
					<td class="adminitem">
						<asp:textbox id="txtDescription" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Discount Percent</td>
					<td class="adminitem">
						<ew:NumericBox ID="txtDiscount" runat="server" DecimalPlaces="2" Width="50px">0</ew:NumericBox>
                        <br />
                        This is a discount off of the <strong>RETAIL PRICE</strong></td>
				</tr>
				
				<tr>
					<td class="adminlabel" style="height: 31px">
                        Qty Threshold</td>
					<td class="adminitem" style="height: 31px">
						<ew:NumericBox ID="txtQtyThreshold" runat="server" width="24px">0</ew:NumericBox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Inventory Goal</td>
					<td class="adminitem">
						<ew:NumericBox ID="txtInventoryGoal" runat="server" width="24px">0</ew:NumericBox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Revenue Goal</td>
					<td class="adminitem">
						$<ew:NumericBox ID="txtRevenueGoal" runat="server" width="94px" DecimalPlaces="2">0.00</ew:NumericBox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Date Created</td>
					<td class="adminitem">
					    <ew:CalendarPopup ID="txtDateCreated" runat="server">
					    </ew:CalendarPopup>

					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Date End</td>
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
					<td class="adminlabel">Products</td>
			
				    <td class="adminitem">
                        <asp:CheckBoxList ID="chkProducts" runat="server" RepeatColumns="2">
                        </asp:CheckBoxList></td>
				
				</tr>
				<tr>
					<td>
					<asp:Button id="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton"></asp:Button>&nbsp;
					<input type="button" onclick="location.href='admin_promos.aspx'" value="Return" class="frmbutton"/>
					</td>
					
					<td align="right">
                        &nbsp;<asp:Button id="btnDelete" runat="server" CausesValidation="False" Text="Delete" OnClick="btnDelete_Click" CssClass="frmbutton"></asp:Button></td>
				</tr>				
				
			</table>
			</asp:panel>
			<script type="text/ecmascript">
			function CheckDelete(){
					
				return confirm("Delete this record? This action cannot be undone...");

			}

			</script>
</div>
</asp:Content>

