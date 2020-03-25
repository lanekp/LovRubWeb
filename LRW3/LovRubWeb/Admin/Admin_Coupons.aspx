<%@ Page Language="C#" Theme="Admin" StylesheetTheme="Admin" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_Coupons.aspx.cs" Inherits="Admin_Admin_Coupons" Title="Coupon Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
    <div id="centercontent"> 
        <h4>Coupons</h4>
		<asp:datagrid id="dg" runat="server" CellPadding="3" GridLines="None" 
			BorderColor="White" BorderWidth="0px" BorderStyle="Solid" BackColor="White" AutoGenerateColumns="False"
			AllowSorting="True" ForeColor="Black" Font-Names="Verdana" Font-Size="8pt" OnItemCommand="dg_ItemCommand">
			<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="Gainsboro"></SelectedItemStyle>
			<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
			<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
			<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="LightSteelBlue"></HeaderStyle>
			<Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CausesValidation="false" CommandName="EditCoupon" Text="Edit" CommandArgument='<%#Eval("CouponCode") %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
			  <asp:BoundColumn DataField="CouponCode" HeaderText="Code"></asp:BoundColumn>
			  <asp:TemplateColumn HeaderText="Class Type">
			    <ItemTemplate>
			    <%# Eval("CouponClassType")%>
			   </ItemTemplate> 
			  </asp:TemplateColumn>
			   <asp:BoundColumn DataField="ExpirationDate" HeaderText="Expires" DataFormatString="{0:d}" ></asp:BoundColumn> 
			  <asp:BoundColumn DataField="IsSingleUse" HeaderText="Single Use"></asp:BoundColumn> 
			  <asp:BoundColumn DataField="NumberOfUses" HeaderText="# of Uses"></asp:BoundColumn>
			</Columns>
		</asp:datagrid>
        <br />
        Create New:
        <asp:DropDownList ID="ddlCouponTypes" runat="server" Width="386px" DataTextField="Description" DataValueField="CouponTypeId"> 
        </asp:DropDownList>
        <asp:Button ID="createCoupon" runat="server" Text="Create" OnClick="createCoupon_Click" /><br />
        <br />
		<asp:Panel ID="editCouponPanel" runat="server" Visible="False">
		</asp:Panel>
		</div>
</asp:Content>

