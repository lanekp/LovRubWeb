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
/// Strongly-typed collection for the Transaction class.
/// </summary>

[Serializable]
public partial class TransactionCollection : ActiveList<Transaction> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public TransactionCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public TransactionCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public TransactionCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public TransactionCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public TransactionCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public TransactionCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public TransactionCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public TransactionCollection Load() {
        
		Query qry = new Query("CSK_Store_Transaction");

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
    public TransactionCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_Transaction table.
/// </summary>
[Serializable]
public partial class Transaction : ActiveRecord<Transaction> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_Transaction");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         Transaction item = new Transaction();
        return Transaction.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_Transaction");
    }
    #endregion
    
    #region .ctors
    public  Transaction() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public Transaction(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public Transaction(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("TransactionID")]
    public int TransactionID {
        get {
         object result=this.GetColumnValue("TransactionID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TransactionID", value);
        }
    }
    [XmlAttribute("OrderID")]
    public int OrderID {
        get {
         object result=this.GetColumnValue("OrderID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OrderID", value);
        }
    }
    [XmlAttribute("AuthorizationCode")]
    public string AuthorizationCode {
        get {
         object result=this.GetColumnValue("AuthorizationCode");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AuthorizationCode", value);
        }
    }
    [XmlAttribute("TransactionDate")]
    public DateTime TransactionDate {
        get {
         object result=this.GetColumnValue("TransactionDate");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TransactionDate", value);
        }
    }
    [XmlAttribute("TransactionTypeID")]
    public int TransactionTypeID {
        get {
         object result=this.GetColumnValue("TransactionTypeID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TransactionTypeID", value);
        }
    }
    [XmlAttribute("Amount")]
    public decimal Amount {
        get {
         object result=this.GetColumnValue("Amount");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Amount", value);
        }
    }
    [XmlAttribute("TransactionNotes")]
    public string TransactionNotes {
        get {
         object result=this.GetColumnValue("TransactionNotes");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TransactionNotes", value);
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
          public static void Insert(int orderID,string authorizationCode,DateTime transactionDate,int transactionTypeID,decimal amount,string transactionNotes)  {
                 Transaction item=new Transaction();
                 		item.OrderID=orderID;
		item.AuthorizationCode=authorizationCode;
		item.TransactionDate=transactionDate;
		item.TransactionTypeID=transactionTypeID;
		item.Amount=amount;
		item.TransactionNotes=transactionNotes;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int transactionID,int orderID,string authorizationCode,DateTime transactionDate,int transactionTypeID,decimal amount,string transactionNotes)  {
                 Transaction item=new Transaction();
                 		item.TransactionID=transactionID;
		item.OrderID=orderID;
		item.AuthorizationCode=authorizationCode;
		item.TransactionDate=transactionDate;
		item.TransactionTypeID=transactionTypeID;
		item.Amount=amount;
		item.TransactionNotes=transactionNotes;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string TransactionID="transactionID";
		public static  string OrderID="orderID";
		public static  string AuthorizationCode="authorizationCode";
		public static  string TransactionDate="transactionDate";
		public static  string TransactionTypeID="transactionTypeID";
		public static  string Amount="amount";
		public static  string TransactionNotes="transactionNotes";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
