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
using Commerce.Common;
using SubSonic;

namespace Commerce.Stats
{

    /// <summary>
    /// A Persistable class that uses Generics to store it's state
    /// in the database. This class maps to the CSK_Stats_Tracker table.
    /// </summary>
    public class Tracker : ActiveRecord<Tracker>
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
                Schema = Query.BuildTableSchema("CSK_Stats_Tracker");

            }
        }

        public Tracker()
            : base()
        {
            SetSQLProps();
        }
        public Tracker(int trackingID)
        {
            SetSQLProps();
            base.LoadByKey(trackingID);
        }

        #endregion

        #region private vars

        int trackingID = 0;
        string userName = string.Empty;
        int adID = 0;
        int promoID = 0;
        string productSKU = string.Empty;
        int categoryID = 0;
        string pageURL = string.Empty;
        int behaviorID = 0;
        string searchString = string.Empty;
        string sessionID = string.Empty;

        #endregion

        #region Public Props
        [XmlAttribute("TrackingID")]
        public int TrackingID
        {
            get { return trackingID; }
            set
            {
                trackingID = value;
                this.MarkDirty();
                this.SetColumnValue("trackingID", value);

            }
        }
        [XmlAttribute("UserName")]
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                this.MarkDirty();
                this.SetColumnValue("userName", value);

            }
        }
        [XmlAttribute("AdID")]
        public int AdID
        {
            get { return adID; }
            set
            {
                adID = value;
                this.MarkDirty();
                this.SetColumnValue("adID", value);

            }
        }
        [XmlAttribute("PromoID")]
        public int PromoID
        {
            get { return promoID; }
            set
            {
                promoID = value;
                this.MarkDirty();
                this.SetColumnValue("promoID", value);

            }
        }
        [XmlAttribute("ProductSKU")]
        public string ProductSKU
        {
            get { return productSKU; }
            set
            {
                productSKU = value;
                this.MarkDirty();
                this.SetColumnValue("productSKU", value);

            }
        }
        [XmlAttribute("CategoryID")]
        public int CategoryID
        {
            get { return categoryID; }
            set
            {
                categoryID = value;
                this.MarkDirty();
                this.SetColumnValue("categoryID", value);

            }
        }
        [XmlAttribute("PageURL")]
        public string PageURL
        {
            get { return pageURL; }
            set
            {
                pageURL = value;
                this.MarkDirty();
                this.SetColumnValue("pageURL", value);

            }
        }
        [XmlAttribute("Behavior")]
        public BehaviorType Behavior
        {
            get { return (BehaviorType)behaviorID; }
            set
            {
                behaviorID = (int)value;
                this.MarkDirty();
                this.SetColumnValue("behaviorID", value);

            }
        }
        [XmlAttribute("SearchString")]
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                this.MarkDirty();
                this.SetColumnValue("searchString", value);

            }
        }
        [XmlAttribute("SessionID")]
        public string SessionID
        {
            get { return sessionID; }
            set
            {
                sessionID = value;
                this.MarkDirty();
                this.SetColumnValue("sessionID", value);

            }
        }

        #endregion

        #region Extended Data Access - Stored Procedures


        /// <summary>
        /// Executes "CSK_Stats_Tracker_GetByBehaviorID" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader GetByBehaviorID(int behaviorID)
        {

            QueryCommand cmd = new QueryCommand("CSK_Stats_Tracker_GetByBehaviorID");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.AddParameter("@behaviorID", behaviorID);

            return DataService.GetReader(cmd);

        }

        /// <summary>
        /// Executes "CSK_Stats_Tracker_SynchTrackingCookie" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader SynchTrackingCookie(string userName, string trackerCookie)
        {

            QueryCommand cmd = new QueryCommand("CSK_Stats_Tracker_SynchTrackingCookie");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.AddParameter("@userName", userName);
            cmd.AddParameter("@trackerCookie", trackerCookie);

            return DataService.GetReader(cmd);

        }

        /// <summary>
        /// Executes "CSK_Stats_Tracker_GetRecentlyViewedProducts" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader GetRecentlyViewedProducts(string username)
        {

            QueryCommand cmd = new QueryCommand("CSK_Stats_Tracker_GetRecentlyViewedProducts");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.AddParameter("@userName", username);

            return DataService.GetReader(cmd);

        }

        /// <summary>
        /// Executes "CSK_Stats_Tracker_GetByProductAndBehavior" and returns the results in an IDataReader 
        /// </summary>
        /// <returns>System.Data.IDataReader </returns>	
        public static IDataReader GetByProductAndBehavior(int behaviorID, string sku)
        {


            QueryCommand cmd = new QueryCommand("CSK_Stats_Tracker_GetByProductAndBehavior");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.AddParameter("@behaviorID", behaviorID);
            cmd.AddParameter("@sku", sku);

            return DataService.GetReader(cmd);

        }
        #endregion

        #region Extended Add Routines

        public static void Add(BehaviorType behavior, int categoryID, string productSKU, string searchString)
        {
            Add(behavior, categoryID, productSKU, searchString, 0, 0, "");
        }
        public static void Add(BehaviorType behavior, string productSKU)
        {
            Add(behavior, 0, productSKU, "", 0, 0, "");
        }
        public static void Add(BehaviorType behavior, int categoryID)
        {
            Add(behavior, categoryID, "", "", 0, 0, "");
        }
        public static void Add(BehaviorType behavior)
        {
            Add(behavior, 0, "", "", 0, 0, "");
        }
        public static void Add(Tracker track)
        {

            track.Save("System");

        }
        public static void Add(BehaviorType behavior, int categoryID, string productSKU, string searchString,
            int adID, int promoID, string pageUrl)
        {

            //get the page from the server
            if (pageUrl == string.Empty)
                pageUrl = System.Web.HttpContext.Current.Request.Url.PathAndQuery;

            string sessionID = System.Web.HttpContext.Current.Session.SessionID;

            Tracker track = new Tracker();
            track.Behavior = behavior;
            track.CategoryID = categoryID;
            track.ProductSKU = productSKU;
            track.SearchString = searchString;
            track.AdID = adID;
            track.PromoID = promoID;
            track.PageURL = pageUrl;
            track.SessionID = sessionID;
            track.UserName = Utility.GetUserName();

            Add(track);

        }


        #endregion

    }
}
