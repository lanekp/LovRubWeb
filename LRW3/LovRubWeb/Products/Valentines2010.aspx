<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="Valentines2010.aspx.cs" Inherits="LovRubWeb.Products.Valentines2010" Title="LovRub - Valentine's Day" %>
<%@ Register Src="../Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>

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
                <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Products/His.aspx">for Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>
        <li class="active"><asp:HyperLink runat="server" NavigateUrl="~/Products/Valentines2010.aspx">LovRub&trade; Valentine's Delight</asp:HyperLink></li>
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <!-- <li><asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li> -->
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <div style="margin: -85px 0 0 203px; 
	            width:663px; 
	            height:500px; 
	            background-image:url(../images/valentines-image.jpg);">

        <h1 style="font-family: arial; font-size: xx-large; font-weight: 900; color: #e31705; margin: 85px 0 0 40px; ">LovRub&trade; Valentine's Day Delight</h1>
		<div class="fancyproductinfo">
			    <p style="font-family: arial; margin: 80px 0 0 -245px; width: 250px; color: #fff; font-size: 12px;">
			        This Valentine&#39s Day, give as good<br />as you hope to get with the LovRub&trade;
			        <br />Chocolate Delight heart.  Full of
			        <br />sinful, all-natural pleasure... and
			        <br />delicious chocolates, too. For your
			        <br />special day &#45; and night &#45; of love,
			        <br />it&#39s quite possibly the ultimate
			        <br />Valentine&#39s Day gift.<br /><br />

                    Each heart is packed with pleasure:<br />
                </p>
                <div style="font-family: arial; margin: 0px 0 0 -245px; color: #fff; font-size: 12px;">
                    <ul>
                        <li><span style="color: #e31705; font-weight: bold;"/>2 Tubes of LovRub</li>
                        <!-- <li><span style="color: #e31705; font-weight: bold;"/>LovRub For Her</li> -->
                        <li><span style="color: #e31705; font-weight: bold;"/>14 Mouth Watering Chocolates</li>
                    </ul>

                    <span style="color: #e31705; font-weight: bold;">GET YOURS IN TIME FOR VALENTINES DAY!</span>
            			        		
			        <p style="color: #FFFFFF; font-weight: bold; font-size: 32px; margin: -5px 0 0 50px;"><strong>$32.95</strong></p>
	                    <div style="width: 150px; float: right; text-align: right; margin:-90px 210px 170px 0px; background: #282828; padding: 0px 0;">
                            <label style="color: #FFF;">His & Hers LovRub: </label>
                            <asp:TextBox ID="txtHisHersQty"  style=" width: 25px;" maxlength="2" Text="0" runat="server"></asp:TextBox>
                            <br />
                            <label style="color: #FFF;">LovRub for Him: </label>
                            <asp:TextBox ID="txtHisQty"  style="width: 25px;" maxlength="2" Text="0" runat="server"></asp:TextBox>
                            <br />
                            <label style="color: #FFF;">LovRub for Her: </label>
                            <asp:TextBox ID="txtHersQty"  style="width: 25px;" maxlength="2" Text="0" runat="server"></asp:TextBox>                            
                            <center><asp:Button ID="Button2" runat="server"  OnClick="Button1_Click" Text="add to cart"/></center>
                        </div>
                    
                </div>
        </div>

    </div>

</asp:Content>
