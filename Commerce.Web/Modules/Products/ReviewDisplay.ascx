<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReviewDisplay.ascx.cs" Inherits="Modules_Products_ReviewDisplay" %>
 <%@ register assembly="MagicAjax" namespace="MagicAjax.UI.Controls" tagprefix="ajax" %>
<%@ Register Assembly="Xpdt.Web.UI.Ratings" Namespace="Xpdt.Web.UI.WebControls" TagPrefix="Xpdt" %>
        <ajax:AjaxPanel ID="Ajaxpanel2" runat="server">
        <%
        //Many thanks to Geri (rapidexposure) for fixing this!
        if (product.Reviews.Count > 0) { %>
        <div class="productsection">
            <h5>Customer Reviews</h5>            
            <asp:Repeater ID="rptReviews" runat="server" OnItemCommand="PostReviewResponse">
                <ItemTemplate>
                <asp:Label ID="lblReviewID" runat="server" Visible="false" Text='<%#Eval("reviewID") %>'></asp:Label>
                <table width="600">
                    <tr>
                        <td colspan="2">
                            <Xpdt:Rater ID="rvRating" runat="server" 
                              DisplayOnly="true"
                              DisplayValue='<%#Convert.ToInt16(Eval("rating")) %>'
                              ></Xpdt:Rater>&nbsp;
                              <b><%#Eval("title") %></b>, <%#Eval("PostDate") %>                       
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                         <b>Reviewer: <%#Eval("authorname") %></b>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <%#Eval("Body") %>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        <h3>Was this review helpful? </h3> 
                        <asp:Button ID="btnYes" CommandName="Yes" runat="server" Text="Yes" />&nbsp;
                        <asp:Button ID="btnNo" CommandName="No" runat="server" Text="No"/>
                        <b><asp:Label ID="lblThanks" runat="server"></asp:Label></b>
                       </td>
                    </tr>
                </table>

                
                </ItemTemplate>
                
            </asp:Repeater>
        </div>
        <%} %>        
        </ajax:AjaxPanel>
