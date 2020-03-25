<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="LovRubWeb.ContactUs" Title="LovRub - Contact Us" %>

<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead id="MastHead1" runat="server">
    </uc1:MastHead>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSubMenu" runat="server">
    
    <ul class="pinnedsubmenu">
		<li><a href="HowItWorks.aspx">How it works</a></li>
		<li><a href="FAQ.aspx">Frequently asked questions</a></li>
		<li><a href="Ingredients.aspx">Ingredients</a></li>
		<li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box of Personal Lubricants"></asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
    <!-- <div class="righticol" style="background: url(images/bi-contactus.jpg) no-repeat top right;"> -->
    <div class="righticol" style="background: url(images/contact.gif) no-repeat top right;">
        <div class="imagedContent" style="padding-bottom:200px;">
        <h1 class="pagetitle">Contact Us</h1>
        <p>If you have any questions, or would like additional information about 
           LovRub and our full line of high-quality, all-natural products, please feel free to contact us:<br />
           <br />
           By Phone: 1-877-956-8782<br /><br />
           By email:  <a href="mailto:service@LovRub"><strong><u>Service@LovRub.com</u></strong></a><br />
           <br />
           <br />           
           By Mail:<br />
            &nbsp;&nbsp;&nbsp;&nbsp;HealthRockers, Inc.<br />
            &nbsp;&nbsp;&nbsp;&nbsp;249-02 Jericho Turnpike<br />
            &nbsp;&nbsp;&nbsp;&nbsp;Suite 104<br />
            &nbsp;&nbsp;&nbsp;&nbsp;Floral Park, NY 11001<br /><br />
           <br />
           <br />
           <br />
           We look forward to hearing from you.
        </p>

        </div>
    </div>
</asp:Content>
