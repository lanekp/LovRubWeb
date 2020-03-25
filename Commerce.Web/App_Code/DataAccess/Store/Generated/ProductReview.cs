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
/// Strongly-typed collection for the ProductReview class.
/// </summary>

[Serializable]
public partial class ProductReviewCollection : ActiveList<ProductReview> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public ProductReviewCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public ProductReviewCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public ProductReviewCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public ProductReviewCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public ProductReviewCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public ProductReviewCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public ProductReviewCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public ProductReviewCollection Load() {
        
		Query qry = new Query("CSK_Store_ProductReview");

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
    public ProductReviewCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_ProductReview table.
/// </summary>
[Serializable]
public partial class ProductReview : ActiveRecord<ProductReview> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_ProductReview");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         ProductReview item = new ProductReview();
        return ProductReview.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_ProductReview");
    }
    #endregion
    
    #region .ctors
    public  ProductReview() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public ProductReview(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public ProductReview(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("ReviewID")]
    public int ReviewID {
        get {
         object result=this.GetColumnValue("ReviewID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ReviewID", value);
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
    [XmlAttribute("Body")]
    public string Body {
        get {
         object result=this.GetColumnValue("Body");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Body", value);
        }
    }
    [XmlAttribute("PostDate")]
    public DateTime PostDate {
        get {
         object result=this.GetColumnValue("PostDate");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("PostDate", value);
        }
    }
    [XmlAttribute("AuthorName")]
    public string AuthorName {
        get {
         object result=this.GetColumnValue("AuthorName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AuthorName", value);
        }
    }
    [XmlAttribute("Rating")]
    public int Rating {
        get {
         object result=this.GetColumnValue("Rating");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Rating", value);
        }
    }
    [XmlAttribute("IsApproved")]
    public bool IsApproved {
        get {
         object result=this.GetColumnValue("IsApproved");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsApproved", value);
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
          public static void Insert(int ProductID,string Title,string Body,DateTime PostDate,string AuthorName,int Rating,bool IsApproved)  {
                 ProductReview item=new ProductReview();
                 		item.ProductID=ProductID;
		item.Title=Title;
		item.Body=Body;
		item.PostDate=PostDate;
		item.AuthorName=AuthorName;
		item.Rating=Rating;
		item.IsApproved=IsApproved;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int ReviewID,int ProductID,string Title,string Body,DateTime PostDate,string AuthorName,int Rating,bool IsApproved)  {
                 ProductReview item=new ProductReview();
                 		item.ReviewID=ReviewID;
		item.ProductID=ProductID;
		item.Title=Title;
		item.Body=Body;
		item.PostDate=PostDate;
		item.AuthorName=AuthorName;
		item.Rating=Rating;
		item.IsApproved=IsApproved;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string ReviewID="ReviewID";
		public static  string ProductID="ProductID";
		public static  string Title="Title";
		public static  string Body="Body";
		public static  string PostDate="PostDate";
		public static  string AuthorName="AuthorName";
		public static  string Rating="Rating";
		public static  string IsApproved="IsApproved";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
