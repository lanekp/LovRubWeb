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

public partial class CallCenter : System.Web.UI.Page
{
    protected int productID;
    protected string productSku;
    protected Guid productGUID;
    int nFreeBottles = 0;
    int nMaleQty, nFemaleQty, nTotalQty = 0;
    Order currentOrder = null;
    bool bSuccess;

    private Commerce.Common.Product product = null;
    //protected ProductDiscount discount;

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    /********************* code for old call center 06/06/08 KPL
    protected void CalcBtn_Click(object sender, EventArgs e)
    {
        // Validate input amounts.
        bSuccess = int.TryParse(txtMaleQty.Text, out nMaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "incorrectMale Qty";
            txtMaleQty.Text = "0";
            return;
        }


        bSuccess = int.TryParse(txtFemaleQty.Text, out nFemaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "incorrectFemale Qty";
            txtFemaleQty.Text = "0";
            return;
        }


        if ((0 == nFemaleQty) && (0 == nMaleQty))
            return;


        // calculate # of free bottles.
        // nFreeBottles s/b == (nFreeFemaleQty + nFreeMaleQty)
        nTotalQty = nMaleQty + nFemaleQty;
        if (nTotalQty < 3)
            nFreeBottles = 0;
        else
            nFreeBottles = (nTotalQty / 3);

      
        // if user gets any free stuff, prompt for it else go to CCBasket
        if (nFreeBottles > 0)
        {
            lblStatusMsg.Text = "Number of Free Bottle(s) is: " + nFreeBottles.ToString();

            // display free bottle controls
            txtFreeMaleQty.Visible = true;
            txtFreeMaleQty.Text = "0";
            lblFreeMaleQty.Visible = true;

            lblFreeFemaleQty.Visible = true;
            txtFreeFemaleQty.Text = "0";
            txtFreeFemaleQty.Visible = true;

            // disable Qty controls
            txtMaleQty.Enabled = false;
            txtFemaleQty.Enabled = false;

            CalcBtn.Enabled = false;
            SubmitBtn.Enabled = true;
            SubmitBtn.Visible = true;
        }
        else
            //Response.Redirect("~/CCBasket.aspx", false);
            //AddToCart(nMaleQty, nFemaleQty, nFreeBottles);
            Submit_Click(sender, e);
    }
    ****************************************************************/
/**************************************
    protected void Submit_Click(object sender, EventArgs e)
    {
        
        // make sure # of free bottles entered matches calculated value
        // Validate input amounts.
        bSuccess = int.TryParse(txtMaleQty.Text, out nMaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "Incorrect Male Qty";
            txtMaleQty.Text = "0";
            return;
        }

        bSuccess = int.TryParse(txtFemaleQty.Text, out nFemaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "Incorrect Female Qty";
            txtFemaleQty.Text = "0";
            return;
        }

        bSuccess = int.TryParse(txtFreeMaleQty.Text, out nFreeMaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "Incorrect Free Male Qty";
            txtFreeMaleQty.Text = "0";
            return;
        }

        bSuccess = int.TryParse(txtFreeFemaleQty.Text, out nFreeFemaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "Incorrect Free female Qty";
            txtFreeFemaleQty.Text = "0";
            return;
        }

        // determine if the # of free bottles is correct. if not display error message.
        // nFreeBottles s/b == (nFreeFemaleQty + nFreeMaleQty)
        nTotalQty = nMaleQty + nFemaleQty;
        if (nTotalQty < 3)
            nFreeBottles = 0;
        else
            nFreeBottles = (nTotalQty / 3);

        if (nFreeBottles != (nFreeFemaleQty + nFreeMaleQty))
        {
            lblStatusMsg.Text = "Incorrect # of free bottles entered";
            return;
        }
      
        //******************************************************
        // Add the 'paid' items to the cart.
        //******************************************************
        // add the Female items to the cart.
        if (nFemaleQty > 0)
        {
            string sFemaleProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";
            productGUID = new Guid(sFemaleProductGUID);
            try
            {
                product = ProductController.GetProductDeepByGUID(productGUID);
                //make sure we have a product
                TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

                //set the page variables
                productID = product.ProductID;
                productSku = product.Sku;
                product.Quantity = nFemaleQty;
                OrderController.AddItem(product);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);  // KPL 04/09/08
                throw ex;
            }
        }

        // add the Male items to the cart.
        if (nMaleQty > 0)
        {
            string sMaleProductGUID = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
            productGUID = new Guid(sMaleProductGUID);
            try
            {
                product = ProductController.GetProductDeepByGUID(productGUID);
                //make sure we have a product
                TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

                //set the page variables
                productID = product.ProductID;
                productSku = product.Sku;
                product.Quantity = nMaleQty;
                OrderController.AddItem(product);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);  // KPL 04/09/08
                throw ex;
            }
        }
        
        //AddToCart(nMaleQty, nFemaleQty, nFreeBottles);

        //*********************************************
        // Add Free Male items to cart.
        //*********************************************
        //nFreeFemaleQty + nFreeMaleQty
        if (nFreeMaleQty > 0)
        {
            string sFreeMaleProductGUID = "b3e3732a-5bfa-4ebf-9dcd-bae2de80a893";
            productGUID = new Guid(sFreeMaleProductGUID);
            try
            {
                product = ProductController.GetProductDeepByGUID(productGUID);
                //make sure we have a product
                TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

                //set the page variables
                productID = product.ProductID;
                productSku = product.Sku;
                product.Quantity = nFreeMaleQty;
                OrderController.AddItem(product);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);  // KPL 04/09/08
                throw ex;
            }
        }
        //*********************************************
        // Add Free Female items to cart.
        //*********************************************
        //nFreeFemaleQty + nFreeMaleQty
        if (nFreeFemaleQty > 0)
        {
            string sFreeFemaleProductGUID = "a4b9c045-22be-47aa-a13b-b6151427ddeb";
            //a4b9c045-22be-47aa-a13b-b6151427ddeb
            productGUID = new Guid(sFreeFemaleProductGUID);
            try
            {
                product = ProductController.GetProductDeepByGUID(productGUID);
                //make sure we have a product
                TestCondition.IsTrue(product.IsLoaded, "Invalid url/product id");

                //set the page variables
                productID = product.ProductID;
                productSku = product.Sku;
                product.Quantity = nFreeFemaleQty;
                OrderController.AddItem(product);
            }
            catch (Exception ex)
            {
                LovRubLogger.LogException(ex);  // KPL 04/09/08
                throw ex;
            }
        }
        // Add keycode for OrderMotion
        // but only add one note, so check to see if the keycode note has already been added.
        bool bIsCallCtrOrder = false;
        currentOrder = OrderController.GetCurrentOrder();
        OrderNoteCollection noteCollection = currentOrder.Notes;
        int nCount = noteCollection.Count;
        for (int nIndex = 0; nCount > nIndex; nIndex++)
        {
            OrderNote note = noteCollection[ nIndex ];
            if (!note.Equals("CALLCENTER"))
                bIsCallCtrOrder = true;
        }
        if (!bIsCallCtrOrder)
            OrderController.AddNote("CALLCENTER", currentOrder);
        // redirect to 'additemresult.aspx'
        if ( (nMaleQty > 0)|| (nFemaleQty > 0) )
            Response.Redirect("CCBasket.aspx", false);
    }
}   
 *****************************************************************/

