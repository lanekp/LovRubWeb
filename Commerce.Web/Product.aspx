<%@ Page Trace="false" Language="C#" CodeFile="Product.aspx.cs" Inherits="_Product" MasterPageFile="~/site.master" AutoEventWireup="true" Title="Product Detail" %>
<%@ Register Src="Modules/Products/FeedBackDisplay.ascx" TagName="FeedBackDisplay"
    TagPrefix="uc2" %>

<%@ Register Src="Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc1" %>

<%@ Register Src="Modules/Products/ProductDescriptorDisplay.ascx" TagName="ProductDescriptorDisplay"
    TagPrefix="uc8" %>

<%@ Register Src="Modules/Products/RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="uc7" %>

<%@ Register Src="Modules/Products/ProductTopDisplay.ascx" TagName="ProductTopDisplay"
    TagPrefix="uc6" %>
<%@ Register Src="Modules/Products/BundleDisplay.ascx" TagName="BundleDisplay"
    TagPrefix="uc6" %>
<%@ Register Src="Modules/Products/ReviewDisplay.ascx" TagName="ReviewDisplay"
    TagPrefix="uc6" %>
<%@ Register Src="Modules/Products/AttributeSelection.ascx" TagName="AttributeSelection"
    TagPrefix="uc5" %>
<%@ Register Namespace="Commerce.Web.UI.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--left menu-->
    <div id="leftcontent">
        <uc2:FeedBackDisplay id="FeedBackDisplay1" runat="server"></uc2:FeedBackDisplay>
        <div class="tenpixspacer"></div>
        <uc1:MainNavigation ID="MainNavigation1" runat="server" />
    </div>
    <!--end left menu-->
    <div id="centercontent">
		<div id="body1">
            <uc6:ProductTopDisplay id="ProductTopDisplay1" runat="server"></uc6:ProductTopDisplay>
            <uc6:BundleDisplay id="BundleDisplay1" runat="server"></uc6:BundleDisplay>
            <uc8:ProductDescriptorDisplay ID="ProductDescriptorDisplay1" runat="server" />
            <uc6:ReviewDisplay id="ReviewDisplay1" runat="server"></uc6:ReviewDisplay>
        </div>
    </div>
    <div id="rightcontent">

        <div class="coreboxtop"></div>
        <div class="coreboxheader">Ready To Buy?</div>
        <div class="coreboxbody">
            Checkout is fast, easy, and secure. You have a choice
            of checking out through this site, or using PayPal's 
            checkout features.
            <div class="tenpixspacer"></div>
            <hr />
            <ew:numericbox id="txtAddQty" runat="server" maxlength="2" text="1" width="15px"></ew:numericbox>
            <asp:ImageButton ID="btnAddToCart" runat="server" SkinID="AddToCart" OnClick="AddToCart_Click" ImageAlign="AbsMiddle" />                 
        </div>
        <div class="coreboxbottom"></div>
        <br class="clear" />
        <%-- 
        /////////////////////////////////
        // Change for QtyDiscount
        --%>
        <asp:Panel ID="pnlQtyDiscounts" runat="server" Visible="false">
            <table width="174" cellpadding="0" cellspacing="0">
               <tr><td style=" padding-left:5px;"><b> Volume Discount</b></td></tr>
               <tr>
                   <td style="text-align:center; padding:5px;  padding-top:0px;"><br />
                       <table cellpadding="0" cellspacing="0" style="border:1px solid #cccccc; border-bottom:0px;">
                           <tr>
                               <td style="background-color:#F1F1F1; font-size:8px; padding:5px; border-bottom:1px solid #cccccc; border-right:1px solid #cccccc;"><b>Qty</b></td>
                               <td style="background-color:whitesmoke; font-size:8px; padding:5px; border-bottom:1px solid #cccccc; border-right:1px solid #cccccc;"><b>Discount</b></td>
                               <td style="font-size:8px; padding:5px; border-bottom:1px solid #cccccc; text-align:right; color:red;"><b>Price</b></td>
                            </tr>
                            <asp:Literal ID="litQtyDiscounts" runat="server"></asp:Literal>  
                       </table>
                   </td>
               </tr>
            </table>
            <table width="174" cellpadding="0" cellspacing="0">
               <tr>
                   <td style="padding:15px; padding-top:0px; font-size:9px;">
                       <i>Note: Quantity discounts <br />shown above will be <br />automatically applied to your <br />order.<br /></i>
                   </td>
               </tr>
            </table><br />
        </asp:Panel>
        <%-- 
        /////////////////////////////////
        --%>
    </div>

</asp:Content>

