if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[AddCategory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[AddCategory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Coupons_GetCoupon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Coupons_GetCoupon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Coupons_GetCouponType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Coupons_GetCouponType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Coupons_SaveCoupon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Coupons_SaveCoupon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Coupons_SaveCouponType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Coupons_SaveCouponType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_AddProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_AddProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Bundle_AddProduct]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_Bundle_AddProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Bundle_GetAvailableProducts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_Bundle_GetAvailableProducts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Bundle_GetByProductID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_Bundle_GetByProductID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Bundle_GetSelectedProducts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_Bundle_GetSelectedProducts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_EnsureOrderCoupon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_EnsureOrderCoupon]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_GetProductList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_GetProductList]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_ProductMatrix]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_ProductMatrix]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_RemoveProducts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Promo_RemoveProducts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Shipping_GetRates]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Shipping_GetRates]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Shipping_GetRates_Air]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Shipping_GetRates_Air]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Shipping_GetRates_Ground]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Shipping_GetRates_Ground]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_FavoriteCategories]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Stats_FavoriteCategories]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_FavoriteProducts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Stats_FavoriteProducts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_Tracker_GetByBehaviorID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Stats_Tracker_GetByBehaviorID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_Tracker_GetByProductAndBehavior]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Stats_Tracker_GetByProductAndBehavior]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_Tracker_SynchTrackingCookie]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Stats_Tracker_SynchTrackingCookie]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_AddItemToCart]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_AddItemToCart]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category_GetAllSubs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Category_GetAllSubs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category_GetByProductID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Category_GetByProductID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category_GetCrumbs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Category_GetCrumbs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category_GetPageByGUIDMulti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Category_GetPageByGUIDMulti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category_GetPageByNameMulti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Category_GetPageByNameMulti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category_GetPageMulti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Category_GetPageMulti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Order_Query]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Order_Query]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_AddRating]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_AddRating]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_DeletePermanent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_DeletePermanent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_GetByCategoryID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_GetByCategoryID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_GetByManufacturerID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_GetByManufacturerID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_GetByPriceRange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_GetByPriceRange]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_GetMostPopular]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_GetMostPopular]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_GetPostAddMulti]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_GetPostAddMulti]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_SmartSearch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Store_Product_SmartSearch]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Tax_GetTaxRate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[CSK_Tax_GetTaxRate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClearLogs]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[ClearLogs]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertCategoryLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertCategoryLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[WriteLog]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[WriteLog]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE [dbo].[AddCategory]
	-- Add the parameters for the function here
	@CategoryName nvarchar(64),
	@LogID int
AS
BEGIN
	SET NOCOUNT ON;
    DECLARE @CatID INT
	SELECT @CatID = CategoryID FROM Category WHERE CategoryName = @CategoryName
	IF @CatID IS NULL
	BEGIN
		INSERT INTO Category (CategoryName) VALUES(@CategoryName)
		SELECT @CatID = @@IDENTITY
	END

	EXEC InsertCategoryLog @CatID, @LogID 

	RETURN @CatID
END


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Coupons_GetCoupon] 
	(
	@couponCode nvarchar(30)
	)
AS
	SELECT 
		C.CouponCode, 
		C.CouponTypeId, 
		C.IsSingleUse, 
		C.UserId, 
		C.NumberUses, 
		C.ExpirationDate, 
		C.XmlData 
	FROM 
		CSK_Coupons C
	WHERE 
		C.CouponCode = @couponCode 	

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Coupons_GetCouponType] 
	(
	@couponTypeId int
	)
AS
	/* SET NOCOUNT ON */ 
	SELECT 
		CT.CouponTypeId, 
		CT.Description, 
		CT.ProcessingClassName 
	FROM 
		CSK_CouponTypes CT
	WHERE 
		CT.CouponTypeId = @couponTypeId 
		
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Coupons_SaveCoupon] 
(
	@CouponCode nvarchar(30), 
	@CouponTypeId int, 
	@IsSingleUse bit, 
	@NumberUses int, 
	@ExpirationDate datetime, 
	@XmlData ntext
)
AS
	IF NOT EXISTS (SELECT CouponCode FROM CSK_Coupons WHERE CouponCode = @CouponCode)
	  BEGIN
		--New coupon ... insert.  
		INSERT INTO CSK_Coupons(
			CouponCode, 
			CouponTypeId, 
			IsSingleUse, 
			UserId, 
			NumberUses, 
			ExpirationDate, 
			[XmlData])
		  VALUES (
			@CouponCode, 
			@CouponTypeId, 
			@IsSingleUse, 
			newid(), 
			@NumberUses, 
			@ExpirationDate, 
			@XmlData)
	  END 
	ELSE 
	  BEGIN 
		UPDATE CSK_Coupons SET 
			CouponTypeId = @CouponTypeId, 
			IsSingleUse = @IsSingleUse, 
			NumberUses = @NumberUses, 
			ExpirationDate = @ExpirationDate, 
			[XmlData] = @XmlData
			WHERE CouponCode = @CouponCode 
	  END 
	RETURN
 


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Coupons_SaveCouponType] 
	(
	@CouponTypeId int, 
	@Description nvarchar(128), 
	@ProcessingClassName nvarchar(256)
	)
AS
	IF EXISTS (SELECT CouponTypeId FROM CSK_CouponTypes WHERE CouponTypeId=@CouponTypeId)

	BEGIN 
		UPDATE CSK_CouponTypes SET 
			Description = @Description, 
			ProcessingClassName = @ProcessingClassName
		WHERE 
			CouponTypeId = @CouponTypeId
		RETURN @CouponTypeId 
	END 
	ELSE
	BEGIN  
		INSERT INTO CSK_CouponTypes
			(Description, ProcessingClassName) 
			VALUES 
			(@Description, @ProcessingClassName)
		RETURN SCOPE_IDENTITY()
	END 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_AddProduct]
	(
	@promoID int,
	@productID int
	)
