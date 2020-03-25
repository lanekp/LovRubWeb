<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Products.aspx.cs" Inherits="Admin_Admin_Products" Title="Product Administration" %>
<%@ Register Src="../Modules/ImageManager.ascx" TagName="ImagePicker" TagPrefix="uc2" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
<div id="centercontent">
        <h4>Products</h4>
		<asp:GridView id="dg" runat="server" DataSourceID="ObjectDataSource1"  AutoGenerateColumns="False" AllowPaging="True" PageSize="50" Width="803px">
			<Columns>

			<asp:BoundField DataField="ProductID" SortExpression="ProductID" HeaderText="ProductID"  Visible="False"></asp:BoundField>
            <asp:TemplateField HeaderText="Product">
            
                <ItemTemplate>
                    <a href="admin_product_details.aspx?id=<%#Eval("productID")%>"><%#Eval("ProductName")%></a>
                </ItemTemplate>
            
            </asp:TemplateField>
			<asp:BoundField DataField="SKU" SortExpression="SKU" HeaderText="SKU" ></asp:BoundField>

			<asp:BoundField DataField="Status" HeaderText="Status" ItemStyle-CssClass="rightAlign"></asp:BoundField>
			<asp:BoundField DataField="ProductType" HeaderText="Product Type" ItemStyle-CssClass="rightAlign"></asp:BoundField>
			<asp:BoundField DataField="OurPrice" SortExpression="OurPrice" HeaderText="Our Price" DataFormatString="{0:C}" HtmlEncode="false" ItemStyle-CssClass="rightAlign"></asp:BoundField>
			<asp:BoundField DataField="RetailPrice" SortExpression="RetailPrice" HeaderText="Retail Price" DataFormatString="{0:C}" HtmlEncode="false" ItemStyle-CssClass="rightAlign"></asp:BoundField>
			<asp:BoundField DataField="ListOrder" SortExpression="ListOrder" HeaderText="List Order" ItemStyle-CssClass="rightAlign"></asp:BoundField>
		</Columns>
		<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="#C6C3C6"></PagerStyle>
	</asp:GridView>
	<BR>
	
	<input type="button" onclick="location.href='admin_product_add.aspx'" value="Add" id="Button1" class="frmbutton" />
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll"
        TypeName="ProductController"></asp:ObjectDataSource>
    <br />
</div>

</asp:Content>

