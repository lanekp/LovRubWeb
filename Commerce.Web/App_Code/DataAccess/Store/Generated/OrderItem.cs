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
/// Strongly-typed collection for the OrderItem class.
/// </summary>

[Serializable]
public partial class OrderItemCollection : ActiveList<OrderItem> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public OrderItemCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public OrderItemCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public OrderItemCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public OrderItemCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public OrderItemCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public OrderItemCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public OrderItemCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public OrderItemCollection Load() {
        
		Query qry = new Query("CSK_Store_OrderItem");

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
    public OrderItemCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_OrderItem table.
/// </summary>
[Serializable]
public partial class OrderItem : ActiveRecord<OrderItem> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_OrderItem");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         OrderItem item = new OrderItem();
        return OrderItem.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_OrderItem");
    }
    #endregion
    
    #region .ctors
    public  OrderItem() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public OrderItem(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public OrderItem(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("OrderItemID")]
    public int OrderItemID {
        get {
         object result=this.GetColumnValue("OrderItemID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OrderItemID", value);
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
    [XmlAttribute("ProductDescription")]
    public string ProductDescription {
        get {
         object result=this.GetColumnValue("ProductDescription");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ProductDescription", value);
        }
    }
    [XmlAttribute("PromoCode")]
    public string PromoCode {
        get {
         object result=this.GetColumnValue("PromoCode");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("PromoCode", value);
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
    [XmlAttribute("Dimensions")]
    public string Dimensions {
        get {
         object result=this.GetColumnValue("Dimensions");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Dimensions", value);
        }
    }

    [XmlAttribute("Length")]
    public decimal Length {
      get {
        object result = this.GetColumnValue("Length");
        decimal oOut = 0;
        try {
          oOut = decimal.Parse(result.ToString());
        }
        catch {
        }
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
        object result = this.GetColumnValue("Height");
        decimal oOut = 0;
        try {
          oOut = decimal.Parse(result.ToString());
        }
        catch {
        }
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
        object result = this.GetColumnValue("Width");
        decimal oOut = 0;
        try {
          oOut = decimal.Parse(result.ToString());
        }
        catch {
        }
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
        object result = this.GetColumnValue("DimensionUnit");
        string sOut = result == null ? string.Empty : result.ToString();
        return sOut;

      }
      set {
        this.MarkDirty();
        this.SetColumnValue("DimensionUnit", value);
      }
    }

    [XmlAttribute("Quantity")]
    public int Quantity {
        get {
         object result=this.GetColumnValue("Quantity");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Quantity", value);
        }
    }
    [XmlAttribute("OriginalPrice")]
    public decimal OriginalPrice {
        get {
         object result=this.GetColumnValue("OriginalPrice");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("OriginalPrice", value);
        }
    }
    [XmlAttribute("PricePaid")]
    public decimal PricePaid {
        get {
         object result=this.GetColumnValue("PricePaid");
         decimal oOut=0;
         try{oOut= decimal.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("PricePaid", value);
        }
    }
    [XmlAttribute("Attributes")]
    public string Attributes {
        get {
         object result=this.GetColumnValue("Attributes");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Attributes", value);
        }
    }
    /////////////////////////////////
    // Change for Volume Discount
    [XmlAttribute("AttributesPrice")]
    public decimal AttributesPrice
    {
        get
        {
            object result = this.GetColumnValue("AttributesPrice");
            decimal oOut = 0;
            try { oOut = decimal.Parse(result.ToString()); }
            catch { }
            return oOut;

        }
        set
        {
            this.MarkDirty();
            this.SetColumnValue("AttributesPrice", value);
        }
    }
    [XmlAttribute("DownloadURL")]
    public string DownloadURL {
        get {
         object result=this.GetColumnValue("DownloadURL");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("DownloadURL", value);
        }
    }
    [XmlAttribute("IsShipped")]
    public bool IsShipped {
        get {
         object result=this.GetColumnValue("IsShipped");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsShipped", value);
        }
    }
    [XmlAttribute("ShipDate")]
    public DateTime ShipDate {
        get {
         object result=this.GetColumnValue("ShipDate");
         DateTime oOut=new DateTime(1900,01, 01);
         try{oOut= DateTime.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShipDate", value);
        }
    }
    [XmlAttribute("ShippingEstimate")]
    public string ShippingEstimate {
        get {
         object result=this.GetColumnValue("ShippingEstimate");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShippingEstimate", value);
        }
    }
    [XmlAttribute("ShipmentReference")]
    public string ShipmentReference {
        get {
         object result=this.GetColumnValue("ShipmentReference");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("ShipmentReference", value);
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
        set {
            this.MarkDirty();
            this.SetColumnValue("Rating", value);
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
    [XmlAttribute("IsLastAdded")]
    public bool IsLastAdded {
        get {
         object result=this.GetColumnValue("IsLastAdded");
         bool bOut=result==null? false : Convert.ToBoolean(result);
         return bOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("IsLastAdded", value);
        }
    }

    #endregion

   #region ObjectDataSource support
   
          /// <summary>
          /// Inserts a record, can be used with the Object Data Source
         /// </summary>
          public static void Insert(int orderID,int productID,string sku,string productName,string imageFile,string productDescription,string promoCode,decimal weight,string dimensions,int quantity,decimal originalPrice,decimal pricePaid,string attributes,decimal attributesPrice,string downloadURL,bool isShipped,DateTime shipDate,string shippingEstimate,string shipmentReference,decimal rating,bool isLastAdded)  {
                 OrderItem item=new OrderItem();
                 		item.OrderID=orderID;
		item.ProductID=productID;
		item.Sku=sku;
		item.ProductName=productName;
		item.ImageFile=imageFile;
		item.ProductDescription=productDescription;
		item.PromoCode=promoCode;
        item.Weight = weight;
        item.Dimensions = dimensions;
        item.Length = 0;
        item.Height = 0;
        item.Width = 0;
        item.DimensionUnit = "";
        item.Quantity = quantity;
		item.OriginalPrice=originalPrice;
		item.PricePaid=pricePaid;
        item.Attributes = attributes;
        item.AttributesPrice = attributesPrice;
        item.DownloadURL = downloadURL;
		item.IsShipped=isShipped;
		item.ShipDate=shipDate;
		item.ShippingEstimate=shippingEstimate;
		item.ShipmentReference=shipmentReference;
		item.Rating=rating;
		item.IsLastAdded=isLastAdded;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
    public static void Update(int orderItemID, int orderID, int productID, string sku, string productName, string imageFile, string productDescription, string promoCode, decimal weight, string dimensions, int quantity, decimal originalPrice, decimal pricePaid, string attributes, decimal attributesPrice, string downloadURL, bool isShipped, DateTime shipDate, string shippingEstimate, string shipmentReference, decimal rating, bool isLastAdded)
    {
                 OrderItem item=new OrderItem();
                 		item.OrderItemID=orderItemID;
		item.OrderID=orderID;
		item.ProductID=productID;
		item.Sku=sku;
		item.ProductName=productName;
		item.ImageFile=imageFile;
		item.ProductDescription=productDescription;
		item.PromoCode=promoCode;
        item.Weight = weight;
        item.Dimensions = dimensions;
        item.Length = 0;
        item.Height = 0;
        item.Width = 0;
        item.DimensionUnit = "";
        item.Quantity = quantity;
		item.OriginalPrice=originalPrice;
		item.PricePaid=pricePaid;
		item.Attributes=attributes;
        item.AttributesPrice = attributesPrice;
		item.DownloadURL=downloadURL;
		item.IsShipped=isShipped;
		item.ShipDate=shipDate;
		item.ShippingEstimate=shippingEstimate;
		item.ShipmentReference=shipmentReference;
		item.Rating=rating;
		item.IsLastAdded=isLastAdded;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string OrderItemID="orderItemID";
		public static  string OrderID="orderID";
		public static  string ProductID="productID";
		public static  string Sku="sku";
		public static  string ProductName="productName";
		public static  string ImageFile="imageFile";
		public static  string ProductDescription="productDescription";
		public static  string PromoCode="promoCode";
		public static  string Weight="weight";
		public static  string Dimensions="dimensions";
		public static  string Length="Length";
		public static  string Height="Height";
		public static  string Width="Width";
		public static  string DimensionUnit="DimensionUnit";
		public static  string Quantity="quantity";
		public static  string OriginalPrice="originalPrice";
		public static  string PricePaid="pricePaid";
        public static  string Attributes = "attributes";
        public static  string AttributesPrice = "attributesPrice";
        public static  string DownloadURL = "downloadURL";
		public static  string IsShipped="isShipped";
		public static  string ShipDate="shipDate";
		public static  string ShippingEstimate="shippingEstimate";
		public static  string ShipmentReference="shipmentReference";
		public static  string Rating="rating";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";
		public static  string IsLastAdded="isLastAdded";

    }
   #endregion

}
}
