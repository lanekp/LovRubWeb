<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeedBackDisplay.ascx.cs"
	Inherits="Modules_Products_FeedBackDisplay" %>
<%@ Register Src="RatingDisplay.ascx" TagName="RatingDisplay" TagPrefix="uc7" %>
<fieldset>
	<legend><b>Tell us what you think</b></legend>
	<div class="tenpixspacer">
	</div>
	<uc7:RatingDisplay ID="RatingDisplay1" runat="server" />
	<div class="twentypixspacer">
	</div>
	<hr />
	Please take a moment to add you review.
	<div class="tenpixspacer">
	</div>
	<%if(Page.User.Identity.IsAuthenticated) { %>
	<a href="#" onclick="showPopWin('<%=Page.ResolveUrl("~/members/productreview.aspx")%>?id=<%=ProductID.ToString() %>&pn=<%=ProductName.Replace("\"","").Replace("'","") %>',650,500,null)">
		<b>Review it!</b></a>
	<%}
					else { %>
	<a href="<%=Page.ResolveUrl("~/login.aspx") %>?ReturnUrl=product.aspx?id=<%=ProductID.ToString() %>">
		<b>Review it!</b></a>
	<%} %>
</fieldset>
