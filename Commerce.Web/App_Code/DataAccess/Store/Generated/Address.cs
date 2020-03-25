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
/// Strongly-typed collection for the Address class.
/// </summary>

[Serializable]
public partial class AddressCollection : ActiveList<Address> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public AddressCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public AddressCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public AddressCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public AddressCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public AddressCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public AddressCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public AddressCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public AddressCollection Load() {
        
		Query qry = new Query("CSK_Store_Address");

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
    public AddressCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_Address table.
/// </summary>
[Serializable]
public partial class Address : ActiveRecord<Address> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_Address");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         Address item = new Address();
        return Address.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_Address");
    }
    #endregion
    
    #region .ctors
    public  Address() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public Address(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public Address(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("AddressID")]
    public int AddressID {
        get {
         object result=this.GetColumnValue("AddressID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AddressID", value);
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
    [XmlAttribute("Phone")]
    public string Phone {
        get {
         object result=this.GetColumnValue("Phone");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Phone", value);
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
    [XmlAttribute("Address1")]
    public string Address1 {
        get {
         object result=this.GetColumnValue("Address1");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Address1", value);
        }
    }
    [XmlAttribute("Address2")]
    public string Address2 {
        get {
         object result=this.GetColumnValue("Address2");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Address2", value);
        }
    }
    [XmlAttribute("City")]
    public string City {
        get {
         object result=this.GetColumnValue("City");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("City", value);
        }
    }
    [XmlAttribute("StateOrRegion")]
    public string StateOrRegion {
        get {
         object result=this.GetColumnValue("StateOrRegion");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("StateOrRegion", value);
        }
    }
    [XmlAttribute("Zip")]
    public string Zip {
        get {
         object result=this.GetColumnValue("Zip");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Zip", value);
        }
    }
    [XmlAttribute("Country")]
    public string Country {
        get {
         object result=this.GetColumnValue("Country");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Country", value);
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
          public static void Insert(string userName,string firstName,string lastName,string phone,string email,string address1,string address2,string city,string stateOrRegion,string zip,string country)  {
                 Address item=new Address();
                 		item.UserName=userName;
		item.FirstName=firstName;
		item.LastName=lastName;
		item.Phone=phone;
		item.Email=email;
		item.Address1=address1;
		item.Address2=address2;
		item.City=city;
		item.StateOrRegion=stateOrRegion;
		item.Zip=zip;
		item.Country=country;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int addressID,string userName,string firstName,string lastName,string phone,string email,string address1,string address2,string city,string stateOrRegion,string zip,string country)  {
                 Address item=new Address();
                 		item.AddressID=addressID;
		item.UserName=userName;
		item.FirstName=firstName;
		item.LastName=lastName;
		item.Phone=phone;
		item.Email=email;
		item.Address1=address1;
		item.Address2=address2;
		item.City=city;
		item.StateOrRegion=stateOrRegion;
		item.Zip=zip;
		item.Country=country;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string AddressID="addressID";
		public static  string UserName="userName";
		public static  string FirstName="firstName";
		public static  string LastName="lastName";
		public static  string Phone="phone";
		public static  string Email="email";
		public static  string Address1="address1";
		public static  string Address2="address2";
		public static  string City="city";
		public static  string StateOrRegion="stateOrRegion";
		public static  string Zip="zip";
		public static  string Country="country";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
