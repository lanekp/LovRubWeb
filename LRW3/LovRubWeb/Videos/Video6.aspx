<%@ Page Language="C#" MasterPageFile="~/VideoPagesMaster.Master" AutoEventWireup="true" CodeFile="Video6.aspx.cs" Inherits="LovRubWeb.Videos.Video6" Title="LovRub - Videos" %>
<%@ Register Src="../Controls/WebParts/VidPlayer.ascx" TagName="VidPlayer" TagPrefix="uc2" %>
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
                <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Products/His.aspx">For Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Products/Hers.aspx">For Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>		
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">

    <div class="rightcol">
        <h1 class="pagetitle">Video
        <strong>
            <asp:HyperLink runat="server" NavigateUrl="~/Videos/Default.aspx">Back to Videos</asp:HyperLink>
        </strong></h1>
            <div id="vidPlayerContainer">
                <uc2:VidPlayer id="VidPlayer1" runat="server" ThumbPath="Sports_Thumbnail.jpg" VidPath="Sports Break regular-LOVRUBFINAL1-h.264 lovrub.flv">
                </uc2:VidPlayer>
                <p></p><b></b> <p></p><b></b>
                <a name="fb_share" type="button_count" href="http://www.facebook.com/sharer.php">Share</a>
                <script src="http://static.ak.fbcdn.net/connect.php/js/FB.Share" type="text/javascript"></script>
            </div>
    </div>
</asp:Content>
