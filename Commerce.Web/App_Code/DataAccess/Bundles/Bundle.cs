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
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SubSonic;
using Commerce.Common;

namespace Commerce.Promotions
{
    public class BundleCollection : ActiveList<Bundle>
    {

    }
    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Promo_Bundle table.
    /// </summary>
    public class Bundle : ActiveRecord<Bundle>
    {

        #region .ctors
        /// <summary>
        /// Sets the static Table property from our Base class. This property tells
        /// the base class how to create the CRUD queries, etc.
        /// </summary>
        void SetSQLProps()
        {

            if (Schema == null)
            {
                Schema = Query.BuildTableSchema("CSK_Promo_Bundle");
                

            }

            //set the default values
            this.SetColumnValue("bundleID", 0);
            this.SetColumnValue("bundleName", string.Empty);
            this.SetColumnValue("discountPercent", 0);
            this.SetColumnValue("description", string.Empty);

            //state properties - these are set automagically 
            //during save
            this.SetColumnValue("createdOn", DateTime.UtcNow);
            this.SetColumnValue("createdBy", string.Empty);
            this.SetColumnValue("modifiedOn", DateTime.UtcNow);
            this.SetColumnValue("modifiedBy", string.Empty);

        }

        public static TableSchema.Table GetTableSchema()
        {
            //instance an object to make sure
            //the table schema has been created
            Bundle item = new Bundle();
            return Bundle.Schema;
        }

        public Bundle()
        {
            SetSQLProps();
            this.MarkNew();
        }
        public Bundle(int bundleID)
        {
            SetSQLProps();
            base.LoadByKey(bundleID);

        }

        #endregion

        #region Public Props
        [XmlAttribute("BundleID")]
        public int BundleID
        {
            get
            {
                return int.Parse(this.GetColumnValue("bundleID").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("bundleID", value);

            }
        }
        [XmlAttribute("BundleName")]
        public string BundleName
        {
            get
            {
                return this.GetColumnValue("bundleName").ToString();
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("bundleName", value);

            }
        }
        [XmlAttribute("DiscountPercent")]
        public int DiscountPercent
        {
            get
            {
                return int.Parse(this.GetColumnValue("discountPercent").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("discountPercent", value);

            }
        }
        [XmlAttribute("Description")]
        public string Description
        {
            get
            {
                return this.GetColumnValue("description").ToString();
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("description", value);

            }
        }

        #endregion

        #region Extended Data Access - Stored Procedures


        /// <summary>
        /// Executes "CSK_Promo_Bundle_GetAvailableProducts" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader GetAvailableProducts(int bundleID)
        {
            return SPs.PromoBundleGetAvailableProducts(bundleID).GetReader();

        }

        /// <summary>
        /// Executes "CSK_Promo_Bundle_GetSelectedProducts" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader GetSelectedProducts(int bundleID) {


            return SPs.PromoBundleGetSelectedProducts(bundleID).GetReader();


        }

        /// <summary>
        /// Executes "CSK_Promo_Bundle_AddProduct" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader AddProduct(int bundleID, int productID) {


            return SPs.PromoBundleAddProduct(bundleID, productID).GetReader();

        }

        /// <summary>
        /// Executes "CSK_Promo_Bundle_RemoveProduct" and returns the results in an IDataReader 
        /// </summary>
        /// <returns> </returns>	
        public static void RemoveProduct(int bundleID, int productID)
        {

            Query q = new Query("CSK_Promo_Product_Bundle_Map");
            q.AddWhere("bundleID", bundleID);
            q.AddWhere("productID", productID);
            q.Execute();
            
        }

        /// <summary>
        /// Executes "CSK_Promo_Bundle_GetByProductID" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader GetByProductID(int productID) {

            return SPs.PromoBundleGetByProductID(productID).GetReader();
            

        }
        #endregion

    }
}
