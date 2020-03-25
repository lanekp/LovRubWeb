#region dCPL Version 1.1.1
/*
The contents of this file are subject to the dashCommerce Public License
Version 1.1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.dashcommerce.org

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is dashCommerce.

The Initial Developer of the Original Code is Mettle Systems LLC.
Portions created by Mettle Systems LLC are Copyright (C) 2007. All Rights Reserved.
*/
#endregion
 
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Commerce.Common;
using System.Collections.Generic;
using System.Data.Common;
using SubSonic;

/// <summary>
///  Business logic for categories
/// </summary>
public static class CategoryController {

  private static CategoryCollection catList;

  /// <summary>
  /// This is the static list for the site's categories. This is held in application
  /// memory and used as needed so the site doesn't need to hit the DB everytime. Will
  /// need to opt out of this if you use a server farm or cluster.
  /// </summary>
  public static CategoryCollection CategoryList {
    get {
      if(catList == null || catList.Count == 0) {
        CategoryController.Load();
      }
      return catList;
    }
    set {
      catList = value;
    }
  }

  /// <summary>
  /// Loads the category info into the static CategoryList
  /// </summary>
  public static void Load() {
    catList = new CategoryCollection();
    IDataReader rdr = Category.FetchAll(OrderBy.Asc("listOrder"));
    catList.Load(rdr);
    rdr.Close();
  }

  /// <summary>
  /// Find a category in the CategoryList
  /// </summary>
  /// <param name="categoryID"></param>
  /// <returns></returns>
  public static Category Find(int categoryID) {
    Category cOut = null;
    foreach(Category cat in catList) {
      if(cat.CategoryID == categoryID) {
        cOut = cat;
        break;
      }
    }
    return cOut;
  }

  /// <summary>
  /// Finds a category by name
  /// </summary>
  /// <param name="categoryName"></param>
  /// <returns></returns>
  public static Category FindByName(string categoryName) {
    Category cOut = null;
    foreach(Category cat in catList) {
      if(cat.CategoryName.ToLower().Equals(categoryName)) {
        cOut = cat;
        break;
      }
    }
    return cOut;
  }

  /// <summary>
  /// Returns all categories in a dataset; used by the
  /// menuing controls
  /// </summary>
  /// <returns></returns>
  public static DataSet GetDataSetList() {
    Query q = new Query(Category.GetTableSchema());
    return q.ExecuteDataSet();
  }

  /// <summary>
  /// Returns all categories for a given product
  /// </summary>
  /// <param name="productID"></param>
  /// <returns>CategoryCollection</returns>
  public static CategoryCollection GetByProductID(int productID) {
    IDataReader rdr = SPs.StoreCategoryGetByProductID(productID).GetReader();
    CategoryCollection list = new CategoryCollection();
    list.Load(rdr);
    rdr.Close();
    return list;
  }

  /// <summary>
  /// Returns a multiple-result set for populating the Category.aspx page. Includes
  /// category info, products, etc.
  /// </summary>
  /// <param name="categoryGUID"></param>
  /// <returns></returns>
  public static DataSet GetPageByName(string categoryName) {
    return SPs.StoreCategoryGetPageByNameMulti(categoryName).GetDataSet();

  }
  /// <summary>
  /// Returns a multiple-result set for populating the Category.aspx page. Includes
  /// category info, products, etc.
  /// </summary>
  /// <param name="categoryGUID"></param>
  /// <returns></returns>
  public static DataSet GetPageByID(int categoryID) {

    return SPs.StoreCategoryGetPageMulti(categoryID).GetDataSet();

  }
  /// <summary>
  /// Returns a multiple-result set for populating the Category.aspx page. Includes
  /// category info, products, etc.
  /// </summary>
  /// <param name="categoryGUID"></param>
  /// <returns></returns>
  public static DataSet GetPageByGUID(string categoryGUID) {

    return SPs.StoreCategoryGetPageByGUIDMulti(categoryGUID).GetDataSet();
  }
}
