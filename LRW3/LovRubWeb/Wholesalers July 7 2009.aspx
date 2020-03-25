<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" CodeFile="Wholesalers July 7 2009.aspx.cs" Inherits="LovRubWeb.Wholesalers" Title="LovRub - Wholesalers" %>

<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead ID="MastHead1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            
            <!-- <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
			
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        
        <li><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <div class="rightwcol" style="background: url(/images/bi-wholesalers.jpg) no-repeat top right;">
        <div id="wholesaleVidContainer">
            <div>
                <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Videos/Video2.aspx" ImageUrl="~/videos/Info-smallthumb.jpg"></asp:HyperLink>
                <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Videos/Video2.aspx">30 Minute Infomercial</asp:HyperLink>                
            </div>
        </div>
        <div class="imagedContent" style="padding-top:75px; margin-top:-200px;">
        <h1 class="pagetitle" style="margin-bottom:20px;">Arouse Your<br />Profit Center...<strong>The &#34Full Keystone&#34 On Every Tube Of LovRub 
            Is Just The Beginning Of Your Business Pleasure&nbsp;.&nbsp;.&nbsp;.!</strong></h1>
        
        <p> 
           Just like LovRub can add new heat to a relationship, it can also put a whole new 
           glow on your bottom line. That&#39s because we stimulate all three of your business 
           pleasure centers:
           
        </p>
        <ul id="stimulation">
           <li>Profit</li>
           <li>Promotion</li>
           <li>Point-Of-Sale</li> 
       </ul>
        <ul id="points">
            <li><strong>Superior Profits!</strong> Lov Rub makes it easy to enjoy impressive profits while still 
                giving your customer great value on a premium-quality product.</li>
            <li><strong>National Promotion Power!</strong> LovRub supports your business efforts
	            with a full marketing program that includes TV, radio, print, and Internet
                campaigns.</li>
            <li><strong>Impactful Point-Of-Sale Materials!</strong> All LovRub product promotions are 
	            packaged to deliver maximum impact in minimal space. Each POS display
	            is designed for powerful visual allure, and comes ready for immediate display 
                in your establishment.</li>
            <li><strong>Love For Every Season!</strong> Over the course of the year, we create a variety
	            of exciting, and profitable, in-store promotions, packaging and in-store 
	            displays, and valuable incentives for retailers that raise sales and your
	            profit levels.
            </li>
        </ul> 
        <p>All-natural enjoyment for your customers.  All easy-to-make profit for you. Now&#39s the time to 
           make sure you&#39ve got plenty of LovRub on hand to <em>start putting new fire in your bottom line.</em> 
           Order now!</p>
        </div>
        
    </div>
</asp:Content>