    protected bool ValidateInputQty()
    {
        bSuccess = int.TryParse(txtMaleQty.Text, out nMaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "incorrectMale Qty";
            txtMaleQty.Text = "0";
            return false;
        }

        bSuccess = int.TryParse(txtFemaleQty.Text, out nFemaleQty);
        if (!bSuccess)
        {
            lblStatusMsg.Text = "incorrectFemale Qty";
            txtFemaleQty.Text = "0";
            return false;
        }
        return true;
    }
    protected void CalcBtn_Click(object sender, EventArgs e)
    {
        // Validate input amounts.
        if (!ValidateInputQty())
            return;

        if ((0 == nFemaleQty) && (0 == nMaleQty))
            return;

        // calculate # of free bottles.
        nTotalQty = nMaleQty + nFemaleQty;
        if (nTotalQty > 1)
            nFreeBottles = 1;

        // if user is eligible for any free stuff, prompt for it else go to CCBasket
        if (nFreeBottles > 0)
        {
            lblStatusMsg.Text = "Customer is entitled to 1 free bottle of RubLov Massage Gel";

            CalcBtn.Enabled = false;
            SubmitBtn.Enabled = true;
            SubmitBtn.Visible = true;
            lblFreeMaleQty.Visible = true;
            CheckBox1.Visible = true;
        }
        else
            Submit_Click(sender, e);
    }

