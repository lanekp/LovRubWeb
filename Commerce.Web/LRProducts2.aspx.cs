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

public partial class LRProducts2 : System.Web.UI.Page
{
    string sMaleProductGUID = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
    string sFemaleProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

    string sMaleDiscountGUID = "38dbc864-dea2-4b78-a745-2bef70336368";
    string sFemaleDiscountGUID = "5424233a-4d2b-45a3-a9c0-6cf2fab56a22";
    //string sMassageGelGUID = "f7ada596-0385-4314-8b13-bd949d3856f0";

    protected int productID;
    protected string productSku;
    protected Guid productGUID;

    private Commerce.Common.Product product = null;
    protected ProductDiscount discount;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /****************************************************************
     * 
     * AddToCart()
     * 
     * *************************************************************/
    void AddToCart(string sGUID, int nQty)
    {
        productGUID = new Guid(sGUID);
        try
        {
            product = ProductController.GetProductDeepByGUID(productGUID);
            //make sure we have a product
            TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

            //set the page variables
            productID = product.ProductID;
            productSku = product.Sku;
            product.Quantity = nQty;
            OrderController.AddCallCenterItem(product);

        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }
    }

    protected void DetermineBasketContents( out int nMaleFullQty, 
                                            out int nMaleDiscountQty, 
                                            out int nFemaleFullQty, 
                                            out int nFemaleDiscountQty)
    {
        nMaleFullQty = 0;
        nMaleDiscountQty = 0;
        nFemaleFullQty = 0;
        nFemaleDiscountQty = 0;

        // Calculate total, male, female qty
        OrderItemCollection orderItemCollection = OrderController.GetCartItems();

        foreach (OrderItem currentItem in orderItemCollection)
        {
            if ("LRM1" == currentItem.Sku)
                nMaleFullQty += currentItem.Quantity;
            if ("LRMCC1" == currentItem.Sku)
                nMaleDiscountQty += currentItem.Quantity;
            if ("LRW1" == currentItem.Sku)
                nFemaleFullQty  += currentItem.Quantity;
            if ("LRWCC1" == currentItem.Sku)
                nFemaleDiscountQty += currentItem.Quantity;
        }
    }

    protected void btnMen1_Click(object sender, EventArgs e)
    {
        int nTotalQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;

        /********************************************************
         *   Determine # of items in cart and their sku
         * 
         *   if cart is empty
         *       add 1st item as full price
         *       add rest as discount
         *   if cart has a full price item already
         *       add rest of items as discount
         *******************************************************/
        try
        {
            // Calculate total, male, female qty
            DetermineBasketContents(out nMaleFullQty, out nMaleDiscountQty, out nFemaleFullQty, out nFemaleDiscountQty);
            nTotalQty = nMaleFullQty + nMaleDiscountQty + nFemaleFullQty + nFemaleDiscountQty;

            // If cart is empty, add 1st item as full price, rest as discounted.
            // in this case, user selected 1 male, so add 1st as full
            if (0 == nTotalQty)
            {
                //put first Male in using current ID (LRM1)
                AddToCart(sMaleProductGUID, 1);
            }

            // if cart has a full price item already, add rest of items as discount
            // in this case, user selected 1 male, so add as discount
            if ((1 == nMaleFullQty) || (1 == nFemaleFullQty))
            {
                AddToCart(sMaleDiscountGUID, 1);
            }

            AddKeyForOrderMotion();

            //Response.Redirect("CCBasket.aspx", false);
            Response.Redirect("BasketNew.aspx", false);
            //Response.Redirect("Basket.aspx", false);
            //Response.Redirect("additemresult.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex); // 04/10/08 KPL added
            throw ex;
        }
    }

