<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductSummaryDisplay.ascx.cs" Inherits="Modules_ProductSummaryDisplay" %>
<%@ Register Assembly="Xpdt.Web.UI.Ratings" Namespace="Xpdt.Web.UI.WebControls" TagPrefix="Xpdt" %>
<div class="productbox">
    <div class="productsummarydisplaywrapper">
        <div class="productsummaryimageholder">
            <a href="<%=Utility.GetRewriterUrl("product",ProductGUID.ToString(),"") %>">
                <img src="<%=ImageFile == string.Empty ? Page.ResolveUrl("~/images/ProductImages/no_image_available.gif") : Page.ResolveUrl(ImageFile)%>"
                    border="0" class="productimage" /></a>
        </div>
        <div class="productsummarytext">
            <div class="productsummaryproductname">
                <a href="<%=Utility.GetRewriterUrl("product",ProductGUID.ToString(),"") %>">
                    <%=ProductName%>
                </a>
                <br />
            </div>
            <div>
                <span class="retailprice">
                    <%=RetailPrice.ToString("c") %>
                </span>&nbsp; <span class="ourprice">
                    <%=GetDiscountedPrice().ToString("C")%>
                </span>
            </div>
            <div class="usuallyships">
                Usually ships in
                <%=ShippingEstimate %>
            </div>
            <div class="smalltext">
                Average Rating:
                <Xpdt:Rater ID="sr1" runat="server" AutoLock="true" DisplayOnly="true"></Xpdt:Rater>
                <br />
            </div>
        </div>
    </div>
</div>
