<%@ Page Language="C#" MasterPageFile="~/admin.master" AutoEventWireup="true" CodeFile="Admin_CouponTypes.aspx.cs" Inherits="Admin_Admin_CouponTypes" Title="Coupon Type Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
    <div id="centercontent"> 
        <h4>Coupon Types</h4>
		<asp:datagrid id="dg" runat="server" CellPadding="3" GridLines="None" 
			BorderColor="White" BorderWidth="0px" BorderStyle="Solid" BackColor="White" AutoGenerateColumns="False"
			AllowSorting="True" ForeColor="Black" Font-Names="Verdana" Font-Size="8pt" OnItemCommand="dg_ItemCommand" >
			<FooterStyle ForeColor="Black" BackColor="#C6C3C6"></FooterStyle>
			<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="Gainsboro"></SelectedItemStyle>
			<AlternatingItemStyle ForeColor="Black" BackColor="WhiteSmoke"></AlternatingItemStyle>
			<ItemStyle ForeColor="Black" BackColor="White"></ItemStyle>
			<HeaderStyle Font-Size="8pt" Font-Names="Verdana" Font-Bold="True" ForeColor="Black" BackColor="LightSteelBlue"></HeaderStyle>
			<Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" CausesValidation="false" 
                            CommandName="EditCouponType" Text="Edit" 
                            CommandArgument='<%# Eval("CouponTypeId") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
			    <asp:BoundColumn DataField="CouponTypeId" HeaderText="ID"></asp:BoundColumn>
			   <asp:BoundColumn DataField="Description" HeaderText="Description"></asp:BoundColumn> 
			  <asp:TemplateColumn HeaderText="Class Type">
			    <ItemTemplate>
			    <%# Eval("ProcessingClassName")%>
			   </ItemTemplate> 
			  </asp:TemplateColumn>
			</Columns>
		</asp:datagrid><br />
        <asp:Button ID="btnNewCouponType" runat="server" Text="New Coupon Type" OnClick="btnNewCouponType_Click" CssClass="frmbutton"/>
       <br /> 
        <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>
        <br />
        <asp:Panel ID="couponTypeEditPanel" runat="server" Visible="false">
            <table class="admintable" cellpadding="5" cellspacing="0">
                <tr>
                    <td class="adminlabel">
                        ID</td>
                    <td class="adminitem">
                        <asp:Label ID="lblID" runat="server" Text=""></asp:Label></td>
                </tr>
               <tr>
                    <td class="adminlabel">
                        Description</td>
                    <td class="adminitem">
                        <asp:TextBox ID="txtDescription" runat="server" Text="" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ControlToValidate="txtDescription" ErrorMessage="Description is required" Display="Dynamic" SetFocusOnError="True" ValidationGroup="CouponTypeEdit">*</asp:RequiredFieldValidator>
                    </td>
                </tr> 
               <tr>
                    <td class="adminlabel">
                        Class Name</td>
                    <td class="adminitem">
                        <asp:TextBox ID="txtClassName" runat="server" Text="" Width="300px"></asp:TextBox><br />
                        This should be entered as the full classname to your Coupon type, such as Commerce.Promotions.MyCouponType. If your type is in a different assembly,
                        make sure to reference that as well:  "Commerce.Promotions.MyCouponType, MyCouponAssembly"
                        <asp:RequiredFieldValidator ID="classNameValidator" runat="server" ControlToValidate="txtClassName" ErrorMessage="Class Name is required" ValidationGroup="CouponTypeEdit">*</asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtClassName"
                            ErrorMessage="Could not create the specified coupon type." OnServerValidate="CustomValidator1_ServerValidate"
                            SetFocusOnError="True" ValidationGroup="CouponTypeEdit">*</asp:CustomValidator></td>
                </tr>
                 <tr>
					<td><asp:Button id="btnSave"  runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="CouponTypeEdit" CssClass="frmbutton"></asp:Button>&nbsp;
					</td>
					
					<td align="left">&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="The coupon type could not be saved due to the following errors:"
                            ValidationGroup="CouponTypeEdit" />
                    </td>
				</tr> 
              </table> 
        </asp:Panel>
        
 
    </div>
</asp:Content>

