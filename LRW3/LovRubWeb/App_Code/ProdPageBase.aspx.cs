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
using Commerce.Common;
using Commerce.Promotions;


public partial class ProdPageBase : System.Web.UI.Page
{
    protected string sFreeMassageGelGUID  = "f7ada596-0385-4314-8b13-bd949d3856f0";
    protected string sStockingGUID        = "f3c2cb6e-e224-4b58-a270-9ac31ef13802";

    protected string sMaleProductGUID     = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
    protected string sFemaleProductGUID   = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";

    protected string sMaleDiscountGUID    = "38dbc864-dea2-4b78-a745-2bef70336368";
    protected string sFemaleDiscountGUID  = "5424233a-4d2b-45a3-a9c0-6cf2fab56a22";

    protected string sRubLov6GUID         = "dddf82e5-796c-49fe-95a8-83fb79eaa3ee";
    protected string sRubLov6DiscountGUID = "d2dfe1fb-e90d-4fae-8ab7-fab38ff272eb";

    protected string sHisHersValentineGUID = "f98cd88b-7aee-4e15-ba2c-f8abdd6dbe07";
    protected string sGayValentineGUID     = "11fe2708-c8e4-44b7-bac8-f6fb45c962ba";
    protected string sLesboValentineGUID   = "350373f2-01af-4211-a567-eecd249a4b2f";

    protected string sLipLovGUID           = "c5dfd625-efdb-4cbf-8581-2a822a8b8836";
    protected string sLipLovDiscountGUID   = "e9f87c75-d0a4-4409-8b7d-7448a8250a5d";
    protected string sSurvivalGUID         = "675ffc62-e55a-4f47-910b-7bee55bba3d2";

    protected string sCherryBDGUID         = "b76c20e0-2c46-4311-bdd8-913c5122b6be";
    protected string sChocolateBDGUID      = "40acdde9-008b-4271-b0cb-31e8daf60394";

    // Valentine's Day 2010 Products
    protected string sHisChocDelightGUID     = "4264d680-d177-4db2-b30d-5281c9cce7b5";
    protected string sHersChocDelightGUID    = "1cc7a50b-b4b0-49f1-9bd6-bba1cb7bbdaa";
    protected string sHisHersChocDelightGUID = "ff8cf450-d888-4228-8deb-4db3e6355ed4";


    protected int productID;
    protected string productSku;
    protected Guid productGUID;

    private Commerce.Common.Product product = null;
    protected ProductDiscount discount;

    /****************************************************************
     * 
     * AddToCart()
     * 
     ***************************************************************/
    protected void AddToCart(string sGUID, int nQty)
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
            /********************
            //* the following if stmt is to track orders from TheLoveDepot.com 2/10
            string sID = "";
            sID = HttpContext.Current.Request.Cookies["ID"].Value;
            if (sID != null)
            {
                Order currentOrder = OrderController.GetCurrentOrder();
                OrderController.AddNote(sID, currentOrder);
            }
            **************/
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }
    }

    
    /****************************************************************
     * 
     * AddKeyForOrderMotion()
     * 
     ***************************************************************/
    public void AddKeyForOrderMotion()
    {
        /************** we got rid of OM
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
        ************************* WE GOT RID OF OM **/
    }

    
    public void Click(int nNewQty, string sFullPriceGUID, string sDiscountPriceGUID)
    {
        int nTotalPaidQty = 0;
        int nMaleFullQty = 0;
        int nFemaleFullQty = 0;
        int nRL6FullQty = 0;
        int nRLFreeQty = 0;
        int nLipLovFullQty = 0;
        int nSurvivalFullQty = 0;

         //********************************************************
         //*   Determine # of items in cart and their sku
         //* 
         //*   Determine # of new items to be added
         //* 
         //*   if cart > 2 items and none are DFDF
         //*      add DFDF
         //*******************************************************
        if (nNewQty <= 0)
            return;

        try
        {
            AddToCart(sFullPriceGUID, nNewQty);
            //AddKeyForOrderMotion();
            Response.Redirect("~/BasketLV3.aspx", false);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }

    }

    /************** 11/24 remove discounted items.
    public void Click( int nNewQty, string sFullPriceGUID, string sDiscountPriceGUID )
    {
            int nTotalPaidQty = 0;
            int nMaleFullQty = 0;
            int nMaleDiscountQty = 0;
            int nFemaleFullQty = 0;
            int nFemaleDiscountQty = 0;
            int nRL6FullQty = 0;
            int nRLG6DiscountQty = 0;
            int nRLFreeQty = 0;
            int nSeasonalQty = 0;
            int nLipLovFullQty = 0;
            int nLipLovDiscountQty = 0;
            int nSurvivalFullQty = 0;

             //********************************************************
             //*   Determine # of items in cart and their sku
             //* 
             //*   Determine # of new items to be added
             //* 
             //*   if cart is empty
             //*      if 1 == nNewQty 
             //*         add 1st item as full price
             //*      if nNewQty > 1
             //*          add 1st item as full price
             //*          add rest as discount
             //* 
             //*   if cart has a full price item already
             //*       add rest of items as discount
             //*   if cart > 2 items and none are DFDF
             //*      add DFDF
             //*******************************************************
            if (nNewQty <= 0)
                return;

            try
            {
                // Calculate total, male, female, RubLov qty
                OrderController.DetermineBasketContents(out nTotalPaidQty,
                                                       out nMaleFullQty,
                                                       out nMaleDiscountQty,
                                                       out nFemaleFullQty,
                                                       out nFemaleDiscountQty,
                                                       out nRL6FullQty,
                                                       out nRLG6DiscountQty,
                                                       out nRLFreeQty,
                                                       out nSeasonalQty,
                                                       out nLipLovFullQty,
                                                       out nLipLovDiscountQty,
                                                       out nSurvivalFullQty);

                // If cart is empty, add 1st item as full price, rest as discounted.
                if (0 == nTotalPaidQty)
                {
                    if (1 == nNewQty)
                        //put first Male in using current ID (LRM1)
                        AddToCart(sFullPriceGUID, 1);

                    // add 1st item as full price, rest as discounted.
                    if (nNewQty > 1)
                    {
                        AddToCart(sFullPriceGUID, 1);

                        // add rest as discount    
                        int nDiscountedLipLovItems = nNewQty - 1;
                        if (nDiscountedLipLovItems > 0)
                            AddToCart(sDiscountPriceGUID, nDiscountedLipLovItems);
                    }
                }

                // if cart has a full price item already, add rest of items as discount
                if ((0 != nMaleFullQty) || 
                    (0 != nFemaleFullQty) || 
                    (0 != nRL6FullQty) || 
                    (0 != nLipLovFullQty) || 
                    (0 != nSurvivalFullQty))
                {
                    AddToCart(sDiscountPriceGUID, nNewQty);
                }

                AddKeyForOrderMotion();

                Response.Redirect("~/BasketLV3.aspx", false);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }
        
    }
     ************* 11/24 ***/
}
