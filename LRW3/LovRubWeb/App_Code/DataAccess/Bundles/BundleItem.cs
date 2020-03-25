#region dCPL Version 1.1.1
/*
The contents of this file are subject to the dashCommerce Public License
Version 1.1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.dashcommerce.org

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is dashCommerce.

The Initial Developer of the Original Code is Mettle Systems LLC.
Portions created by Mettle Systems LLC are Copyright (C) 2007. All Rights Reserved.
*/
#endregion
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Commerce.Promotions
{
    public class BundleItemCollection : List<BundleItem>
    {

    }
    public class BundleItem 
    {


        #region private vars

        int _ProductID;
        string _Sku;
        string _ProductName;
        string _ShortDescription;
        decimal _OurPrice;
        decimal _RetailPrice;
        string _ImageFile;
        string _BundleName;
        int _DiscountPercent;
        string _Description;
        int _BundleID;
        #endregion

        #region Public Props
        public int ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        public string Sku
        {
            get
            {
                return _Sku;
            }
            set
            {
                _Sku = value;
            }
        }
        public string ProductName
        {
            get
            {
                return _ProductName;
            }
            set
            {
                _ProductName = value;
            }
        }
        public string ShortDescription
        {
            get
            {
                return _ShortDescription;
            }
            set
            {
                _ShortDescription = value;
            }
        }
        public decimal OurPrice
        {
            get
            {
                return _OurPrice;
            }
            set
            {
                _OurPrice = value;
            }
        }
        public decimal RetailPrice
        {
            get
            {
                return _RetailPrice;
            }
            set
            {
                _RetailPrice = value;
            }
        }
        public string ImageFile
        {
            get
            {
                return _ImageFile;
            }
            set
            {
                _ImageFile = value;
            }
        }
        public string BundleName
        {
            get
            {
                return _BundleName;
            }
            set
            {
                _BundleName = value;
            }
        }
        public int DiscountPercent
        {
            get
            {
                return _DiscountPercent;
            }
            set
            {
                _DiscountPercent = value;
            }
        }
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        public int BundleID
        {
            get
            {
                return _BundleID;
            }
            set
            {
                _BundleID = value;
            }
        }
        #endregion

        public void Load(IDataReader rdr)
        {
            try{_ProductID = (int)rdr["ProductID"];}catch{};
            try{_Sku = rdr["Sku"].ToString();}catch{};
            try{_ProductName = rdr["ProductName"].ToString();}catch{};
            try{_ShortDescription = rdr["ShortDescription"].ToString();}catch{};
            try{_OurPrice = (decimal)rdr["OurPrice"];}catch{};
            try{_RetailPrice = (decimal)rdr["RetailPrice"];}catch{};
            try{_ImageFile = rdr["ImageFile"].ToString();}catch{};
            try{_BundleName = rdr["BundleName"].ToString();}catch{};
            try{_DiscountPercent = (int)rdr["DiscountPercent"];}catch{};
            try{_Description = rdr["Description"].ToString();}catch{};
            try { _BundleID = (int)rdr["BundleID"]; } catch { };
        }


        #region Extended Data Access
        /// <summary>
        /// Executes "CSK_Promo_Bundle_GetList" and returns the results in an BundleCollection 
        /// </summary>
        /// <returns>Commerce.Common.BundleCollection </returns>	
        public static BundleItemCollection GetByProductID(int productID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            BundleItemCollection coll = null;
            DbCommand dbCommand = null;
            try
            {
                //specify the SP
                string cmd = "CSK_Promo_Bundle_GetByProductID";
                using (dbCommand = db.GetStoredProcCommand(cmd))
                {
                    db.AddInParameter(dbCommand, "@productID", DbType.Int32, productID);
                    coll = new BundleItemCollection();

                    //Load the reader
                    IDataReader rdr = db.ExecuteReader(dbCommand);
                    BundleItem item;
                    while (rdr.Read())
                    {
                        item = new BundleItem();
                        item.Load(rdr);
                        coll.Add(item);
                    }
                    rdr.Close();
                }

            }
            finally
            {
                dbCommand.Dispose();
            }
            return coll;
        }

        #endregion

    
    }


}
