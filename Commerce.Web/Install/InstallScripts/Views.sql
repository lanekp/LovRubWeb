if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductCrossSells]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[ProductCrossSells]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vwProduct]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vwProduct]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[vCoupons]') and OBJECTPROPERTY(id, N'IsView') = 1)
drop view [dbo].[vCoupons]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.vCoupons
AS
SELECT     dbo.CSK_Coupons.CouponCode, dbo.CSK_Coupons.CouponTypeId, dbo.CSK_Coupons.IsSingleUse, 
                      dbo.CSK_CouponTypes.Description AS CouponType, dbo.CSK_CouponTypes.ProcessingClassName AS CouponClassType, 
                      dbo.CSK_CouponTypes.IsAspClass, dbo.CSK_Coupons.NumberUses AS NumberOfUses, dbo.CSK_Coupons.ExpirationDate, 
                      dbo.CSK_Coupons.XmlData, dbo.CSK_Coupons.UserId
FROM         dbo.CSK_Coupons INNER JOIN
                      dbo.CSK_CouponTypes ON dbo.CSK_Coupons.CouponTypeId = dbo.CSK_CouponTypes.CouponTypeId

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.ProductCrossSells
AS
SELECT     dbo.CSK_Store_Product.productID, dbo.CSK_Store_Product.sku, dbo.CSK_Store_Product.productName, dbo.CSK_Store_Product.shortDescription, 
                      dbo.CSK_Store_Product.manufacturerID, dbo.CSK_Store_Product.attributeXML, dbo.CSK_Store_Product.statusID, 
                      dbo.CSK_Store_Product.productTypeID, dbo.CSK_Store_Product.shippingTypeID, dbo.CSK_Store_Product.shipEstimateID, 
                      dbo.CSK_Store_Product.taxTypeID, dbo.CSK_Store_Product.stockLocation, dbo.CSK_Store_Product.ourPrice, dbo.CSK_Store_Product.retailPrice, 
                      dbo.CSK_Store_Product.weight, dbo.CSK_Store_Product.currencyCode, dbo.CSK_Store_Product.unitOfMeasure, 
                      dbo.CSK_Store_Product.adminComments, dbo.CSK_Store_Product.length, dbo.CSK_Store_Product.height, dbo.CSK_Store_Product.width, 
                      dbo.CSK_Store_Product.dimensionUnit, dbo.CSK_Store_Product.isDeleted, dbo.CSK_Store_Product.listOrder, dbo.CSK_Store_Product.ratingSum, 
                      dbo.CSK_Store_Product.totalRatingVotes, dbo.CSK_Store_Product.defaultImage, dbo.CSK_Store_Product.createdOn, 
                      dbo.CSK_Store_Product.createdBy, dbo.CSK_Store_Product.modifiedOn, dbo.CSK_Store_Product.modifiedBy, 
                      dbo.CSK_Promo_Product_CrossSell_Map.crossProductID, dbo.CSK_Promo_Product_CrossSell_Map.productID AS fromProductID, 
                      dbo.CSK_Store_Product.productGUID, CONVERT(money, dbo.CSK_Store_Product.ratingSum) / CONVERT(money, 
                      dbo.CSK_Store_Product.totalRatingVotes) AS rating
FROM         dbo.CSK_Store_Product INNER JOIN
                      dbo.CSK_Promo_Product_CrossSell_Map ON dbo.CSK_Store_Product.productID = dbo.CSK_Promo_Product_CrossSell_Map.crossProductID
WHERE     (dbo.CSK_Store_Product.statusID <> 99)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE VIEW dbo.vwProduct
AS
SELECT     dbo.CSK_Store_Product.productID, dbo.CSK_Store_Product.sku, dbo.CSK_Store_Product.productName, dbo.CSK_Store_Product.shortDescription, 
                      dbo.CSK_Store_Product.manufacturerID, dbo.CSK_Store_Product.statusID, dbo.CSK_Store_Product.productTypeID, 
                      dbo.CSK_Store_Product.shippingTypeID, dbo.CSK_Store_Product.shipEstimateID, dbo.CSK_Store_Product.taxTypeID, 
                      dbo.CSK_Store_Product.stockLocation, dbo.CSK_Store_Product.ourPrice, dbo.CSK_Store_Product.retailPrice, dbo.CSK_Store_Product.weight, 
                      dbo.CSK_Store_Product.currencyCode, dbo.CSK_Store_Product.unitOfMeasure, dbo.CSK_Store_Product.adminComments, 
                      dbo.CSK_Store_Product.length, dbo.CSK_Store_Product.height, dbo.CSK_Store_Product.width, dbo.CSK_Store_Product.dimensionUnit, 
                      dbo.CSK_Store_Product.isDeleted, dbo.CSK_Store_Product.listOrder, dbo.CSK_Store_Product.ratingSum, dbo.CSK_Store_Product.totalRatingVotes, 
                      dbo.CSK_Store_Product.createdOn, dbo.CSK_Store_Product.createdBy, dbo.CSK_Store_Product.modifiedOn, dbo.CSK_Store_Product.modifiedBy, 
                      dbo.CSK_Store_ShippingEstimate.shippingEstimate, dbo.CSK_Store_ShippingEstimate.leadTimeDays,
                          (SELECT     TOP 1 imageFile
                            FROM          dbo.CSK_Store_Image
                            WHERE      (productID = dbo.CSK_Store_Product.productID)
                            ORDER BY listOrder) AS imageFile,
                          (SELECT     TOP 1 categoryID
                            FROM          dbo.CSK_Store_Category
                            WHERE      (dbo.CSK_Store_Product.productID = dbo.CSK_Store_Product.productID)
                            ORDER BY categoryID) AS categoryID, CONVERT(money, dbo.CSK_Store_Product.ratingSum) / CONVERT(money, 
                      dbo.CSK_Store_Product.totalRatingVotes) AS rating, dbo.CSK_Store_Manufacturer.manufacturer, dbo.CSK_Store_ProductStatus.status, 
                      dbo.CSK_Tax_Type.taxType, dbo.CSK_Tax_Type.taxCode, dbo.CSK_Store_ShippingType.shippingType, dbo.CSK_Store_ShippingType.shippingCode, 
                      dbo.CSK_Store_Product.defaultImage, dbo.CSK_Store_Product.productGUID, dbo.CSK_Store_Product.attributeXML
FROM         dbo.CSK_Store_Product INNER JOIN
                      dbo.CSK_Store_ShippingEstimate ON dbo.CSK_Store_Product.shipEstimateID = dbo.CSK_Store_ShippingEstimate.shipEstimateID INNER JOIN
                      dbo.CSK_Store_Manufacturer ON dbo.CSK_Store_Product.manufacturerID = dbo.CSK_Store_Manufacturer.manufacturerID INNER JOIN
                      dbo.CSK_Store_ProductStatus ON dbo.CSK_Store_Product.statusID = dbo.CSK_Store_ProductStatus.statusID INNER JOIN
                      dbo.CSK_Tax_Type ON dbo.CSK_Store_Product.taxTypeID = dbo.CSK_Tax_Type.taxTypeID INNER JOIN
                      dbo.CSK_Store_ShippingType ON dbo.CSK_Store_Product.shippingTypeID = dbo.CSK_Store_ShippingType.shippingTypeID
WHERE     (dbo.CSK_Store_Product.isDeleted = 0)

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

