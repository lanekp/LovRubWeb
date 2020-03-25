<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductTopDisplay.ascx.cs" Inherits="Modules_Products_ProductTopDisplay" %>
<%@ Register Src="AttributeSelection.ascx" TagName="AttributeSelection" TagPrefix="uc5" %>
<%@ Register Assembly="Xpdt.Web.UI.Ratings" Namespace="Xpdt.Web.UI.WebControls" TagPrefix="Xpdt" %>


<h4><%=product.ProductName %></h4>
<table class="productsection">
    <tr>
       <%if(product.Images.Count>1) {%>
        <td valign="top" style="width: 66px">
            <table>
                <%foreach(Commerce.Common.Image img in product.Images){ %>
                <tr><td class="smalltext" style="cursor:hand"><img height="30" width="40" src="<%=Page.ResolveUrl("~/"+img.ImageFile)%>" alt="<%=img.ImageFile%>" onmouseover="imgProduct.src='<%=Page.ResolveUrl("~/"+img.ImageFile) %>';document.getElementById('imgCaption').innerHTML='<%=img.Caption %>'"/></td></tr>
                <%} %>
            
            </table>
        </td>
        <%} %> 
        <td valign="top">
            <table width="100%">
                <tr>
                    <td width="180">
                        <img src="<%=product.ImageFile == null  ? Page.ResolveUrl("~/images/ProductImages/no_image_available.gif") : Page.ResolveUrl("~/" + product.ImageFile) %>" name="imgProduct" id="imgProduct" alt="<%=product.ProductName %>"/>
                        <div class="smalltext" name="imgCaption" id="imgCaption"><% if(product.Images.Count >= 1)
																																											Response.Write(product.Images[0].Caption);%></div>
                    </td>
                    <td>
                        <table>
                            <tr>
                                <td width="120">Retail Price</td>
                                <td class="retailprice"><%=product.RetailPrice.ToString("c") %></td>
                            </tr>
                            <tr>
                                <td>
                                    <b><%=discount.Title %></b><br />
                                    <i><%=discount.Description %></i>
                               
                                </td>
                                <td>
                                    <b class="price">
                                        <%=discount.DiscountedPrice.ToString("C")%>
                                    </b>
                                </td>
		                    </tr>
                			<tr>
			                    <td>You Save:</td>
			                    <td><%=product.YouSavePrice.ToString("C") %> (<%=product.YouSavePercent.ToString("p") %>)</td>
			                </tr>
			                <tr>
				                <td>Availability:</td>
				                <td>
                                    <%=product.ShippingEstimate %>
                                    
        			                <%
                                      if (product.Status == Commerce.Common.ProductStatus.Discontinued) {
			                        %>
        			                    <br /><i>This product has been discontinued, however it is still available for 
        			                    special purchase. Please allow extra time for delivery.</i>
                        			    
			                        <%}
                                     else if (product.Status == Commerce.Common.ProductStatus.FutureRelease)
                                     {  %>
        			                    <br /><i>This product is set for future release. These dates may change; please
        			                    be aware that the dates shown above are only an estimate.</i>
			                        <%}else if(product.Status == Commerce.Common.ProductStatus.OnBackorder) {  %>
                                        <br /><i>This product in on backorder and may take extra time to ship.</i>
                                    <%}%>	
                                    
                                    
                                </td>
			                </tr>
			                <tr>
				                <td>Avg. Rating:</td>
				                <td><Xpdt:Rater ID="pRating" runat="server" 
                                      DisplayOnly="true"
                                      ToolTipFormat="Average Rating is {0} over {1}"
                                      DisplayValue="3"

                                      ></Xpdt:Rater></td>
			                </tr>
			                <%//if (product.Attributes.Count > 0){ %>
                            <tr>
                                <td colspan="2">
                                    <uc5:AttributeSelection id="attList" runat="server"
                                    >
                                    </uc5:AttributeSelection>
                                </td>
                            </tr>
                            <%//} %>

                        </table>
                    </td>
                </tr>

            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="hookline">
        <%=product.ShortDescription %>
        </td>
        
    </tr>
</table>