AS
	
	INSERT into CSK_Promo_Product_Promo_Map (promoID, productID)
	VALUES (@promoID, @productID)
	
	RETURN





GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_Bundle_AddProduct]
	(
	@bundleID int,
	@productID int
	)
AS
	if not exists(Select productID FROM CSK_Promo_Product_Bundle_Map WHERE productID=@productID
	AND bundleID=@bundleID)
	BEGIN
		INSERT INTO CSK_Promo_Product_Bundle_Map(productID, bundleID)
		VALUES  (@productID, @bundleID)
	
	END
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Promo_Bundle_GetAvailableProducts]
	(
	@bundleID int
	)
AS
	
	SELECT productID, sku, productName, imageFile
	FROM vwProduct
	WHERE productID NOT IN(SELECT productID FROM CSK_Promo_Product_Bundle_Map WHERE bundleID=@bundleID)
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





	CREATE PROCEDURE [dbo].[CSK_Promo_Bundle_GetByProductID]
	(
		@productID int
	)
	AS
	DECLARE @bundleID int
	SELECT @bundleID=bundleID FROM CSK_Promo_Product_Bundle_Map WHERE productID=@productID
	SELECT     CSK_Promo_Bundle.bundleID, CSK_Promo_Bundle.bundleName, CSK_Promo_Bundle.discountPercent, CSK_Promo_Bundle.description, 
	                      CSK_Promo_Bundle.createdOn, CSK_Promo_Bundle.createdBy, CSK_Promo_Bundle.modifiedOn, CSK_Promo_Bundle.modifiedBy, 
	                      CSK_Store_Product.productID, CSK_Store_Product.sku, CSK_Store_Product.productName, CSK_Store_Product.shortDescription, 
	                      CSK_Store_Product.defaultImage AS imageFile, CSK_Store_Product.ourPrice, CSK_Store_Product.retailPrice, CSK_Store_Product.weight
	FROM         CSK_Promo_Bundle INNER JOIN
	                      CSK_Promo_Product_Bundle_Map ON CSK_Promo_Bundle.bundleID = CSK_Promo_Product_Bundle_Map.bundleID INNER JOIN
	                      CSK_Store_Product ON CSK_Promo_Product_Bundle_Map.productID = CSK_Store_Product.productID
	WHERE     (CSK_Promo_Bundle.bundleID = @bundleID)

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_Bundle_GetSelectedProducts]
	(
	@bundleID int
	)
AS
	SELECT productID, sku, productName
	FROM CSK_Store_Product
	WHERE productID IN(SELECT productID FROM CSK_Promo_Product_Bundle_Map WHERE bundleID=@bundleID)
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_EnsureOrderCoupon]
	(
		@orderID int
	)
AS
	
	DECLARE @itemCount int
	SELECT @itemCount=COUNT(orderItemID) FROM CSK_Store_OrderItem
	WHERE orderID=@orderID
	
	IF @itemCount=0
	BEGIN
		DECLARE @discountAmount money
		DECLARE @couponCodes nvarchar(100)
		SELECT @discountAmount=discountAmount, @couponCodes=couponCodes FROM CSK_Store_Order WHERE orderID=@orderID
		
		UPDATE CSK_Store_Order SET CouponCodes='',discountAmount=0 WHERE orderID=@orderID
		
		--add a note to the order that all coupons were removed
		IF @couponCodes<>''
			INSERT INTO CSK_Store_OrderNote(orderID, note,orderStatus, createdOn, createdBy, modifiedOn, modifiedBy)
			VALUES(@orderID, 'Coupon '+@couponCodes+' removed','Not checked out',getdate(),'Coupon System',getdate(),'Coupon System')
	END
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_GetProductList]
	(
		@promoID int
	)
AS
	SELECT     productID, promoID
	FROM         CSK_Promo_Product_Promo_Map
	WHERE     (promoID = @promoID)
	
	
	SELECT     productID, sku, productName
	FROM         CSK_Store_Product

	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_ProductMatrix]
AS


	SELECT     CSK_Promo_Campaign.campaignID, CSK_Promo_Campaign.campaignName, CSK_Promo.promoID, CSK_Promo.promoCode, CSK_Promo.title, 
	                      CSK_Promo.description, CSK_Store_Product.productID, CSK_Store_Product.sku, CSK_Store_Product.productName, CSK_Store_Product.ourPrice, 
	                      CSK_Store_Product.retailPrice, CSK_Store_Product.retailPrice * CSK_Promo.discount / 100 AS discountAmount, 
	                      CSK_Store_Product.retailPrice - CSK_Store_Product.retailPrice * CSK_Promo.discount / 100 AS discountedPrice, CSK_Promo.discount, 
	                      CSK_Promo.qtyThreshold, CSK_Promo.isActive, CSK_Promo.dateEnd
	FROM         CSK_Promo INNER JOIN
	                      CSK_Promo_Product_Promo_Map ON CSK_Promo.promoID = CSK_Promo_Product_Promo_Map.promoID INNER JOIN
	                      CSK_Store_Product ON CSK_Promo_Product_Promo_Map.productID = CSK_Store_Product.productID INNER JOIN
	                      CSK_Promo_Campaign ON CSK_Promo.campaignID = CSK_Promo_Campaign.campaignID
	WHERE     (CSK_Promo.isActive = 1) AND (CSK_Promo.dateEnd >= GETDATE())
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Promo_RemoveProducts] 
	(
	@promoID int
	)
AS
	DELETE FROM CSK_Promo_Product_Promo_Map
	WHERE promoID=@promoID
	RETURN



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Shipping_GetRates]
	(
		@weight money
	)
