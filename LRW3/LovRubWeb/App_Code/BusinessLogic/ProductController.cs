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
using Commerce.Promotions;
using System.Data.Common;
using Commerce.Common;
using SubSonic;
using System.Collections;

/// <summary>
/// Business logic for products
/// </summary>
public static class ProductController{

    /// <summary>
    /// Returns all products
    /// </summary>
    /// <returns></returns>
    public static ProductCollection GetAll()
    {
        ProductCollection list = new ProductCollection().Load();
        return list;
    }

    /// <summary>
    /// Sets a default image for a product
    /// </summary>
    /// <param name="productID"></param>
    /// <param name="imageFile"></param>
    public static void SetProductDefaultImage(int productID,string imageFile)
    {
        Query q = new Query(Product.GetTableSchema());
        q.AddWhere("productID", productID);
        q.AddUpdateSetting("defaultImage", imageFile);
        q.Execute();

    }

    /// <summary>
    /// Returns products for a category
    /// </summary>
    /// <param name="categoryID">Value for the @categoryID parameter</param>
    /// <returns>ProductCollection</returns>	
    public static IDataReader GetByCategoryID(int categoryID)
    {
        return SPs.StoreProductGetByCategoryID(categoryID).GetReader();
    }

    /// <summary>
    /// Returns all products for a manufacturer
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="manufacturerID"></param>
    /// <returns></returns>
    public static IDataReader GetByManufacturerID(int categoryID, int manufacturerID)
    {

        return SPs.StoreProductGetByManufacturerID(manufacturerID, categoryID).GetReader();

    }
    
    /// <summary>
    /// Returns products by price range/category
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="priceLow"></param>
    /// <param name="priceHigh"></param>
    /// <returns></returns>
    public static IDataReader GetByPriceRange(int categoryID, decimal priceLow, decimal priceHigh)
    {
        return SPs.StoreProductGetByPriceRange(categoryID, priceLow, priceHigh).GetReader();
    }
    
    /// <summary>
    /// Returns reviews by product author
    /// </summary>
    /// <param name="productID"></param>
    /// <param name="author"></param>
    /// <returns></returns>
    public static ProductReviewCollection GetByProductAndAuthor(int productID,string author)
    {

        return new ProductReviewCollection().Where("productID", productID).Where("Authorname", author).Load();
    }

    /// <summary>
    /// Returns text descriptors for a given product
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static ProductDescriptorCollection GetDescriptors(int productID)
    {
        ProductDescriptorCollection list = new ProductDescriptorCollection().Where("productID",productID).OrderByAsc("listOrder").Load();
        return list;
    }
    /// <summary>
    /// Updates the XML attributes for a given product
    /// </summary>
    /// <param name="productID"></param>
    /// <param name="atts"></param>
    public static void UpdateProductAttributes(int productID, Commerce.Common.Attributes atts)
    {
        Commerce.Common.Product prod = new Commerce.Common.Product(productID);
        prod.Attributes = atts;
        prod.Save(Utility.GetUserName());
    }
    
    /// <summary>
    /// Removes a product from a category
    /// </summary>
    /// <param name="productID"></param>
    /// <param name="categoryID"></param>
    public static void RemoveFromCategory(int productID, int categoryID){
        Utility.DeleteManyToManyRecord("CSK_Store_Product_Category_Map", "productID", "categoryID", productID, categoryID);
    }

    /// <summary>
    /// Adds a product to a category
    /// </summary>
    /// <param name="productID"></param>
    /// <param name="categoryID"></param>
    public static void AddToCategory(int productID, int categoryID)
    {
        Utility.SaveManyToManyRecord("CSK_Store_Product_Category_Map", "productID", "categoryID", productID, categoryID);
    }

    /// <summary>
    /// Retrieves all images for a given product
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static ImageCollection GetImages(int productID)
    {
        ImageCollection list = new ImageCollection().Where("productID", productID).OrderByAsc("listOrder").Load() ;
        return list;
    }

    /// <summary>
    /// Gets a product based on ID
    /// </summary>
    /// <param name="productID"></param>
    /// <returns></returns>
    public static Product GetProduct(int productID){

        //load up the product
        Product product=Product.FetchByID(productID);

        //set the image
        Query q = new Query(Commerce.Common.Image.GetTableSchema());
        q.AddWhere("productID", productID);
        q.Top = "1";
        q.SelectList = "imageFile";

        string imgFile = q.ExecuteScalar().ToString();
        product.ImageFile = imgFile;
        return product;

    }

    /// <summary>
    /// Loads a product using a passed-in dataset
    /// </summary>
    /// <param name="product"></param>
    /// <param name="ds"></param>
    static void LoadByDataSet(Product product,DataSet ds)
    {

        //load up the product
        if (ds.Tables[0].Rows.Count > 0) {
            product.Load(ds.Tables[0].Rows[0]);
            product.ShippingEstimate = ds.Tables[0].Rows[0]["shippingEstimate"].ToString();
        }
        
        // and each of the child collections
        //load the collections
        product.Images = new ImageCollection();
        product.Images.Load(ds.Tables[1]);

        if (product.Images.Count > 0)
            product.ImageFile = product.Images[0].ImageFile;

        //reviews
        product.Reviews = new ProductReviewCollection();
        product.Reviews.Load(ds.Tables[2]);


        //descriptors
        product.Descriptors = new ProductDescriptorCollection();
        product.Descriptors.Load(ds.Tables[3]);


    }
    
