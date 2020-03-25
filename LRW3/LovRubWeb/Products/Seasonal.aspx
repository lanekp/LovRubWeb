<%@ Page Language="C#" MasterPageFile="~/SubSiteBase.Master" AutoEventWireup="true" CodeFile="Seasonal.aspx.cs" Inherits="LovRubWeb.Products.Seasonal" Title="LovRub - Seasonal Products" %>
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
		
		<li class="large">Sexual enhancement gels
			<ul>
                <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Products/His.aspx">for Him</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Products/Hers.aspx">for Her</asp:HyperLink></li>				
			</ul></li>
		<li><asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Products/BodyMassage.aspx">Body massage gel</asp:HyperLink></li>
        <li><asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov Lip Gel</asp:HyperLink></li>		
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/SurvivalKit.aspx">His & Her Survival Kit</asp:HyperLink></li>        
		<li class="active"><asp:HyperLink runat="server" NavigateUrl="~/Products/Seasonal.aspx">Valentine's Day Gifts</asp:HyperLink></li>

	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <li><asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>
	</ul>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" runat="server">
    <div class="rightcol lgphoto" style="background-image: url(../images/vday.jpg); height: 499px;">
			
			<div style="width: 190px; position:absolute; top: 340px; right: 0px;">
                <div style="overflow: hidden;">
	                <label style="font-size: 11px; color: #FFF; font-weight: bold; float: left; width: 60px; text-align: center;">His/Her Tubes<br/>

                      <asp:DropDownList ID="ddlHisHer"  Width="42px" runat="server">
                            <asp:ListItem Selected="True">0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>                            
                      </asp:DropDownList>

	                </label>
	                
	                <label style="font-size: 11px; color: #FFF; font-weight: bold; float: left; width: 60px; text-align: center;">2 Male Tubes<br/>
                      <asp:DropDownList ID="ddlGay"  Width="42px" runat="server">
                            <asp:ListItem Selected="True">0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>                            
                      </asp:DropDownList>
	                </label>

	                <label style="font-size: 11px; color: #FFF; font-weight: bold; float: left; width: 60px; text-align: center;">2 Female Tubes<br/>
                      <asp:DropDownList ID="ddlLesbo"  Width="42px" runat="server">
                            <asp:ListItem Selected="True">0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>                            
                      </asp:DropDownList>
	                </label>

	            </div>
	            <div style="text-align: center; margin: 5px 0 0 0;">
                <asp:Button ID="Button1" runat="server"  OnClick="Button1_Click" Text="add to cart" CssClass="fobjbutton" />				
				</div>
			</div>

	</div>
	
</asp:Content>
