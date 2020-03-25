using System;
using System.Collections.Generic;
using Commerce.Common;
using Commerce.Promotions;

public class QtyDiscountController
{
    public static void SetDiscount()
    {
        //int nTotalQuantity = 0;
        /**
         calculate total qty, maleqty, femaleqty;
          
        **/

        // New prices 09/13/09:First tub3 19.99, all additional tubes 9.99
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
        OrderItemCollection orderItemCollection = OrderController.GetCartItems();
        Order currentOrder = OrderController.GetCurrentOrder();
        int nTotalQuantity = 0;

        foreach (OrderItem currentItem in orderItemCollection)
        {
            // don't count the free ones when calculating price. KPL 1/6/08
            if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                nTotalQuantity += currentItem.Quantity;
        }

        // If total quantity of items is < 2, (ie, ==1), reset price to original, 19.99
        if (nTotalQuantity < 2)
        {
            // don't count the free ones. KPL 1/6/08
            foreach (OrderItem currentItem in orderItemCollection)
            {
                if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                {
                    currentItem.PricePaid = currentItem.OriginalPrice;
                    currentItem.Save(Utility.GetUserName());
                }
            }
            // Add a Column to Order Table to save the collection as Xml to show it later !!! 
            //currentOrder.DiscountDisplay = ddc.ToXml();
            currentOrder.Save(Utility.GetUserName());
            return;
        }

        // If total quantity of items is 2 or more, set first to 19.99, rest to 9.99
        if (nTotalQuantity >= 2)
        {
            // set price of 1st item to 19.99
            OrderItemCollection items = OrderController.GetCartItems();
            OrderItem item = items[0];
            
            item.PricePaid = item.OriginalPrice;
            item.Save(Utility.GetUserName());

            int nCount = items.Count;

            // set price of rest of items to 9.99
            for (int nIndex = 1; nIndex < nCount; nIndex++)
            {
                item = items[nIndex];
                item.PricePaid = item.OriginalPrice - 10;
                item.Save(Utility.GetUserName());

            }

        }
        

        // If total quantity of items is 2 or more, set first to 19.99, rest to 9.99
        if (nTotalQuantity >= 2)
        {
            foreach (OrderItem currentItem in orderItemCollection)
            {
                // if it's a free product, ignore. KPL 01/06/08
                if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                {
                    currentItem.PricePaid = currentItem.OriginalPrice - 2;
                    currentItem.Save(Utility.GetUserName());
                }
            }
            // Add a Column to Order Table to save the collection as Xml to show it later !!! 
            //currentOrder.DiscountDisplay = ddc.ToXml();
            currentOrder.Save(Utility.GetUserName());
            return;
        }

        // If total quantity of items is 2, set each to 17.95
        if (2 == nTotalQuantity)
        {
            foreach (OrderItem currentItem in orderItemCollection)
            {
                if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                {
                    currentItem.PricePaid = currentItem.OriginalPrice - 2;
                    currentItem.Save(Utility.GetUserName());
                }
            }
            // Add a Column to Order Table to save the collection as Xml to show it later !!! 
            //currentOrder.DiscountDisplay = ddc.ToXml();
            currentOrder.Save(Utility.GetUserName());
            return;
        }

        /************ 09/13/09 KPL Commented out due to new price changes 
                OrderItemCollection orderItemCollection = OrderController.GetCartItems();
                Order currentOrder = OrderController.GetCurrentOrder();
                int nTotalQuantity = 0;

                foreach (OrderItem currentItem in orderItemCollection)
                {
                    // don't count the free ones when calculating price. KPL 1/6/08
                    if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                        nTotalQuantity += currentItem.Quantity;
                }

                // If total quantity of items is < 2, reset price to original.
                if (nTotalQuantity < 2)
                {
                    // don't count the free ones. KPL 1/6/08
                    foreach (OrderItem currentItem in orderItemCollection)
                    {
                        if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                        {
                            currentItem.PricePaid = currentItem.OriginalPrice;
                            currentItem.Save(Utility.GetUserName());
                        }
                    }
                    // Add a Column to Order Table to save the collection as Xml to show it later !!! 
                    //currentOrder.DiscountDisplay = ddc.ToXml();
                    currentOrder.Save(Utility.GetUserName());
                    return;
                }

                // If total quantity of items is 3 or more, set each to 17.99
                if (nTotalQuantity >= 3)
                {
                    foreach (OrderItem currentItem in orderItemCollection)
                    {
                        // if it's a free product, ignore. KPL 01/06/08
                        if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                        {
                            currentItem.PricePaid = currentItem.OriginalPrice - 2;
                            currentItem.Save(Utility.GetUserName());
                        }
                    }
                    // Add a Column to Order Table to save the collection as Xml to show it later !!! 
                    //currentOrder.DiscountDisplay = ddc.ToXml();
                    currentOrder.Save(Utility.GetUserName());
                    return;
                }

                // If total quantity of items is 2, set each to 17.95
                if (2 == nTotalQuantity)
                {
                    foreach (OrderItem currentItem in orderItemCollection)
                    {
                        if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                        {
                            currentItem.PricePaid = currentItem.OriginalPrice - 2;
                            currentItem.Save(Utility.GetUserName());
                        }
                    }
                    // Add a Column to Order Table to save the collection as Xml to show it later !!! 
                    //currentOrder.DiscountDisplay = ddc.ToXml();
                    currentOrder.Save(Utility.GetUserName());
                    return;
                }

        09/13/09 KPL ***************************************/

        /**** KPL 03/04/08 Commented out due to price change from 29.95 to 19.95       
                        OrderItemCollection orderItemCollection = OrderController.GetCartItems();
                        Order currentOrder = OrderController.GetCurrentOrder();
                        int nTotalQuantity = 0;

                        foreach (OrderItem currentItem in orderItemCollection)
                        {
                            // don't count the free ones when calculating price. KPL 1/6/08
                            if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                                nTotalQuantity += currentItem.Quantity;
                        }
                                // If total quantity of items is < 2, reset price to original.
                                if (nTotalQuantity < 2)
                                {
                                     // don't count the free ones. KPL 1/6/08
                                    foreach (OrderItem currentItem in orderItemCollection)
                                    {
                                        if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                                        {
                                            currentItem.PricePaid = currentItem.OriginalPrice;
                                            currentItem.Save(Utility.GetUserName());
                                        }
                                    }
                                    // Add a Column to Order Table to save the collection as Xml to show it later !!! 
                                    //currentOrder.DiscountDisplay = ddc.ToXml();
                                    currentOrder.Save(Utility.GetUserName());
                                    return;
                                }
        
                                // If total quantity of items is 3 or more, set each to 19.99
                                if (nTotalQuantity >= 3)
                                {
                                    foreach (OrderItem currentItem in orderItemCollection)
                                    {
                                        // if it's a free product, ignore. KPL 01/06/08
                                        if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                                        {
                                            currentItem.PricePaid = currentItem.OriginalPrice - 10;
                                            currentItem.Save(Utility.GetUserName());
                                        }
                                    }
                                    // Add a Column to Order Table to save the collection as Xml to show it later !!! 
                                    //currentOrder.DiscountDisplay = ddc.ToXml();
                                    currentOrder.Save(Utility.GetUserName());
                                    return;
                                }

                                // If total quantity of items is 2, set each to 24.99        
                                if (2 == nTotalQuantity)
                                {
                                    foreach (OrderItem currentItem in orderItemCollection)
                                    {
                                        if (("LRFreeMale" != currentItem.Sku) && ("LRFreeFemale" != currentItem.Sku))
                                        {
                                            currentItem.PricePaid = currentItem.OriginalPrice - 5;
                                            currentItem.Save(Utility.GetUserName());
                                        }
                                    }
                                    // Add a Column to Order Table to save the collection as Xml to show it later !!! 
                                    //currentOrder.DiscountDisplay = ddc.ToXml();
                                    currentOrder.Save(Utility.GetUserName());
                                    return;
                                }
                **** END KPL 03/04/08 Commented out due to price change from 29.95 to 19.95       ***/

        /***************************************************************** KPL 
        int key = 0;
        Order currentOrder = OrderController.GetCurrentOrder();
        Dictionary<int, DiscountDisplay> dic = new Dictionary<int, DiscountDisplay>();
        foreach (OrderItem currentItem in currentOrder.Items)
        {
            if (currentItem != null)
            {
                if (!currentItem.PromoCode.StartsWith("BUNDLE:"))
                {
                    key = currentItem.ProductID;
                    if (!dic.ContainsKey(key))
                    {
                        dic.Add(key, new DiscountDisplay(currentItem.Quantity, currentItem.OriginalPrice, currentItem.ProductName));
                    }
                    else
                    {
                        DiscountDisplay item = new DiscountDisplay();
                        dic.TryGetValue(key, out item);
                        dic.Remove(key);
                        item.Qty = currentItem.Quantity + item.Qty;
                        dic.Add(key, item);
                    }
                }
            }
        }

        Dictionary<int, DiscountDisplay>.Enumerator enumerator = dic.GetEnumerator();
        DiscountDisplayCollection ddc = new DiscountDisplayCollection();
        while (enumerator.MoveNext())
        {
            DiscountDisplay discount = DiscountDisplay.GetDiscount(enumerator.Current.Key, enumerator.Current.Value.Qty, enumerator.Current.Value.Price);
            if (discount != null)
            {
                //bool display = false;
                foreach (OrderItem currentItem in currentOrder.Items)
                {
                    if (currentItem != null)
                    {
                        if (currentItem.ProductID == enumerator.Current.Key)
                        {
                            // note:
                            // discount.IsActive is checked in the query to the database

                            if (discount.IsPercent)
                            {
                                Product product = new Product(currentItem.ProductID);
                                PromotionService.SetProductPricing(product);
                                if (discount.Discount > (100 * product.YouSavePercent))
                                {
                                    currentItem.PricePaid = ((currentItem.OriginalPrice - (currentItem.OriginalPrice * (discount.Discount / 100))) + currentItem.AttributesPrice);
                                    currentItem.Save(Utility.GetUserName());
                                    //display = true;
                                }
                                else
                                {
                                    currentItem.PricePaid = product.OurPrice + currentItem.AttributesPrice;
                                    currentItem.Save(Utility.GetUserName());
                                }
                            }
                            else
                            {
                                currentItem.PricePaid = (currentItem.OriginalPrice - discount.Discount) + currentItem.AttributesPrice;
                                currentItem.Save(Utility.GetUserName());
                            }
                        }
                    }
                }
                //if (display)
                //    ddc.Add(new DiscountDisplay(discount.Qty, discount.Discount, discount.DiscountAmount, enumerator.Current.Value.Name, discount.IsPercent));
            }
            else
            {
                foreach (OrderItem currentItem in currentOrder.Items)
                {
                    if (currentItem != null)
                    {
                        if (currentItem.ProductID == enumerator.Current.Key)
                        {
                            if (!currentItem.PromoCode.StartsWith("BUNDLE:"))
                            {
                                Product product = new Product(enumerator.Current.Key);
                                PromotionService.SetProductPricing(product);
                                currentItem.PricePaid = product.OurPrice + currentItem.AttributesPrice;
                                currentItem.Save(Utility.GetUserName());
                            }
                        }
                    }
                }
            }
        }
        // Add a Column to Order Table to save the collection as Xml to show it later !!! 
        //currentOrder.DiscountDisplay = ddc.ToXml();
        currentOrder.Save(Utility.GetUserName());
        ****************************************************KPL ***/
    }
}