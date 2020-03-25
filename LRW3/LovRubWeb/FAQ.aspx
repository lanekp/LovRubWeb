<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" CodeFile="FAQ.aspx.cs" Inherits="LovRubWeb.FAQ" Title="LovRub - Frequently Asked Questions" %>

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
			<li><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
	</ul>

 	
	
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSubMenu" runat="server">

    <ul class="pinnedsubmenu">
		<li><a href="HowItWorks.aspx">How it works</a></li>
		<li class="active"><a href="/FAQ.aspx">Frequently asked questions</a></li>
		<li><asp:HyperLink runat="server" Text="Ingredients" NavigateUrl="~/Ingredients.aspx"></asp:HyperLink></li>
		<li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
    <div class="righticol" style="background: url(images/bi-faqs.jpg) no-repeat top right;">
        <div class="imagedContent">
        <h1 class="pagetitle">FAQ (Frequently Asked Questions)</h1>
        <div class="FAQpair">
            <p>What is LovRub&#8482?</p>
            <p>LovRub&#8482 is a male and female sexual arousal gel that&#39s applied topically. 
               LovRub&#8482 was clinically formulated by a scientist and sexual health expert 
               for the specific purpose to improve sexual pleasure and satisfaction. 
               This unique formulation is made with Aloe Vera, which is known to revitalize 
               skin in the areas most involved in arousal.</p> 
        </div>
        <div class="FAQpair">
            <p>Can LovRub&#8482 be used with a condom?</p>
            <p>Yes, LovRub&#8482 is &#34latex&#34 and &#34polyurethane&#34 condom compatible. Always practice safe sex.</p>
        </div>
        <div class="FAQpair">
            <p>Is LovRub&#8482 safe to use during oral sex?</p>
            <p>Yes, most definitely.</p>
        </div>
        <div class="FAQpair">
            <p>How is LovRub&#8482 different from other topical sexual enhancement products?</p>
            <p>Unlike other topical sexual enhancement products, LovRub&#8482 is 100% natural and water 
               soluble, so it&#39s safe to use with condoms.</p>
        </div>
        <div class="FAQpair">
            <p>Are there any known side effects?</p>
            <p>No; however, everyone is unique, so if you experience any discomfort while using 
               LovRub&#8482, discontinue use and consult with a physician before using the product again.</p>
        </div>
        <div class="FAQpair">
            <p>Is LovRub&#8482 different from sexual herbal pill supplements?</p>
            <p>Yes, LovRub&#8482 is COMPLETELY DIFFERENT! Unlike a pill taken orally, LovRub&#39s&#8482 patented 
               formula uses targeted topical release directly to the &#34source&#34 for INSTANT SEXUAL ENHANCEMENT.</p>
        </div>
        <div class="FAQpair">
            <p>Can LovRub&#8482 For Men and LovRub&#8482 For Women Be Used Together?</p>
            <p>Yes, very effectively, to the mutual pleasure of both partners.</p>
        </div>
        <div class="FAQpair">
            <p>Can LovRub&#8482 be shipped discretely?</p>
            <p>Absolutely! Your privacy is 100% guaranteed. All orders are shipped in 
               unmarked packaging and credits are billed by HealthRockers, Inc.</p>
        </div>
        
        <div class="FAQpair">
            <p>Where do I apply Body Dessert&#8482?</p>
            <p>Wherever it gives you pleasure.</p>
        </div>
        <div class="FAQpair">
            <p>Is Body Dessert&#8482 all natural like the other LovRub products?</p>
            <p>Yes, both great flavors are made with all natural ingredients</p>
        </div>
        <div class="FAQpair">
            <p>How does Body Dessert&#8482 work? How do I get satisfaction?</p>
            <p>When you apply your mouth&#39s moisture, Body Dessert&#8482 heats up and stimulates the area.</p>
        </div>
        <div class="FAQpair">
            <p>How do you apply LipLov&#8482?</p>
            <p>Apply like you would a lip gloss. When you moisten your lips they will puff up and tingle, then do what comes naturally.</p>
        </div>
        <div class="FAQpair">
            <p>Is there a flavor to LipLov&#8482?</p>
            <p>Yes, you&#39ll enjoy the light cherry flavor and it&#39s soothing effect on your lips.</p>
        </div>
        
        <div class="FAQpair">
            <p>Is LipLov&#8482 made with natural ingredients?</p>
            <p>Yes, LipLov&#8482 is made with all natural ingredients.</p>
        </div>
        
        </div>
    </div>
</asp:Content>
