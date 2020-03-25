<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Logs.aspx.cs" Inherits="Admin_Admin_Logs" Title="View Site Logs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">

    <div id="centercontent">
        <h4>Site Logs</h4>
        These logs represent all user activity on the site. For Application Logs, check the Event Viewer (or whichever
        Log Source is specified in the site configuration).
        <br />
        
        <br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" PageSize="10" Width="650px">
            <Columns>
                <asp:BoundField DataField="createdOn" HeaderText="Date" SortExpression="createdOn" 
                DataFormatString="{0:d}" HtmlEncode="False"/>
                <asp:BoundField DataField="userName" HeaderText="User" SortExpression="userName" />
                <asp:BoundField DataField="behavior" HeaderText="Behavior" SortExpression="behavior" />
                <asp:BoundField DataField="pageURL" HeaderText="Page" SortExpression="pageURL" />
                <asp:BoundField DataField="categoryName" HeaderText="Product Category" SortExpression="categoryName" />
                <asp:BoundField DataField="productName" HeaderText="Product" SortExpression="productName" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CommerceTemplate %>"
            SelectCommand="SELECT CSK_Stats_Tracker.createdOn, CSK_Stats_Tracker.userName, 
            CSK_Stats_Behavior.behavior, CSK_Stats_Tracker.pageURL, 
            CSK_Store_Category.categoryName, 
            CSK_Store_Product.productName 
            FROM CSK_Stats_Tracker 
            INNER JOIN CSK_Stats_Behavior 
            ON CSK_Stats_Tracker.behaviorID = CSK_Stats_Behavior.behaviorID 
            LEFT OUTER JOIN CSK_Store_Category 
            ON CSK_Stats_Tracker.categoryID = 
            CSK_Store_Category.categoryID 
            LEFT OUTER JOIN CSK_Store_Product ON 
            CSK_Stats_Tracker.productSKU = 
            CSK_Store_Product.sku ORDER BY 
            CSK_Stats_Tracker.createdOn DESC">
        </asp:SqlDataSource>
        <br />
        
    </div>

</asp:Content>

