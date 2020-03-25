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
/// Strongly-typed collection for the Product class.
/// </summary>

[Serializable]
public partial class ProductCollection : ActiveList<Product> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public ProductCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public ProductCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public ProductCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public ProductCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public ProductCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public ProductCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public ProductCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public ProductCollection Load() {
        
		Query qry = new Query("CSK_Store_Product");

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
    public ProductCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_Product table.
/// </summary>
[Serializable]
public partial class Product : ActiveRecord<Product> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_Product");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         Product item = new Product();
        return Product.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_Product");
    }
    #endregion
    
    #region .ctors
    public  Product() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public Product(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public Product(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
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
    [XmlAttribute("Sku")]
    public string Sku {
        get {
         object result=this.GetColumnValue("Sku");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Sku", value);
        }
    }
    [XmlAttribute("ProductGUID")]
    public string ProductGUID {
        get {
         object result=this.GetColumnValue("ProductGUID");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ProductGUID", value);
        }
    }
    [XmlAttribute("ProductName")]
    public string ProductName {
        get {
         object result=this.GetColumnValue("ProductName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ProductName", value);
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
    [XmlAttribute("ManufacturerID")]
    public int ManufacturerID {
        get {
         object result=this.GetColumnValue("ManufacturerID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ManufacturerID", value);
        }
    }
    [XmlAttribute("AttributeXML")]
    public string AttributeXML {
        get {
         object result=this.GetColumnValue("AttributeXML");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AttributeXML", value);
        }
    }
    [XmlAttribute("StatusID")]
    public int StatusID {
        get {
         object result=this.GetColumnValue("StatusID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("StatusID", value);
        }
    }
    [XmlAttribute("ProductTypeID")]
    public int ProductTypeID {
        get {
         object result=this.GetColumnValue("ProductTypeID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ProductTypeID", value);
        }
    }
    [XmlAttribute("ShippingTypeID")]
    public int ShippingTypeID {
        get {
         object result=this.GetColumnValue("ShippingTypeID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShippingTypeID", value);
        }
    }
    [XmlAttribute("ShipEstimateID")]
    public int ShipEstimateID {
        get {
         object result=this.GetColumnValue("ShipEstimateID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShipEstimateID", value);
        }
    }
    [XmlAttribute("TaxTypeID")]
    public int TaxTypeID {
        get {
         object result=this.GetColumnValue("TaxTypeID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TaxTypeID", value);
        }
    }
    [XmlAttribute("StockLocation")]
    public string StockLocation {
        get {
         object result=this.GetColumnValue("StockLocation");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("StockLocation", value);
        }
    }
    [XmlAttribute("OurPrice")]
    public decimal OurPrice {
        get {
         object result=this.GetColumnValue("OurPrice");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OurPrice", value);
        }
    }
    [XmlAttribute("RetailPrice")]
    public decimal RetailPrice {
        get {
         object result=this.GetColumnValue("RetailPrice");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("RetailPrice", value);
        }
    }
    [XmlAttribute("Weight")]
    public decimal Weight {
        get {
         object result=this.GetColumnValue("Weight");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Weight", value);
        }
    }
    [XmlAttribute("CurrencyCode")]
    public string CurrencyCode {
        get {
         object result=this.GetColumnValue("CurrencyCode");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("CurrencyCode", value);
        }
    }
    [XmlAttribute("UnitOfMeasure")]
    public string UnitOfMeasure {
        get {
         object result=this.GetColumnValue("UnitOfMeasure");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("UnitOfMeasure", value);
        }
    }
    [XmlAttribute("AdminComments")]
    public string AdminComments {
        get {
         object result=this.GetColumnValue("AdminComments");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AdminComments", value);
        }
    }
    [XmlAttribute("Length")]
    public decimal Length {
        get {
         object result=this.GetColumnValue("Length");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Length", value);
        }
    }
    [XmlAttribute("Height")]
    public decimal Height {
        get {
         object result=this.GetColumnValue("Height");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Height", value);
        }
    }
    [XmlAttribute("Width")]
    public decimal Width {
        get {
         object result=this.GetColumnValue("Width");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Width", value);
        }
    }
    [XmlAttribute("DimensionUnit")]
    public string DimensionUnit {
        get {
         object result=this.GetColumnValue("DimensionUnit");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("DimensionUnit", value);
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
    [XmlAttribute("RatingSum")]
    public int RatingSum {
        get {
         object result=this.GetColumnValue("RatingSum");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("RatingSum", value);
        }
    }
    [XmlAttribute("TotalRatingVotes")]
    public int TotalRatingVotes {
        get {
         object result=this.GetColumnValue("TotalRatingVotes");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TotalRatingVotes", value);
        }
    }
    [XmlAttribute("DefaultImage")]
    public string DefaultImage {
        get {
         object result=this.GetColumnValue("DefaultImage");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("DefaultImage", value);
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
          public static void Insert(string sku,string productGUID,string productName,string shortDescription,int manufacturerID,string attributeXML,int statusID,int productTypeID,int shippingTypeID,int shipEstimateID,int taxTypeID,string stockLocation,decimal ourPrice,decimal retailPrice,decimal weight,string currencyCode,string unitOfMeasure,string adminComments,decimal length,decimal height,decimal width,string dimensionUnit,bool isDeleted,int listOrder,int ratingSum,int totalRatingVotes,string defaultImage)  {
                 Product item=new Product();
                 		item.Sku=sku;
		item.ProductGUID=productGUID;
		item.ProductName=productName;
		item.ShortDescription=shortDescription;
		item.ManufacturerID=manufacturerID;
		item.AttributeXML=attributeXML;
		item.StatusID=statusID;
		item.ProductTypeID=productTypeID;
		item.ShippingTypeID=shippingTypeID;
		item.ShipEstimateID=shipEstimateID;
		item.TaxTypeID=taxTypeID;
		item.StockLocation=stockLocation;
		item.OurPrice=ourPrice;
		item.RetailPrice=retailPrice;
		item.Weight=weight;
		item.CurrencyCode=currencyCode;
		item.UnitOfMeasure=unitOfMeasure;
		item.AdminComments=adminComments;
		item.Length=length;
		item.Height=height;
		item.Width=width;
		item.DimensionUnit=dimensionUnit;
		item.IsDeleted=isDeleted;
		item.ListOrder=listOrder;
		item.RatingSum=ratingSum;
		item.TotalRatingVotes=totalRatingVotes;
		item.DefaultImage=defaultImage;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int productID,string sku,string productGUID,string productName,string shortDescription,int manufacturerID,string attributeXML,int statusID,int productTypeID,int shippingTypeID,int shipEstimateID,int taxTypeID,string stockLocation,decimal ourPrice,decimal retailPrice,decimal weight,string currencyCode,string unitOfMeasure,string adminComments,decimal length,decimal height,decimal width,string dimensionUnit,bool isDeleted,int listOrder,int ratingSum,int totalRatingVotes,string defaultImage)  {
                 Product item=new Product();
                 		item.ProductID=productID;
		item.Sku=sku;
		item.ProductGUID=productGUID;
		item.ProductName=productName;
		item.ShortDescription=shortDescription;
		item.ManufacturerID=manufacturerID;
		item.AttributeXML=attributeXML;
		item.StatusID=statusID;
		item.ProductTypeID=productTypeID;
		item.ShippingTypeID=shippingTypeID;
		item.ShipEstimateID=shipEstimateID;
		item.TaxTypeID=taxTypeID;
		item.StockLocation=stockLocation;
		item.OurPrice=ourPrice;
		item.RetailPrice=retailPrice;
		item.Weight=weight;
		item.CurrencyCode=currencyCode;
		item.UnitOfMeasure=unitOfMeasure;
		item.AdminComments=adminComments;
		item.Length=length;
		item.Height=height;
		item.Width=width;
		item.DimensionUnit=dimensionUnit;
		item.IsDeleted=isDeleted;
		item.ListOrder=listOrder;
		item.RatingSum=ratingSum;
		item.TotalRatingVotes=totalRatingVotes;
		item.DefaultImage=defaultImage;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string ProductID="productID";
		public static  string Sku="sku";
		public static  string ProductGUID="productGUID";
		public static  string ProductName="productName";
		public static  string ShortDescription="shortDescription";
		public static  string ManufacturerID="manufacturerID";
		public static  string AttributeXML="attributeXML";
		public static  string StatusID="statusID";
		public static  string ProductTypeID="productTypeID";
		public static  string ShippingTypeID="shippingTypeID";
		public static  string ShipEstimateID="shipEstimateID";
		public static  string TaxTypeID="taxTypeID";
		public static  string StockLocation="stockLocation";
		public static  string OurPrice="ourPrice";
		public static  string RetailPrice="retailPrice";
		public static  string Weight="weight";
		public static  string CurrencyCode="currencyCode";
		public static  string UnitOfMeasure="unitOfMeasure";
		public static  string AdminComments="adminComments";
		public static  string Length="length";
		public static  string Height="height";
		public static  string Width="width";
		public static  string DimensionUnit="dimensionUnit";
		public static  string IsDeleted="isDeleted";
		public static  string ListOrder="listOrder";
		public static  string RatingSum="ratingSum";
		public static  string TotalRatingVotes="totalRatingVotes";
		public static  string DefaultImage="defaultImage";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
