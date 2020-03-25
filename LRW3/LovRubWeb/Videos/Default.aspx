<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LovRubWeb.Videos.Default" Title="LovRub - Videos" %>
<%@ Register Src="../Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead ID="MastHead1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>			
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    <ul class="submenu">
		<li class="large">Sexual enhancement gels
			<ul>
                <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Products/His.aspx">for Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
     <div class="rightcol">
        <h1 class="pagetitle">Videos<strong>Please select a video below.</strong></h1>
        
            <div id="vidContainer">
                <div>
                    <a href="Video8.aspx"><img src="SheetClutch_Thumbnail.jpg" alt="LovRub Sheet Clutch Commercial" /></a>
                    <a href="Video8.aspx">The Sheet Clutch</a>
                </div>
            
                <div>
                    <a href="Video6.aspx"><img src="Sports_Thumbnail.jpg" alt="LovRub Sports Commercial" /></a>
                    <a href="Video6.aspx">Sports Commercial</a>
                </div>

                <div>
                    <a href="Video2.aspx"><img src="LovRub-Office-Thumb.jpg" alt="LovRub Office Commercial" /></a>
                    <a href="Video2.aspx">Office Commercial</a> 
                </div>
                 <div>
                    <a href="Video3.aspx"><img src="LovRub-Family-Thumb.jpg" alt="LovRub Family Commercial" /></a>
                    <a href="Video3.aspx">Family Commercial</a> 
                 </div>
                 <div>
                    <a href="Video7.aspx"><img src="Valentines_Thumbnail.jpg" alt="Valentines Day" /></a>
                    <a href="Video7.aspx">Valentine's Day Commercial</a> 
                 </div>
                 <div>
                    <a href="Video5.aspx"><img src="ChristmasThumb.jpg" alt="Information" /></a>
                    <a href="Video5.aspx">Holiday Season Commercial</a> 
                 </div>
                 
<!--
                 <div>
                    <a href="Video4.aspx"><img src="120-smallthumb.jpg" alt="120 second spot" /></a>
                    <a href="Video4.aspx">2 Minute Commercial</a> 
                 </div>
-->                 

            </div>
      
    </div>
</asp:Content>