    protected void btnMen2_Click(object sender, EventArgs e)
    {
        int nTotalQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;

       /********************************************************
        *   Determine # of items in cart and their sku
        * 
        *   if cart is empty
        *       add 1st item as full price
        *       add rest as discount
        *   if cart has a full price item already
        *       add rest of items as discount
        *******************************************************/
        try
        {
            // Calculate total, male, female qty
            DetermineBasketContents(out nMaleFullQty, out nMaleDiscountQty, out nFemaleFullQty, out nFemaleDiscountQty);

            nTotalQty = nMaleFullQty + nMaleDiscountQty + nFemaleFullQty + nFemaleDiscountQty;

            // If cart is empty, add 1st item as full price, rest as discounted.
            // in this case, user selected 2 male, so add 1st as full, 2nd as discount
            if (0 == nTotalQty)
            {
                //put first Male in using current ID (LRM1)
                AddToCart(sMaleProductGUID, 1);

                //add next Male items to cart at Discounted Price (LRMCC1, LRWCC1)
                AddToCart(sMaleDiscountGUID, 1);
            }

            // if cart has a full price item already, add rest of items as discount
            // in this case, user selected 2 male, so add both as discount
            if ((1 == nMaleFullQty) || (1 == nFemaleFullQty))
            {
                AddToCart(sMaleDiscountGUID, 2);
            }

            AddKeyForOrderMotion();

            //Response.Redirect("CCBasket.aspx", false);
            Response.Redirect("BasketNew.aspx", false);
            //Response.Redirect("Basket.aspx", false);

            //Response.Redirect("additemresult.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex); // 04/10/08 KPL added
            throw ex;
        }
    }

