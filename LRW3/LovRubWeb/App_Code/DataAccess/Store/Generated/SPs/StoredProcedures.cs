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
public class SPs {
            /// <summary>
            /// Creates an object wrapper for the CSK_Coupons_GetCoupon Stored Procedure
            /// </summary>
            public static StoredProcedure CouponsGetCoupon(string couponCode){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Coupons_GetCoupon");
                	sp.Command.AddParameter("@couponCode",couponCode, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Order_Query Stored Procedure
            /// </summary>
            public static StoredProcedure StoreOrderQuery(DateTime dateStart,DateTime dateEnd,string userName,string orderNumber){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Order_Query");
                	sp.Command.AddParameter("@dateStart",dateStart, DbType.DateTime);
	sp.Command.AddParameter("@dateEnd",dateEnd, DbType.DateTime);
	sp.Command.AddParameter("@userName",userName, DbType.String);
	sp.Command.AddParameter("@orderNumber",orderNumber, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Category_GetPageByNameMulti Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetPageByNameMulti(string categoryName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Category_GetPageByNameMulti");
                	sp.Command.AddParameter("@categoryName",categoryName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Coupons_SaveCoupon Stored Procedure
            /// </summary>
            public static StoredProcedure CouponsSaveCoupon(string CouponCode,int CouponTypeId,bool IsSingleUse,int NumberUses,DateTime ExpirationDate,string XmlData){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Coupons_SaveCoupon");
                	sp.Command.AddParameter("@CouponCode",CouponCode, DbType.String);
	sp.Command.AddParameter("@CouponTypeId",CouponTypeId, DbType.Int32);
	sp.Command.AddParameter("@IsSingleUse",IsSingleUse, DbType.Boolean);
	sp.Command.AddParameter("@NumberUses",NumberUses, DbType.Int32);
	sp.Command.AddParameter("@ExpirationDate",ExpirationDate, DbType.DateTime);
	sp.Command.AddParameter("@XmlData",XmlData, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_CategoryGetActive Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetActive(){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_CategoryGetActive");
                
                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_AddRating Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductAddRating(int productID,int rating,string userName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_AddRating");
                	sp.Command.AddParameter("@productID",productID, DbType.Int32);
	sp.Command.AddParameter("@rating",rating, DbType.Int32);
	sp.Command.AddParameter("@userName",userName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Stats_FavoriteProducts Stored Procedure
            /// </summary>
            public static StoredProcedure StatsFavoriteProducts(string userName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Stats_FavoriteProducts");
                	sp.Command.AddParameter("@userName",userName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Stats_FavoriteCategories Stored Procedure
            /// </summary>
            public static StoredProcedure StatsFavoriteCategories(string userName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Stats_FavoriteCategories");
                	sp.Command.AddParameter("@userName",userName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_AddItemToCart Stored Procedure
            /// </summary>
            public static StoredProcedure StoreAddItemToCart(string userName,int productID,string attributes,decimal pricePaid,string promoCode,int quantity){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_AddItemToCart");
                	sp.Command.AddParameter("@userName",userName, DbType.String);
	sp.Command.AddParameter("@productID",productID, DbType.Int32);
	sp.Command.AddParameter("@attributes",attributes, DbType.String);
	sp.Command.AddParameter("@pricePaid",pricePaid, DbType.Currency);
	sp.Command.AddParameter("@promoCode",promoCode, DbType.String);
	sp.Command.AddParameter("@quantity",quantity, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_EnsureOrderCoupon Stored Procedure
            /// </summary>
            public static StoredProcedure PromoEnsureOrderCoupon(int orderID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_EnsureOrderCoupon");
                	sp.Command.AddParameter("@orderID",orderID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_GetPostAddMulti Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductGetPostAddMulti(string userName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_GetPostAddMulti");
                	sp.Command.AddParameter("@userName",userName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_DeletePermanent Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductDeletePermanent(int productID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_DeletePermanent");
                	sp.Command.AddParameter("@productID",productID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_ProductMatrix Stored Procedure
            /// </summary>
            public static StoredProcedure PromoProductMatrix(){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_ProductMatrix");
                
                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Category_GetByProductID Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetByProductID(int productID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Category_GetByProductID");
                	sp.Command.AddParameter("@productID",productID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_Bundle_GetSelectedProducts Stored Procedure
            /// </summary>
            public static StoredProcedure PromoBundleGetSelectedProducts(int bundleID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_Bundle_GetSelectedProducts");
                	sp.Command.AddParameter("@bundleID",bundleID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_Bundle_GetByProductID Stored Procedure
            /// </summary>
            public static StoredProcedure PromoBundleGetByProductID(int productID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_Bundle_GetByProductID");
                	sp.Command.AddParameter("@productID",productID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_GetProductList Stored Procedure
            /// </summary>
            public static StoredProcedure PromoGetProductList(int promoID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_GetProductList");
                	sp.Command.AddParameter("@promoID",promoID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Coupons_GetCouponType Stored Procedure
            /// </summary>
            public static StoredProcedure CouponsGetCouponType(int couponTypeId){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Coupons_GetCouponType");
                	sp.Command.AddParameter("@couponTypeId",couponTypeId, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Coupons_GetAllCouponTypes Stored Procedure
            /// </summary>
            public static StoredProcedure CouponsGetAllCouponTypes(){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Coupons_GetAllCouponTypes");
                
                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Coupons_SaveCouponType Stored Procedure
            /// </summary>
            public static StoredProcedure CouponsSaveCouponType(int CouponTypeId,string Description,string ProcessingClassName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Coupons_SaveCouponType");
                	sp.Command.AddParameter("@CouponTypeId",CouponTypeId, DbType.Int32);
	sp.Command.AddParameter("@Description",Description, DbType.String);
	sp.Command.AddParameter("@ProcessingClassName",ProcessingClassName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Tax_GetTaxRate Stored Procedure
            /// </summary>
            public static StoredProcedure TaxGetTaxRate(string zip){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Tax_GetTaxRate");
                	sp.Command.AddParameter("@zip",zip, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Tax_SaveZipRate Stored Procedure
            /// </summary>
            public static StoredProcedure TaxSaveZipRate(string state,string zipCode,decimal rate,string userName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Tax_SaveZipRate");
                	sp.Command.AddParameter("@state",state, DbType.String);
	sp.Command.AddParameter("@zipCode",zipCode, DbType.String);
	sp.Command.AddParameter("@rate",rate, DbType.Currency);
	sp.Command.AddParameter("@userName",userName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Tax_CalculateAmountByZIP Stored Procedure
            /// </summary>
            public static StoredProcedure TaxCalculateAmountByZIP(string zipCode,decimal subTotal){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Tax_CalculateAmountByZIP");
                	sp.Command.AddParameter("@zipCode",zipCode, DbType.String);
	sp.Command.AddParameter("@subTotal",subTotal, DbType.Currency);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Tax_CalculateAmountByState Stored Procedure
            /// </summary>
            public static StoredProcedure TaxCalculateAmountByState(string stateAbbreviation,decimal subTotal){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Tax_CalculateAmountByState");
                	sp.Command.AddParameter("@stateAbbreviation",stateAbbreviation, DbType.String);
	sp.Command.AddParameter("@subTotal",subTotal, DbType.Currency);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Stats_Tracker_SynchTrackingCookie Stored Procedure
            /// </summary>
            public static StoredProcedure StatsTrackerSynchTrackingCookie(string userName,string trackerCookie){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Stats_Tracker_SynchTrackingCookie");
                	sp.Command.AddParameter("@userName",userName, DbType.String);
	sp.Command.AddParameter("@trackerCookie",trackerCookie, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Stats_Tracker_GetByBehaviorID Stored Procedure
            /// </summary>
            public static StoredProcedure StatsTrackerGetByBehaviorID(int behaviorID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Stats_Tracker_GetByBehaviorID");
                	sp.Command.AddParameter("@behaviorID",behaviorID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Stats_Tracker_GetByProductAndBehavior Stored Procedure
            /// </summary>
            public static StoredProcedure StatsTrackerGetByProductAndBehavior(int behaviorID,string sku){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Stats_Tracker_GetByProductAndBehavior");
                	sp.Command.AddParameter("@behaviorID",behaviorID, DbType.Int32);
	sp.Command.AddParameter("@sku",sku, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_RemoveProducts Stored Procedure
            /// </summary>
            public static StoredProcedure PromoRemoveProducts(int promoID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_RemoveProducts");
                	sp.Command.AddParameter("@promoID",promoID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_AddProduct Stored Procedure
            /// </summary>
            public static StoredProcedure PromoAddProduct(int promoID,int productID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_AddProduct");
                	sp.Command.AddParameter("@promoID",promoID, DbType.Int32);
	sp.Command.AddParameter("@productID",productID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_Bundle_AddProduct Stored Procedure
            /// </summary>
            public static StoredProcedure PromoBundleAddProduct(int bundleID,int productID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_Bundle_AddProduct");
                	sp.Command.AddParameter("@bundleID",bundleID, DbType.Int32);
	sp.Command.AddParameter("@productID",productID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Shipping_GetRates_Ground Stored Procedure
            /// </summary>
            public static StoredProcedure ShippingGetRatesGround(decimal weight){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Shipping_GetRates_Ground");
                	sp.Command.AddParameter("@weight",weight, DbType.Currency);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Shipping_GetRates_Air Stored Procedure
            /// </summary>
            public static StoredProcedure ShippingGetRatesAir(decimal weight){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Shipping_GetRates_Air");
                	sp.Command.AddParameter("@weight",weight, DbType.Currency);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Shipping_GetRates Stored Procedure
            /// </summary>
            public static StoredProcedure ShippingGetRates(decimal weight){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Shipping_GetRates");
                	sp.Command.AddParameter("@weight",weight, DbType.Currency);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Content_Update Stored Procedure
            /// </summary>
            public static StoredProcedure ContentUpdate(int contentID,string contentGUID,string title,string contentName,string content,string iconPath,DateTime dateExpires,int contentGroupID,string lastEditedBy,string externalLink,string status,int listOrder,string callOut,DateTime createdOn,string createdBy,DateTime modifiedOn,string modifiedBy){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Content_Update");
                	sp.Command.AddParameter("@contentID",contentID, DbType.Int32);
	sp.Command.AddParameter("@contentGUID",contentGUID, DbType.Guid);
	sp.Command.AddParameter("@title",title, DbType.String);
	sp.Command.AddParameter("@contentName",contentName, DbType.String);
	sp.Command.AddParameter("@content",content, DbType.String);
	sp.Command.AddParameter("@iconPath",iconPath, DbType.String);
	sp.Command.AddParameter("@dateExpires",dateExpires, DbType.DateTime);
	sp.Command.AddParameter("@contentGroupID",contentGroupID, DbType.Int32);
	sp.Command.AddParameter("@lastEditedBy",lastEditedBy, DbType.String);
	sp.Command.AddParameter("@externalLink",externalLink, DbType.String);
	sp.Command.AddParameter("@status",status, DbType.String);
	sp.Command.AddParameter("@listOrder",listOrder, DbType.Int32);
	sp.Command.AddParameter("@callOut",callOut, DbType.String);
	sp.Command.AddParameter("@createdOn",createdOn, DbType.DateTime);
	sp.Command.AddParameter("@createdBy",createdBy, DbType.String);
	sp.Command.AddParameter("@modifiedOn",modifiedOn, DbType.DateTime);
	sp.Command.AddParameter("@modifiedBy",modifiedBy, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Content_Get Stored Procedure
            /// </summary>
            public static StoredProcedure ContentGet(string contentName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Content_Get");
                	sp.Command.AddParameter("@contentName",contentName, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Content_Insert Stored Procedure
            /// </summary>
            public static StoredProcedure ContentInsert(string contentGUID,string title,string contentName,string content,string iconPath,DateTime dateExpires,int contentGroupID,string lastEditedBy,string externalLink,string status,int listOrder,string callOut,DateTime createdOn,string createdBy,DateTime modifiedOn,string modifiedBy){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Content_Insert");
                	sp.Command.AddParameter("@contentGUID",contentGUID, DbType.Guid);
	sp.Command.AddParameter("@title",title, DbType.String);
	sp.Command.AddParameter("@contentName",contentName, DbType.String);
	sp.Command.AddParameter("@content",content, DbType.String);
	sp.Command.AddParameter("@iconPath",iconPath, DbType.String);
	sp.Command.AddParameter("@dateExpires",dateExpires, DbType.DateTime);
	sp.Command.AddParameter("@contentGroupID",contentGroupID, DbType.Int32);
	sp.Command.AddParameter("@lastEditedBy",lastEditedBy, DbType.String);
	sp.Command.AddParameter("@externalLink",externalLink, DbType.String);
	sp.Command.AddParameter("@status",status, DbType.String);
	sp.Command.AddParameter("@listOrder",listOrder, DbType.Int32);
	sp.Command.AddParameter("@callOut",callOut, DbType.String);
	sp.Command.AddParameter("@createdOn",createdOn, DbType.DateTime);
	sp.Command.AddParameter("@createdBy",createdBy, DbType.String);
	sp.Command.AddParameter("@modifiedOn",modifiedOn, DbType.DateTime);
	sp.Command.AddParameter("@modifiedBy",modifiedBy, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Content_Save Stored Procedure
            /// </summary>
            public static StoredProcedure ContentSave(string contentName,string title,string content,int groupID,string iconPath,string status,string userName,string callOut,string externalLink){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Content_Save");
                	sp.Command.AddParameter("@contentName",contentName, DbType.String);
	sp.Command.AddParameter("@title",title, DbType.String);
	sp.Command.AddParameter("@content",content, DbType.String);
	sp.Command.AddParameter("@groupID",groupID, DbType.Int32);
	sp.Command.AddParameter("@iconPath",iconPath, DbType.String);
	sp.Command.AddParameter("@status",status, DbType.String);
	sp.Command.AddParameter("@userName",userName, DbType.String);
	sp.Command.AddParameter("@callOut",callOut, DbType.String);
	sp.Command.AddParameter("@externalLink",externalLink, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the ClearLogs Stored Procedure
            /// </summary>
            public static StoredProcedure ClearLogs(){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("ClearLogs");
                
                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the InsertCategoryLog Stored Procedure
            /// </summary>
            public static StoredProcedure InsertCategoryLog(int CategoryID,int LogID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("InsertCategoryLog");
                	sp.Command.AddParameter("@CategoryID",CategoryID, DbType.Int32);
	sp.Command.AddParameter("@LogID",LogID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the WriteLog Stored Procedure
            /// </summary>
            public static StoredProcedure WriteLog(int EventID,int Priority,string Severity,string Title,DateTime Timestamp,string MachineName,string AppDomainName,string ProcessID,string ProcessName,string ThreadName,string Win32ThreadId,string Message,string FormattedMessage,int LogId){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("WriteLog");
                	sp.Command.AddParameter("@EventID",EventID, DbType.Int32);
	sp.Command.AddParameter("@Priority",Priority, DbType.Int32);
	sp.Command.AddParameter("@Severity",Severity, DbType.String);
	sp.Command.AddParameter("@Title",Title, DbType.String);
	sp.Command.AddParameter("@Timestamp",Timestamp, DbType.DateTime);
	sp.Command.AddParameter("@MachineName",MachineName, DbType.String);
	sp.Command.AddParameter("@AppDomainName",AppDomainName, DbType.String);
	sp.Command.AddParameter("@ProcessID",ProcessID, DbType.String);
	sp.Command.AddParameter("@ProcessName",ProcessName, DbType.String);
	sp.Command.AddParameter("@ThreadName",ThreadName, DbType.String);
	sp.Command.AddParameter("@Win32ThreadId",Win32ThreadId, DbType.String);
	sp.Command.AddParameter("@Message",Message, DbType.String);
	sp.Command.AddParameter("@FormattedMessage",FormattedMessage, DbType.String);
	sp.Command.AddParameter("@LogId",LogId, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Config_GetList Stored Procedure
            /// </summary>
            public static StoredProcedure StoreConfigGetList(){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Config_GetList");
                
                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Category_GetCrumbs Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetCrumbs(int categoryID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Category_GetCrumbs");
                	sp.Command.AddParameter("@categoryID",categoryID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_GetByPriceRange Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductGetByPriceRange(int categoryID,decimal priceStart,decimal priceEnd){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_GetByPriceRange");
                	sp.Command.AddParameter("@categoryID",categoryID, DbType.Int32);
	sp.Command.AddParameter("@priceStart",priceStart, DbType.Currency);
	sp.Command.AddParameter("@priceEnd",priceEnd, DbType.Currency);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_GetByManufacturerID Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductGetByManufacturerID(int manufacturerID,int categoryID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_GetByManufacturerID");
                	sp.Command.AddParameter("@manufacturerID",manufacturerID, DbType.Int32);
	sp.Command.AddParameter("@categoryID",categoryID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_GetByCategoryID Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductGetByCategoryID(int categoryID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_GetByCategoryID");
                	sp.Command.AddParameter("@categoryID",categoryID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_GetMostPopular Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductGetMostPopular(){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_GetMostPopular");
                
                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Promo_Bundle_GetAvailableProducts Stored Procedure
            /// </summary>
            public static StoredProcedure PromoBundleGetAvailableProducts(int bundleID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Promo_Bundle_GetAvailableProducts");
                	sp.Command.AddParameter("@bundleID",bundleID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the AddCategory Stored Procedure
            /// </summary>
            public static StoredProcedure AddCategory(string CategoryName,int LogID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("AddCategory");
                	sp.Command.AddParameter("@CategoryName",CategoryName, DbType.String);
	sp.Command.AddParameter("@LogID",LogID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_SmartSearch Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductSmartSearch(int DescriptionLength,bool AllWords,string Word1,string Word2,string Word3,string Word4,string Word5){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_SmartSearch");
                	sp.Command.AddParameter("@DescriptionLength",DescriptionLength, DbType.Int32);
	sp.Command.AddParameter("@AllWords",AllWords, DbType.Boolean);
	sp.Command.AddParameter("@Word1",Word1, DbType.String);
	sp.Command.AddParameter("@Word2",Word2, DbType.String);
	sp.Command.AddParameter("@Word3",Word3, DbType.String);
	sp.Command.AddParameter("@Word4",Word4, DbType.String);
	sp.Command.AddParameter("@Word5",Word5, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Category_GetAllSubs Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetAllSubs(int parentID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Category_GetAllSubs");
                	sp.Command.AddParameter("@parentID",parentID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Category_GetPageMulti Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetPageMulti(int categoryID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Category_GetPageMulti");
                	sp.Command.AddParameter("@categoryID",categoryID, DbType.Int32);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Category_GetPageByGUIDMulti Stored Procedure
            /// </summary>
            public static StoredProcedure StoreCategoryGetPageByGUIDMulti(string categoryGUID){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Category_GetPageByGUIDMulti");
                	sp.Command.AddParameter("@categoryGUID",categoryGUID, DbType.String);

                return sp;
            }

            /// <summary>
            /// Creates an object wrapper for the CSK_Store_Product_GetByCategoryName Stored Procedure
            /// </summary>
            public static StoredProcedure StoreProductGetByCategoryName(string categoryName){;
                SubSonic.StoredProcedure sp = new SubSonic.StoredProcedure("CSK_Store_Product_GetByCategoryName");
                	sp.Command.AddParameter("@categoryName",categoryName, DbType.String);

                return sp;
            }

}

}