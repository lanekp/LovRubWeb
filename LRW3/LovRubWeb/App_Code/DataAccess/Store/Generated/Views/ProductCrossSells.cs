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
/// Strongly-typed collection for the ProductCrossSells class.
/// </summary>
public class ProductCrossSellsCollection :ReadOnlyList<ProductCrossSells> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public ProductCrossSellsCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public ProductCrossSellsCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public ProductCrossSellsCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public ProductCrossSellsCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public ProductCrossSellsCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public ProductCrossSellsCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public ProductCrossSellsCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public ProductCrossSellsCollection Load() {
        
		Query qry = new Query("ProductCrossSells");

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
    public ProductCrossSellsCollection() {
        

    }

}

/// <summary>
/// This is an ReadOnly class which wraps the ProductCrossSells table.
/// </summary>
[Serializable]
public partial class ProductCrossSells : ReadOnlyRecord<ProductCrossSells> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("ProductCrossSells");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         ProductCrossSells item = new ProductCrossSells();
        return ProductCrossSells.Schema;
    }
    #endregion

        #region Query Accessor
    public static Query CreateQuery() {
        return new Query("ProductCrossSells");
    }
    #endregion
    
    #region .ctors
    public  ProductCrossSells() {
        SetSQLProps();
        
    }

    public ProductCrossSells(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
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
    }
    [XmlAttribute("Sku")]
    public string Sku {
        get {
         object result=this.GetColumnValue("Sku");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("ProductName")]
    public string ProductName {
        get {
         object result=this.GetColumnValue("ProductName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("ShortDescription")]
    public string ShortDescription {
        get {
         object result=this.GetColumnValue("ShortDescription");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("AttributeXML")]
    public string AttributeXML {
        get {
         object result=this.GetColumnValue("AttributeXML");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("ProductTypeID")]
    public int ProductTypeID {
        get {
         object result=this.GetColumnValue("ProductTypeID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

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
    }
    [XmlAttribute("ShipEstimateID")]
    public int ShipEstimateID {
        get {
         object result=this.GetColumnValue("ShipEstimateID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

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
    }
    [XmlAttribute("StockLocation")]
    public string StockLocation {
        get {
         object result=this.GetColumnValue("StockLocation");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("RetailPrice")]
    public decimal RetailPrice {
        get {
         object result=this.GetColumnValue("RetailPrice");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

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
    }
    [XmlAttribute("CurrencyCode")]
    public string CurrencyCode {
        get {
         object result=this.GetColumnValue("CurrencyCode");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("UnitOfMeasure")]
    public string UnitOfMeasure {
        get {
         object result=this.GetColumnValue("UnitOfMeasure");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("AdminComments")]
    public string AdminComments {
        get {
         object result=this.GetColumnValue("AdminComments");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("Height")]
    public decimal Height {
        get {
         object result=this.GetColumnValue("Height");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

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
    }
    [XmlAttribute("DimensionUnit")]
    public string DimensionUnit {
        get {
         object result=this.GetColumnValue("DimensionUnit");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("IsDeleted")]
    public bool IsDeleted {
        get {
         object result=this.GetColumnValue("IsDeleted");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

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
    }
    [XmlAttribute("RatingSum")]
    public int RatingSum {
        get {
         object result=this.GetColumnValue("RatingSum");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

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
    }
    [XmlAttribute("DefaultImage")]
    public string DefaultImage {
        get {
         object result=this.GetColumnValue("DefaultImage");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("CreatedBy")]
    public string CreatedBy {
        get {
         object result=this.GetColumnValue("CreatedBy");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("ModifiedBy")]
    public string ModifiedBy {
        get {
         object result=this.GetColumnValue("ModifiedBy");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("CrossProductID")]
    public int CrossProductID {
        get {
         object result=this.GetColumnValue("CrossProductID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
    }
    [XmlAttribute("FromProductID")]
    public int FromProductID {
        get {
         object result=this.GetColumnValue("FromProductID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
    }

    #endregion


   #region Columns Struct
    public struct Columns{
		public static  string ProductID="productID";
		public static  string Sku="sku";
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
		public static  string CrossProductID="crossProductID";
		public static  string FromProductID="fromProductID";

    }
   #endregion

}


}
