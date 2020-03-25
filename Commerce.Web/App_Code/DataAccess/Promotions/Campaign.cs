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

namespace Commerce.Promotions
{

    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Promo_Campaign table.
    /// </summary>
    public class Campaign : ActiveRecord<Campaign>
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
                Schema = Query.BuildTableSchema("CSK_Promo_Campaign");
            }

            //set the default values
            this.SetColumnValue("campaignID", 0);
            this.SetColumnValue("campaignName", string.Empty);
            this.SetColumnValue("description", string.Empty);
            this.SetColumnValue("objective", string.Empty);
            this.SetColumnValue("revenueGoal", 0);
            this.SetColumnValue("inventoryGoal", 0);
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
            Campaign item = new Campaign();
            return Campaign.Schema;
        }

        public Campaign()
        {
            SetSQLProps();
            this.MarkNew();
        }
        public Campaign(int campaignID)
        {
            SetSQLProps();
            base.LoadByKey(campaignID);

        }

        #endregion

        #region Public Props
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
        [XmlAttribute("CampaignName")]
        public string CampaignName
        {
            get
            {
                return this.GetColumnValue("campaignName").ToString();
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("campaignName", value);

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
        [XmlAttribute("Objective")]
        public string Objective
        {
            get
            {
                return this.GetColumnValue("objective").ToString();
            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("objective", value);

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

    }
}
