<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductCategories.ascx.cs"
	Inherits="Modules_Admin_ProductCategories" %>
<table class="admintable">
	<tr>
		<td>
			<h4>
				Categories</h4>
		</td>
	</tr>
	<tr valign="top">
		<td>
			<asp:Label ID="lblID" runat="server" Visible="False"></asp:Label>
			<asp:DropDownList ID="ddlCats" runat="server" CssClass="adminitem" />
			<asp:Button ID="btnCats" runat="server" Text="Add" OnClick="btnCats_Click" CssClass="frmbutton" />
		</td>
	</tr>
	<tr>
		<td>
			<asp:DataGrid ID="dgCats" runat="server" Width="500px" BorderColor="White" BorderWidth="0px"
				AutoGenerateColumns="False" OnDeleteCommand="DeleteCat">
				<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="Gainsboro"></SelectedItemStyle>
				<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" ForeColor="Black"
					BackColor="LightSteelBlue"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="categoryID" HeaderText="ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="CategoryName" HeaderText="Category"></asp:BoundColumn>
					<asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" Text="Delete"></asp:ButtonColumn>
				</Columns>
			</asp:DataGrid>
		</td>
	</tr>
</table>