AS
	--this is a very simple rate calculator that does not take into account
	--distance. Use only for testing
	SELECT     shippingRateID, Service, AmountPerUnit, @weight * AmountPerUnit AS Rate, isAirOnly, isGroundOnly
	FROM         CSK_Shipping_Rate
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Shipping_GetRates_Air]
	(
		@weight money
	)
AS
	--this is a very simple rate calculator that does not take into account
	--distance. Use only for testing
	SELECT     shippingRateID, Service, AmountPerUnit, @weight * AmountPerUnit AS Rate, isAirOnly, isGroundOnly
	FROM         CSK_Shipping_Rate
	WHERE isAirOnly=1
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Shipping_GetRates_Ground]
	(
		@weight money
	)
AS
	--this is a very simple rate calculator that does not take into account
	--distance. Use only for testing
	SELECT     shippingRateID, Service, AmountPerUnit, @weight * AmountPerUnit AS Rate, isAirOnly, isGroundOnly
	FROM         CSK_Shipping_Rate
	WHERE isGroundOnly=1
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Stats_FavoriteCategories]
	(
	   @userName nvarchar(50)
	)
AS
SELECT TOP 5 
	dbo.CSK_Stats_Behavior.behavior
	,dbo.CSK_Stats_Tracker.categoryID
	,dbo.CSK_Stats_Tracker.userName
	,dbo.CSK_Store_Category.categoryGUID
	,dbo.CSK_Store_Category.categoryName
	,COUNT(dbo.CSK_Stats_Tracker.trackingID) AS ViewCount
FROM dbo.CSK_Stats_Behavior 
	INNER JOIN
    dbo.CSK_Stats_Tracker ON dbo.CSK_Stats_Behavior.behaviorID = dbo.CSK_Stats_Tracker.behaviorID 
	INNER JOIN
	dbo.CSK_Store_Category ON dbo.CSK_Stats_Tracker.categoryID = dbo.CSK_Store_Category.categoryID
WHERE CSK_Stats_Tracker.userName = @userName
GROUP BY 
	dbo.CSK_Stats_Behavior.behavior
	,dbo.CSK_Stats_Tracker.categoryID
	,dbo.CSK_Stats_Tracker.userName
	,dbo.CSK_Store_Category.categoryGUID
	,dbo.CSK_Store_Category.categoryName
ORDER BY COUNT(dbo.CSK_Stats_Tracker.trackingID) DESC
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Stats_FavoriteProducts]
	(
	   @userName nvarchar(50)
	)
AS
	
SELECT     TOP 100 PERCENT CSK_Stats_Tracker.userName, CSK_Store_Product.productGUID, CSK_Store_Product.productName, 
                      COUNT(CSK_Stats_Tracker.trackingID) AS ViewCount, CSK_Store_Product.defaultImage, CSK_Store_Product.productID
FROM         CSK_Stats_Tracker INNER JOIN
                      CSK_Store_Product ON CSK_Stats_Tracker.productSKU = CSK_Store_Product.sku
WHERE     (CSK_Stats_Tracker.userName = @userName)
GROUP BY CSK_Stats_Tracker.userName, CSK_Store_Product.productGUID, CSK_Store_Product.productName, CSK_Store_Product.defaultImage, 
                      CSK_Store_Product.productID
ORDER BY COUNT(CSK_Stats_Tracker.trackingID) DESC

RETURN
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


	

	CREATE PROCEDURE [dbo].[CSK_Stats_Tracker_GetByBehaviorID]
	(
		@behaviorID int
	)
	AS
	SELECT 
	trackingID,
		userName,
		adID,
		promoID,
		productSKU,
		categoryID,
		pageURL,
		behaviorID,
		searchString,
		sessionID,
		createdOn,
		createdBy,
		modifiedOn,
		modifiedBy
	
	FROM CSK_Stats_Tracker
	WHERE 
		behaviorID=@behaviorID
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Stats_Tracker_GetByProductAndBehavior] 
	(
	@behaviorID int,
	@sku nvarchar(50)
	)
AS
	SELECT     trackingID, userName, adID, promoID, productSKU, categoryID, pageURL, behaviorID, searchString, sessionID, createdOn, createdBy, modifiedOn, 
	                      modifiedBy
	FROM         CSK_Stats_Tracker
	WHERE     (productSKU = @sku) AND (behaviorID = @behaviorID)
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Stats_Tracker_SynchTrackingCookie]
	(
	@userName nvarchar(50),
	@trackerCookie nvarchar(50)
	)
AS
	UPDATE CSK_Stats_Tracker SET userName=@userName WHERE userName=@trackerCookie
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_AddItemToCart]
	(
	@userName nvarchar(50),
	@productID int,
	@attributes nvarchar(4000)='',
	@pricePaid money,
	@promoCode nvarchar(50)='',
	@quantity int =1
	)
