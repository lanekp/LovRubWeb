<%@ Control Language="C#" %>
<%@ Register Src="AcceptedPayment.ascx" TagName="AcceptedPayment" TagPrefix="uc6" %>

<div class="browsebox">
<%
     
    //Using the Site's static category collection (created in Global.asax OnAppStart)
    //showing only parent and direct child however feel free to use whatever makes
    //sense to you

    foreach (Commerce.Common.Category cat in CategoryController.CategoryList)
    {

        if (cat.ParentID == 0)
        {
        %>
        <h4> <a href="<%=Utility.GetRewriterUrl("catalog",cat.CategoryGUID.ToString() ,"")%>"> <%=cat.CategoryName%></a></h4>
        <%
            
            //get the kids
            foreach (Commerce.Common.Category subCat in CategoryController.CategoryList)
            {
                if (subCat.ParentID == cat.CategoryID)
                {
        %>
        <div>
            <a class="subcategory" href="<%=Utility.GetRewriterUrl("catalog",subCat.CategoryGUID.ToString(),"")%>">
            <%=subCat.CategoryName%>
            </a>
        </div>   
        <%             
            
                }
            }
            
        }
    }
    %>
    
    <uc6:AcceptedPayment ID="AcceptedPayment1" runat="server" />

</div>
