<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductQtyDiscounts.ascx.cs" Inherits="Modules_Admin_ProductQtyDiscounts" %>

<table cellpadding="0" cellspacing="0" style="width:504px; border:1px solid #cccccc; background-color:#f1f1f1; padding:5px; margin-bottom:8px;">
    <tr>
        <td nowrap="nowrap" style="white-space:nowrap; padding-left:10px; padding-top:8px; width:60px;">
            <asp:ImageButton ID="btnAddQtyDiscount" runat="server" OnClick="AddQtyDiscount" ImageUrl="~/images/icons/add.gif" ImageAlign="AbsMiddle" AlternateText="Add Volume Discount" />
        </td>
        <td nowrap="nowrap" style="white-space:nowrap;">quantity </td>
        <td style="padding:5px; padding-right:78px;"><asp:TextBox ID="txtNewQuantity" runat="server" Width="25"></asp:TextBox></td>
        <td nowrap="nowrap" style="white-space:nowrap;">Discount </td>
        <td style="padding:5px; padding-right:76px;"><asp:TextBox ID="txtDiscount" runat="server" Width="25"></asp:TextBox></td>
        <td nowrap="nowrap" style="white-space:nowrap; padding-right:108px;"><asp:CheckBox ID="chkIsPercent" runat="server" Checked="true" /> IsPercent</td>
        <td nowrap="nowrap" style="white-space:nowrap; padding-right:95px;"><asp:CheckBox ID="chkIsActive" runat="server" Checked="true" /> IsActive</td>
    </tr>
</table>  
<asp:DataGrid ID="dgDiscount" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="false"
OnDeleteCommand="removeSelection" 
OnEditCommand="editSelection"
OnUpdateCommand="updateSelection"
OnCancelCommand="cancelSelection">
    <Columns>
        <asp:TemplateColumn ItemStyle-Width="20">
            <ItemTemplate>
                <asp:ImageButton ID="lnkDelete" runat="server" CommandName="Delete" ImageUrl="~/images/icons/delete.gif" AlternateText="Delete" />
            </ItemTemplate>
        </asp:TemplateColumn>
        <asp:EditCommandColumn ItemStyle-Width="40" EditText="&lt;img src='../images/icons/edit.gif' alt='Edit' /&gt;" UpdateText="&lt;img src='../images/icons/icon_check.gif' alt='Update' /&gt;" CancelText="&lt;img src='../images/icons/restore.gif' alt='Cancel' /&gt;"></asp:EditCommandColumn>
        <asp:BoundColumn DataField="discountID" HeaderText="ID" Visible="false" ReadOnly="true" />
        <asp:BoundColumn DataField="quantity" HeaderText="quantity" />
        <asp:BoundColumn DataField="Discount" HeaderText="Discount" />
        <asp:TemplateColumn HeaderText="IsPercent">
            <ItemTemplate><asp:CheckBox runat="server" ID="IsPercent" Checked='<%# Eval("isPercent") %>' Enabled="false" /></ItemTemplate>
            <EditItemTemplate><asp:CheckBox runat="server" ID="IsPercent" Checked='<%# Eval("isPercent") %>' /></EditItemTemplate>
        </asp:TemplateColumn>
        <asp:TemplateColumn HeaderText="IsActive">
            <ItemTemplate><asp:CheckBox runat="server" ID="IsActive" Checked='<%# Eval("isActive") %>' Enabled="false" /></ItemTemplate>
            <EditItemTemplate><asp:CheckBox runat="server" ID="IsActive" Checked='<%# Eval("isActive") %>' /></EditItemTemplate>
        </asp:TemplateColumn>
    </Columns>
</asp:DataGrid>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
ConnectionString="<%$ ConnectionStrings:CommerceTemplate %>" 
DeleteCommand="DELETE FROM CSK_Store_Product_QtyDiscount WHERE (discountID = @discountID)" 
InsertCommand="INSERT INTO CSK_Store_Product_QtyDiscount(ProductId, quantity, discount, isPercent, IsActive) VALUES (@ProductId, @quantity, @discount, @isPercent, @IsActive)" 
SelectCommand="SELECT discountID, quantity, discount, isPercent, IsActive FROM CSK_Store_Product_QtyDiscount WHERE (ProductId = @ProductId) ORDER BY quantity ASC" 
UpdateCommand="UPDATE CSK_Store_Product_QtyDiscount SET quantity = @quantity, discount = @discount, isPercent = @isPercent, IsActive = @IsActive WHERE (discountID = @discountID)">
    <DeleteParameters>
        <asp:Parameter Name="discountID" />
    </DeleteParameters>
    <UpdateParameters>
        <asp:Parameter Name="quantity" />
        <asp:Parameter Name="discount" />
        <asp:Parameter Name="isPercent" />
        <asp:Parameter Name="isActive" />
        <asp:Parameter Name="discountID" />
    </UpdateParameters>
    <SelectParameters>
        <asp:QueryStringParameter DefaultValue="" Name="productID" QueryStringField="id" />
    </SelectParameters>
    <InsertParameters>
        <asp:Parameter Name="productID" />
        <asp:Parameter Name="quantity" />
        <asp:Parameter Name="discount" />
        <asp:Parameter Name="isPercent" />
        <asp:Parameter Name="isActive" />
    </InsertParameters>
</asp:SqlDataSource>