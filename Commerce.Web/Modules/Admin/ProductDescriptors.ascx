<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductDescriptors.ascx.cs"
	Inherits="Modules_Admin_ProductDescriptors" %>
<asp:Label ID="lblProductID" runat="server" Visible="false"></asp:Label>
<table class="admintable">
	<tr>
		<td>
			<h4>
				Descriptors</h4>
		</td>
	</tr>
	<tr>
		<td class="adminlabel">
			Decriptive Sections
		</td>
		<td class="adminitem" style="width: 475px">
			<asp:Repeater ID="rptDescriptors" runat="server" OnItemCommand="DeleteDescriptor">
				<ItemTemplate>
					<table width="100%" cellspacing="0">
						<tr bgcolor="whitesmoke">
							<td width="20">
								<asp:Label ID="lblDescriptorID" runat="server" Text='<%#Eval("descriptorID") %>'
									Visible="false"></asp:Label>
								<asp:ImageButton ID="imgSave" runat="server" ImageUrl="~/images/icons/icon_disk.gif"
									CommandName="Save" CommandArgument='<%#Eval("descriptorID") %>' /></td>
							<td width="90%">
								<b>
									<%#Eval("title") %>
								</b>&nbsp;<asp:CheckBox ID="chkIsBulletedList" runat="server" Checked='<%#(bool)Eval("isBulletedList") %>'
									Text="Is Bulleted List" />
								&nbsp;&nbsp;<b>List Order:</b>&nbsp;<asp:TextBox ID="txtDescriptorListOrder" runat="server"
									Text='<%#Eval("listOrder")%>' Width="20px"></asp:TextBox>
							</td>
							<td align="right">
								<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/icons/delete.gif"
									CommandName="Delete" CommandArgument='<%#Eval("descriptorID") %>' /></td>
							</td>
						</tr>
						<tr>
							<td colspan="4">
								<asp:TextBox ID="txtDescriptor" runat="server" TextMode="MultiLine" Height="100px"
									Width="500px" Text='<%#Eval("descriptor")%>'></asp:TextBox>
							</td>
						</tr>
					</table>
				</ItemTemplate>
			</asp:Repeater>
		</td>
	</tr>
	<tr>
		<td class="adminlabel">
			Add a Descriptive Section</td>
		<td class="adminitem" style="width: 475px">
			List Order<br />
			<asp:TextBox ID="txtDescriptorListOrder" runat="server" Width="28px">1</asp:TextBox><br />
			Title<br />
			<asp:TextBox ID="txtDescriptorTitle" runat="server" Width="328px"></asp:TextBox>
			<asp:CheckBox ID="chkIsBulletedList" runat="server" Text="Is Bulleted List" /><br />
			<br />
			Text/List<br />
			<asp:TextBox ID="txtDescriptor" runat="server" TextMode="MultiLine" Height="123px"
				Width="500px"></asp:TextBox>
			<br />
		</td>
	</tr>
	<tr>
		<td>
		</td>
		<td>
				<asp:Button ID="btnSaveDescriptor" runat="server" Text="Save" OnClick="btnSaveDescriptor_Click" CssClass="frmbutton" />
		</td>
	</tr>

</table>
