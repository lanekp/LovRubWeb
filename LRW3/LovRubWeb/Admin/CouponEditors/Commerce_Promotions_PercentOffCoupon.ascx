<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Commerce_Promotions_PercentOffCoupon.ascx.cs" Inherits="Admin_CouponEditors_Commerce_Promotions_PercentOffCoupon" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>

<table class="admintable" cellpadding="5" cellspacing="0">
    <tr>
        <td class="adminlabel">
            Coupon Code</td>
        <td class="adminitem">
            <asp:TextBox ID="txtCouponCode" runat="server" Text=""></asp:TextBox>
            <asp:RequiredFieldValidator ID="couponCodeValidator" runat="server" ControlToValidate="txtCouponCode"
                Display="Dynamic" ErrorMessage="A Coupon Code is required">*</asp:RequiredFieldValidator>
            <asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" CausesValidation="False" /></td>
    </tr>
    <tr>
        <td class="adminlabel">
            # of Uses</td>
        <td class="adminitem">
            <asp:Label ID="lblNumUses" runat="server" Text="" Width="300px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="adminlabel">
            Is Single Use</td>
        <td class="adminitem">
            <asp:CheckBox ID="chkIsSingleUse" runat="server" Text="" Width="300px"></asp:CheckBox>
        </td>  
    </tr>
   <tr>
        <td class="adminlabel">
            Expiration Date</td>
        <td class="adminitem"> 
            <ew:CalendarPopup ID="txtExpirationDate" runat="server">
            </ew:CalendarPopup>
        </td>  
    </tr> 
   <tr>
        <td class="adminlabel">
            Percent Off Order</td>
        <td class="adminitem">
            <ew:NumericBox ID="txtDiscount" runat="server" DecimalPlaces="0" Width="50px">0</ew:NumericBox>
            <asp:RequiredFieldValidator ID="discountValidator" runat="server" ControlToValidate="txtDiscount"
                Display="Dynamic" ErrorMessage="A percentage off is required" ValidationGroup="CouponEdit">*</asp:RequiredFieldValidator></td>  
    </tr> 

    <tr>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="CouponEdit">
            </asp:Button>&nbsp;
             <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" >
            </asp:Button>&nbsp;
       </td>
        <td align="left">
            &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="The coupon could not be saved due to the following errors:"
                ValidationGroup="CouponEdit" />
        </td>
    </tr>
</table>
