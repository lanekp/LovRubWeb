using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;
using SubSonic;

namespace Commerce.Common
{
    public class SPsQtyDiscount
    {
        /// <summary>
        /// Creates an object wrapper for the CSK_Store_AddItemToCart_QtyDiscount Stored Procedure
        /// </summary>
        public static StoredProcedure StoreAddItemToCart(string userName, int productID, string attributes, decimal pricePaid, string promoCode, int quantity, decimal attributesPrice)
        {
            SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_AddItemToCart_QtyDiscount");
            sp.Command.AddParameter("@userName", userName, DbType.String);
            sp.Command.AddParameter("@productID", productID, DbType.Int32);
            sp.Command.AddParameter("@attributes", attributes, DbType.String);
            sp.Command.AddParameter("@pricePaid", pricePaid, DbType.Currency);
            sp.Command.AddParameter("@attributesPrice", attributesPrice, DbType.Currency);
            sp.Command.AddParameter("@promoCode", promoCode, DbType.String);
            sp.Command.AddParameter("@quantity", quantity, DbType.Int32);

            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the CSK_Store_Product_QtyDiscount_GetByProductID Stored Procedure
        /// </summary>
        public static StoredProcedure StoreProductQtyDiscountGetByProductID(int productID)
        {
            StoredProcedure sp = new StoredProcedure("CSK_Store_Product_QtyDiscount_GetByProductID");
            sp.Command.AddParameter("@productID", productID);
            return sp;
        }

        /// <summary>
        /// Creates an object wrapper for the CSK_Store_Product_QtyDiscount_Get Stored Procedure
        /// </summary>
        public static StoredProcedure StoreProductQtyDiscountGet(int productID, int quantity)
        {
            StoredProcedure sp = new StoredProcedure("CSK_Store_Product_QtyDiscount_Get");
            sp.Command.AddParameter("@productID", productID);
            sp.Command.AddParameter("@quantity", quantity);
            return sp;
        }
    }

    public partial class QtyDiscountCollection : ActiveList<QtyDiscount>
    {
        #region Extended Data Access

        public static QtyDiscountCollection GetByProductID(int productID)
        {
            QtyDiscountCollection coll = new QtyDiscountCollection();
            using (IDataReader rdr = SPsQtyDiscount.StoreProductQtyDiscountGetByProductID(productID).GetReader())
            {
                coll.Load(rdr);
            }
            return coll;
        }

        #endregion
    }
}