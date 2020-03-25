using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Commerce.Common;
using Commerce.Promotions;

public partial class LRMaleProduct : System.Web.UI.Page
{

    protected int productID;
    protected string productSku;
    protected Guid productGUID;

    private Commerce.Common.Product product = null;
    protected ProductDiscount discount;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //protected void btnMen2_Click(object sender, ImageClickEventArgs e)
    protected void btnMen2_Click(object sender, EventArgs e)
    {
        string sProductGUID = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
        productGUID = new Guid(sProductGUID);
        try
        {
            product = ProductController.GetProductDeepByGUID(productGUID);
            //make sure we have a product
            TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

            //set the page variables
            productID = product.ProductID;
            productSku = product.Sku;
            product.Quantity = 2;
            OrderController.AddItem(product);
            AddKeyForOrderMotion();

            //This behavior is by design 
            //See http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemwebhttpresponseclassendtopic.asp
            Response.Redirect("additemresult.aspx", false);
            //Response.Redirect("order.aspx", false); KPL

        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex); // 04/10/08 KPL added
            throw ex;
        }
    }

    protected void btnMen1_Click(object sender, EventArgs e)
    //protected void btnMen1_Click(object sender, ImageClickEventArgs e)
    {
        string sProductGUID = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
        productGUID = new Guid(sProductGUID);
        try
        {
            product = ProductController.GetProductDeepByGUID(productGUID);
            //make sure we have a product
            TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

            //set the page variables
            productID = product.ProductID;
            productSku = product.Sku;
            product.Quantity = 1;
            OrderController.AddItem(product);
            AddKeyForOrderMotion();
            //This behavior is by design 
            //See http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemwebhttpresponseclassendtopic.asp
            Response.Redirect("additemresult.aspx", false);
            //Response.Redirect("order.aspx", false); KPL
            
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex); // 04/10/08 KPL added
            throw ex;
            //ExceptionPolicy.HandleException(ex, "Application Exception");
            //Response.Redirect(Page.ResolveUrl("~/ExceptionPage.aspx"), false);
        }
    }


    protected void btnMen3_Click(object sender, EventArgs e)
    {
        string sProductGUID = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
        productGUID = new Guid(sProductGUID);
        try
        {
            product = ProductController.GetProductDeepByGUID(productGUID);
            //make sure we have a product
            TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

            //set the page variables
            productID = product.ProductID;
            productSku = product.Sku;
            product.Quantity = 3;
            OrderController.AddItem(product);
            AddKeyForOrderMotion();
            //This behavior is by design 
            //See http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpref/html/frlrfsystemwebhttpresponseclassendtopic.asp
            Response.Redirect("additemresult.aspx", false);
            //Response.Redirect("order.aspx", false); KPL

        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex); // 04/10/08 KPL added
            throw ex;
        }
    }

    public void AddKeyForOrderMotion()
    {
        // should only add one note. so check for existing note before adding new one.

        // Add keycode for OrderMotion
        Order currentOrder = OrderController.GetCurrentOrder();
        OrderController.AddNote("WEB", currentOrder);

        // get keycode
        OrderNoteCollection noteCollection = currentOrder.Notes;
        int nCount = noteCollection.Count;
        if (nCount > 0)
        {
            OrderNote note = noteCollection[0];
            String sk = note.Note;
        }
    }

}
