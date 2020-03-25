<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductImages.ascx.cs"
	Inherits="Modules_Admin_ProductImages" %>
<%@ Register Src="../ImageManager.ascx" TagName="ImagePicker" TagPrefix="uc2" %>
<table class="admintable">
	        <tr>
		<td>
			<h4>
				Images</h4>
		</td>
	</tr>
	<tr>
		<td class="adminlabel">
			<b>Select an Image:</b></td>
		<td class="adminitem">
			<uc2:imagepicker id="ImagePicker1" runat="server" imagefolder="images/productimages" />
		</td>
	        </tr>
	        <tr>
		<td class="adminlabel">
			Image Caption
		</td>
		<td class="adminitem">
			<asp:TextBox ID="txtNewImageCaption" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox></td>
	        </tr>
	        <tr>
		<td class="adminlabel">
			Image List Order</td>
		<td class="adminitem">
			<asp:TextBox id="txtNewImageListOrder" runat="server" width="34px" text="0"></asp:TextBox>
		</td>
	        </tr>
	        <tr>
		<td colspan="2">
			<asp:Button ID="btnSaveImage" runat="server" OnClick="btnSaveImage_Click" Text="Add Image" CssClass="frmbutton" /></td>
	        </tr>
	   </table>
        <br />
        <asp:Label ID="lblProductID" runat="server" Visible="False"></asp:Label><br />
        <table width="650" cellspacing="0" >
	    <asp:Repeater ID="rptImages" runat="server" OnItemCommand="DeleteImage">
	        <ItemTemplate>
                <tr>
				<td class="adminlabel" width="15">
					<b>
						<%#Eval("listorder") %>
					</b>
					<asp:Label ID="lblImageID" runat="server" Text='<%#Eval("imageID") %>' Visible="false"></asp:Label></td>
                    <td align="center">
					&nbsp;&nbsp;&nbsp;<img src="<%=Utility.GetSiteRoot()%>/<%#Eval("imagefile")%>"
						alt="<%#Eval("imagefile") %>" /><br />
					<i>
						<%#Eval("caption")%>
					</i>
                    </td>
				<td>
					<asp:Button ID="btnDelImage" runat="server" Text="Delete" CssClass="frmbutton" /></td>
                </tr>
	        </ItemTemplate>
	    </asp:Repeater>
</table>
