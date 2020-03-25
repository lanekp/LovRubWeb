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

namespace Commerce.Common {
/// <summary>
/// Strongly-typed collection for the ProductDescriptor class.
/// </summary>

[Serializable]
public partial class ProductDescriptorCollection : ActiveList<ProductDescriptor> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public ProductDescriptorCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public ProductDescriptorCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public ProductDescriptorCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public ProductDescriptorCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public ProductDescriptorCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public ProductDescriptorCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public ProductDescriptorCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public ProductDescriptorCollection Load() {
        
		Query qry = new Query("CSK_Store_ProductDescriptor");

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
    public ProductDescriptorCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_ProductDescriptor table.
/// </summary>
[Serializable]
public partial class ProductDescriptor : ActiveRecord<ProductDescriptor> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_ProductDescriptor");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         ProductDescriptor item = new ProductDescriptor();
        return ProductDescriptor.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_ProductDescriptor");
    }
    #endregion
    
    #region .ctors
    public  ProductDescriptor() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public ProductDescriptor(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public ProductDescriptor(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("DescriptorID")]
    public int DescriptorID {
        get {
         object result=this.GetColumnValue("DescriptorID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("DescriptorID", value);
        }
    }
    [XmlAttribute("ProductID")]
    public int ProductID {
        get {
         object result=this.GetColumnValue("ProductID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ProductID", value);
        }
    }
    [XmlAttribute("Title")]
    public string Title {
        get {
         object result=this.GetColumnValue("Title");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Title", value);
        }
    }
    [XmlAttribute("Descriptor")]
    public string Descriptor {
        get {
         object result=this.GetColumnValue("Descriptor");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Descriptor", value);
        }
    }
    [XmlAttribute("IsBulletedList")]
    public bool IsBulletedList {
        get {
         object result=this.GetColumnValue("IsBulletedList");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsBulletedList", value);
        }
    }
    [XmlAttribute("ListOrder")]
    public int ListOrder {
        get {
         object result=this.GetColumnValue("ListOrder");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ListOrder", value);
        }
    }

    #endregion

   #region ObjectDataSource support
   
          /// <summary>
          /// Inserts a record, can be used with the Object Data Source
         /// </summary>
          public static void Insert(int productID,string title,string descriptor,bool isBulletedList,int listOrder)  {
                 ProductDescriptor item=new ProductDescriptor();
                 		item.ProductID=productID;
		item.Title=title;
		item.Descriptor=descriptor;
		item.IsBulletedList=isBulletedList;
		item.ListOrder=listOrder;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int descriptorID,int productID,string title,string descriptor,bool isBulletedList,int listOrder)  {
                 ProductDescriptor item=new ProductDescriptor();
                 		item.DescriptorID=descriptorID;
		item.ProductID=productID;
		item.Title=title;
		item.Descriptor=descriptor;
		item.IsBulletedList=isBulletedList;
		item.ListOrder=listOrder;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string DescriptorID="descriptorID";
		public static  string ProductID="productID";
		public static  string Title="title";
		public static  string Descriptor="descriptor";
		public static  string IsBulletedList="isBulletedList";
		public static  string ListOrder="listOrder";

    }
   #endregion

}
}
