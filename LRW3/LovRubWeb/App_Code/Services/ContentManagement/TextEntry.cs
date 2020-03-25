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
using System.Data;
using SubSonic;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Commerce.ContentManagement {

    /// <summary>
    /// Strongly-typed collection for the TextEntry class.
    /// </summary>
    public partial class TextEntryCollection : ActiveList<TextEntry> {

        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
        public TextEntryCollection OrderByAsc(string columnName) {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }
        public TextEntryCollection OrderByDesc(string columnName) {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }
        public TextEntryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
            return this;

        }

        public TextEntryCollection Where(Where where) {
            wheres.Add(where);
            return this;
        }
        public TextEntryCollection Where(string columnName, object value) {
            Where where = new Where();
            where.ColumnName = columnName;
            where.ParameterValue = value;
            Where(where);
            return this;
        }
        public TextEntryCollection Where(string columnName, Comparison comp, object value) {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;

        }
        public TextEntryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            betweens.Add(between);
            return this;
        }
        public TextEntryCollection Load() {

            Query qry = new Query("CSK_Content_Text");

            foreach (Where where in wheres) {
                qry.AddWhere(where);
            }
            foreach (BetweenAnd between in betweens) {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
                qry.OrderBy = orderBy;



            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }
        public TextEntryCollection() {


        }


    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the TextEntry table.
    /// </summary>
    [Serializable]
    public partial class TextEntry : ActiveRecord<TextEntry> {

        #region Default Settings
        void SetSQLProps() {
            if (Schema == null)
                Schema = Query.BuildTableSchema("CSK_Content_Text");
        }
        #endregion

        #region Schema Accessor
        public static TableSchema.Table GetTableSchema() {
            TextEntry item = new TextEntry();
            return TextEntry.Schema;
        }
        #endregion

        #region Query Accessor
        public static Query CreateQuery() {
            return new Query("CSK_Content_Text");
        }
        #endregion

        #region .ctors
        public TextEntry() {
            SetSQLProps();
            SetDefaults();
            this.MarkNew();
        }

        public TextEntry(object keyID) {
            SetSQLProps();
            base.LoadByKey(keyID);
        }
        public TextEntry(string contentName) {
            IDataReader rdr =TextEntry.FetchByParameter("contentName", contentName);
            if (rdr.Read()) {
                this.Load(rdr);
            }
            rdr.Close();

        }
        #endregion

        #region Public Properties
        [XmlAttribute("ContentID")]
        public int ContentID {
            get {
                object result = this.GetColumnValue("ContentID");
                int oOut = 0;
                try { oOut = int.Parse(result.ToString()); } catch { }
                return oOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ContentID", value);
            }
        }
        [XmlAttribute("ContentGUID")]
        public string ContentGUID {
            get {
                object result = this.GetColumnValue("ContentGUID");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ContentGUID", value);
            }
        }
        [XmlAttribute("Title")]
        public string Title {
            get {
                object result = this.GetColumnValue("Title");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("Title", value);
            }
        }
        [XmlAttribute("ContentName")]
        public string ContentName {
            get {
                object result = this.GetColumnValue("ContentName");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ContentName", value);
            }
        }
        [XmlAttribute("Content")]
        public string Content {
            get {
                object result = this.GetColumnValue("Content");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("Content", value);
            }
        }
        [XmlAttribute("IconPath")]
        public string IconPath {
            get {
                object result = this.GetColumnValue("IconPath");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("IconPath", value);
            }
        }
        [XmlAttribute("DateExpires")]
        public DateTime DateExpires {
            get {
                object result = this.GetColumnValue("DateExpires");
                DateTime oOut = new DateTime(1900, 01, 01);
                try { oOut = DateTime.Parse(result.ToString()); } catch { }
                return oOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("DateExpires", value);
            }
        }
        [XmlAttribute("ContentGroupID")]
        public int ContentGroupID {
            get {
                object result = this.GetColumnValue("ContentGroupID");
                int oOut = 0;
                try { oOut = int.Parse(result.ToString()); } catch { }
                return oOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ContentGroupID", value);
            }
        }
        [XmlAttribute("LastEditedBy")]
        public string LastEditedBy {
            get {
                object result = this.GetColumnValue("LastEditedBy");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("LastEditedBy", value);
            }
        }
        [XmlAttribute("ExternalLink")]
        public string ExternalLink {
            get {
                object result = this.GetColumnValue("ExternalLink");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ExternalLink", value);
            }
        }
        [XmlAttribute("Status")]
        public string Status {
            get {
                object result = this.GetColumnValue("Status");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("Status", value);
            }
        }
        [XmlAttribute("ListOrder")]
        public int ListOrder {
            get {
                object result = this.GetColumnValue("ListOrder");
                int oOut = 0;
                try { oOut = int.Parse(result.ToString()); } catch { }
                return oOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("ListOrder", value);
            }
        }
        [XmlAttribute("CallOut")]
        public string CallOut {
            get {
                object result = this.GetColumnValue("CallOut");
                string sOut = result == null ? string.Empty : result.ToString();
                return sOut;

            }
            set {
                this.MarkDirty();
                this.SetColumnValue("CallOut", value);
            }
        }
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

        #endregion

        #region ObjectDataSource support

        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(string contentGUID, string title, string contentName, string content, string iconPath, DateTime dateExpires, int contentGroupID, string lastEditedBy, string externalLink, string status, int listOrder, string callOut) {
            TextEntry item = new TextEntry();
            item.ContentGUID = contentGUID;
            item.Title = title;
            item.ContentName = contentName;
            item.Content = content;
            item.IconPath = iconPath;
            item.DateExpires = dateExpires;
            item.ContentGroupID = contentGroupID;
            item.LastEditedBy = lastEditedBy;
            item.ExternalLink = externalLink;
            item.Status = status;
            item.ListOrder = listOrder;
            item.CallOut = callOut;

            item.Save(System.Web.HttpContext.Current.User.Identity.Name);
        }


        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(int contentID, string contentGUID, string title, string contentName, string content, string iconPath, DateTime dateExpires, int contentGroupID, string lastEditedBy, string externalLink, string status, int listOrder, string callOut) {
            TextEntry item = new TextEntry();
            item.ContentID = contentID;
            item.ContentGUID = contentGUID;
            item.Title = title;
            item.ContentName = contentName;
            item.Content = content;
            item.IconPath = iconPath;
            item.DateExpires = dateExpires;
            item.ContentGroupID = contentGroupID;
            item.LastEditedBy = lastEditedBy;
            item.ExternalLink = externalLink;
            item.Status = status;
            item.ListOrder = listOrder;
            item.CallOut = callOut;

            item.IsNew = false;
            item.Save(System.Web.HttpContext.Current.User.Identity.Name);
        }

        #endregion

        #region Columns Struct
        public struct Columns {
            public static string ContentID = "contentID";
            public static string ContentGUID = "contentGUID";
            public static string Title = "title";
            public static string ContentName = "contentName";
            public static string Content = "content";
            public static string IconPath = "iconPath";
            public static string DateExpires = "dateExpires";
            public static string ContentGroupID = "contentGroupID";
            public static string LastEditedBy = "lastEditedBy";
            public static string ExternalLink = "externalLink";
            public static string Status = "status";
            public static string ListOrder = "listOrder";
            public static string CallOut = "callOut";
            public static string CreatedOn = "createdOn";
            public static string CreatedBy = "createdBy";
            public static string ModifiedOn = "modifiedOn";
            public static string ModifiedBy = "modifiedBy";

        }
        #endregion

    }





}