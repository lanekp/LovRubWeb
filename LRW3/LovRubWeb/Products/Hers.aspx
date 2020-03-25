<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="Hers.aspx.cs" Inherits="LovRubWeb.Products.Hers" Title="LovRub - For Her" %>

<%@ Register Src="~/Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
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
                <li><asp:HyperLink runat="server" NavigateUrl="~/Products/His.aspx">for Him</asp:HyperLink></li>
                <li class="active"><asp:HyperLink runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Valentines2010.aspx">LovRub&trade; Valentine's Delight</asp:HyperLink></li>        
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <!-- <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox-Her.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li> -->
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <!-- <div class="rightcol lgphoto" style="background-image: url(../images/lovrub-her.jpg); height: 499px;"> -->
    <div class="rightcol lgphoto" style="background-image: url(../images/loverub_for_her_notype.jpg); height: 498px;">
		<div class="fancyproductinfo">
			<h1 style="margin: -15px 0 0 -270px; color: #FFF; height: 40px;">LovRub&trade; for Women
			    <em style="width: 360px; margin: -21px 0 0 250px;">The Female Sexual Enhancement Gel For Greater Sexual Satisfaction & More Intense Orgasms.
                </em>
            </h1>
			<p>
				<ul style="color: #FFF; margin: 0 0 0 -30px; width: 360px; line-height: 21px; list-style-position: inside;">
					<li><span style="color: #e31705; font-weight: bold;">ALL-NATURAL,</span> plus Aloe Vera.</li>
					<li><span style="color: #e31705; font-weight: bold;">CLINICALLY FORMULATED</span> by scientists & sex-health experts.</li>
					<li><span style="color: #e31705; font-weight: bold;">GREATER AROUSAL AND STRONGER ORGASMS.</span></li>
                	<li><span style="color: #e31705; font-weight: bold;">A DIME-SIZE DAB</span> is all it takes.</li>
                	<li><span style="color: #e31705; font-weight: bold;">20-30 APPLICATIONS</span> per tube.</li>
                	<li><span style="color: #e31705; font-weight: bold;">ULTIMATE SEXUAL PLEASURE</span> at an <span style="color: #e31705; font-weight: bold;">AFFORDABLE PRICE.</span></li>
                	<li>Condom Safe - Made in the USA.</li>
                </ul>
            </p>

			<p class="firstprice">$19.99</p>

			<!-- <p class="saleprice"><strong style="color: #FFF !important;">$14.99</strong>First Tube</p> -->
			<!-- <p class="saleprice"><strong style="color: #FFF !important;">$9.99</strong>Second Tube</p> -->
			<p class="saleprice"><strong style="color: #FFF !important;">$14.99</strong>Per Tube</p>
			<div class="fancyinputwrapper">
                <label>Quantity:<br/>
                    <asp:TextBox ID="txtQty" CssClass="fobj" style="width: 25px;" maxlength="2" Text="1" runat="server"></asp:TextBox>
                </label>
				<asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="add to cart" CssClass="fobjbutton" />
			</div>

		</div>
	</div>

</asp:Content>