    protected void btnMen3_Click(object sender, EventArgs e)
    {
        int nTotalQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;

        /********************************************************
         *   Determine # of items in cart and their sku
         * 
         *   if cart is empty
         *       add 1st item as full price
         *       add rest as discount
         *   if cart has a full price item already
         *       add rest of items as discount
         *******************************************************/
        try
        {
            // Calculate total, male, female qty
            DetermineBasketContents(out nMaleFullQty, out nMaleDiscountQty, out nFemaleFullQty, out nFemaleDiscountQty);
            nTotalQty = nMaleFullQty + nMaleDiscountQty + nFemaleFullQty + nFemaleDiscountQty;

            // If cart is empty, add 1st item as full price, rest as discounted.
            // in this case, user selected 3 male, so add 1st as full, last 2 as discount
            if (0 == nTotalQty)
            {
                //put first Male in using current ID (LRM1)
                AddToCart(sMaleProductGUID, 1);

                //add next Male items to cart at Discounted Price (LRMCC1, LRWCC1)
                AddToCart(sMaleDiscountGUID, 2);
            }

            // if cart has a full price item already, add rest of items as discount
            // in this case, user selected 2 male, so add both as discount
            if ((1 == nMaleFullQty) || (1 == nFemaleFullQty))
            {
                AddToCart(sMaleDiscountGUID, 3);
            }

            AddKeyForOrderMotion();

            //Response.Redirect("CCBasket.aspx", false);
            Response.Redirect("BasketNew.aspx", false);
            //Response.Redirect("Basket.aspx", false);

            //Response.Redirect("additemresult.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }
    }

    protected void btnWomen1_Click(object sender, EventArgs e)
    {
        int nTotalQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;
        /********************************************************
         *   Determine # of items in cart and their sku
         * 
         *   if cart is empty
         *       add 1st item as full price
         *       add rest as discount
         *   if cart has a full price item already
         *       add rest of items as discount
         *******************************************************/
        try
        {
            // Calculate total, male, female qty
            DetermineBasketContents(out nMaleFullQty, out nMaleDiscountQty, out nFemaleFullQty, out nFemaleDiscountQty);
            nTotalQty = nMaleFullQty + nMaleDiscountQty + nFemaleFullQty + nFemaleDiscountQty;

            // If cart is empty, add 1st item as full price, rest as discounted.
            // in this case, user selected 1 female, so add 1st as full
            if (0 == nTotalQty)
            {
                //put first female in using current ID (LRW1)
                AddToCart(sFemaleProductGUID, 1);
            }

            // if cart has a full price item already, add rest of items as discount
            // in this case, user selected 1 female, so add as discount
            if ((1 == nMaleFullQty) || (1 == nFemaleFullQty))
            {
                AddToCart(sFemaleDiscountGUID, 1);
            }

            AddKeyForOrderMotion();

            //Response.Redirect("CCBasket.aspx", false);
            Response.Redirect("BasketNew.aspx", false);
            //Response.Redirect("Basket.aspx", false);

            //Response.Redirect("additemresult.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex); // 04/10/08 KPL added
            throw ex;
        }
    }

    protected void btnWomen2_Click(object sender, EventArgs e)
    {
        int nTotalQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;
        /********************************************************
         *   Determine # of items in cart and their sku
         * 
         *   if cart is empty
         *       add 1st item as full price
         *       add rest as discount
         *   if cart has a full price item already
         *       add rest of items as discount
         *******************************************************/
        try
        {
            // Calculate total, male, female qty
            DetermineBasketContents(out nMaleFullQty, out nMaleDiscountQty, out nFemaleFullQty, out nFemaleDiscountQty);

            nTotalQty = nMaleFullQty + nMaleDiscountQty + nFemaleFullQty + nFemaleDiscountQty;

            // If cart is empty, add 1st item as full price, rest as discounted.
            // in this case, user selected 2 male, so add 1st as full, 2nd as discount
            if (0 == nTotalQty)
            {
                //put first Male in using current ID (LRM1)
                AddToCart(sFemaleProductGUID, 1);

                //add next Male items to cart at Discounted Price (LRMCC1, LRWCC1)
                AddToCart(sFemaleDiscountGUID, 1);
            }

            // if cart has a full price item already, add rest of items as discount
            // in this case, user selected 2 male, so add both as discount
            if ((1 == nMaleFullQty) || (1 == nFemaleFullQty))
            {
                AddToCart(sFemaleDiscountGUID, 2);
            }

            AddKeyForOrderMotion();

            //Response.Redirect("CCBasket.aspx", false);
            Response.Redirect("BasketNew.aspx", false);
            //Response.Redirect("Basket.aspx", false);

            //Response.Redirect("additemresult.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }
    }

    protected void btnWomen3_Click(object sender, EventArgs e)
    {
        int nTotalQty = 0;
        int nMaleFullQty = 0;
        int nMaleDiscountQty = 0;
        int nFemaleFullQty = 0;
        int nFemaleDiscountQty = 0;
        /********************************************************
         *   Determine # of items in cart and their sku
         * 
         *   if cart is empty
         *       add 1st item as full price
         *       add rest as discount
         *   if cart has a full price item already
         *       add rest of items as discount
         *******************************************************/
        try
        {
            // Calculate total, male, female qty
            DetermineBasketContents(out nMaleFullQty, out nMaleDiscountQty, out nFemaleFullQty, out nFemaleDiscountQty);
            nTotalQty = nMaleFullQty + nMaleDiscountQty + nFemaleFullQty + nFemaleDiscountQty;

            // If cart is empty, add 1st item as full price, rest as discounted.
            // in this case, user selected 3 male, so add 1st as full, last 2 as discount
            if (0 == nTotalQty)
            {
                //put first Male in using current ID (LRM1)
                AddToCart(sFemaleProductGUID, 1);

                //add next Male items to cart at Discounted Price (LRMCC1, LRWCC1)
                AddToCart(sFemaleDiscountGUID, 2);
            }

            // if cart has a full price item already, add rest of items as discount
            // in this case, user selected 2 male, so add both as discount
            if ((1 == nMaleFullQty) || (1 == nFemaleFullQty))
            {
                AddToCart(sFemaleDiscountGUID, 3);
            }

            AddKeyForOrderMotion();

            //Response.Redirect("CCBasket.aspx", false);
            Response.Redirect("BasketNew.aspx", false);
            //Response.Redirect("Basket.aspx", false);
            //Response.Redirect("additemresult.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }
    }

    /*
    protected void btnWomen1_Click(object sender, EventArgs e)
    {
        string sProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

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

    protected void btnWomen2_Click(object sender, EventArgs e)
    {
        string sProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

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
            //ExceptionPolicy.HandleException(ex, "Application Exception");
            //Response.Redirect(Page.ResolveUrl("~/ExceptionPage.aspx"), false);
        }
    }
    protected void btnWomen3_Click(object sender, EventArgs e)
    {
        string sProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

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
            Response.Redirect("Additemresult.aspx", false);
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
    */


    /**************************************************************    
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

     * //protected void btnWomen1_Click(object sender, ImageClickEventArgs e)
    protected void btnWomen1_Click(object sender, EventArgs e)
    {
        string sProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

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

    protected void btnWomen2_Click(object sender, EventArgs e)
    //protected void btnWomen2_Click(object sender, ImageClickEventArgs e)
    {
        string sProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

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
            //ExceptionPolicy.HandleException(ex, "Application Exception");
            //Response.Redirect(Page.ResolveUrl("~/ExceptionPage.aspx"), false);
        }
    }
    protected void btnWomen3_Click(object sender, EventArgs e)
    {
        string sProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

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
            Response.Redirect("Additemresult.aspx", false);
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

     *********************************************************************/

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
