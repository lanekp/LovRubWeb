<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Bundles.aspx.cs" Inherits="Admin_Admin_Bundles" Title="Bundles Administration" %>
<%@Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew"%>
<%@Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1"%>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>


<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">

        <h4>Product Bundles</h4>
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
						<asp:BoundColumn DataField="BundleID" HeaderText="BundleID"  Visible="false"></asp:BoundColumn>
						<asp:BoundColumn DataField="BundleName" HeaderText="BundleName" ></asp:BoundColumn>
						<asp:BoundColumn DataField="DiscountPercent" HeaderText="DiscountPercent" ></asp:BoundColumn>
						<asp:BoundColumn DataField="Description" HeaderText="Description" ></asp:BoundColumn>
						<asp:BoundColumn DataField="CreatedOn" HeaderText="DateCreated" ></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
				</asp:datagrid>
				<br />
				<asp:button id="cmdAdd"  runat="server" OnClick="btnAdd_Click" CausesValidation="False" Text="Add" CssClass="frmbutton"></asp:button>
			</asp:panel>
			<asp:panel id="pnlEdit" Runat="server">
			<uc1:ResultMessage ID="uResult" runat="server" EnableViewState="false" />	
			<table class="admintable" cellpadding="5" cellspacing="0">
				<tr id="trID" runat="server">
					<td class="adminlabel">ID</td>
					<td class="adminitem"><asp:label id="lblID" runat="server" /></td>
				</tr>
				<tr>
					<td class="adminlabel">
                        Bundle Name</td>
					<td class="adminitem">
						<asp:textbox id="txtBundleName" runat="server" width="200px"></asp:textbox>
					</td>
				</tr>
				
				<tr>
					<td class="adminlabel">
                        Discount Percent</td>
					<td class="adminitem">
                        <asp:TextBox ID="txtDiscountPercent" runat="server" MaxLength="3" Width="26px">0</asp:TextBox>%
                        <br />
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtDiscountPercent"
                            Display="Dynamic" ErrorMessage="Invalid Percentage" MaximumValue="100" MinimumValue="0"
                            Type="Integer"></asp:RangeValidator></td>
				</tr>
				
				<tr>
					<td class="adminlabel">Description</td>
					<td class="adminitem">
						<asp:textbox id="txtDescription" runat="server" TextMode="MultiLine" Height="100px" Width="400px"></asp:textbox>
					</td>
				</tr>
				<%if (lblID.Text != string.Empty)
      { %>
                <tr>
                    <td class="adminlabel">
                        Products</td>
                    <td class="adminitem">
            			<ajax:AjaxPanel ID="Ajaxpanel" runat="server">
                        <table>
                            <tr>
                                <td><b>SKU</b></td>
                                <td><b>Product</b></td>
                                <td></td>
                            </tr>
                        <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="DeleteBundle">
                            <ItemTemplate>
                            <tr>
                                <td>
                                <asp:Label ID="lblProductID" runat="server" Visible="false" Text='<%#Eval("productID") %>'></asp:Label>
                                <%#Eval("sku") %></td>
                                <td><%#Eval("productName") %></td>
                                <td><asp:LinkButton ID="lnkDel" runat="server" Text="Remove"></asp:LinkButton></td>
                            </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        </table>
                        <asp:DropDownList ID="ddlAddProductID" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="btnAddProduct" runat="server" OnClick="btnAddProduct_Click" Text="Add Product" />
                        </ajax:AjaxPanel>
                       </td>
                </tr>
				<%}%>
					
				<tr>
					<td>
					<asp:Button id="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton"></asp:Button>&nbsp;
					<input type="button" onclick="location.href='<%=Request.Url.PathAndQuery%>'" value="Return" class="frmbutton" />
					</td>
					
					<td align="right"><asp:Button id="btnDelete" runat="server" CausesValidation="False" Text="Delete" OnClick="btnDelete_Click" CssClass="frmbutton"></asp:Button></td>
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

