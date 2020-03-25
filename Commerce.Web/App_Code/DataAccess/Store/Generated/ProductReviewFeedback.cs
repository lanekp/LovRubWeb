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
/// Strongly-typed collection for the ProductReviewFeedback class.
/// </summary>

[Serializable]
public partial class ProductReviewFeedbackCollection : ActiveList<ProductReviewFeedback> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public ProductReviewFeedbackCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public ProductReviewFeedbackCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public ProductReviewFeedbackCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public ProductReviewFeedbackCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public ProductReviewFeedbackCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public ProductReviewFeedbackCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public ProductReviewFeedbackCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public ProductReviewFeedbackCollection Load() {
        
		Query qry = new Query("CSK_Store_ProductReviewFeedback");

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
    public ProductReviewFeedbackCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_ProductReviewFeedback table.
/// </summary>
[Serializable]
public partial class ProductReviewFeedback : ActiveRecord<ProductReviewFeedback> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_ProductReviewFeedback");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         ProductReviewFeedback item = new ProductReviewFeedback();
        return ProductReviewFeedback.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_ProductReviewFeedback");
    }
    #endregion
    
    #region .ctors
    public  ProductReviewFeedback() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public ProductReviewFeedback(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public ProductReviewFeedback(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("FeedbackID")]
    public int FeedbackID {
        get {
         object result=this.GetColumnValue("FeedbackID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("FeedbackID", value);
        }
    }
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
    [XmlAttribute("UserName")]
    public string UserName {
        get {
         object result=this.GetColumnValue("UserName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("UserName", value);
        }
    }
    [XmlAttribute("IsHelpful")]
    public bool IsHelpful {
        get {
         object result=this.GetColumnValue("IsHelpful");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsHelpful", value);
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
          public static void Insert(int ReviewID,string UserName,bool IsHelpful)  {
                 ProductReviewFeedback item=new ProductReviewFeedback();
                 		item.ReviewID=ReviewID;
		item.UserName=UserName;
		item.IsHelpful=IsHelpful;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int feedbackID,int ReviewID,string UserName,bool IsHelpful)  {
                 ProductReviewFeedback item=new ProductReviewFeedback();
                 		item.FeedbackID=feedbackID;
		item.ReviewID=ReviewID;
		item.UserName=UserName;
		item.IsHelpful=IsHelpful;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string FeedbackID="feedbackID";
		public static  string ReviewID="ReviewID";
		public static  string UserName="UserName";
		public static  string IsHelpful="IsHelpful";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
