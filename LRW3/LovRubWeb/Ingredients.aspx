<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" CodeFile="Ingredients.aspx.cs" Inherits="LovRubWeb.Ingredients" Title="LovRub - Ingredients" %>

<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead ID="MastHead1" runat="server" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    <ul class="pinnedsubmenu">
		<li><a href="HowItWorks.aspx">How it works</a></li>
		<li><a href="FAQ.aspx">Frequently asked questions</a></li>
		<li class="active"><a href="Ingredients.aspx">Ingredients</a></li>
        <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>		
	</ul>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <div class="righticol" style="background: url(images/bi-productshot.jpg) no-repeat top right;">
        <div class="imagedContent">
        <h1 class="pagetitle">INGREDIENTS</h1>
        <h2>Water Soluble. Safe To Use With Condoms.</h2>
        <h3>LOVRUB:</h3>
        <p>LovRub is a non drug, natural, nutraceutical formulation  designed to 
enhance sexual pleasure by producing nitric oxide effect in the human 
body. </p>
		<p>LovRub, applied topically, is a natural, non drug nutraceutical formulation designed to 
enhance sexual function by safely increasing nitric oxide production in the targeted area, 
contributing to enhanced pleasure and  maximum sexual satisfaction. </p>
		<p>Nitric Oxide (NO) is the newest and most effective means of increasing sexual pleasure 
and satisfaction in both normal males and females, and in those whose libidos are 
compromised.</p>
		<p>Sexual stimulation causes local release of nitric oxide (NO), resulting in smooth muscle 
relaxation and inflow of blood to the corpus cavernosum.  Thus nithe penis by dilating the blood vessels of penile erectile tissue. </p>
		<p style="font-weight: bold;">There is a natural, non drug method of creating nitric oxide effect 
in  human body and LovRub does just that.</p>
		<p><strong>Increasing orgasm in women:</strong>  LovRub increases the incidence of orgasm in 
women because NO allows clitoral and vaginal tissue to enlarge during sexual stimulation 
and become responsive.  NO effect can easily be increased in women by topically 
applying LovRub.</p>
		<p><strong>L-ARGININE:</strong>  L-arginine equals nitric oxide.    L-arginine is the precursor to  nitric oxide. 
L-arginine derived NO formulas contribute to maximum pleasure and sexual satsfaction.</p>
		<p><strong>RESVERATROL:</strong>  There is a natural, non drug method of creating nitric oxide in the human 
body.  The mechanism is complex, but the trigger mechanism is not.  To produce NO in the 
body, a terminal nitrogen atom must combine with an oxygen molecule in the blood.  An 
enzyme called nitric oxide synthase controls this reaction. This reaction can be accomplished 
via topical application that contains... Resveratrol along with L-Arginine.</p>
		<p>Resveratrol increases Nitric Oxide Synthase, the enzyme responsible for  the biosynthesis 
of NO from L-arginine.  Resveratrol is a grape derived polyphenolic phytoalexin 
antioxidant and it Increases NO production.</p>
		<p><strong>ALOE VERA:</strong>   Enhanses absorption of resveratrol and arginine throuh the skin. Is also a 
natural moisturizer . </p>
		<p>ANY ONE OF THESE INGREDIENTS BY THEM SELF ARE INCOMPLETE.  NO 
OTHER PRODUCT IN THE MARKET CONTAINS ALL THESE THREE ESSENTIAL 
INGREDIENTS TOGETHER </p>
        <p> DI Water, Aloe Vera Gel, Glycerin, L-Arginine, Glycereth-26,
            Hydroxyethylcellulose, Trans-Resveratrol (muscadine, grape extract),
            Propylene Glycol, Diazolidinyl Urea, Methyl Paraben,
            Menthol.</p>
        <h3>RUBLOV:</h3> 
        <p> Aloe Vera Gel, Glycerine, DI Water, L-Arginine, Trans-Resveratrol, 
            Propylene Glycol, Triethanolamine, Carbomer, Diazolidinyl Urea, 
            Methylaparaben, Allantoin, Disodium EDTA, Quaternium-15, Fragrance.
        </p>
        </div>
    </div>
</asp:Content>