    /// <summary>
    /// Gets a product and all of it's subcollections (images, promos, etc)
    /// </summary>
    /// <param name="sku"></param>
    /// <returns></returns>
    public static Commerce.Common.Product GetProductDeep(string sku){
        //load up the product using a multi-return DataSte
        int productID = 0;
        Query q = new Query(Product.GetTableSchema());
        q.AddWhere("sku", sku);
        q.SelectList="productID";
        productID = (int)q.ExecuteScalar();

        return GetProductDeep(productID);
    }
    /// <summary>
    /// Gets a product and all of it's subcollections (images, promos, etc)
    /// </summary>
    public static Commerce.Common.Product GetProductDeepByGUID(Guid productGUID) {
			//load up the product using a multi-return DataSte
			int productID = 0;
			Query q = new Query(Product.GetTableSchema());
            
			q.AddWhere("productGUID", productGUID);
            q.SelectList = "productID";

			productID = (int)q.ExecuteScalar();
			return GetProductDeep(productID);
		}

    /// <summary>
    /// Returns the data needed to popluated the ItemJustAdded page
    /// </summary>
    /// <returns></returns>
    public static DataSet GetPostAddPage()
    {
        return SPs.StoreProductGetPostAddMulti(Utility.GetUserName()).GetDataSet();
        
    }

    /// <summary>
    /// Gets a product and all of it's subcollections (images, promos, etc)
    /// </summary>
    public static Commerce.Common.Product GetProductDeep(int productID)
    {
        //load up the product using a multi-return DataSet
        //for performance, queue up the 4 SQL calls into one
        string sql = "";
        
        //Product Main Info
        Query q = new Query("vwProduct");
        q.AddWhere("productID", productID);
        
        //append
        sql += q.GetSql()+"\r\n";

        //Images
        q = new Query(Commerce.Common.Image.GetTableSchema());
        q.AddWhere("productID", productID);
        q.OrderBy = OrderBy.Asc("listOrder");
        //append
        sql += q.GetSql() + "\r\n";

        //Reviews
        q = new Query(ProductReview.GetTableSchema());
        q.AddWhere("productID", productID);
        q.AddWhere("isApproved", 1);

        //append
        sql += q.GetSql() + "\r\n";


        //Descriptors
        q = new Query(ProductDescriptor.GetTableSchema());
        q.AddWhere("productID", productID);
        q.OrderBy = OrderBy.Asc("listOrder");

       
        //append
        sql += q.GetSql() + "\r\n";

        QueryCommand cmd = new QueryCommand(sql);
        cmd.AddParameter("@productID", productID,DbType.Int32);
        cmd.AddParameter("@isApproved", true,DbType.Boolean);
        DataSet ds = DataService.GetDataSet(cmd);
        
        
        Product product = new Product();
        
        LoadByDataSet(product, ds);
        return product;
    }  
    /// <summary>
    /// This is a semi-smart query that will sort your returns based on word count 
    /// </summary>
    /// <param name="descriptionLength">How long the resulting product description will be</param>
    /// <param name="AllWords">Whether to use all the words in the query, or just the blob</param>

    /// <returns>System.Data.IDataReader</returns>	
    public static IDataReader RunSmartSearch(int descriptionLength,
        string query)
    {

        bool AllWords = true;
        //thanks to Moody for this routine
        //Define the parameters
        int howManyWords = 5;//words which is allowed to take from search text box you can enter to 5 words
        string[] queryparam = new string[howManyWords]; //array to containe the words entered in search text box
        char[] wordSeparators = new char[] { ',', ';', ',', '.', '!', ',', '?', '-', ' ' };//char elemnets is used when to seperat the entered query
        string[] words = query.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
        int index = 1;
        for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
        {

            //check to see if you entered more than one words
            if (words[i].Length > 2)
            {
                queryparam[i] = words[i];
            }
            index++;
        }
        int bitNum;
        if (AllWords == true) { bitNum = 1; }
        else { bitNum = 0; }

        return SPs.StoreProductSmartSearch(
            descriptionLength, AllWords,
            queryparam[0],
            queryparam[1],
            queryparam[2],
            queryparam[3],
            queryparam[4]

            ).GetReader();


    }
    /// <summary>
    /// Removes all information from the DB about this product
    /// including all reviews, review feedback, cross-sells, etc.
    /// Does NOT remove any products from checked-out orders, however
    /// all deleted products will be removed from non-checked out carts
    /// </summary>
    /// <param name="productID"></param>
    public static new void DeletePermanent(int productID){
        
        //change as needed
        //currently just removes the product from the DB
        //load the default db from the base class

        SPs.StoreProductDeletePermanent(productID).Execute();
       
    }
 
    /// <summary>
    /// Gets the most popular products for use on the 404 and basket pages
    /// </summary>
    /// <returns></returns>
    public static IDataReader GetMostPopular()
    {

        return SPs.StoreProductGetMostPopular().GetReader();

    }

}


