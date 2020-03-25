<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="LovRubWeb.Products.Default" Title="LovRub - Sexual Enhancement Gels" %>
<%@ Register Src="../Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">
    <uc1:MastHead ID="MastHead1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" runat="server">
    <ul class="mm">
            <!-- <li><asp:HyperLink ID="ID1" runat="server" NavigateUrl="~/TeriTalk.aspx">Teri Talk</asp:HyperLink></li> -->
			<li><asp:HyperLink ID="ID2"  runat="server" NavigateUrl="~/Testimonials.aspx">Testimonials</asp:HyperLink></li>
			<li><asp:HyperLink ID="ID3" runat="server" NavigateUrl="~/AboutUs.aspx">About Us</asp:HyperLink></li>
			<li class="active"><asp:HyperLink  ID="ID8" runat="server" NavigateUrl="~/Products/Default.aspx">Products</asp:HyperLink></li>
			<li><asp:HyperLink ID="ID4"  runat="server" NavigateUrl="~/Videos/Default.aspx">Videos</asp:HyperLink></li>
			<li><asp:HyperLink ID="ID5"  runat="server" NavigateUrl="~/ContactUs.aspx">Contact Us</asp:HyperLink></li>
			<li><asp:HyperLink ID="ID6"  runat="server" NavigateUrl="~/HottestNews.aspx">Hottest News</asp:HyperLink></li>
	</ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" runat="server">
    <ul class="submenu">
		<li class="large">Sexual Enhancement Gels
			<ul>
                <li><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Products/His.aspx">for Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>

		<li><asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>		
        <li><asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>		
        <li><asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Products/New-Dessert.aspx">Body Dessert</asp:HyperLink></li>		        
        <li><asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Products/Valentines2010.aspx">LovRub&trade; Valentine's Delight</asp:HyperLink></li>
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink14"  runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink15"  runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        
        <!-- <li><asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Discreet Shipping Box for Our Personal Lubricants"></asp:HyperLink></li> -->
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <!-- 
    <div class="rightcol lgphoto"><img src="..\images\mainproductimage2.jpg" style="" alt="LovRub Sexual Stimulant and Personal Lubricant"/>
    </div>                
    -->
    <div class="rightcol lgphoto"><img src="..\images\mainproductimage2.jpg" style="" alt="LovRub Sexual Stimulant and Personal Lubricant"/>
    </div>                
    

   
				
</asp:Content>