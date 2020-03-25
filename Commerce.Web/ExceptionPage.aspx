<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="ExceptionPage.aspx.cs"
	Inherits="ExceptionPage" Title="Untitled Page" %>
<%@ Register Src="Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc6" %>
<%@ Register Src="Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div id="leftcontent">
		<uc6:MainNavigation ID="MainNavigation1" runat="server" />
	</div>
	<div id="centercontent">
		<h4>Oops! An error has occured!</h4>
		<uc1:ResultMessage ID="ResultMessage1" runat="server" />
	</div>
</asp:Content>
