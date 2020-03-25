<%@ Page ValidateRequest="false" Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true"
	CodeFile="Admin_Categories.aspx.cs" Inherits="Admin_Admin_Categories" Title="Categories Administration" %>

<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc2" %>
<%@ Register Src="../Modules/ImageManager.ascx" TagName="ImagePicker" TagPrefix="uc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" runat="Server">
  <asp:ScriptManager runat="server" EnablePartialRendering="true" ID="scriptManager">
  </asp:ScriptManager >

     <asp:UpdatePanel ID="WizUpdatePanel" runat="server" UpdateMode="Conditional" >
     <ContentTemplate> 
	<div id="centercontent">
		<h4>
			Product Categories</h4>
	       <table width="90%">
			<tr>
				<td valign="top">
				<table>
				    <tr>
				        <td>
				        Select a Category:<br />
                            <br />
                            &nbsp;<asp:ListBox ID="lstCats" runat="server" Width="190px" AutoPostBack="True" Height="325px" 
                            OnSelectedIndexChanged="lstCats_SelectedIndexChanged"></asp:ListBox></td>
				        <td></td>
				    </tr>
				    <tr>
				        <td><asp:TextBox ID="txtCatNew" runat="server" Width="182px"></asp:TextBox></td>
				        <td><asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"
						CssClass="frmbutton" /></td>
				    </tr>
				</table>
                <br />
					
				</td>
				<td>
					<table class="admintable" cellpadding="5" cellspacing="0">
						<tr>
							<td class="adminlabel">
								ID</td>
							<td class="adminitem">
								<asp:Label ID="lblID" runat="server" Text=""></asp:Label>
								<uc2:ResultMessage ID="ResultMessage1" runat="server" />
							</td>
						</tr>
						<tr>
							<td class="adminlabel">
                                Parent Category</td>
							<td class="adminitem">
                                <asp:DropDownList ID="ddlParentID" runat="server">
                                </asp:DropDownList></td>
						</tr>
						<tr>
							<td class="adminlabel">
								Category Name</td>
							<td class="adminitem">
								<asp:TextBox ID="txtCategoryName" runat="server" Width="353px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="adminlabel">
								Image</td>
							<td class="adminitem">
								&nbsp;<uc1:ImagePicker ID="ImagePicker1" runat="server" ImageFolder="images/pageheaders" />
							</td>
						</tr>
						<tr>
							<td class="adminlabel">
								Short Description</td>
							<td class="adminitem">
								<asp:TextBox ID="txtShortDescription" runat="server" TextMode="MultiLine" Height="100px"
									Width="400px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="adminlabel">
								Long Description</td>
							<td class="adminitem">
								<asp:TextBox ID="txtLongDescription" runat="server" MaxLength="2500" Height="297px" TextMode="MultiLine" Width="400px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="adminlabel">
								List Order</td>
							<td class="adminitem">
								<ew:NumericBox ID="txtListOrder" runat="server" Width="24px"></ew:NumericBox>
							</td>
						</tr>
						<tr>
							<td>
								<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton">
								</asp:Button>&nbsp;
							</td>
							<td align="right">
								&nbsp;<asp:Button ID="btnDelete" runat="server" CausesValidation="False" Text="Delete"
									OnClick="btnDelete_Click" CssClass="frmbutton"></asp:Button></td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</div>
    </asp:Panel>
    </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="uProgress" runat="server">
        <ProgressTemplate>
        <div class="loadingbox">
            <img src="../images/spinner.gif" align="absmiddle"/>&nbsp;&nbsp;<asp:Label ID="lblProgress" runat="server">Processing...</asp:Label>
        </div>
        </ProgressTemplate>
     </asp:UpdateProgress> 

	<script type="text/ecmascript">
	function CheckDelete(){
			
		return confirm("Delete this record? This action cannot be undone...");

	}

	</script>

</asp:Content>
