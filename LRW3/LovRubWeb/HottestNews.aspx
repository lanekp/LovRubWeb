<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" Title="LovRub - Latest News" %>
<%@ Register Src="~/Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead id="MastHead1" runat="server">
    </uc1:MastHead>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="ID1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>			
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphSubMenu" runat="server">

    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>        
	</ul>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
    <!-- <div class="righticol" style="background: url(images/bi-hottestnews.jpg) no-repeat top right;"> -->
    <div class="righticol" style="background: url(images/hottest_news.gif) no-repeat top right;">
        <div class="imagedContent">
        <h1 class="pagetitle">Hottest News</h1>
        <div class="article">
            <p>The creators of LovRub&#8482, are at it again!  We can't get into too many details, 
            but very soon Exotic Elements&#8482, another ALL-NATURAL LovRub&#8482 product is going to 
            make taking your vitamins, very sexy!  The same team that brought you all of LovRub&#8482's 
            exciting products are hard at work perfecting the formula that will once again change 
            the enhancement industry!  
            </p>
        </div>
        <div class="article">
            <h2>LIPLOV&#8482;&#45 THE NAME ON EVERY BODY&#39S LIPS!</h2>
            <p>It&#39s here at last!  And oral sex will never be the same&#133it&#39ll be better than ever!
                New LipLov&#8482 from Health Rockers adds an exciting new sensation to one of humankind&#39s greatest pleasures. 
                This definitely isn&#39t your mother&#39s &#45 or your kids&#39 &#45 lip balm. 
                Because while it looks like an ordinary tube of chapstick &#45 and goes 
                on in much the same way &#45 the effect is nothing short of extraordinary.
                Male/Female, Straight/Gay, Young/Old &#45 everyone will love the sexual excitement 
                of being kissed with lips touched with LipLov&#8482. You may think you&#39ve already 
                experienced the very best in oral sex, but take it from us: you haven&#39t lived 
                until you&#39ve added LipLov&#8482. 
                Discover why word-of-mouth is our best advertising&#133order some online now, 
                or look for it in your favorite adult store.
            </p> 
        </div>
<!--        
        <div class="article">
            <h2>FOR WHEN THOSE WHO HAVE BEEN NICE WANT TO GET NAUGHTY</h2>
            <p>Start a warm and pleasurable new holiday tradition with the LovRub Holiday Stocking, featuring one tube each for you and your special someone. At only $19.99, it&#39s the ultimate adult stocking stuffer.</p> 
        </div>
        <div class="article">
            <h2>LET SOMEONE ELSE SEND FLOWERS</h2>
            <p>It&#39s the gift that says how you feel and how you want the two of 
               you to feel long after February 14th. Give the wonderfully hot, 
               deliciously sweet LovRub &#34Chocolate Delight Heart&#34 this Valentine&#39s 
               Day, and spark some serious love.</p> 
        </div>
-->        
        </div>
    </div>
</asp:Content>
