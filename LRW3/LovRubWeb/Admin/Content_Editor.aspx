<%@ Page  validaterequest="false" Language="C#" Theme="Admin" StylesheetTheme="Admin" AutoEventWireup="true" CodeFile="Content_Editor.aspx.cs" Inherits="Admin_Content_Editor" %>
<%@ OutputCache  NoStore="true" Location="None"%>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Content: <%=Request.QueryString["id"].ToString() %></title>
</head>
<body bgcolor="#f5f5f5">
    <form id="form1" runat="server">
        <div style="text-align:center;margin:10px;">
            <div>
                <FTB:FreeTextBox id="txtContent" runat="server" SupportFolder="~/ftb/"></FTB:FreeTextBox>
            </div>
            <div>	
                <uc1:ResultMessage ID="ResultMessage1" runat="server" />
                <asp:button id="btnSave" runat="server" CausesValidation="False" Text="Save" OnClick="btnSave_Click"></asp:button>&nbsp;
                <input type="button" value="Close" onclick="parent.hidePopWin(false);parent.location.reload();" />
            </div>
        </div> 
    </form>
</body>
</html>