AS
	
	--first, get the order ID
	declare @orderID int
	SELECT @orderID=orderID FROM CSK_Store_Order WHERE userName=@userName AND orderStatusID=9999
	
	--reset any discounts/coupons (basket-wide) they don't apply anymore since we're
	--adding an item
	UPDATE CSK_Store_Order SET DiscountAmount=0, CouponCodes='' WHERE orderID=@orderID
	
	
	--reset isLastAdded
	UPDATE CSK_Store_OrderItem SET isLastAdded=0 WHERE orderID=@orderID
	
	--next, see if the product is in the basket, with the same set of attributes
	IF EXISTS (SELECT productID FROM CSK_Store_OrderItem WHERE orderID=@orderID AND productID=@productID AND attributes=@attributes)
		BEGIN
			--update the quantity
			--first reset the last item added
			UPDATE CSK_Store_OrderItem 
			SET quantity=quantity+@quantity,isLAstAdded=1
			WHERE orderID=@orderID AND productID=@productID AND attributes=@attributes
		END
	
	ELSE
		BEGIN
			--the product's not in there, add it
			INSERT INTO CSK_Store_OrderItem
          (
          productID, 
          sku, 
          productName, 
          orderID, 
          imageFile, 
          productDescription, 
          promoCode, 
          quantity, 
          originalPrice, 
          pricePaid, 
          attributes, 
          shippingEstimate, 
          rating, 
          isLastAdded,
          createdOn, 
          modifiedOn,
          createdBy,
          modifiedBy,
          weight,
		      length,
		      width,
		      height,
		      dimensionUnit
          )
			SELECT     
			productID, 
			sku, 
			productName, 
			@orderID, 
			defaultImage, 
			shortDescription, 
			@promoCode, 
			@quantity, 
			retailPrice, 
			@pricePaid, 
			@attributes, 
			shippingEstimate, 
			rating, 
			1,
			getdate(),
			getdate(),
			@userName,
			@userName,
			weight,
			length,
			width,
			height,
			dimensionUnit
			FROM         
			vwProduct
			WHERE 
			productID=@productID
	
		END
	
	
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Category_GetAllSubs]
	(
		@parentID int
	)
AS
	SELECT     categoryID, categoryGUID, categoryName, imageFile, parentID, shortDescription, longDescription, listOrder
	FROM         CSK_Store_Category
	WHERE categoryID IN (SELECT id FROM dbo.GetChildren(@parentID))
	AND categoryID<>@parentID
	ORDER BY listOrder
	
	RETURN
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Category_GetByProductID]
	(
	@productID int
	)
AS
	SELECT     dbo.CSK_Store_Category.categoryID, dbo.CSK_Store_Category.categoryName, dbo.CSK_Store_Category.categoryGUID AS imageFile, 
                      dbo.CSK_Store_Category.imageFile AS parentID, dbo.CSK_Store_Category.parentID AS shortDescription, 
                      dbo.CSK_Store_Category.shortDescription AS longDescription, dbo.CSK_Store_Category.longDescription AS listOrder, 
                      dbo.CSK_Store_Category.listOrder AS createdOn, dbo.CSK_Store_Category.createdOn AS createdBy, 
                      dbo.CSK_Store_Category.createdBy AS modifiedOn, dbo.CSK_Store_Category.modifiedOn AS modifiedBy, 
                      dbo.CSK_Store_Category.modifiedBy AS productID, dbo.CSK_Store_Product_Category_Map.productID
FROM         dbo.CSK_Store_Product_Category_Map INNER JOIN
                      dbo.CSK_Store_Category ON dbo.CSK_Store_Product_Category_Map.categoryID = dbo.CSK_Store_Category.categoryID
                      WHERE CSK_Store_Product_Category_Map.productID=@productID
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Category_GetCrumbs] 
	@categoryID int
AS
	DECLARE @parentID int
	DECLARE @category varchar(50)
	DECLARE @categoryGUID nvarchar(50)
	DECLARE @output varchar(500)
	DECLARE @loopCount int
	SET @parentID=9999
	
	CREATE TABLE #cats(
		categoryID int,
		category varchar(50),
		categoryGUID nvarchar(50),
		listOrder int
	)
	
	SET @loopCount=1
	
	while(@parentID <>0 AND @loopCount<10)
	BEGIN
		SELECT @parentID=parentID, 
				@category=categoryName, 
				@categoryGUID=categoryGUID  
		FROM CSK_Store_Category WHERE categoryID=@categoryID
		
		IF(@category<>'')
			SET @output=@output+';'+@category
		
		INSERT INTO #cats(categoryID, category, categoryGUID, listOrder) VALUES(@categoryID, @category, @categoryGUID, @loopCount)
		SET @categoryID=@parentID
		SET @loopCount=@loopCount+1
	END
	SELECT * FROM #cats ORDER BY listOrder DESC
	DROP Table #cats
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Store_Category_GetPageByGUIDMulti]
	(
		@categoryGUID nvarchar(50)
	)
AS
	DECLARE @categoryID int
	SELECT @categoryID = categoryID FROM CSK_Store_Category WHERE categoryGUID = @categoryGUID
	--main record
	SELECT     categoryID, categoryName, imageFile, parentID, shortDescription, longDescription, listOrder, createdOn, createdBy, modifiedOn, modifiedBy
	FROM         CSK_Store_Category
	WHERE     (categoryID = @categoryID)
	
	--subs
	EXEC CSK_Store_Category_GetAllSubs @categoryID
	
	--brands
	
	SELECT     CSK_Store_Manufacturer.manufacturerID, CSK_Store_Manufacturer.manufacturer
	FROM         CSK_Store_Manufacturer INNER JOIN
	                      CSK_Store_Product ON CSK_Store_Manufacturer.manufacturerID = CSK_Store_Product.manufacturerID INNER JOIN
	                      CSK_Store_Product_Category_Map ON CSK_Store_Product.productID = CSK_Store_Product_Category_Map.productID
	WHERE     (CSK_Store_Product_Category_Map.categoryID IN
	                          (SELECT     Id
	                            FROM          dbo.GetChildren(@categoryID) AS GetChildren_1))
	GROUP BY CSK_Store_Manufacturer.manufacturerID, CSK_Store_Manufacturer.manufacturer
	
	
	--price range
	DECLARE @minPrice money, @maxPrice money
	SELECT @minPrice=MIN(ourPrice), @maxPrice=MAX(ourPrice)
	FROM CSK_Store_Product 
	WHERE productID IN(select productID FROM CSK_Store_Product_Category_Map WHERE categoryID IN (SELECT id FROM dbo.GetChildren(@categoryID))
	)
	CREATE TABLE #prices(lowRange money, hiRange money)
	DECLARE @thisLow money, @thisHigh money
	SET @thisLow=@minPrice
	SET @thisHigh=2*@thisLow-1
	IF @thisLow = 0
	BEGIN
		SET @thisHigh = 1
	END	

	DECLARE @loopCatch int
	
	--catch infinite loops
	SELECT @loopCatch=1
	WHILE @thisLow<=@maxPrice AND @loopCatch<100
		BEGIN
			
			INSERT INTO #prices(lowRange, hiRange)
			VALUES (@thisLow, @thisHigh)
			
			SET @thisLow=@thisHigh+1
			SET @thisHigh=2*@thisLow-1
			SELECT @loopCatch=@loopCatch+1

		END
	SELECT * FROM #prices
	DROP TABLE #prices
	
	--products
	EXEC CSK_Store_Product_GetByCategoryID @categoryID
	
	--bread crumbs
	EXEC CSK_Store_Category_GetCrumbs @categoryID
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Category_GetPageByNameMulti]
	(
		@categoryName nvarchar(50)
	)
