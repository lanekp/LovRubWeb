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
/// Strongly-typed collection for the Ad class.
/// </summary>

[Serializable]
public partial class AdCollection : ActiveList<Ad> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public AdCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public AdCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public AdCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public AdCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public AdCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public AdCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public AdCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public AdCollection Load() {
        
		Query qry = new Query("CSK_Store_Ad");

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
    public AdCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_Ad table.
/// </summary>
[Serializable]
public partial class Ad : ActiveRecord<Ad> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_Ad");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         Ad item = new Ad();
        return Ad.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_Ad");
    }
    #endregion
    
    #region .ctors
    public  Ad() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public Ad(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public Ad(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("AdID")]
    public int AdID {
        get {
         object result=this.GetColumnValue("AdID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AdID", value);
        }
    }
    [XmlAttribute("PageName")]
    public string PageName {
        get {
         object result=this.GetColumnValue("PageName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("PageName", value);
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
    [XmlAttribute("Placement")]
    public string Placement {
        get {
         object result=this.GetColumnValue("Placement");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Placement", value);
        }
    }
    [XmlAttribute("AdText")]
    public string AdText {
        get {
         object result=this.GetColumnValue("AdText");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AdText", value);
        }
    }
    [XmlAttribute("ProductSku")]
    public string ProductSku {
        get {
         object result=this.GetColumnValue("ProductSku");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ProductSku", value);
        }
    }
    [XmlAttribute("PromoID")]
    public int PromoID {
        get {
         object result=this.GetColumnValue("PromoID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("PromoID", value);
        }
    }
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
    [XmlAttribute("DateExpires")]
    public DateTime DateExpires {
        get {
         object result=this.GetColumnValue("DateExpires");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("DateExpires", value);
        }
    }
    [XmlAttribute("IsActive")]
    public bool IsActive {
        get {
         object result=this.GetColumnValue("IsActive");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsActive", value);
        }
    }
    [XmlAttribute("IsDeleted")]
    public bool IsDeleted {
        get {
         object result=this.GetColumnValue("IsDeleted");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsDeleted", value);
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
          public static void Insert(string pageName,int listOrder,string placement,string adText,string productSku,int promoID,int categoryID,DateTime dateExpires,bool isActive,bool isDeleted)  {
                 Ad item=new Ad();
                 		item.PageName=pageName;
		item.ListOrder=listOrder;
		item.Placement=placement;
		item.AdText=adText;
		item.ProductSku=productSku;
		item.PromoID=promoID;
		item.CategoryID=categoryID;
		item.DateExpires=dateExpires;
		item.IsActive=isActive;
		item.IsDeleted=isDeleted;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int adID,string pageName,int listOrder,string placement,string adText,string productSku,int promoID,int categoryID,DateTime dateExpires,bool isActive,bool isDeleted)  {
                 Ad item=new Ad();
                 		item.AdID=adID;
		item.PageName=pageName;
		item.ListOrder=listOrder;
		item.Placement=placement;
		item.AdText=adText;
		item.ProductSku=productSku;
		item.PromoID=promoID;
		item.CategoryID=categoryID;
		item.DateExpires=dateExpires;
		item.IsActive=isActive;
		item.IsDeleted=isDeleted;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string AdID="adID";
		public static  string PageName="pageName";
		public static  string ListOrder="listOrder";
		public static  string Placement="placement";
		public static  string AdText="adText";
		public static  string ProductSku="productSku";
		public static  string PromoID="promoID";
		public static  string CategoryID="categoryID";
		public static  string DateExpires="dateExpires";
		public static  string IsActive="isActive";
		public static  string IsDeleted="isDeleted";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
