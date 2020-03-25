<%@ Page Language="C#" MasterPageFile="~/siteBase.Master" AutoEventWireup="true" CodeFile="AboutUs.aspx.cs" Inherits="LovRubWeb.AboutUs" Title="LovRub - About Us" %>

<%@ Register Src="Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead id="MastHead1" runat="server">
    </uc1:MastHead>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li class="active"><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
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
		<li><a href="FAQ.aspx">Frequently asked questions</a></li>
		<li><a href="Ingredients.aspx">Ingredients</a></li>
        <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box of Sexual Stimulants"></asp:HyperLink></li>		
		
	</ul>
	
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphContent" runat="server">
    <div class="righticol" style="background: url(images/bi-productshot.jpg) no-repeat top right;">
        <div class="imagedContent">
        <h1 class="pagetitle">About Us</h1>
        <p> HealthRockers, the manufacturer of LovRub,<br />
            is a consumer products manufacturer. We were<br />
            founded on the idea that quality products <br />
            and fanatical customer care are the most <br />
            important aspects of what we do.
        </p>
        <p>
            LovRub is manufactured and packaged <br />
            in the United States in an FDA certified <br />
            pharmaceutical and consumer products <br />
            manufacturing facility.
        </p>
        <h2>RETURNS POLICY</h2>
        <p>
            Health Rockers guarantees that you must be 100% satisfied with your purchase or 
            we will refund the total cost of the product(s) purchased within the last 30 days 
            provided it is new, unopened merchandise in its original condition.<br />
            If you have any questions about our return policy or about a specific return, contact us at: <br />
            Health Rockers, Inc.<br />
            P.O. Box 361<br />
            Holtsville, NY 11742-0361<br /><br />

            You can call us at 877-956-8782 or e-mail us at Service@LovRub.com


        </p>
        <h2>SHIPPING RATES</h2>
            <table border="0">
                <thead>
                <tr>
                    <td>Number of Bottles</td>
                    <td>Rates</td> 
                    <td>Expected Delivery</td> 
                </tr> 
                </thead>
                
                <tr>
                    <td>1</td>
                    <td>$5.50</td> 
                    <td>4 -10 Business Days</td> 
                </tr> 
                <tr>
                    <td>2</td>
                    <td>$5.50</td> 
                    <td>4 -10 Business Days</td> 
                </tr> 
                <tr>
                    <td>3 or more</td>
                    <td>$7.25</td> 
                    <td>4 -10 Business Days</td> 
                </tr>  
                <tr>
                    <td>International</td>
                    <td>$20.99</td> 
                    <td>14-21  Business Days</td> 
                </tr>
            </table>
            <p>All orders are processed and shipped via the US Postal service</p>
            <p>You can expect delivery in 4 to 10 business days. International orders will take longer.</p>
            <p>Your privacy is 100% guaranteed- all orders are shipped in unmarked packaging and credit cards are billed by HealthRockers, Inc.</p> 
        </div>
    </div>
</asp:Content>
