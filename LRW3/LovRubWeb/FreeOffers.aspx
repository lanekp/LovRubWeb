<%@ Page Language="C#" 
         MasterPageFile="~/siteBase.Master" 
         AutoEventWireup="true" 
         CodeFile="FreeOffers.aspx.cs" 
         Inherits="FreeOffers" 
         Title="Free Offers from LovRub" %>
         
<%@ Register Src="~/Controls/WebParts/MastHead.ascx" TagName="MastHead" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMastHead" runat="server">

    <uc1:MastHead ID="MastHead1" runat="server" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphMainMenu" Runat="Server">
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

<asp:Content ID="Content3" ContentPlaceHolderID="cphPolaroid" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="cphSubMenu" Runat="Server">

    <ul class="submenu">
		<li class="large">Sexual enhancement gels
			<ul>
                <li><asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Products/His.aspx">male</asp:HyperLink></li>
                <li><asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Products/Hers.aspx">female</asp:HyperLink></li>				
			</ul></li>
		<li><asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Products/BodyMassage.aspx">RubLov</asp:HyperLink></li>
        <li><asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Products/LipLov.aspx">LipLov</asp:HyperLink></li>		
	</ul>
    <ul class="pinnedsubmenu">
        <li><asp:HyperLink runat="server" NavigateUrl="~/HowItWorks.aspx">How it works</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/FAQ.aspx">Frequently asked questions</asp:HyperLink></li>	
        <li><asp:HyperLink runat="server" NavigateUrl="~/Ingredients.aspx">Ingredients</asp:HyperLink></li>	        		
        <li><asp:HyperLink runat="server" NavigateUrl="~/Products/Default.aspx" ImageUrl="~/images/HealthRockersBox.png" ToolTip="Our Discreet Shipping Box"></asp:HyperLink></li>        
	</ul>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphContent" Runat="Server">
    
<div class="righticol" style="background: url(images/bi-productshot.jpg) no-repeat top right;">
    <div class="imagedContent" style="padding-bottom:200px;">

        <h1 class="pagetitle">Select Your Free Gift</h1>
        
        <p> Thanks for your order. Please choose one of the gifts below as a sign of
            our appreciation.
        </p>

    <table  align="center" cellpadding="0" cellspacing="0">        
    <tr>
        <td>
            <p>RubLov Massage Gel 2oz.</p>
        </td>
        <td>
            <asp:CheckBox ID="chkRubLov" 
                        OnCheckedChanged="RubLovCheckedChange" 
                        AutoPostBack="true" 
                        runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <p>Holiday Stocking. Filled with LovRub tube.</p></td>
        <td>
            <asp:CheckBox ID="chkStocking" 
                        OnCheckedChanged="StockingCheckedChange" 
                        AutoPostBack="true" 
                        runat="server" />
        </td>
    </tr>
    
    <tr align="center">
        <td>
            <asp:Button ID="Button1" 
                        OnClick="Button1_Click"
                        runat="server" 
                        Text="Continue with Checkout >>>" />
        </td>
    </tr>

    </table>
        
    </div>
</div>


</asp:Content>