AS
	DECLARE @categoryID int
	--replace the spaces here to accomodate URL rewrite
	SELECT @categoryID=categoryID FROM CSK_Store_Category WHERE REPLACE(categoryName,' ','')=REPLACE(@categoryName,' ','')


	EXEC CSK_Store_Category_GetPageMulti @categoryID
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Category_GetPageMulti]
	(
		@categoryID int
	)
AS
	--main record
	SELECT     categoryID, categoryName, imageFile, parentID, shortDescription, longDescription, listOrder, createdOn, createdBy, modifiedOn, modifiedBy
	FROM         CSK_Store_Category
	WHERE     (categoryID = @categoryID)
	
	--subs
	EXEC CSK_Store_Category_GetAllSubs @categoryID
	
	--brands
	
	SELECT     CSK_Store_Manufacturer.manufacturerID, CSK_Store_Manufacturer.manufacturer
	FROM         CSK_Store_Manufacturer INNER JOIN
	                      CSK_Store_Product ON CSK_Store_Manufacturer.manufacturerID = CSK_Store_Product.manufacturerID INNER JOIN
	                      CSK_Store_Product_Category_Map ON CSK_Store_Product.productID = CSK_Store_Product_Category_Map.productID
	WHERE     (CSK_Store_Product_Category_Map.categoryID IN
	                          (SELECT     Id
	                            FROM          dbo.GetChildren(@categoryID) AS GetChildren_1))
	GROUP BY CSK_Store_Manufacturer.manufacturerID, CSK_Store_Manufacturer.manufacturer
	
	
	--price range
	DECLARE @minPrice money, @maxPrice money
	SELECT @minPrice=MIN(ourPrice), @maxPrice=MAX(ourPrice)
	FROM CSK_Store_Product 
	WHERE productID IN(select productID FROM CSK_Store_Product_Category_Map WHERE categoryID IN (SELECT id FROM dbo.GetChildren(@categoryID))
	)
	CREATE TABLE #prices(lowRange money, hiRange money)
	DECLARE @thisLow money, @thisHigh money
	SET @thisLow=@minPrice
	SET @thisHigh=2*@thisLow-1
	IF @thisLow = 0
	BEGIN
		SET @thisHigh = 1
	END	

	DECLARE @loopCatch int
	
	--catch infinite loops
	SELECT @loopCatch=1
	WHILE @thisLow<=@maxPrice AND @loopCatch<100
		BEGIN
			
			INSERT INTO #prices(lowRange, hiRange)
			VALUES (@thisLow, @thisHigh)
			
			SET @thisLow=@thisHigh+1
			SET @thisHigh=2*@thisLow-1
			SELECT @loopCatch=@loopCatch+1

		END
	SELECT * FROM #prices
	DROP TABLE #prices
	
	--products
	EXEC CSK_Store_Product_GetByCategoryID @categoryID
	
	--bread crumbs
	EXEC CSK_Store_Category_GetCrumbs @categoryID
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Order_Query]
	(
		@dateStart datetime='1/1/1900',
		@dateEnd datetime='1/1/2100',
		@userName nvarchar(50)='',
		@orderNumber nvarchar(50)=''
	)
