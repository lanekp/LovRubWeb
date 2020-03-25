<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MastHead.ascx.cs" Inherits="LovRubWeb.Controls.WebParts.MastHead" %>
<div class="masthead">
	
	<!--
	<a href="/" class="logonorm" title="LovRub - his/her's sexual stimulation gel"></a>
	<a href="Wholesalers.aspx" class="wholesalerslink" title="Wholesalers buy LovRub">Wholesalers</a>
	-->
	
	<asp:HyperLink runat="server" 
	               CssClass="logonorm" 
	               ToolTip="LovRub - his/her's sexual stimulation gel" 
	               NavigateUrl="~/Default.aspx">
    </asp:HyperLink>
	
	<asp:HyperLink runat="server"
	               CssClass="viewcartlink"
	               tooltip="View My Cart"
	               NavigateUrl="~/BasketLV3.aspx">
	               View My Cart
	</asp:HyperLink>
	
	
	<asp:HyperLink runat="server" 
	               CssClass="wholesalerslink" 
	               ToolTip="Wholesalers buy LovRub" 
	               NavigateUrl="~/Wholesalers.aspx">Wholesalers
    </asp:HyperLink>
</div>