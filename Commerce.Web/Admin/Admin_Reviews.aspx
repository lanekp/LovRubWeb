<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Reviews.aspx.cs" Inherits="Admin_Admin_Reviews" Title="Product Reviews Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
    
    <div id="centercontent">
    <h4>Product Reviews</h4>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ReviewID" DataSourceID="SqlDataSource1" PageSize="20" EmptyDataText="No Reveiws..">
            <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="ProductID,ReviewID,productName" DataNavigateUrlFormatString="admin_productreviews.aspx?p={0}&amp;r={1}&amp;pn={2}"
                HeaderText="View" DataTextField="Title" >
                <ItemStyle HorizontalAlign="Left" />
            </asp:HyperLinkField>  
                <asp:BoundField DataField="ProductName" HeaderText="Product" SortExpression="Rating"  ReadOnly="True" />
      
                <asp:BoundField DataField="PostDate" HeaderText="PostDate" 
                SortExpression="PostDate"  ReadOnly="True" DataFormatString="{0:d}" HtmlEncode="False" />
                <asp:BoundField DataField="AuthorName" HeaderText="AuthorName" SortExpression="AuthorName"  ReadOnly="True" />
                <asp:BoundField DataField="Rating" HeaderText="Rating" SortExpression="Rating"  ReadOnly="True" />
                <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" SortExpression="IsApproved" />
            </Columns>
        </asp:GridView>
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CommerceTemplate %>"
            SelectCommand="SELECT 
            CSK_Store_ProductReview.ReviewID, 
            CSK_Store_ProductReview.ProductID, 
            CSK_Store_ProductReview.Title, 
            CSK_Store_ProductReview.Body, 
            CSK_Store_ProductReview.PostDate, 
            CSK_Store_ProductReview.AuthorName, 
            CSK_Store_ProductReview.Rating, 
            CSK_Store_ProductReview.IsApproved, 
            CSK_Store_Product.productName FROM CSK_Store_ProductReview INNER JOIN CSK_Store_Product
             ON CSK_Store_ProductReview.ProductID = CSK_Store_Product.productID"></asp:SqlDataSource>
    </div>
</asp:Content>



