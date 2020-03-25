<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="Video1.aspx.cs" Inherits="LovRubWeb.Videos.Video1" Title="LovRub - Videos" %>

<%@ Register Src="../Controls/WebParts/VidPlayer.ascx" TagName="VidPlayer" TagPrefix="uc2" %>
<%@ Register Src="../Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead ID="MastHead1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    <ul class="submenu">
		<li class="large">Sexual enhancement gels
			<ul>
				<li><a href="~/Products/His.aspx">For Him</a></li>
				<li><a href="~/Products/Hers.aspx">For Her</a></li>

			</ul></li>
		<li><asp:HyperLink runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
	</ul>
    <ul class="pinnedsubmenu">
		<li><a href="HowItWorks.aspx">How it works</a></li>
		<li><a href="FAQ.aspx">Frequently asked questions</a></li>
		<li><a href="/Ingredients.aspx">Ingredients</a></li>
		<li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <div class="rightcol">
        <h1 class="pagetitle">Video<strong><a href="/Videos/" title="Back to Videos">Back to videos</a></strong></h1>
        
            <div id="vidPlayerContainer">
                <uc2:VidPlayer id="VidPlayer1" runat="server" ThumbPath="Jess-thumb.jpg" VidPath="Jess01.flv">
                </uc2:VidPlayer>
            </div>
        
    </div>
</asp:Content>
