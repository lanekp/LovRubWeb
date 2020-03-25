<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" Title="Manufacturer Administration" %>

<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" runat="Server">
	<div id="centercontent">
   <h4>Manufacturers</h4>

		<asp:Label ID="lblError" runat="server"></asp:Label>
		<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="manufacturerID"
			DataSourceID="SqlDataSource1">
			<Columns>
				<asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
				<asp:BoundField DataField="manufacturerID" HeaderText="ID" InsertVisible="False"
					ReadOnly="True" SortExpression="manufacturerID" />
				<asp:BoundField DataField="manufacturer" HeaderText="Manufacturer" SortExpression="manufacturer" />
			</Columns>
		</asp:GridView>
		<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ConnectionStrings:CommerceTemplate%>"
			DeleteCommand="DELETE FROM [CSK_Store_Manufacturer] WHERE [manufacturerID] = @manufacturerID"
			InsertCommand="INSERT INTO [CSK_Store_Manufacturer] ([manufacturer]) VALUES (@manufacturer)"
			ProviderName="System.Data.SqlClient" SelectCommand="SELECT [manufacturerID], [manufacturer] FROM [CSK_Store_Manufacturer]"
			UpdateCommand="UPDATE [CSK_Store_Manufacturer] SET [manufacturer] = @manufacturer WHERE [manufacturerID] = @manufacturerID">
			<DeleteParameters>
				<asp:Parameter Name="manufacturerID" Type="Int32" />
			</DeleteParameters>
			<UpdateParameters>
				<asp:Parameter Name="manufacturer" Type="String" />
				<asp:Parameter Name="manufacturerID" Type="Int32" />
			</UpdateParameters>
			<InsertParameters>
				<asp:Parameter Name="manufacturer" Type="String" />
			</InsertParameters>
		</asp:SqlDataSource>
		<br />
		<br />
		<h5>
			Add a Manufacturer</h5>
		<asp:TextBox ID="txtNewMan" runat="server"></asp:TextBox>
		<asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="AddManufacturer" CssClass="frmbutton" />
	</div>

	<script runat="server">
		void AddManufacturer(object sender, System.EventArgs e) {
			if(txtNewMan.Text.Trim() != string.Empty) {
				SqlDataSource1.InsertParameters["manufacturer"].DefaultValue = txtNewMan.Text;
				SqlDataSource1.Insert();
				Response.Redirect(Request.Url.PathAndQuery, false);
			}
		}
		protected void Page_Load(object sender, EventArgs e) {
			Page.Error += new EventHandler(Page_Error);
		}

		void Page_Error(object sender, EventArgs e) {
			Server.Transfer("admin_reference_error.aspx");
		}

	</script>

</asp:Content>