AS
	
	--get the orders with the criteria above
	
	SELECT     CSK_Store_Order.orderNumber, CSK_Store_Order.orderID, CSK_Store_Order.orderDate, CSK_Store_Order.orderStatusID, CSK_Store_Order.userName, 
	                      CSK_Store_Order.shippingMethod, CSK_Store_Order.subTotalAmount, CSK_Store_Order.shippingAmount, CSK_Store_Order.handlingAmount, 
	                      CSK_Store_Order.taxAmount, CSK_Store_Order.taxRate, CSK_Store_Order.couponCodes, CSK_Store_Order.discountAmount, 
	                      CSK_Store_Order.specialInstructions, CSK_Store_Order.shipToAddress, CSK_Store_Order.billToAddress, CSK_Store_Order.userIP, 
	                      CSK_Store_Order.shippingTrackingNumber, CSK_Store_Order.numberOfPackages, CSK_Store_Order.packagingNotes, CSK_Store_Order.createdOn, 
	                      CSK_Store_Order.createdBy, CSK_Store_Order.modifiedOn, CSK_Store_Order.modifiedBy, CSK_Store_Order.email, CSK_Store_Order.firstName, 
	                      CSK_Store_Order.lastName, SUM(CSK_Store_OrderItem.pricePaid * CONVERT(money, CSK_Store_OrderItem.quantity)) AS SubtotalAmount, 
	                      (SELECT SUM(amount) FROM CSK_Store_Transaction WHERE orderID=CSK_Store_Order.orderID)
	                      AS Payments, CSK_Store_OrderStatus.OrderStatus, CSK_Store_OrderStatus.OrderStatusID AS Expr1
	FROM         CSK_Store_Order INNER JOIN
	                      CSK_Store_OrderItem ON CSK_Store_Order.orderID = CSK_Store_OrderItem.orderID INNER JOIN
	                      CSK_Store_Transaction ON CSK_Store_Order.orderID = CSK_Store_Transaction.orderID INNER JOIN
	                      CSK_Store_OrderStatus ON CSK_Store_Order.orderStatusID = CSK_Store_OrderStatus.OrderStatusID
	GROUP BY CSK_Store_Order.orderNumber, CSK_Store_Order.orderID, CSK_Store_Order.orderDate, CSK_Store_Order.orderStatusID, 
	                      CSK_Store_Order.userName, CSK_Store_Order.shippingMethod, CSK_Store_Order.subTotalAmount, CSK_Store_Order.shippingAmount, 
	                      CSK_Store_Order.handlingAmount, CSK_Store_Order.taxAmount, CSK_Store_Order.taxRate, CSK_Store_Order.couponCodes, 
	                      CSK_Store_Order.discountAmount, CSK_Store_Order.specialInstructions, CSK_Store_Order.shipToAddress, CSK_Store_Order.billToAddress, 
	                      CSK_Store_Order.userIP, CSK_Store_Order.shippingTrackingNumber, CSK_Store_Order.numberOfPackages, CSK_Store_Order.packagingNotes, 
	                      CSK_Store_Order.createdOn, CSK_Store_Order.createdBy, CSK_Store_Order.modifiedOn, CSK_Store_Order.modifiedBy, CSK_Store_Order.email, 
	                      CSK_Store_Order.firstName, CSK_Store_Order.lastName, CSK_Store_OrderStatus.OrderStatus, CSK_Store_OrderStatus.OrderStatusID
	HAVING      (CSK_Store_Order.orderNumber LIKE '%' + @orderNumber) AND (CSK_Store_Order.orderDate BETWEEN @dateStart AND @dateEnd) AND 
	                      (CSK_Store_Order.userName LIKE '%' + @userName) AND (CSK_Store_OrderStatus.OrderStatusID <> 9999)
	ORDER BY CSK_Store_Order.orderDate DESC
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Product_AddRating]
	(
		@productID int,
		@rating int,
		@userName nvarchar(50)
	)
AS
	DELETE FROM CSK_Store_ProductRating WHERE userName=@userName AND productID=@productID
	INSERT INTO CSK_Store_ProductRating(productID,userName,rating,createdOn, createdBy, modifiedOn, modifiedBy)
	VALUES (@productID,@userName,@rating,getdate(),@userName,getdate(),@userName)
	
	--synch the product ratings
	DECLARE @rateSum int
	DECLARE @totalVotes int
	SELECT @rateSum=SUM(rating), @totalVotes=COUNT(ratingID) FROM CSK_Store_ProductRating WHERE productID=@productID
	UPDATE CSK_Store_Product SET ratingSum=@rateSum, totalRatingVotes=@totalVotes WHERE productID=@productID
	
	
	RETURN

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Product_DeletePermanent]
	(
		@productID int
	)
AS
	--FK tables
	BEGIN TRANSACTION
	
	DELETE FROM CSK_PROMO_Product_Bundle_Map WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Promo_Product_CrossSell_Map WHERE productID = @productID OR crossProductID=@productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Promo_Product_Promo_Map WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Store_Product_Category_Map WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Store_ProductDescriptor WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Store_ProductRating WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Store_ProductReviewFeedback WHERE reviewID IN (SELECT reviewID FROM CSK_Store_ProductRating WHERE productID=@productID);
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Store_ProductReview WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR
	
	DELETE FROM CSK_Store_Image WHERE productID = @productID;
	IF @@ERROR>0 GOTO TRANS_ERR


	--Product Table
	DELETE FROM CSK_Store_Product WHERE productID=@productID
	IF @@ERROR>0 GOTO TRANS_ERR
	
	
	--remove all items from non-checked out carts
	DELETE FROM CSK_Store_OrderItem 
	WHERE productID=@productID
	AND orderID IN (SELECT orderID FROM CSK_Store_Order WHERE orderStatusID=9999)
	IF @@ERROR>0 GOTO TRANS_ERR

	COMMIT TRANSACTION
	
	RETURN
