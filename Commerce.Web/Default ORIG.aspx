<%@ Page ValidateRequest="false" EnableViewState="false" Language="C#" MasterPageFile="~/site.master"
  AutoEventWireup="true" CodeFile="Default ORIG.aspx.cs" Inherits="_Default" Title="dashCommerce - ASP.NET Open Source e-Commerce" %>

<%@ Register Src="Modules/MainNavigation.ascx" TagName="MainNavigation" TagPrefix="uc6" %>
<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <div id="leftcontent">
    <uc6:MainNavigation ID="MainNavigation1" runat="server" />
  </div>
  <div id="centercontent">
    <uc4:AdContainer ID="AdContainer2" runat="server" BoxPlacement="Center" BoxCssClass="">
    </uc4:AdContainer>
    <uc5:Paragraph ID="Paragraph1" runat="server" ContentName="DefaultMiddle" />
  </div>
  <div id="rightcontent">
    <uc4:AdContainer ID="AdContainer1" runat="server" BoxPlacement="Right"></uc4:AdContainer>
  </div>
</asp:Content>
