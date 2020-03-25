using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
using SubSonic;

namespace Commerce.Common
{
    /// <summary>
    /// Strongly-typed collection for the QtyDiscount class.
    /// </summary>
    public partial class QtyDiscountCollection : ActiveList<QtyDiscount>
    {

        List<Where> wheres = new List<Where>();
        List<BetweenAnd> betweens = new List<BetweenAnd>();
        SubSonic.OrderBy orderBy;
        public QtyDiscountCollection OrderByAsc(string columnName)
        {
            this.orderBy = SubSonic.OrderBy.Asc(columnName);
            return this;
        }
        public QtyDiscountCollection OrderByDesc(string columnName)
        {
            this.orderBy = SubSonic.OrderBy.Desc(columnName);
            return this;
        }
        public QtyDiscountCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd)
        {
            return this;

        }

        public QtyDiscountCollection Where(Where where)
        {
            wheres.Add(where);
            return this;
        }
        public QtyDiscountCollection Where(string columnName, object value)
        {
            Where where = new Where();
            where.ColumnName = columnName;
            where.ParameterValue = value;
            Where(where);
            return this;
        }
        public QtyDiscountCollection Where(string columnName, Comparison comp, object value)
        {
            Where where = new Where();
            where.ColumnName = columnName;
            where.Comparison = comp;
            where.ParameterValue = value;
            Where(where);
            return this;

        }
        public QtyDiscountCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd)
        {
            BetweenAnd between = new BetweenAnd();
            between.ColumnName = columnName;
            between.StartDate = dateStart;
            between.EndDate = dateEnd;
            betweens.Add(between);
            return this;
        }
        public QtyDiscountCollection Load()
        {

            Query qry = new Query("CSK_Store_Product_QtyDiscount");

            foreach (Where where in wheres)
            {
                qry.AddWhere(where);
            }
            foreach (BetweenAnd between in betweens)
            {
                qry.AddBetweenAnd(between);
            }

            if (orderBy != null)
                qry.OrderBy = orderBy;



            IDataReader rdr = qry.ExecuteReader();
            this.Load(rdr);
            rdr.Close();
            return this;
        }
        public QtyDiscountCollection()
        {


        }

    }

    /// <summary>
    /// This is an ActiveRecord class which wraps the QtyDiscount table.
    /// </summary>
    [Serializable]
    public partial class QtyDiscount : ActiveRecord<QtyDiscount>
    {

        #region Default Settings
        void SetSQLProps()
        {
            if (Schema == null)
                Schema = Query.BuildTableSchema("CSK_Store_Product_QtyDiscount");
        }
        #endregion

        #region Schema Accessor
        public static TableSchema.Table GetTableSchema()
        {
            QtyDiscount item = new QtyDiscount();
            return QtyDiscount.Schema;
        }
        #endregion

        #region Query Accessor
        public static Query CreateQuery()
        {
            return new Query("CSK_Store_Product_QtyDiscount");
        }
        #endregion

        #region .ctors
        public QtyDiscount()
        {
            SetSQLProps();
            SetDefaults();
            this.MarkNew();
        }

        public QtyDiscount(object keyID)
        {
            SetSQLProps();
            base.LoadByKey(keyID);
        }

        #endregion

        #region Public Properties
        [XmlAttribute("DiscountID")]
        public int DiscountID
        {
            get
            {
                object result = this.GetColumnValue("discountID");
                int oOut = 0;
                try { oOut = int.Parse(result.ToString()); }
                catch { }
                return oOut;

            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("discountID", value);
            }
        }
        [XmlAttribute("ProductID")]
        public int ProductID
        {
            get
            {
                object result = this.GetColumnValue("productID");
                int oOut = 0;
                try { oOut = int.Parse(result.ToString()); }
                catch { }
                return oOut;

            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("productID", value);
            }
        }
        [XmlAttribute("Quantity")]
        public int Quantity
        {
            get
            {
                object result = this.GetColumnValue("quantity");
                int oOut = 0;
                try { oOut = int.Parse(result.ToString()); }
                catch { }
                return oOut;

            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("quantity", value);
            }
        }
        [XmlAttribute("Discount")]
        public decimal Discount
        {
            get
            {
                object result = this.GetColumnValue("discount");
                decimal oOut = 0;
                try { oOut = decimal.Parse(result.ToString()); }
                catch { }
                return oOut;

            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("discount", value);
            }
        }
        [XmlAttribute("IsPercent")]
        public bool IsPercent
        {
            get
            {
                object result = this.GetColumnValue("isPercent");
                bool bOut = result == null ? false : Convert.ToBoolean(result);
                return bOut;

            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("isPercent", value);
            }
        }
        [XmlAttribute("IsActive")]
        public bool IsActive
        {
            get
            {
                object result = this.GetColumnValue("isActive");
                bool bOut = result == null ? false : Convert.ToBoolean(result);
                return bOut;

            }
            set
            {
                this.MarkDirty();
                this.SetColumnValue("isActive", value);
            }
        }

        #endregion

        #region ObjectDataSource support

        /// <summary>
        /// Inserts a record, can be used with the Object Data Source
        /// </summary>
        public static void Insert(int productID, int quantity, decimal discount, bool isPercent, bool isActive)
        {
            QtyDiscount item = new QtyDiscount();
            item.ProductID = productID;
            item.Quantity = quantity;
            item.Discount = discount;
            item.IsPercent = isPercent;
            item.IsActive = isActive;

            item.Save(System.Web.HttpContext.Current.User.Identity.Name);
        }


        /// <summary>
        /// Updates a record, can be used with the Object Data Source
        /// </summary>
        public static void Update(int discountID, int productID, int quantity, decimal discount, bool isPercent, bool isActive)
        {
            QtyDiscount item = new QtyDiscount();
            item.DiscountID = discountID;
            item.ProductID = productID;
            item.Quantity = quantity;
            item.Discount = discount;
            item.IsPercent = isPercent;
            item.IsActive = isActive;

            item.IsNew = false;
            item.Save(System.Web.HttpContext.Current.User.Identity.Name);
        }

        #endregion

        #region Columns Struct
        public struct Columns
        {
            public static string DiscountID = "discountID";
            public static string ProductID = "productID";
            public static string Quantity = "quantity";
            public static string Discount = "discount";
            public static string IsPercent = "isPercent";
            public static string IsActive = "isActive";

        }
        #endregion

    }
}