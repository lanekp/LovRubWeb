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
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SubSonic;
using Commerce.Common;

namespace Commerce.Promotions
{

    /// <summary>
    /// A simple "smart" class. Use "Save" to put the item to the DB
    /// </summary>
    public class Promo : ActiveRecord<Promo>
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
                Schema = Query.BuildTableSchema("CSK_Promo");

            }

            //set the default values
            this.SetColumnValue("promoID", 0);
            this.SetColumnValue("campaignID", 0);
            this.SetColumnValue("promoCode", string.Empty);
            this.SetColumnValue("title", string.Empty);
            this.SetColumnValue("description", string.Empty);
            this.SetColumnValue("discount", 0);
            this.SetColumnValue("qtyThreshold", 0);
            this.SetColumnValue("inventoryGoal", 0);
            this.SetColumnValue("revenueGoal", 0);
            this.SetColumnValue("dateEnd", new DateTime(1900, 01, 01));
            this.SetColumnValue("isActive", false);

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
            Promo item = new Promo();
            return Promo.Schema;
        }

        public Promo()
        {
            SetSQLProps();
            this.MarkNew();
        }
        public Promo(int promoID)
        {
            SetSQLProps();
            base.LoadByKey(promoID);

        }

        #endregion

        #region Public Props
        [XmlAttribute("CreatedOn")]
        public DateTime CreatedOn {
            get {
                object result = this.GetColumnValue("CreatedOn");
                DateTime oOut = new DateTime(1900, 01, 01);
                try { oOut = DateTime.Parse(result.ToString()); } catch { }
                return oOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("CreatedOn", value);
            }
        }
        [XmlAttribute("CreatedBy")]
        public string CreatedBy {
            get {
                object result = this.GetColumnValue("CreatedBy");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("CreatedBy", value);
            }
        }
        [XmlAttribute("ModifiedOn")]
        public DateTime ModifiedOn {
            get {
                object result = this.GetColumnValue("ModifiedOn");
                DateTime oOut = new DateTime(1900, 01, 01);
                try { oOut = DateTime.Parse(result.ToString()); } catch { }
                return oOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ModifiedOn", value);
            }
        }
        [XmlAttribute("ModifiedBy")]
        public string ModifiedBy {
            get {
                object result = this.GetColumnValue("ModifiedBy");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ModifiedBy", value);
            }
        }
        [XmlAttribute("PromoID")]
        public int PromoID
        {
            get
            {
                return int.Parse(this.GetColumnValue("promoID").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("promoID", value);

            }
        }
        [XmlAttribute("CampaignID")]
        public int CampaignID
        {
            get
            {
                return int.Parse(this.GetColumnValue("campaignID").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("campaignID", value);

            }
        }
        [XmlAttribute("PromoCode")]
        public string PromoCode
        {
            get
            {
                return this.GetColumnValue("promoCode").ToString();
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("promoCode", value);

            }
        }
        [XmlAttribute("Title")]
        public string Title
        {
            get
            {
                return this.GetColumnValue("title").ToString();
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("title", value);

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
        [XmlAttribute("Discount")]
        public decimal Discount
        {
            get
            {
                return decimal.Parse(this.GetColumnValue("discount").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("discount", value);

            }
        }
        [XmlAttribute("QtyThreshold")]
        public int QtyThreshold
        {
            get
            {
                return int.Parse(this.GetColumnValue("qtyThreshold").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("qtyThreshold", value);

            }
        }
        [XmlAttribute("InventoryGoal")]
        public int InventoryGoal
        {
            get
            {
                return int.Parse(this.GetColumnValue("inventoryGoal").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("inventoryGoal", value);

            }
        }
        [XmlAttribute("RevenueGoal")]
        public decimal RevenueGoal
        {
            get
            {
                return decimal.Parse(this.GetColumnValue("revenueGoal").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("revenueGoal", value);

            }
        }
        [XmlAttribute("DateEnd")]
        public DateTime DateEnd
        {
            get
            {
                return DateTime.Parse(this.GetColumnValue("dateEnd").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("dateEnd", value);

            }
        }
        [XmlAttribute("IsActive")]
        public bool IsActive
        {
            get
            {
                return bool.Parse(this.GetColumnValue("isActive").ToString());
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("isActive", value);

            }
        }

        #endregion

        #region Extended Data Access


        /// <summary>
        /// Executes "CSK_Promo_ProductMatrix" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader ProductMatrix() {

            return SPs.PromoProductMatrix().GetReader();

        }
        /// <summary>
        /// Executes "CSK_Promo_GetProductList" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static DataSet GetProductList(int promoID) {

            return SPs.PromoGetProductList(promoID).GetDataSet() ;

        }

        /// <summary>
        /// Executes "CSK_Promo_RemoveProducts" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader RemoveProducts(int promoID) {

            return SPs.PromoRemoveProducts(promoID).GetReader();

        }

        #endregion

    }
}
