<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="New-Dessert.aspx.cs" Inherits="LovRubWeb.Products.Dessert" Title="LovRub - Body Dessert" %>
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
        <li class="active"><asp:HyperLink runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Valentines2010.aspx">LovRub&trade; Valentine's Delight</asp:HyperLink></li>        
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <!-- <li><asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li> -->
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">

    <div class="rightcol lgphoto"><img src="..\images\dessert-image.jpg" alt="LovRub Body Dessert"/>
    <!-- <div class="kpllgphoto" style="background-color: #000000"><img src="..\images\dessert-image.jpg" alt="LovRub Body Dessert"/> -->
        <div class="fancyproductinfo">
            <h1>LovRub Body Dessert&trade;</h1>
            <p style="font-family: arial; margin: 30px 0 0 -10px; width: 250px; color: #fff; font-size: 12px;">LovRub&#39s latest addition to its all natural sexual enhancement product line is here.<br />
                When mixed with your mouth&#39s moisture, Body Dessert turns on the heat. And it comes in two delicious flavors; cherry and chocolate. <br /><br />
                4 oz. Bottle
            </p>
                		
            <p style="font-weight: bold; font-size: 32px; margin: 1px 0 0 -15px;"><strong>$14.95</strong></p>
            <p style="font-size: 10px; font-weight: normal; margin: -10px 0 0 10px;">Per Bottle</p>
            <div style="width: 180px; float: right; text-align: right; margin-top: -90px; margin-bottom: 170px; margin-right: 80px; margin-left: 0px; background: #282828; padding: 0px 0;">                        
                <!-- <h4 style="color: #FFF;">Select Your Flavor and Quantity:</h4> -->
                <label style="color: #FFF;">Chocolate Body Dessert: </label>
                <asp:TextBox ID="txtChocQty"  style="width: 25px;" maxlength="2" Text="0" runat="server"></asp:TextBox>
                <br />
                <label style="color: #FFF;">Cherry Body Dessert: </label>
                <asp:TextBox ID="txtCherryQty"  style="width: 25px;" maxlength="2" Text="0" runat="server"></asp:TextBox>
                <center><asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="add to cart"/></center>
            </div>
	    </div>

    </div>

</asp:Content>
