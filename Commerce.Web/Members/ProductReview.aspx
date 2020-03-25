<%@ Page validaterequest="false" Language="C#" AutoEventWireup="true" CodeFile="ProductReview.aspx.cs" Inherits="Members_ProductReview" %>

<%@ Register Src="../Modules/ResultMessage.ascx" TagName="ResultMessage" TagPrefix="uc1" %>
<%@ Register Assembly="Xpdt.Web.UI.Ratings" Namespace="Xpdt.Web.UI.WebControls" TagPrefix="Xpdt" %>
<%@ register assembly="MagicAjax" namespace="MagicAjax.UI.Controls" tagprefix="ajax" %>
<%@ Register Assembly="MagicAjax" Namespace="MagicAjax.UI.Controls" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Product Review</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajax:AjaxPanel ID="Ajaxpanel1" runat="server">
        <asp:Panel ID="pnlReview" runat="server">
        <table width="550" align="center">
            <tr><td align="center"><h4><%=Utility.GetParameter("pn")%></h4></td></tr>
        </table>
        <table width="550" align="center">
            <tr>
                <td><b>Your Rating:</b>
                    <asp:DropDownList ID="ddlRating" runat="server">
                        <asp:ListItem Value="1">1 - Horrible</asp:ListItem>
                        <asp:ListItem Value="2">2 - Not so good</asp:ListItem>
                        <asp:ListItem  Value="3">3 - OK, not great</asp:ListItem>
                        <asp:ListItem Selected="True" Value="4">4 - Good</asp:ListItem>
                        <asp:ListItem Value="5">5 - Excellent</asp:ListItem>
                    </asp:DropDownList>
                   </td>
            </tr>
            <tr>
                <td>
                    <b>Title</b><br />
                    <asp:TextBox ID="txtTitle" runat="server" Width="510px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="Required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>
                    <b>Review</b><br />
                    <span class="smalltext">A review should focus on the things you consider both positive and negative about
                    a product. A good tip is to support every thought you have with a concrete example, 
                    such as "I found the phone very hard use as I could not see the buttons clearly
                    when the phone was held at arm's-length". Your review will itself be graded by our users
                    who find it helpful. The higher the "grade", the better positioning this review 
                    will receive.
                    
                    Your review will be moderated by our 
                    staff and posted once approved.</span>
                    <asp:TextBox ID="txtReview" runat="server" TextMode="multiLine" Height="177px" Width="511px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtReview"
                        ErrorMessage="Required"></asp:RequiredFieldValidator></td>
            
            </tr>
            <tr>
                <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                <input type="button" value="Close" onclick="window.top.hidePopWin();" />
                </td>
            </tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlFinished" runat="server">
        <table width="550" align="center">
            <tr><td><h5>Thank You!</h5></td></tr>
            <tr><td>
                Your review has been submitted and will be read by one of our staff. If approved, your
               review will appear along with the other reviews from our loyal customers. This usually
               takes up to 2 weeks. Thank you again for your submission.
            </td></tr>
        </table>
        <table width="500">
            <tr><td align="center"><uc1:ResultMessage ID="ResultMessage1" runat="server" /></td></tr>
            <tr><td height="20" align="center"><input type="button" value="Close" onclick="window.top.hidePopWin();" /></td></tr>
        </table>
        </asp:Panel>
        <asp:Panel ID="pnlReviewed" runat="server" Visible="false">
          <table width="550" align="center">
            <tr><td><h5>Your review was already received...</h5></td></tr>
            <tr><td>
               Our records currently indicate that you have already reviewed this product and
               currently we only allow one review per user. If you would like to modify your review, 
               please contact us and let us know.
            </td></tr>
        </table>      
        
        </asp:Panel>
        </ajax:AjaxPanel>
    </form>
</body>
</html>
