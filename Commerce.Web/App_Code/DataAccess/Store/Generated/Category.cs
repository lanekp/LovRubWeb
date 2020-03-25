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
/// Strongly-typed collection for the Category class.
/// </summary>

[Serializable]
public partial class CategoryCollection : ActiveList<Category> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public CategoryCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public CategoryCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public CategoryCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public CategoryCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public CategoryCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public CategoryCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public CategoryCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public CategoryCollection Load() {
        
		Query qry = new Query("CSK_Store_Category");

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
    public CategoryCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_Category table.
/// </summary>
[Serializable]
public partial class Category : ActiveRecord<Category> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_Category");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         Category item = new Category();
        return Category.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_Category");
    }
    #endregion
    
    #region .ctors
    public  Category() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public Category(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public Category(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("CategoryID")]
    public int CategoryID {
        get {
         object result=this.GetColumnValue("CategoryID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("CategoryID", value);
        }
    }
    [XmlAttribute("CategoryGUID")]
    public string CategoryGUID {
        get {
         object result=this.GetColumnValue("CategoryGUID");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("CategoryGUID", value);
        }
    }
    [XmlAttribute("CategoryName")]
    public string CategoryName {
        get {
         object result=this.GetColumnValue("CategoryName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("CategoryName", value);
        }
    }
    [XmlAttribute("ImageFile")]
    public string ImageFile {
        get {
         object result=this.GetColumnValue("ImageFile");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ImageFile", value);
        }
    }
    [XmlAttribute("ParentID")]
    public int ParentID {
        get {
         object result=this.GetColumnValue("ParentID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ParentID", value);
        }
    }
    [XmlAttribute("ShortDescription")]
    public string ShortDescription {
        get {
         object result=this.GetColumnValue("ShortDescription");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShortDescription", value);
        }
    }
    [XmlAttribute("LongDescription")]
    public string LongDescription {
        get {
         object result=this.GetColumnValue("LongDescription");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("LongDescription", value);
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
    [XmlAttribute("CreatedOn")]
    public DateTime CreatedOn {
        get {
         object result=this.GetColumnValue("CreatedOn");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
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
         object result=this.GetColumnValue("CreatedBy");
         string sOut=result==null? string.Empty : result.ToString();
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
         object result=this.GetColumnValue("ModifiedOn");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
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
         object result=this.GetColumnValue("ModifiedBy");
         string sOut=result==null? string.Empty : result.ToString();
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
          public static void Insert(string categoryGUID,string categoryName,string imageFile,int parentID,string shortDescription,string longDescription,int listOrder)  {
                 Category item=new Category();
                 		item.CategoryGUID=categoryGUID;
		item.CategoryName=categoryName;
		item.ImageFile=imageFile;
		item.ParentID=parentID;
		item.ShortDescription=shortDescription;
		item.LongDescription=longDescription;
		item.ListOrder=listOrder;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int categoryID,string categoryGUID,string categoryName,string imageFile,int parentID,string shortDescription,string longDescription,int listOrder)  {
                 Category item=new Category();
                 		item.CategoryID=categoryID;
		item.CategoryGUID=categoryGUID;
		item.CategoryName=categoryName;
		item.ImageFile=imageFile;
		item.ParentID=parentID;
		item.ShortDescription=shortDescription;
		item.LongDescription=longDescription;
		item.ListOrder=listOrder;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string CategoryID="categoryID";
		public static  string CategoryGUID="categoryGUID";
		public static  string CategoryName="categoryName";
		public static  string ImageFile="imageFile";
		public static  string ParentID="parentID";
		public static  string ShortDescription="shortDescription";
		public static  string LongDescription="longDescription";
		public static  string ListOrder="listOrder";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
