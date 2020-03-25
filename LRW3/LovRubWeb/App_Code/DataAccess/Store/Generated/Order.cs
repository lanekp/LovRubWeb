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
/// Strongly-typed collection for the Order class.
/// </summary>

[Serializable]
public partial class OrderCollection : ActiveList<Order> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public OrderCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public OrderCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public OrderCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public OrderCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public OrderCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public OrderCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public OrderCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public OrderCollection Load() {
        
		Query qry = new Query("CSK_Store_Order");

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
    public OrderCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_Order table.
/// </summary>
[Serializable]
public partial class Order : ActiveRecord<Order> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_Order");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         Order item = new Order();
        return Order.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_Order");
    }
    #endregion
    
    #region .ctors
    public  Order() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public Order(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public Order(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
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
    [XmlAttribute("OrderGUID")]
    public string OrderGUID {
        get {
         object result=this.GetColumnValue("OrderGUID");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OrderGUID", value);
        }
    }
    [XmlAttribute("OrderNumber")]
    public string OrderNumber {
        get {
         object result=this.GetColumnValue("OrderNumber");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OrderNumber", value);
        }
    }
    [XmlAttribute("OrderDate")]
    public DateTime OrderDate {
        get {
         object result=this.GetColumnValue("OrderDate");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OrderDate", value);
        }
    }
    [XmlAttribute("OrderStatusID")]
    public int OrderStatusID {
        get {
         object result=this.GetColumnValue("OrderStatusID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OrderStatusID", value);
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
    [XmlAttribute("Email")]
    public string Email {
        get {
         object result=this.GetColumnValue("Email");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Email", value);
        }
    }
    [XmlAttribute("FirstName")]
    public string FirstName {
        get {
         object result=this.GetColumnValue("FirstName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("FirstName", value);
        }
    }
    [XmlAttribute("LastName")]
    public string LastName {
        get {
         object result=this.GetColumnValue("LastName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("LastName", value);
        }
    }
    [XmlAttribute("ShipPhone")]
    public string ShipPhone {
        get {
         object result=this.GetColumnValue("ShipPhone");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShipPhone", value);
        }
    }
    [XmlAttribute("ShippingMethod")]
    public string ShippingMethod {
        get {
         object result=this.GetColumnValue("ShippingMethod");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShippingMethod", value);
        }
    }
    [XmlAttribute("SubTotalAmount")]
    public decimal SubTotalAmount {
        get {
         object result=this.GetColumnValue("SubTotalAmount");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("SubTotalAmount", value);
        }
    }
    [XmlAttribute("ShippingAmount")]
    public decimal ShippingAmount {
        get {
         object result=this.GetColumnValue("ShippingAmount");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShippingAmount", value);
        }
    }
    [XmlAttribute("HandlingAmount")]
    public decimal HandlingAmount {
        get {
         object result=this.GetColumnValue("HandlingAmount");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("HandlingAmount", value);
        }
    }
    [XmlAttribute("TaxAmount")]
    public decimal TaxAmount {
        get {
         object result=this.GetColumnValue("TaxAmount");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TaxAmount", value);
        }
    }
    [XmlAttribute("TaxRate")]
    public decimal TaxRate {
        get {
         object result=this.GetColumnValue("TaxRate");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TaxRate", value);
        }
    }
    [XmlAttribute("CouponCodes")]
    public string CouponCodes {
        get {
         object result=this.GetColumnValue("CouponCodes");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("CouponCodes", value);
        }
    }
    [XmlAttribute("DiscountAmount")]
    public decimal DiscountAmount {
        get {
         object result=this.GetColumnValue("DiscountAmount");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("DiscountAmount", value);
        }
    }
    [XmlAttribute("SpecialInstructions")]
    public string SpecialInstructions {
        get {
         object result=this.GetColumnValue("SpecialInstructions");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("SpecialInstructions", value);
        }
    }
    [XmlAttribute("ShipToAddress")]
    public string ShipToAddress {
        get {
         object result=this.GetColumnValue("ShipToAddress");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShipToAddress", value);
        }
    }
    [XmlAttribute("BillToAddress")]
    public string BillToAddress {
        get {
         object result=this.GetColumnValue("BillToAddress");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("BillToAddress", value);
        }
    }
    [XmlAttribute("UserIP")]
    public string UserIP {
        get {
         object result=this.GetColumnValue("UserIP");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("UserIP", value);
        }
    }
    [XmlAttribute("ShippingTrackingNumber")]
    public string ShippingTrackingNumber {
        get {
         object result=this.GetColumnValue("ShippingTrackingNumber");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShippingTrackingNumber", value);
        }
    }
    [XmlAttribute("NumberOfPackages")]
    public int NumberOfPackages {
        get {
         object result=this.GetColumnValue("NumberOfPackages");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("NumberOfPackages", value);
        }
    }
    [XmlAttribute("PackagingNotes")]
    public string PackagingNotes {
        get {
         object result=this.GetColumnValue("PackagingNotes");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("PackagingNotes", value);
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
          public static void Insert(string orderGUID,string orderNumber,DateTime orderDate,int orderStatusID,string userName,string email,string firstName,string lastName,string shipPhone,string shippingMethod,decimal subTotalAmount,decimal shippingAmount,decimal handlingAmount,decimal taxAmount,decimal taxRate,string couponCodes,decimal discountAmount,string specialInstructions,string shipToAddress,string billToAddress,string userIP,string shippingTrackingNumber,int numberOfPackages,string packagingNotes)  {
                 Order item=new Order();
                 		item.OrderGUID=orderGUID;
		item.OrderNumber=orderNumber;
		item.OrderDate=orderDate;
		item.OrderStatusID=orderStatusID;
		item.UserName=userName;
		item.Email=email;
		item.FirstName=firstName;
		item.LastName=lastName;
		item.ShipPhone=shipPhone;
		item.ShippingMethod=shippingMethod;
		item.SubTotalAmount=subTotalAmount;
		item.ShippingAmount=shippingAmount;
		item.HandlingAmount=handlingAmount;
		item.TaxAmount=taxAmount;
		item.TaxRate=taxRate;
		item.CouponCodes=couponCodes;
		item.DiscountAmount=discountAmount;
		item.SpecialInstructions=specialInstructions;
		item.ShipToAddress=shipToAddress;
		item.BillToAddress=billToAddress;
		item.UserIP=userIP;
		item.ShippingTrackingNumber=shippingTrackingNumber;
		item.NumberOfPackages=numberOfPackages;
		item.PackagingNotes=packagingNotes;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int orderID,string orderGUID,string orderNumber,DateTime orderDate,int orderStatusID,string userName,string email,string firstName,string lastName,string shipPhone,string shippingMethod,decimal subTotalAmount,decimal shippingAmount,decimal handlingAmount,decimal taxAmount,decimal taxRate,string couponCodes,decimal discountAmount,string specialInstructions,string shipToAddress,string billToAddress,string userIP,string shippingTrackingNumber,int numberOfPackages,string packagingNotes)  {
                 Order item=new Order();
                 		item.OrderID=orderID;
		item.OrderGUID=orderGUID;
		item.OrderNumber=orderNumber;
		item.OrderDate=orderDate;
		item.OrderStatusID=orderStatusID;
		item.UserName=userName;
		item.Email=email;
		item.FirstName=firstName;
		item.LastName=lastName;
		item.ShipPhone=shipPhone;
		item.ShippingMethod=shippingMethod;
		item.SubTotalAmount=subTotalAmount;
		item.ShippingAmount=shippingAmount;
		item.HandlingAmount=handlingAmount;
		item.TaxAmount=taxAmount;
		item.TaxRate=taxRate;
		item.CouponCodes=couponCodes;
		item.DiscountAmount=discountAmount;
		item.SpecialInstructions=specialInstructions;
		item.ShipToAddress=shipToAddress;
		item.BillToAddress=billToAddress;
		item.UserIP=userIP;
		item.ShippingTrackingNumber=shippingTrackingNumber;
		item.NumberOfPackages=numberOfPackages;
		item.PackagingNotes=packagingNotes;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string OrderID="orderID";
		public static  string OrderGUID="orderGUID";
		public static  string OrderNumber="orderNumber";
		public static  string OrderDate="orderDate";
		public static  string OrderStatusID="orderStatusID";
		public static  string UserName="userName";
		public static  string Email="email";
		public static  string FirstName="firstName";
		public static  string LastName="lastName";
		public static  string ShipPhone="shipPhone";
		public static  string ShippingMethod="shippingMethod";
		public static  string SubTotalAmount="subTotalAmount";
		public static  string ShippingAmount="shippingAmount";
		public static  string HandlingAmount="handlingAmount";
		public static  string TaxAmount="taxAmount";
		public static  string TaxRate="taxRate";
		public static  string CouponCodes="couponCodes";
		public static  string DiscountAmount="discountAmount";
		public static  string SpecialInstructions="specialInstructions";
		public static  string ShipToAddress="shipToAddress";
		public static  string BillToAddress="billToAddress";
		public static  string UserIP="userIP";
		public static  string ShippingTrackingNumber="shippingTrackingNumber";
		public static  string NumberOfPackages="numberOfPackages";
		public static  string PackagingNotes="packagingNotes";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