TRANS_ERR:
	ROLLBACK TRANSACTION
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





	CREATE PROCEDURE [dbo].[CSK_Store_Product_GetByCategoryID]
	(
		@categoryID int
	)
	AS
	SELECT     productID, sku, productGUID, productName, shortDescription, manufacturerID, statusID, productTypeID, shippingTypeID, shipEstimateID, taxTypeID, stockLocation, 
	                      ourPrice, retailPrice, weight, currencyCode, unitOfMeasure, adminComments, length, height, width, dimensionUnit, isDeleted, listOrder, RatingSum, 
	                      totalRatingVotes, createdOn, createdBy, modifiedOn, modifiedBy, shippingEstimate, leadTimeDays, imageFile, categoryID, rating, manufacturer, status,
	                       taxType, taxCode, shippingType, shippingCode
	FROM         vwProduct
	WHERE     (productID IN
	                          (SELECT     productID
	                            FROM          CSK_Store_Product_Category_Map
	                            WHERE      (categoryID IN
	                                                       (SELECT     Id
	                                                         FROM          dbo.GetChildren(@categoryID) AS GetChildren_1)))) AND (statusID <> 99)
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


	

	CREATE PROCEDURE [dbo].[CSK_Store_Product_GetByManufacturerID]
	(
		@manufacturerID int,
		@categoryID int
	)
	AS
	SELECT     productID, sku, productGUID, productName, shortDescription, manufacturerID, statusID, productTypeID, shippingTypeID, shipEstimateID, taxTypeID, stockLocation, 
	                      ourPrice, retailPrice, weight, currencyCode, unitOfMeasure, adminComments, length, height, width, dimensionUnit, isDeleted, listOrder, RatingSum, 
	                      totalRatingVotes, createdOn, createdBy, modifiedOn, modifiedBy, shippingEstimate, leadTimeDays, imageFile, categoryID, rating, manufacturer, status,
	                       taxType, taxCode, shippingType, shippingCode
	FROM         vwProduct
	WHERE     (manufacturerID = @manufacturerID) AND (productID IN
	                          (SELECT     productID
	                            FROM          CSK_Store_Product_Category_Map
	                            WHERE      (categoryID IN
	                                                       (SELECT     Id
	                                                         FROM          dbo.GetChildren(@categoryID) AS GetChildren_1)))) AND (statusID <> 99)
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


	

	CREATE PROCEDURE [dbo].[CSK_Store_Product_GetByPriceRange]
	(
		@categoryID int,
		@priceStart money,
		@priceEnd money
	)
	AS
	SELECT     productID, sku, productGUID, productName, shortDescription, manufacturerID, statusID, productTypeID, shippingTypeID, shipEstimateID, taxTypeID, stockLocation, 
	                      ourPrice, retailPrice, weight, currencyCode, unitOfMeasure, adminComments, length, height, width, dimensionUnit, isDeleted, listOrder, RatingSum, 
	                      totalRatingVotes, createdOn, createdBy, modifiedOn, modifiedBy, shippingEstimate, leadTimeDays, imageFile, categoryID, rating, manufacturer, status,
	                       taxType, taxCode, shippingType, shippingCode
	FROM         vwProduct
	WHERE     (productID IN
	                          (SELECT     productID
	                            FROM          CSK_Store_Product_Category_Map
	                            WHERE      (categoryID IN
	                                                       (SELECT     Id
	                                                         FROM          dbo.GetChildren(@categoryID) AS GetChildren_1)))) AND (ourPrice BETWEEN @priceStart AND @priceEnd) AND 
	                      (statusID <> 99)
	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO


CREATE PROCEDURE [dbo].[CSK_Store_Product_GetMostPopular]
AS
	SELECT     TOP 6 vwProduct.productID, vwProduct.sku, vwProduct.productGUID, vwProduct.productName, vwProduct.shortDescription, COUNT(CSK_Stats_Tracker.trackingID) AS Views, 
	                      vwProduct.imageFile, vwProduct.shippingEstimate, vwProduct.rating, vwProduct.status, vwProduct.ourPrice, vwProduct.retailPrice, 
	                      vwProduct.statusID
	FROM         vwProduct INNER JOIN
	                      CSK_Stats_Tracker ON vwProduct.sku = CSK_Stats_Tracker.productSKU
	GROUP BY vwProduct.productID, vwProduct.sku, vwProduct.productGUID, vwProduct.productName, vwProduct.shortDescription, vwProduct.imageFile, vwProduct.shippingEstimate, 
	                      vwProduct.rating, vwProduct.status, vwProduct.ourPrice, vwProduct.retailPrice, vwProduct.statusID
	HAVING      (vwProduct.statusID <> 99)
	ORDER BY Views DESC
	
	
	RETURN


GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

	CREATE PROCEDURE [dbo].[CSK_Store_Product_GetPostAddMulti]
	(
		@userName nvarchar(50)
	)
AS
	
	--get the last item added
	DECLARE @orderID nvarchar(50)
	SELECT @orderID=orderID FROM CSK_STORE_Order WHERE userName=@userName AND orderStatusID=9999
	
	DECLARE @productID int
	SELECT @productID=productID FROM CSK_Store_OrderItem WHERE orderID=@orderID AND isLastAdded=1
	
	--recently added
	SELECT     TOP 1 orderItemID, orderID, productID, sku, productName, productDescription, weight, dimensions, quantity, originalPrice, pricePaid, attributes, 
	                      downloadURL, isShipped, shipDate, shipmentReference, createdOn, createdBy, modifiedOn, modifiedBy,
	                          (SELECT     TOP 1 imageFile
	                            FROM          CSK_Store_Image
	                            WHERE      (productID = @productID)) AS imageFile, imageFile AS Expr1, shippingEstimate, rating
	FROM         CSK_Store_OrderItem
	WHERE     (orderID = @orderID) AND (productID = @productID)
	ORDER BY modifiedOn DESC
	
	
	--get the most recently viewed
	SELECT     TOP 5 CSK_Stats_Tracker.userName, vwProduct.sku, vwProduct.productName, vwProduct.shortDescription, vwProduct.ourPrice, vwProduct.retailPrice, 
	                      vwProduct.weight, vwProduct.statusID, vwProduct.shippingEstimate, vwProduct.productGUID, vwProduct.defaultImage, vwProduct.rating, 
	                      vwProduct.productID
	FROM         CSK_Stats_Tracker INNER JOIN
	                      vwProduct ON CSK_Stats_Tracker.productSKU = vwProduct.sku
	WHERE     (vwProduct.isDeleted = 0)
	GROUP BY CSK_Stats_Tracker.userName, vwProduct.sku, vwProduct.productName, vwProduct.shortDescription, vwProduct.ourPrice, vwProduct.retailPrice, 
	                      vwProduct.weight, vwProduct.statusID, vwProduct.shippingEstimate, vwProduct.productGUID, vwProduct.defaultImage, vwProduct.rating, 
	                      vwProduct.productID
	HAVING      (CSK_Stats_Tracker.userName = @userName) AND (vwProduct.statusID <> 99) AND productID<>@productID
	
	--cross-sells
	SELECT * FROM ProductCrossSells WHERE fromProductID=@productID
	
	--also-boughts
	
	--promotions for basket page
	

	RETURN 

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Store_Product_SmartSearch]
(@DescriptionLength INT,
 @AllWords BIT,

 @Word1 VARCHAR(50) = NULL,
 @Word2 VARCHAR(50) = NULL,
 @Word3 VARCHAR(50) = NULL,
 @Word4 VARCHAR(50) = NULL,
 @Word5 VARCHAR(50) = NULL)
