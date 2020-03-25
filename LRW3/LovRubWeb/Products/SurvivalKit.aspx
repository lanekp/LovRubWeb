<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="SurvivalKit.aspx.cs" Inherits="LovRubWeb.Products.SurvivalKit" Title="LovRub - Survival Kit" %>

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
                <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>		
        <li class="active"><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Valentines2010.aspx">LovRub&trade; Valentine's Delight</asp:HyperLink></li>        
                
        
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <!-- <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li> -->
	</ul>
</asp:Content>


<asp:Content ID="Content6" ContentPlaceHolderID="cphContent" runat="server">
    <!-- <div class="rightcol lgphoto"><img src="../images/survivalkitimage.jpg" style="height:499" alt=""/> -->
    <div class="rightcol lgphoto" style="background-image: url(http://lovrub.com/images/survivalkitimage.jpg); height: 499px;">
        <h1 style="font-family: arial; font-weight: bolder; color: #fff; padding: 8px 0 0 65px; ">Survival Kit For Lovers</h1>
		    <div class="fancyproductinfo">
			    <h1 style="font-family: arial; font-weight: bolder; margin: 60px 0 0 -25px; width: 250px; color: #fff; font-size: 16px;">Whatever happens you can ride it out in total pleasure with: </h1>
			    <ul style="font-family: arial; font-weight: bolder;color:#FFF; margin: 5px 0 0 -50px; width: 245px; font-family: arial black;">
				    <li style="font-family: arial; font-weight: bolder;"><span style="font-family: arial; font-weight: bolder; color: #e31705;">ALL-NATURAL</span> LOVRUB SEXUAL ENHANCEMENT GEL FOR HIM & HER</li>
				    <li style="font-family: arial; font-weight: bolder;"><span style="font-family: arial; font-weight: bolder; color: #e31705;">RUBLOV</span> MASSAGE OIL</li>
				    <li style="font-family: arial; font-weight: bolder;"><span style="font-family: arial; font-weight: bolder; color: #e31705;">LIPLOV</span> ORAL STIMULATOR</li>
				    <li style="font-family: arial; font-weight: bolder;"><span style="font-family: arial; font-weight: bolder; color: #e31705;">LOV RUBBER</span> CONDOMS (2)</li>
				    <li style="font-family: arial; font-weight: bolder;"><span style="font-family: arial; font-weight: bolder; color: #e31705;">CHOCOLATE HEARTS</span> (2)</li>

			    </ul>
    		
			    <p style="font-weight: bold; font-size: 28px; margin: 30px 0 0 -15px;"><strong>$39.95</strong></p>
			    <div class="fancyinputwrapper" style="margin: -55px 120px 0 0; background: #000;">
                    <label>Quantity:<br/>
                        <asp:TextBox ID="txtQty" CssClass="fobj" style="width: 25px;" maxlength="2" Text="1" runat="server"></asp:TextBox>
                    </label>
				    <asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="add to cart" CssClass="fobjbutton" />
		        </div>
	    </div>
    </div>
</asp:Content>	


