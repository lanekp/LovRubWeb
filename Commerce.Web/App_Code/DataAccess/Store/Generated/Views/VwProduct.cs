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
/// Strongly-typed collection for the VwProduct class.
/// </summary>
public class VwProductCollection :ReadOnlyList<VwProduct> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public VwProductCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public VwProductCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public VwProductCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public VwProductCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public VwProductCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public VwProductCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public VwProductCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public VwProductCollection Load() {
        
		Query qry = new Query("vwProduct");

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
    public VwProductCollection() {
        

    }

}

/// <summary>
/// This is an ReadOnly class which wraps the vwProduct table.
/// </summary>
[Serializable]
public partial class VwProduct : ReadOnlyRecord<VwProduct> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("vwProduct");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         VwProduct item = new VwProduct();
        return VwProduct.Schema;
    }
    #endregion

        #region Query Accessor
    public static Query CreateQuery() {
        return new Query("vwProduct");
    }
    #endregion
    
    #region .ctors
    public  VwProduct() {
        SetSQLProps();
        
    }

    public VwProduct(object keyID) {
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
    [XmlAttribute("ShippingEstimate")]
    public string ShippingEstimate {
        get {
         object result=this.GetColumnValue("ShippingEstimate");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("LeadTimeDays")]
    public int LeadTimeDays {
        get {
         object result=this.GetColumnValue("LeadTimeDays");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
    }
    [XmlAttribute("ImageFile")]
    public string ImageFile {
        get {
         object result=this.GetColumnValue("ImageFile");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    }
    [XmlAttribute("Rating")]
    public decimal Rating {
        get {
         object result=this.GetColumnValue("Rating");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
    }
    [XmlAttribute("Manufacturer")]
    public string Manufacturer {
        get {
         object result=this.GetColumnValue("Manufacturer");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("Status")]
    public string Status {
        get {
         object result=this.GetColumnValue("Status");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("TaxType")]
    public string TaxType {
        get {
         object result=this.GetColumnValue("TaxType");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("TaxCode")]
    public string TaxCode {
        get {
         object result=this.GetColumnValue("TaxCode");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("ShippingType")]
    public string ShippingType {
        get {
         object result=this.GetColumnValue("ShippingType");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
    }
    [XmlAttribute("ShippingCode")]
    public string ShippingCode {
        get {
         object result=this.GetColumnValue("ShippingCode");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
    [XmlAttribute("ProductGUID")]
    public string ProductGUID {
        get {
         object result=this.GetColumnValue("ProductGUID");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

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
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";
		public static  string ShippingEstimate="shippingEstimate";
		public static  string LeadTimeDays="leadTimeDays";
		public static  string ImageFile="imageFile";
		public static  string CategoryID="categoryID";
		public static  string Rating="rating";
		public static  string Manufacturer="manufacturer";
		public static  string Status="status";
		public static  string TaxType="taxType";
		public static  string TaxCode="taxCode";
		public static  string ShippingType="shippingType";
		public static  string ShippingCode="shippingCode";
		public static  string DefaultImage="defaultImage";
		public static  string ProductGUID="productGUID";

    }
   #endregion

}


}