    /****************************************************************
     * 
     * AddToCart()
     * 
     * *************************************************************/
    void AddToCart( string sGUID, int nQty)
    {
        //string sFemaleProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";
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

            //**********************************************************************************
            // Add keycode for OrderMotion
            // but only add one note, so check to see if the keycode note has already been added.
            //**********************************************************************************
            bool bIsCallCtrOrder = false;
            currentOrder = OrderController.GetCurrentOrder();
            OrderNoteCollection noteCollection = currentOrder.Notes;
            int nCount = noteCollection.Count;
            for (int nIndex = 0; nCount > nIndex; nIndex++)
            {
                OrderNote note = noteCollection[nIndex];
                //if (note.Equals("CALLCENTER"))
                if (true == note.Note.Equals("CALLCENTER"))
                {
                    bIsCallCtrOrder = true;
                    break;
                }
            }
            if (false == bIsCallCtrOrder)
                OrderController.AddNote("CALLCENTER", currentOrder);
        }
        catch (Exception ex)
        {
            LovRubLogger.LogException(ex);
            throw ex;
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        string sMaleProductGUID = "a3ba18d1-b7d0-488c-9687-706873e0ee53";
        string sFemaleProductGUID = "f6d3b994-d5ca-491f-b55a-f22fa8974b25";
        // Local GUIDs
        //string sMaleDiscountGUID = "63365e35-8bfa-47ec-b83b-b799fc5e7cf5";
        //string sFemaleDiscountGUID = "5977c427-2f44-40e8-bf5f-14e68d6d3e03";
        //string sMassageGelGUID = "698b62ca-0672-49ba-a760-db0729bec0ea";

        // Production GUIDs
        string sMaleDiscountGUID = "38dbc864-dea2-4b78-a745-2bef70336368";
        string sFemaleDiscountGUID = "5424233a-4d2b-45a3-a9c0-6cf2fab56a22";
        string sMassageGelGUID = "f7ada596-0385-4314-8b13-bd949d3856f0";

        int nCounter = 0;
        bool bAlreadyChargedFullPrice = false;

        // Validate input amounts.
        // make sure # of free bottles entered matches calculated value
        if (!ValidateInputQty())
            return;

        if (true == CheckBox1.Checked)
            nFreeBottles = 1;
     
        //******************************************************
        // Add the ordered items to the cart.
        //******************************************************
        nTotalQty = nMaleQty + nFemaleQty;
        if (1 == nTotalQty)
        {
            // determine if male or female
            // add the 1 Female item to the cart.
            if (nFemaleQty > 0)
            {
                AddToCart(sFemaleProductGUID, nFemaleQty);
            }
            // add the 1 Male item to the cart.
            if (nMaleQty > 0)
            {
                AddToCart(sMaleProductGUID, nMaleQty);
            }
        } //if (1 == nTotalQty)

        /*****************************************
         * if 2 or more items
         *      if nMaleQty > 0
         *          put first Male in using current ID (LRM1)
         *          bAlreadyChargedFullPrice = true;* 
         *          nMaleQty--;
         *      
         *          while(0 != nMaleQty)
         *              add next item to cart as a new ID (LRMCC1, LRWCC1)
         *              nMaleQty--;
         *   
         *      if nFemaleQty > 0
         *          if (!bAlreadyChargeFullPrice)
         *                  put first female in using current ID (LRW1)
         *                  bAlreadyChargedFullPrice = true;* 
         *                  nFemaleQty--;
         *              
         *          while(0 != nFemaleQty)
         *              add next item to cart as a new ID (LRMCC1, LRWCC1)
         *              nFemaleQty--;
         *      if nFreeBottle
         *          add RubLov Massage Gel into cart (DFDF).
         * 
         ****************************************/
        if (nTotalQty >= 2)
        {
            if (nMaleQty > 0)
            {
                nCounter = nMaleQty;
                //put first Male in using current ID (LRM1)
                AddToCart(sMaleProductGUID, 1);
                bAlreadyChargedFullPrice = true;
                nCounter--;
                if (0 != nCounter)
                    //add next Male items to cart at Discounted Price (LRMCC1, LRWCC1)
                    AddToCart(sMaleDiscountGUID, nCounter);
            }
            if (nFemaleQty > 0)
            {
                nCounter = nFemaleQty;
                if (false == bAlreadyChargedFullPrice)
                {
                    //put first Female in using current ID (LRW1)
                    AddToCart(sFemaleProductGUID, 1);
                    bAlreadyChargedFullPrice = true;
                    nCounter--;
                }
                if (0 != nCounter)
                    //add rest of female items at Discounted Price (LRMCC1, LRWCC1)
                    AddToCart(sFemaleDiscountGUID, nCounter);
            }

            if (1 == nFreeBottles)
                AddToCart(sMassageGelGUID, 1);
        }

        // Add keycode for OrderMotion
        // but only add one note, so check to see if the keycode note has already been added.
        bool bIsCallCtrOrder = false;
        currentOrder = OrderController.GetCurrentOrder();
        OrderNoteCollection noteCollection = currentOrder.Notes;
        int nCount = noteCollection.Count;
        for (int nIndex = 0; nCount > nIndex; nIndex++)
        {
            OrderNote note = noteCollection[ nIndex ];
            if (!note.Equals("CALLCENTER"))
            {
                bIsCallCtrOrder = true;
                break;
            }
        }
        if (false == bIsCallCtrOrder)
            OrderController.AddNote("CALLCENTER", currentOrder);

        // redirect to 'CCBasket.aspx'
        if ( (nMaleQty > 0) || (nFemaleQty > 0) )
            Response.Redirect("CCBasket.aspx", false);
    }
}
