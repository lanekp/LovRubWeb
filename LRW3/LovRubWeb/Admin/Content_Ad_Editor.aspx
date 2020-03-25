<%@ Page validaterequest="false"   Language="C#" Theme="Admin" StylesheetTheme="Admin" AutoEventWireup="true" CodeFile="Content_Ad_Editor.aspx.cs" Inherits="Admin_Content_Ad_Editor" %>
<%@ OutputCache  NoStore="true" Location="None"%>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Edit Ad</title>
</head>
<body onunload="refreshParent()">
    <form id="form1" runat="server">
       <asp:Label ID="lblID" runat="server" Visible="false" ></asp:Label>
    <table cellpadding="3">
        <tr>
            <td colspan="2"><b>Ad Text</b></td>
        </tr>
        <tr>
            <td align="center" colspan="2"><FTB:FreeTextBox ID="txtAdText" runat="server" SupportFolder="~/ftb/" Height="300"></FTB:FreeTextBox></td>
        </tr>
        <tr>
            <td colspan="2" class="sectionheader">Target this ad</td>
        </tr>
        <tr>
            <td colspan="2" class="adminlabel">
            Select a product or category below for this ad. The ad will then be
            "clickable" and stats can be compiled about clickthroughs, etc.
            </td>
        </tr>
        <tr>
            <td class="adminlabel"><b>Product</b></td>
            <td class="adminlabel"><asp:DropDownList ID="ddlProductID" runat="server"></asp:DropDownList></td>
        </tr>
        <tr><td colspan="2" class="adminlabel">--or--</td></tr>
        <tr>
            <td class="adminlabel"><b>Category</b></td>
            <td class="adminlabel"><asp:DropDownList ID="ddlCategoryID" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>
                
                <asp:button id="btnSave" runat="server" CausesValidation="False" Text="Save" OnClick="btnSave_Click" CssClass="frmbutton"></asp:button>&nbsp;
                <input type="button" value="Close" onclick="parent.hidePopWin(false);parent.location.reload();" class="frmbutton" />&nbsp;
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" CssClass="frmbutton"/>
            </td>
        </tr>
        <tr>
            <td><uc1:ResultMessage ID="ResultMessage1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
<script>
function CheckDelete(){
		
	return confirm("Delete this record? This action cannot be undone...");

}
//thanks racer94
function refreshParent() {

parent.location.reload(true);

}

</script>