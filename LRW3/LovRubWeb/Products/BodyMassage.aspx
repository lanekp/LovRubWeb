<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="BodyMassage.aspx.cs" Inherits="LovRubWeb.Products.BodyMassage" Title="LovRub - Body Massage Gel" %>

<%@ Register Src="../Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead ID="MastHead1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
			
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    <ul class="submenu">
		<li class="large">Sexual Enhancement Gels
			<ul>
                <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Products/His.aspx">for Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>

		<li class="active"><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Valentines2010.aspx">LovRub&trade; Valentine's Delight</asp:HyperLink></li>
        
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <!-- <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox-Rublov.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li> -->
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <div class="rightcol lgphoto" style="background-image: url(http://www.lovrub.com/images/RubLov_NoType.jpg); height: 499px;">
		<div class="fancyproductinfo">
			<h1>It's All-Over Excitement</h1>
			<p>RubLov is a <span style="color: #e31705;">SEXUAL ENHANCEMENT MASSAGE GEL</span> for men and women:
			<ul style="color:#FFF;">
				<li><span style="color: #e31705;">ALL-NATURAL</span> ingredients.</li>
				<li>The ideal 'warm-up' for LovRub topical stimulant.</li>
				<li><span style="color: #e31705;">FEELS FABULOUS</span> all over.</li>
				<li>Provides deep-reaching <span style="color: #e31705;">EROTIC PLEASURE</span>.</li>
			</ul>
			
			</p>
			<p class="firstprice">$24.95</p>

			<!-- <p class="saleprice"><strong>$14.99</strong>First Bottle</p>
			<p class="saleprice"><strong>$9.99</strong>Second Bottle</p>
			-->
			<p class="saleprice"><strong>$19.95</strong>Per Bottle</p>
			<div class="fancyinputwrapper">
				
                <label>Quantity:<br/>
                    <asp:TextBox ID="txtQty" CssClass="fobj" style="width: 25px;" maxlength="2" Text="1" runat="server"></asp:TextBox>
                </label>
				<asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="add to cart" CssClass="fobjbutton" />
			</div>

		</div>
	</div>

</asp:Content>
