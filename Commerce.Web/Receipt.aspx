<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeFile="Receipt.aspx.cs" Inherits="Receipt" Title="Receipt" %>
<%@ Register Src="Modules/Content/Paragraph.ascx" TagName="Paragraph" TagPrefix="uc5" %>
<%@ Register Src="Modules/AdContainer.ascx" TagName="AdContainer" TagPrefix="uc4" %>
<%@ Register Src="Modules/RecentCategories.ascx" TagName="RecentCategories" TagPrefix="uc2" %>
<%@ Register Src="Modules/RecentProductsViewed.ascx" TagName="RecentProductsViewed"
    TagPrefix="uc3" %>
<%@ Register Src="Modules/CatalogList.ascx" TagName="CatalogList" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        
        <div id="leftcontent">
         <%if (RecentCategories1.GetCount() > 0)  { %>
        <uc2:RecentCategories ID="RecentCategories1" runat="server" />
        <%} %>
         <uc1:CatalogList id="CatalogList1" runat="server">
        </uc1:CatalogList>
         <br />
         <uc4:AdContainer id="AdContainer1" runat="server" BoxPlacement="Left" >
        </uc4:AdContainer>
       
        </div>
        <div id="centercontent">

            <asp:Label ID="lblReceipt" runat="server"></asp:Label>
        
        </div>
        <div id="rightcontent">
             <uc4:AdContainer id="AdContainer2" runat="server" BoxPlacement="Right" >
            </uc4:AdContainer>
       
        </div>

</asp:Content>

