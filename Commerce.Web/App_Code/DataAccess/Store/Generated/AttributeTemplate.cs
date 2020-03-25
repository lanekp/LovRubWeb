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
/// Strongly-typed collection for the AttributeTemplate class.
/// </summary>

[Serializable]
public partial class AttributeTemplateCollection : ActiveList<AttributeTemplate> {
    
    List<Where> wheres = new List<Where>();
    List<BetweenAnd> betweens = new List<BetweenAnd>();
    SubSonic.OrderBy orderBy;
    public AttributeTemplateCollection OrderByAsc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Asc(columnName);
        return this;
    }
    public AttributeTemplateCollection OrderByDesc(string columnName) {
        this.orderBy = SubSonic.OrderBy.Desc(columnName);
        return this;
    }
    public AttributeTemplateCollection WhereDatesBetween(string columnName, DateTime dateStart, DateTime dateEnd) {
        return this;

    }

    public AttributeTemplateCollection Where(Where where) {
        wheres.Add(where);
        return this;
    }
    public AttributeTemplateCollection Where(string columnName, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.ParameterValue = value;
        Where(where);
        return this;
    }
    public AttributeTemplateCollection Where(string columnName, Comparison comp, object value) {
        Where where = new Where();
        where.ColumnName = columnName;
        where.Comparison = comp;
        where.ParameterValue = value;
        Where(where);
        return this;

    }
    public AttributeTemplateCollection BetweenAnd(string columnName, DateTime dateStart, DateTime dateEnd) {
        BetweenAnd between = new BetweenAnd();
        between.ColumnName = columnName;
        between.StartDate = dateStart;
        between.EndDate = dateEnd;
        betweens.Add(between);
        return this;
    }
    public AttributeTemplateCollection Load() {
        
		Query qry = new Query("CSK_Store_AttributeTemplate");

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
    public AttributeTemplateCollection() {
        

    }

}

/// <summary>
/// This is an ActiveRecord class which wraps the CSK_Store_AttributeTemplate table.
/// </summary>
[Serializable]
public partial class AttributeTemplate : ActiveRecord<AttributeTemplate> {
    
    #region Default Settings
    void SetSQLProps() {
        if (Schema == null)
            Schema = Query.BuildTableSchema("CSK_Store_AttributeTemplate");
    }
    #endregion
    
    #region Schema Accessor
    public static TableSchema.Table GetTableSchema() {
         AttributeTemplate item = new AttributeTemplate();
        return AttributeTemplate.Schema;
    }
    #endregion

    #region Query Accessor
    public static Query CreateQuery() {
        return new Query("CSK_Store_AttributeTemplate");
    }
    #endregion
    
    #region .ctors
    public  AttributeTemplate() {
        SetSQLProps();
        SetDefaults();
        this.MarkNew();
    }

    public AttributeTemplate(object keyID) {
        SetSQLProps();
        base.LoadByKey(keyID);
    }
 
    public AttributeTemplate(string columnName, object columnValue) {
        SetSQLProps();
        base.LoadByParam(columnName,columnValue);
    }
    
    #endregion
    
    #region Public Properties
        [XmlAttribute("TemplateID")]
    public int TemplateID {
        get {
         object result=this.GetColumnValue("TemplateID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("TemplateID", value);
        }
    }
    [XmlAttribute("AttributeName")]
    public string AttributeName {
        get {
         object result=this.GetColumnValue("AttributeName");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AttributeName", value);
        }
    }
    [XmlAttribute("SelectionList")]
    public string SelectionList {
        get {
         object result=this.GetColumnValue("SelectionList");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("SelectionList", value);
        }
    }
    [XmlAttribute("Description")]
    public string Description {
        get {
         object result=this.GetColumnValue("Description");
         string sOut=result==null? string.Empty : result.ToString();
         return sOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("Description", value);
        }
    }
    [XmlAttribute("AttributeTypeID")]
    public int AttributeTypeID {
        get {
         object result=this.GetColumnValue("AttributeTypeID");
         int oOut=0;
         try{oOut= int.Parse(result.ToString());}catch{}
         return oOut;

        }
        set {
            this.MarkDirty();
            this.SetColumnValue("AttributeTypeID", value);
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
          public static void Insert(string attributeName,string selectionList,string description,int attributeTypeID)  {
                 AttributeTemplate item=new AttributeTemplate();
                 		item.AttributeName=attributeName;
		item.SelectionList=selectionList;
		item.Description=description;
		item.AttributeTypeID=attributeTypeID;

                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   
          /// <summary>
          /// Updates a record, can be used with the Object Data Source
         /// </summary>
          public static void Update(int templateID,string attributeName,string selectionList,string description,int attributeTypeID)  {
                 AttributeTemplate item=new AttributeTemplate();
                 		item.TemplateID=templateID;
		item.AttributeName=attributeName;
		item.SelectionList=selectionList;
		item.Description=description;
		item.AttributeTypeID=attributeTypeID;

                 item.IsNew=false;
                 item.Save(System.Web.HttpContext.Current.User.Identity.Name);
           }

   #endregion

   #region Columns Struct
    public struct Columns{
		public static  string TemplateID="templateID";
		public static  string AttributeName="attributeName";
		public static  string SelectionList="selectionList";
		public static  string Description="description";
		public static  string AttributeTypeID="attributeTypeID";
		public static  string CreatedOn="createdOn";
		public static  string CreatedBy="createdBy";
		public static  string ModifiedOn="modifiedOn";
		public static  string ModifiedBy="modifiedBy";

    }
   #endregion

}
}
