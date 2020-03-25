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


namespace LovRubWeb.Products
{
    public partial class SurvivalKit : ProdPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int nNewQty = 0;

            if (txtQty.Text.Equals(""))
                return;
            try
            {
                int.TryParse(txtQty.Text, out nNewQty);
                
                if (0 == nNewQty)
                    return;

                AddToCart(sSurvivalGUID, nNewQty);

                //AddKeyForOrderMotion();

                Response.Redirect("~/BasketLV3.aspx", false);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }

/*************************************************************************

            int nTotalQty = 0;
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

            int nNewQty = 0;
************/

            /********************************************************
             *   Determine # of items in cart and their sku
             * 
             *   Determine # of new items to be added
             * 
             *   if cart is empty
             *      if 1 == nNewQty 
             *         add 1st item as full price
             *      if nNewQty > 1
             *          add 1st item as full price
             *          add rest as discount
             * 
             *   if cart has a full price item already
             *       add rest of items as discount
             *   if cart > 2 items and none are DFDF
             *      add DFDF
             *******************************************************/

/*************************************************
            if (txtQty.Text.Equals(""))
                return;
            try
            {
                int.TryParse(txtQty.Text, out nNewQty);

                // Calculate total, male, female, RubLov qty
                OrderController.DetermineBasketContents(out nMaleFullQty,
                                                        out nMaleDiscountQty,
                                                        out nFemaleFullQty,
                                                        out nFemaleDiscountQty,
                                                        out nRL6FullQty,
                                                        out nRLG6DiscountQty,
                                                        out nRLFreeQty,
                                                        out nSeasonalQty,
                                                        out nLipLovFullQty,
                                                        out nLipLovDiscountQty);

                nTotalQty = nMaleFullQty +
                            nMaleDiscountQty +
                            nFemaleFullQty +
                            nFemaleDiscountQty +
                            nRL6FullQty +
                            nRLG6DiscountQty +
                            nRLFreeQty +
                            nSeasonalQty +
                            nLipLovFullQty +
                            nLipLovDiscountQty;

                // If cart is empty, add 1st item as full price, rest as discounted.
                if (0 == nTotalQty)
                {
                    if (1 == nNewQty)
                        //put first Male in using current ID (LRM1)
                        AddToCart(sMaleProductGUID, 1);

                    // add 1st item as full price, rest as discounted.
                    if (nNewQty > 1)
                    {
                        AddToCart(sMaleProductGUID, 1);

                        // add rest as discount    
                        int nDiscountedMaleItems = nNewQty - 1;
                        if (nDiscountedMaleItems > 0)
                            AddToCart(sMaleDiscountGUID, nDiscountedMaleItems);
                    }
                }

                // if cart has a full price item already, add rest of items as discount
                if ((0 != nMaleFullQty) || (0 != nFemaleFullQty) || (0 != nRL6FullQty) || (0 != nLipLovFullQty))
                {
                    AddToCart(sMaleDiscountGUID, nNewQty);
                }

                AddKeyForOrderMotion();

                Response.Redirect("~/BasketLV3.aspx", false);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);
                throw ex;
            }
*********************************************/            
        }
    }
}