-- @MinPrice money,
 --@MaxPrice money)

AS

--MANY THANKS TO MOODY FOR THIS ROUTINE--

/* Create the table variable that will contain the search results */
DECLARE @Products TABLE
(RowNumber SMALLINT IDENTITY (1,1) NOT NULL,
 ProductID INT,
  productName nvarchar(500),
  shortDescription VARCHAR(2000),
  ourPrice MONEY,
  retailPrice MONEY,
rating money,
  ProductImage nvarchar(500),
  SKU varchar(50),
  Rank INT)

IF @AllWords = 0
   INSERT INTO @Products          
   SELECT ProductID,productName,
          SUBSTRING(shortDescription, 1, @DescriptionLength) + '...' AS shortDescription,
           ourPrice,
	  retailPrice,
	rating,
	imageFile,
	sku,
          3 * dbo.WordCount(@Word1, productName) + dbo.WordCount(@Word1, shortDescription) +
          3 * dbo.WordCount(@Word2, productName) + dbo.WordCount(@Word2, shortDescription) +
          3 * dbo.WordCount(@Word3, productName) + dbo.WordCount(@Word3, shortDescription) +
          3 * dbo.WordCount(@Word4, productName) + dbo.WordCount(@Word4, shortDescription) +
          3 * dbo.WordCount(@Word5, productName) + dbo.WordCount(@Word5, shortDescription)
          AS Rank
   FROM dbo.vwProduct
   WHERE statusID<>99
   ORDER BY Rank DESC
  
/* Populate @Products for an all-words search */
IF @AllWords = 1
   INSERT INTO @Products          
   SELECT  ProductID,productName,
          SUBSTRING(shortDescription, 1, @DescriptionLength) + '...' AS shortDescription,
           ourPrice,
	  retailPrice,
	rating,
	imageFile,
	sku,        
       (3 * dbo.WordCount(@Word1, productName) + dbo.WordCount(@Word1, shortDescription)) *
          CASE
            WHEN @Word2 IS NULL THEN 1
            ELSE 3 * dbo.WordCount(@Word2, productName) + dbo.WordCount(@Word2, shortDescription)
          END *
          CASE
            WHEN @Word3 IS NULL THEN 1
            ELSE 3 * dbo.WordCount(@Word3, productName) + dbo.WordCount(@Word3, shortDescription)
          END *
          CASE
            WHEN @Word4 IS NULL THEN 1
            ELSE 3 * dbo.WordCount(@Word4, productName) + dbo.WordCount(@Word4, shortDescription)
          END *
          CASE
            WHEN @Word5 IS NULL THEN 1
            ELSE 3 * dbo.WordCount(@Word5, productName) + dbo.WordCount(@Word5, shortDescription)
          END
          AS Rank
   FROM dbo.vwProduct
   WHERE statusID<>99
   ORDER BY Rank DESC


/* Send back the requested products */
SELECT ProductID, productName,
          SUBSTRING(shortDescription, 1, @DescriptionLength) + '...' AS shortDescription,
   ProductImage, ourPrice,retailPrice,rating,productImage,SKU,
  Rank
FROM @Products
WHERE Rank > 0 --and UnitCost >=@MinPrice  and UnitCost <= @MaxPrice
 
ORDER BY Rank DESC

 



GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[CSK_Tax_GetTaxRate]
	(
	@zip nvarchar(50)
	)
AS
BEGIN
	--use the state that this zip is in
	DECLARE @state char(2)
	SELECT @state=stateAbbreviation FROM CSK_Util_ZipCode WHERE zipCode=@zip
SELECT     rateID, rate, state, zipCode
FROM         CSK_Tax_Rate
WHERE     (state = @state)
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[ClearLogs]
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM CategoryLog
	DELETE FROM [Log]
    DELETE FROM Category
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROCEDURE [dbo].[InsertCategoryLog]
	@CategoryID INT,
	@LogID INT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @CatLogID INT
	SELECT @CatLogID FROM CategoryLog WHERE CategoryID=@CategoryID and LogID = @LogID
	IF @CatLogID IS NULL
	BEGIN
		INSERT INTO CategoryLog (CategoryID, LogID) VALUES(@CategoryID, @LogID)
		RETURN @@IDENTITY
	END
	ELSE RETURN @CatLogID
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO





/****** Object:  Stored Procedure dbo.WriteLog    Script Date: 10/1/2004 3:16:36 PM ******/

CREATE PROCEDURE [dbo].[WriteLog]
(
	@EventID int, 
	@Priority int, 
	@Severity nvarchar(32), 
	@Title nvarchar(256), 
	@Timestamp datetime,
	@MachineName nvarchar(32), 
	@AppDomainName nvarchar(512),
	@ProcessID nvarchar(256),
	@ProcessName nvarchar(512),
	@ThreadName nvarchar(512),
	@Win32ThreadId nvarchar(128),
	@Message nvarchar(1500),
	@FormattedMessage ntext,
	@LogId int OUTPUT
)
AS 

	INSERT INTO [Log] (
		EventID,
		Priority,
		Severity,
		Title,
		[Timestamp],
		MachineName,
		AppDomainName,
		ProcessID,
		ProcessName,
		ThreadName,
		Win32ThreadId,
		Message,
		FormattedMessage
	)
	VALUES (
		@EventID, 
		@Priority, 
		@Severity, 
		@Title, 
		@Timestamp,
		@MachineName, 
		@AppDomainName,
		@ProcessID,
		@ProcessName,
		@ThreadName,
		@Win32ThreadId,
		@Message,
		@FormattedMessage)

	SET @LogID = @@IDENTITY
	RETURN @LogID




GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

