if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_Promos_CMRC_PROMOS]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] DROP CONSTRAINT FK_CMRC_Products_Promos_CMRC_PROMOS
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_Bundles_CMRC_Bundles]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo_Product_Bundle_Map] DROP CONSTRAINT FK_CMRC_Products_Bundles_CMRC_Bundles
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_PROMOS_CMRC_PROMO_Campaigns]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo] DROP CONSTRAINT FK_CMRC_PROMOS_CMRC_PROMO_Campaigns
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_STATS_Tracker_CMRC_STATS_Behavior]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Stats_Tracker] DROP CONSTRAINT FK_CMRC_STATS_Tracker_CMRC_STATS_Behavior
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_ProductAttributes_CMRC_ProductAttributeTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Attribute] DROP CONSTRAINT FK_CMRC_ProductAttributes_CMRC_ProductAttributeTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_Categories_CMRC_ProductCategories]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] DROP CONSTRAINT FK_CMRC_Products_Categories_CMRC_ProductCategories
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_CMRC_Manufacturers]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT FK_CMRC_Products_CMRC_Manufacturers
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CSK_Store_OrderItem_CSK_Store_Order]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_OrderItem] DROP CONSTRAINT FK_CSK_Store_OrderItem_CSK_Store_Order
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CSK_Store_OrderNote_CSK_Store_Order]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_OrderNote] DROP CONSTRAINT FK_CSK_Store_OrderNote_CSK_Store_Order
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CSK_Store_Transaction_CSK_Store_Order]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Transaction] DROP CONSTRAINT FK_CSK_Store_Transaction_CSK_Store_Order
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_Bundles_CMRC_Products]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo_Product_Bundle_Map] DROP CONSTRAINT FK_CMRC_Products_Bundles_CMRC_Products
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] DROP CONSTRAINT FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] DROP CONSTRAINT FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product1
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_Promos_CMRC_Products]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] DROP CONSTRAINT FK_CMRC_Products_Promos_CMRC_Products
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_ProductAttributes_CMRC_Products]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Attribute] DROP CONSTRAINT FK_CMRC_ProductAttributes_CMRC_Products
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_ProductImages_CMRC_Products]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Image] DROP CONSTRAINT FK_CMRC_ProductImages_CMRC_Products
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_Categories_CMRC_Products]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] DROP CONSTRAINT FK_CMRC_Products_Categories_CMRC_Products
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CSK_Store_ProductDescriptor_CSK_Store_Product]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_ProductDescriptor] DROP CONSTRAINT FK_CSK_Store_ProductDescriptor_CSK_Store_Product
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_CMRC_ProductStatus]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT FK_CMRC_Products_CMRC_ProductStatus
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_CMRC_ProductType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT FK_CMRC_Products_CMRC_ProductType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_CMRC_ShipEstimates]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT FK_CMRC_Products_CMRC_ShipEstimates
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_CMRC_ShippingType]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT FK_CMRC_Products_CMRC_ShippingType
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_OrderTransactions_CMRC_OrderTransactionTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Transaction] DROP CONSTRAINT FK_CMRC_OrderTransactions_CMRC_OrderTransactionTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CMRC_Products_CMRC_TaxTypes]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT FK_CMRC_Products_CMRC_TaxTypes
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CategoryLog_Category]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CategoryLog] DROP CONSTRAINT FK_CategoryLog_Category
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_CategoryLog_Log]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[CategoryLog] DROP CONSTRAINT FK_CategoryLog_Log
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CSK_Messaging_Mailer_isSystemMailer]') AND type = 'D')
ALTER TABLE [dbo].[CSK_Messaging_Mailer] DROP CONSTRAINT [DF_CSK_Messaging_Mailer_isSystemMailer]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CSK_Messaging_Mailer_createdOn]') AND type = 'D')
ALTER TABLE [dbo].[CSK_Messaging_Mailer] DROP CONSTRAINT [DF_CSK_Messaging_Mailer_createdOn]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_CSK_Messaging_Mailer_modifiedOn]') AND type = 'D')
ALTER TABLE [dbo].[CSK_Messaging_Mailer] DROP CONSTRAINT [DF_CSK_Messaging_Mailer_modifiedOn]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Content_Group]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Content_Group]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Content_Text]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Content_Text]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_CouponTypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_CouponTypes]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Coupons]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Coupons]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Messaging_Mailer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Messaging_Mailer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Promo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Bundle]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Promo_Bundle]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Campaign]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Promo_Campaign]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Product_Bundle_Map]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Promo_Product_Bundle_Map]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Product_CrossSell_Map]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Promo_Product_CrossSell_Map]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Promo_Product_Promo_Map]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Promo_Product_Promo_Map]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Shipping_Rate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Shipping_Rate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_Behavior]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Stats_Behavior]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Stats_Tracker]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Stats_Tracker]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Ad]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Ad]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Ad_Text]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Ad_Text]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Address]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Address]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Attribute]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Attribute]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_AttributeTemplate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_AttributeTemplate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_AttributeType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_AttributeType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Category]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Image]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Image]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Manufacturer]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Manufacturer]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Order]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Order]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_OrderItem]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_OrderItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_OrderNote]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_OrderNote]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_OrderStatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_OrderStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Product]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ProductDescriptor]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ProductDescriptor]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ProductRating]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ProductRating]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ProductReview]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ProductReview]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ProductReviewFeedback]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ProductReviewFeedback]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ProductStatus]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ProductStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ProductType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ProductType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Product_Category_Map]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Product_Category_Map]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ShippingEstimate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ShippingEstimate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_ShippingType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_ShippingType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_Transaction]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_Transaction]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Store_TransactionType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Store_TransactionType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Tax_Rate]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Tax_Rate]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Tax_Type]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Tax_Type]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Util_Country]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Util_Country]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Util_Currency]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Util_Currency]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CSK_Util_ZipCode]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CSK_Util_ZipCode]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Category]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Category]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CategoryLog]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CategoryLog]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Log]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Log]
GO

CREATE TABLE [dbo].[CSK_Content_Group] (
	[groupID] [int] NOT NULL,
	[contentGroup] [varchar] (50) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Content_Text] (
	[contentID] [int] IDENTITY (1, 1) NOT NULL,
	[contentGUID] [uniqueidentifier] NULL,
	[title] [nvarchar] (500) NULL,
	[contentName] [nvarchar] (50) NOT NULL,
	[content] [nvarchar] (MAX) NULL,
	[iconPath] [nvarchar] (250) NULL,
	[dateExpires] [datetime] NULL,
	[contentGroupID] [int] NOT NULL,
	[lastEditedBy] [nvarchar] (100) NULL,
	[externalLink] [nvarchar] (250) NULL,
	[status] [nvarchar] (50) NULL,
	[listOrder] [int] NOT NULL,
	[callOut] [nvarchar] (250) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_CouponTypes] (
	[CouponTypeId] [int] IDENTITY (1, 1) NOT NULL,
	[Description] [nvarchar] (128) NOT NULL,
	[ProcessingClassName] [nvarchar] (256) NOT NULL,
	[IsAspClass] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Coupons] (
	[CouponCode] [nvarchar] (30) NOT NULL,
	[CouponTypeId] [int] NOT NULL,
	[IsSingleUse] [bit] NOT NULL,
	[UserId] [uniqueidentifier] NULL,
	[NumberUses] [int] NOT NULL,
	[ExpirationDate] [datetime] NULL,
	[XmlData] [ntext] NOT NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Messaging_Mailer] (
	[mailerID] [int] IDENTITY (1, 1) NOT NULL,
	[mailerName] [nvarchar] (50) NOT NULL,
	[toList] [nvarchar] (500) NULL,
	[ccList] [nvarchar] (500) NULL,
	[fromName] [nvarchar] (50) NOT NULL,
	[fromEmail] [nvarchar] (50) NOT NULL,
	[subject] [nvarchar] (50) NOT NULL,
	[messageBody] [ntext] NOT NULL,
	[isHTML] [bit] NOT NULL,
	[isSystemMailer] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Promo] (
	[promoID] [int] IDENTITY (1, 1) NOT NULL,
	[campaignID] [int] NOT NULL,
	[promoCode] [nvarchar] (50) NULL,
	[title] [nvarchar] (50) NOT NULL,
	[description] [nvarchar] (500) NOT NULL,
	[discount] [money] NOT NULL,
	[qtyThreshold] [int] NOT NULL,
	[inventoryGoal] [int] NOT NULL,
	[revenueGoal] [money] NOT NULL,
	[dateEnd] [datetime] NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Promo_Bundle] (
	[bundleID] [int] IDENTITY (1, 1) NOT NULL,
	[bundleName] [nvarchar] (50) NOT NULL,
	[discountPercent] [int] NOT NULL,
	[description] [nvarchar] (500) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Promo_Campaign] (
	[campaignID] [int] IDENTITY (1, 1) NOT NULL,
	[campaignName] [nvarchar] (50) NOT NULL,
	[description] [nvarchar] (50) NOT NULL,
	[objective] [nvarchar] (500) NULL,
	[revenueGoal] [money] NOT NULL,
	[inventoryGoal] [int] NOT NULL,
	[dateEnd] [datetime] NOT NULL,
	[isActive] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Promo_Product_Bundle_Map] (
	[productID] [int] NOT NULL,
	[bundleID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] (
	[productID] [int] NOT NULL,
	[crossProductID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Promo_Product_Promo_Map] (
	[productID] [int] NOT NULL,
	[promoID] [int] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Shipping_Rate] (
	[shippingRateID] [int] IDENTITY (1, 1) NOT NULL,
	[Service] [varchar] (50) NOT NULL,
	[Rate] [money] NULL,
	[AmountPerUnit] [money] NOT NULL,
	[isAirOnly] [bit] NOT NULL,
	[isGroundOnly] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Stats_Behavior] (
	[behaviorID] [int] IDENTITY (1, 1) NOT NULL,
	[behavior] [nvarchar] (50) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Stats_Tracker] (
	[trackingID] [int] IDENTITY (1, 1) NOT NULL,
	[userName] [nvarchar] (50) NOT NULL,
	[adID] [int] NULL,
	[promoID] [int] NULL,
	[productSKU] [nvarchar] (50) NULL,
	[categoryID] [int] NULL,
	[pageURL] [nvarchar] (100) NULL,
	[behaviorID] [int] NOT NULL,
	[searchString] [nvarchar] (150) NULL,
	[sessionID] [nvarchar] (50) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Ad] (
	[adID] [int] IDENTITY (1, 1) NOT NULL,
	[pageName] [nvarchar] (50) NULL,
	[listOrder] [int] NOT NULL,
	[placement] [nvarchar] (50) NOT NULL,
	[adText] [nvarchar] (2500) NOT NULL,
	[productSku] [nvarchar] (50) NULL,
	[promoID] [int] NULL,
	[categoryID] [int] NULL,
	[dateExpires] [datetime] NULL,
	[isActive] [bit] NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Ad_Text] (
	[adTextID] [int] IDENTITY (1, 1) NOT NULL,
	[adID] [int] NOT NULL,
	[adText] [nvarchar] (1500) NOT NULL,
	[language] [nvarchar] (10) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Address] (
	[addressID] [int] IDENTITY (1, 1) NOT NULL,
	[userName] [nvarchar] (50) NOT NULL,
	[firstName] [nvarchar] (50) NOT NULL,
	[lastName] [nvarchar] (50) NOT NULL,
	[phone] [nvarchar] (50) NULL,
	[email] [nvarchar] (50) NULL,
	[address1] [nvarchar] (50) NOT NULL,
	[address2] [nvarchar] (50) NULL,
	[city] [nvarchar] (50) NOT NULL,
	[stateOrRegion] [nvarchar] (50) NOT NULL,
	[zip] [nvarchar] (50) NOT NULL,
	[country] [nvarchar] (50) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Attribute] (
	[productAttributeID] [int] IDENTITY (1, 1) NOT NULL,
	[productID] [int] NOT NULL,
	[attributeName] [nvarchar] (50) NOT NULL,
	[selectionList] [nvarchar] (3000) NOT NULL,
	[description] [nvarchar] (500) NULL,
	[attributeTypeID] [int] NOT NULL,
	[priceAdjustment] [money] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_AttributeTemplate] (
	[templateID] [int] IDENTITY (1, 1) NOT NULL,
	[attributeName] [nvarchar] (50) NOT NULL,
	[selectionList] [nvarchar] (3000) NOT NULL,
	[description] [nvarchar] (500) NULL,
	[attributeTypeID] [int] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_AttributeType] (
	[attributeTypeID] [int] IDENTITY (1, 1) NOT NULL,
	[attributeType] [nvarchar] (50) NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Category] (
	[categoryID] [int] IDENTITY (1, 1) NOT NULL,
	[categoryGUID] [uniqueidentifier] NOT NULL,
	[categoryName] [nvarchar] (150) NOT NULL,
	[imageFile] [nvarchar] (500) NULL,
	[parentID] [int] NULL,
	[shortDescription] [nvarchar] (500) NULL,
	[longDescription] [ntext] NULL,
	[listOrder] [int] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Image] (
	[imageID] [int] IDENTITY (1, 1) NOT NULL,
	[productID] [int] NOT NULL,
	[imageFile] [nvarchar] (500) NULL,
	[listOrder] [int] NOT NULL,
	[caption] [nvarchar] (500) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Manufacturer] (
	[manufacturerID] [int] IDENTITY (1, 1) NOT NULL,
	[manufacturer] [nvarchar] (50) NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Order] (
	[orderID] [int] IDENTITY (1, 1) NOT NULL,
	[orderGUID] [nvarchar] (50) NOT NULL,
	[orderNumber] [varchar] (50) NULL,
	[orderDate] [smalldatetime] NOT NULL,
	[orderStatusID] [int] NOT NULL,
	[userName] [varchar] (100) NOT NULL,
	[email] [nvarchar] (50) NULL,
	[firstName] [nvarchar] (50) NULL,
	[lastName] [nvarchar] (50) NULL,
	[shipPhone] [nvarchar] (50) NULL,
	[shippingMethod] [varchar] (100) NULL,
	[subTotalAmount] [money] NOT NULL,
	[shippingAmount] [money] NOT NULL,
	[handlingAmount] [money] NOT NULL,
	[taxAmount] [money] NOT NULL,
	[taxRate] [numeric](18, 0) NOT NULL,
	[couponCodes] [nvarchar] (50) NULL,
	[discountAmount] [money] NOT NULL,
	[specialInstructions] [nvarchar] (1500) NULL,
	[shipToAddress] [nvarchar] (500) NULL,
	[billToAddress] [nvarchar] (500) NULL,
	[userIP] [nvarchar] (50) NOT NULL,
	[shippingTrackingNumber] [nvarchar] (150) NULL,
	[numberOfPackages] [int] NULL,
	[packagingNotes] [nvarchar] (500) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_OrderItem] (
	[orderItemID] [int] IDENTITY (1, 1) NOT NULL,
	[orderID] [int] NOT NULL,
	[productID] [int] NOT NULL,
	[sku] [nvarchar] (50) NULL,
	[productName] [nvarchar] (250) NULL,
	[imageFile] [nvarchar] (500) NULL,
	[productDescription] [nvarchar] (2500) NULL,
	[promoCode] [nvarchar] (50) NULL,
	[weight] [money] NULL,
	[dimensions] [nvarchar] (50) NULL,
	[length] [numeric](18, 0) NOT NULL,
	[height] [numeric](18, 0) NOT NULL,
	[width] [numeric](18, 0) NOT NULL,
	[dimensionUnit] [varchar] (20) NOT NULL,
	[quantity] [int] NOT NULL,
	[originalPrice] [money] NOT NULL,
	[pricePaid] [money] NOT NULL,
	[attributes] [nvarchar] (4000) NULL,
	[downloadURL] [nvarchar] (250) NULL,
	[isShipped] [bit] NOT NULL,
	[shipDate] [datetime] NULL,
	[shippingEstimate] [nvarchar] (150) NULL,
	[shipmentReference] [nvarchar] (50) NULL,
	[rating] [money] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL,
	[isLastAdded] [bit] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_OrderNote] (
	[noteID] [int] IDENTITY (1, 1) NOT NULL,
	[orderID] [int] NOT NULL,
	[note] [nvarchar] (1500) NOT NULL,
	[orderStatus] [nvarchar] (50) NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_OrderStatus] (
	[OrderStatusID] [int] NOT NULL,
	[OrderStatus] [nvarchar] (50) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Product] (
	[productID] [int] IDENTITY (1, 1) NOT NULL,
	[sku] [nvarchar] (50) NULL,
	[productGUID] [uniqueidentifier] NOT NULL,
	[productName] [nvarchar] (150) NOT NULL,
	[shortDescription] [nvarchar] (1000) NULL,
	[manufacturerID] [int] NOT NULL,
	[attributeXML] [ntext] NULL,
	[statusID] [int] NOT NULL,
	[productTypeID] [int] NOT NULL,
	[shippingTypeID] [int] NOT NULL,
	[shipEstimateID] [int] NOT NULL,
	[taxTypeID] [int] NOT NULL,
	[stockLocation] [nvarchar] (150) NULL,
	[ourPrice] [money] NOT NULL,
	[retailPrice] [money] NOT NULL,
	[weight] [numeric](19, 4) NOT NULL,
	[currencyCode] [char] (3) NOT NULL,
	[unitOfMeasure] [nvarchar] (50) NULL,
	[adminComments] [nvarchar] (1000) NULL,
	[length] [numeric](18, 0) NOT NULL,
	[height] [numeric](18, 0) NOT NULL,
	[width] [numeric](18, 0) NOT NULL,
	[dimensionUnit] [varchar] (20) NOT NULL,
	[isDeleted] [bit] NOT NULL,
	[listOrder] [int] NOT NULL,
	[ratingSum] [int] NOT NULL,
	[totalRatingVotes] [int] NOT NULL,
	[defaultImage] [nvarchar] (500) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ProductDescriptor] (
	[descriptorID] [int] IDENTITY (1, 1) NOT NULL,
	[productID] [int] NOT NULL,
	[title] [nvarchar] (100) NOT NULL,
	[descriptor] [nvarchar] (2500) NOT NULL,
	[isBulletedList] [bit] NOT NULL,
	[listOrder] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ProductRating] (
	[ratingID] [int] IDENTITY (1, 1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[UserName] [nvarchar] (256) NOT NULL,
	[Rating] [int] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ProductReview] (
	[ReviewID] [int] IDENTITY (1, 1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Title] [nvarchar] (100) NOT NULL,
	[Body] [ntext] NOT NULL,
	[PostDate] [datetime] NOT NULL,
	[AuthorName] [nvarchar] (256) NOT NULL,
	[Rating] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ProductReviewFeedback] (
	[feedbackID] [int] IDENTITY (1, 1) NOT NULL,
	[ReviewID] [int] NOT NULL,
	[UserName] [nvarchar] (256) NOT NULL,
	[IsHelpful] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ProductStatus] (
	[statusID] [int] IDENTITY (1, 1) NOT NULL,
	[status] [nvarchar] (50) NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ProductType] (
	[productTypeID] [int] IDENTITY (1, 1) NOT NULL,
	[productType] [nvarchar] (50) NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Product_Category_Map] (
	[productID] [int] NOT NULL,
	[categoryID] [int] NOT NULL,
	[listOrder] [int] NOT NULL,
	[isFeatured] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ShippingEstimate] (
	[shipEstimateID] [int] IDENTITY (1, 1) NOT NULL,
	[shippingEstimate] [nvarchar] (150) NOT NULL,
	[leadTimeDays] [int] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_ShippingType] (
	[shippingTypeID] [int] IDENTITY (1, 1) NOT NULL,
	[shippingType] [nvarchar] (50) NOT NULL,
	[shippingCode] [nvarchar] (10) NULL,
	[isDownloadable] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_Transaction] (
	[transactionID] [int] IDENTITY (1, 1) NOT NULL,
	[orderID] [int] NOT NULL,
	[authorizationCode] [nvarchar] (50) NULL,
	[transactionDate] [datetime] NOT NULL,
	[transactionTypeID] [int] NOT NULL,
	[amount] [money] NOT NULL,
	[transactionNotes] [nvarchar] (500) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Store_TransactionType] (
	[transactionTypeID] [int] IDENTITY (1, 1) NOT NULL,
	[transactionType] [nvarchar] (50) NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Tax_Rate] (
	[rateID] [int] IDENTITY (1, 1) NOT NULL,
	[rate] [money] NOT NULL,
	[state] [varchar] (50) NOT NULL,
	[zipCode] [varchar] (50) NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Tax_Type] (
	[taxTypeID] [int] IDENTITY (1, 1) NOT NULL,
	[taxType] [nvarchar] (50) NOT NULL,
	[taxCode] [nvarchar] (10) NULL,
	[isExempt] [bit] NOT NULL,
	[createdOn] [datetime] NULL,
	[createdBy] [nvarchar] (50) NULL,
	[modifiedOn] [datetime] NULL,
	[modifiedBy] [nvarchar] (50) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Util_Country] (
	[countryID] [int] IDENTITY (1, 1) NOT NULL,
	[code] [char] (2) NOT NULL,
	[country] [nvarchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Util_Currency] (
	[codeID] [int] IDENTITY (1, 1) NOT NULL,
	[code] [char] (3) NOT NULL,
	[description] [nvarchar] (255) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CSK_Util_ZipCode] (
	[zipCodeID] [int] IDENTITY (1, 1) NOT NULL,
	[stateAbbreviation] [nvarchar] (2) NULL,
	[zipCode] [nvarchar] (12) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Category] (
	[CategoryID] [int] IDENTITY (1, 1) NOT NULL,
	[CategoryName] [nvarchar] (64) NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[CategoryLog] (
	[CategoryLogID] [int] IDENTITY (1, 1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[LogID] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Log] (
	[LogID] [int] IDENTITY (1, 1) NOT NULL,
	[EventID] [int] NULL,
	[Priority] [int] NOT NULL,
	[Severity] [nvarchar] (32) NOT NULL,
	[Title] [nvarchar] (256) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[MachineName] [nvarchar] (32) NOT NULL,
	[AppDomainName] [nvarchar] (512) NOT NULL,
	[ProcessID] [nvarchar] (256) NOT NULL,
	[ProcessName] [nvarchar] (512) NOT NULL,
	[ThreadName] [nvarchar] (512) NULL,
	[Win32ThreadId] [nvarchar] (128) NULL,
	[Message] [nvarchar] (1500) NULL,
	[FormattedMessage] [ntext] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[CSK_Content_Group] WITH NOCHECK ADD 
	CONSTRAINT [PK_PPSD_ContentGroups] PRIMARY KEY  CLUSTERED 
	(
		[groupID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Content_Text] WITH NOCHECK ADD 
	CONSTRAINT [PK_CONTENT_Text] PRIMARY KEY  CLUSTERED 
	(
		[contentID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_CouponTypes] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_CouponTypes] PRIMARY KEY  CLUSTERED 
	(
		[CouponTypeId]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Coupons] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Coupons] PRIMARY KEY  CLUSTERED 
	(
		[CouponCode]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Messaging_Mailer] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Mailers] PRIMARY KEY  CLUSTERED 
	(
		[mailerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Promo] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_PROMO_Rules] PRIMARY KEY  CLUSTERED 
	(
		[promoID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Promo_Bundle] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Bundles] PRIMARY KEY  CLUSTERED 
	(
		[bundleID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Promo_Campaign] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_PROMO_Campaigns] PRIMARY KEY  CLUSTERED 
	(
		[campaignID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Promo_Product_Bundle_Map] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Store_Product_Bundle_Map] PRIMARY KEY  CLUSTERED 
	(
		[productID],
		[bundleID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Promo_Product_CrossSell_Map] PRIMARY KEY  CLUSTERED 
	(
		[productID],
		[crossProductID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Products_Promos] PRIMARY KEY  CLUSTERED 
	(
		[productID],
		[promoID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Shipping_Rate] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ShippingRates] PRIMARY KEY  CLUSTERED 
	(
		[shippingRateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Stats_Behavior] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_STATS_Behavior] PRIMARY KEY  CLUSTERED 
	(
		[behaviorID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Stats_Tracker] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_STATS_Tracker] PRIMARY KEY  CLUSTERED 
	(
		[trackingID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Ad] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Ads] PRIMARY KEY  CLUSTERED 
	(
		[adID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Ad_Text] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Store_Ad_Text] PRIMARY KEY  CLUSTERED 
	(
		[adTextID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Address] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_AddressBook] PRIMARY KEY  CLUSTERED 
	(
		[addressID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Attribute] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductAttributes] PRIMARY KEY  CLUSTERED 
	(
		[productAttributeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_AttributeTemplate] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductAttributeTemplates] PRIMARY KEY  CLUSTERED 
	(
		[templateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_AttributeType] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductAttributeTypes] PRIMARY KEY  CLUSTERED 
	(
		[attributeTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Category] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductCategories] PRIMARY KEY  CLUSTERED 
	(
		[categoryID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Image] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductImages] PRIMARY KEY  CLUSTERED 
	(
		[imageID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Manufacturer] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Manufacturers] PRIMARY KEY  CLUSTERED 
	(
		[manufacturerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Order] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Store_Order] PRIMARY KEY  CLUSTERED 
	(
		[orderID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_OrderItem] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_OrderItems] PRIMARY KEY  CLUSTERED 
	(
		[orderItemID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_OrderNote] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_OrderNotes] PRIMARY KEY  CLUSTERED 
	(
		[noteID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Product] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Products] PRIMARY KEY  CLUSTERED 
	(
		[productID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ProductDescriptor] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Store_ProductDescriptor] PRIMARY KEY  CLUSTERED 
	(
		[descriptorID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ProductRating] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductRating] PRIMARY KEY  CLUSTERED 
	(
		[ratingID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ProductReview] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Reviews] PRIMARY KEY  CLUSTERED 
	(
		[ReviewID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ProductReviewFeedback] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ReviewHelpfulness] PRIMARY KEY  CLUSTERED 
	(
		[feedbackID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ProductStatus] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductStatus] PRIMARY KEY  CLUSTERED 
	(
		[statusID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ProductType] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ProductType] PRIMARY KEY  CLUSTERED 
	(
		[productTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Products_Categories] PRIMARY KEY  CLUSTERED 
	(
		[productID],
		[categoryID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ShippingEstimate] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ShipEstimates] PRIMARY KEY  CLUSTERED 
	(
		[shipEstimateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_ShippingType] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_ShippingType] PRIMARY KEY  CLUSTERED 
	(
		[shippingTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Transaction] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Store_Transaction] PRIMARY KEY  CLUSTERED 
	(
		[transactionID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_TransactionType] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_OrderTransactionTypes] PRIMARY KEY  CLUSTERED 
	(
		[transactionTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Tax_Rate] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_Taxes] PRIMARY KEY  CLUSTERED 
	(
		[rateID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Tax_Type] WITH NOCHECK ADD 
	CONSTRAINT [PK_CMRC_TaxTypes] PRIMARY KEY  CLUSTERED 
	(
		[taxTypeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Util_Country] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Util_Country] PRIMARY KEY  CLUSTERED 
	(
		[countryID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Util_Currency] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Util_Currency] PRIMARY KEY  CLUSTERED 
	(
		[codeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Util_ZipCode] WITH NOCHECK ADD 
	CONSTRAINT [PK_CSK_Util_ZipCode] PRIMARY KEY  CLUSTERED 
	(
		[zipCodeID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Category] WITH NOCHECK ADD 
	CONSTRAINT [PK_Categories] PRIMARY KEY  CLUSTERED 
	(
		[CategoryID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CategoryLog] WITH NOCHECK ADD 
	CONSTRAINT [PK_CategoryLog] PRIMARY KEY  CLUSTERED 
	(
		[CategoryLogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Log] WITH NOCHECK ADD 
	CONSTRAINT [PK_Log] PRIMARY KEY  CLUSTERED 
	(
		[LogID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Content_Group] ADD 
	CONSTRAINT [DF_CSK_Content_Group_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Content_Group_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Content_Text] ADD 
	CONSTRAINT [DF_CONTENT_Text_contentGUID] DEFAULT (newid()) FOR [contentGUID],
	CONSTRAINT [DF_PPSD_Content_contentGroupID] DEFAULT (0) FOR [contentGroupID],
	CONSTRAINT [DF_CONTENT_Text_listOrder] DEFAULT (1) FOR [listOrder],
	CONSTRAINT [DF_CSK_Content_Text_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Content_Text_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_CouponTypes] ADD 
	CONSTRAINT [DF_CSK_CouponTypes_IsAspClass] DEFAULT (0) FOR [IsAspClass]
GO

ALTER TABLE [dbo].[CSK_Coupons] ADD 
	CONSTRAINT [DF_CMRC_Coupons_NumberUses] DEFAULT (0) FOR [NumberUses]
GO

ALTER TABLE [dbo].[CSK_Messaging_Mailer] ADD 
	CONSTRAINT [DF_CMRC_Mailers_isHTML] DEFAULT (0) FOR [isHTML],
  CONSTRAINT [DF_CSK_Messaging_Mailer_isSystemMailer]  DEFAULT (0) FOR [isSystemMailer],
	CONSTRAINT [DF_CSK_Messaging_Mailer_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Messaging_Mailer_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Promo] ADD 
	CONSTRAINT [DF_CMRC_PROMOS_amountOff_1] DEFAULT (0) FOR [discount],
	CONSTRAINT [DF_CMRC_PROMOS_qtyThreshold_1] DEFAULT (0) FOR [qtyThreshold],
	CONSTRAINT [DF_CMRC_PROMOS_Rules_inventoryGoal] DEFAULT (0) FOR [inventoryGoal],
	CONSTRAINT [DF_CMRC_PROMOS_Rules_revenueGoal] DEFAULT (0) FOR [revenueGoal],
	CONSTRAINT [DF_CMRC_PROMOS_Rules_isActive] DEFAULT (1) FOR [isActive],
	CONSTRAINT [DF_CSK_Promo_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Promo_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Promo_Bundle] ADD 
	CONSTRAINT [DF_CMRC_Bundles_bundleName] DEFAULT (0) FOR [bundleName],
	CONSTRAINT [DF_CMRC_Bundles_discountPercent] DEFAULT (0) FOR [discountPercent],
	CONSTRAINT [DF_CSK_Promo_Bundle_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Promo_Bundle_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Promo_Campaign] ADD 
	CONSTRAINT [DF_CMRC_PROMO_Campaigns_revenueGoal] DEFAULT (0) FOR [revenueGoal],
	CONSTRAINT [DF_CMRC_PROMO_Campaigns_inventoryGoal] DEFAULT (0) FOR [inventoryGoal],
	CONSTRAINT [DF_CMRC_PROMO_Campaigns_isActive] DEFAULT (1) FOR [isActive],
	CONSTRAINT [DF_CSK_Promo_Campaign_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Promo_Campaign_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] ADD 
	CONSTRAINT [DF_CSK_Promo_Product_Promo_Map_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Promo_Product_Promo_Map_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Shipping_Rate] ADD 
	CONSTRAINT [DF_CSK_Shipping_Rate_IsAirOnly] DEFAULT (0) FOR [isAirOnly],
	CONSTRAINT [DF_CSK_Shipping_Rate_isGroundOnly] DEFAULT (0) FOR [isGroundOnly],
	CONSTRAINT [DF_CSK_Shipping_Rate_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Shipping_Rate_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Stats_Behavior] ADD 
	CONSTRAINT [DF_CSK_Stats_Behavior_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Stats_Behavior_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Stats_Tracker] ADD 
	CONSTRAINT [DF_CSK_Stats_Tracker_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Stats_Tracker_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Ad] ADD 
	CONSTRAINT [DF_CMRC_Ads_listOrder] DEFAULT (1) FOR [listOrder],
	CONSTRAINT [DF_CMRC_Ads_productID] DEFAULT ('') FOR [productSku],
	CONSTRAINT [DF_CMRC_Ads_promoID] DEFAULT (0) FOR [promoID],
	CONSTRAINT [DF_CMRC_Ads_categoryID] DEFAULT (0) FOR [categoryID],
	CONSTRAINT [DF_CMRC_Ads_isActive] DEFAULT (1) FOR [isActive],
	CONSTRAINT [DF_CMRC_Ads_isDeleted] DEFAULT (0) FOR [isDeleted],
	CONSTRAINT [DF_CSK_Store_Ad_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Ad_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Ad_Text] ADD 
	CONSTRAINT [DF_CSK_Store_Ad_Text_language] DEFAULT (N'en-US') FOR [language]
GO

ALTER TABLE [dbo].[CSK_Store_Address] ADD 
	CONSTRAINT [DF_CSK_Address_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Address_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Attribute] ADD 
	CONSTRAINT [DF_CMRC_ProductAttributes_attributeTypeID] DEFAULT (1) FOR [attributeTypeID],
	CONSTRAINT [DF_CMRC_ProductAttributes_priceAdjustment] DEFAULT (0) FOR [priceAdjustment],
	CONSTRAINT [DF_CSK_Store_Attribute_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Attribute_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_AttributeTemplate] ADD 
	CONSTRAINT [DF_CMRC_ProductAttributeTemplates_attributeTypeID] DEFAULT (1) FOR [attributeTypeID],
	CONSTRAINT [DF_CSK_Store_AttributeTemplate_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_AttributeTemplate_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_AttributeType] ADD 
	CONSTRAINT [DF_CSK_Store_AttributeType_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_AttributeType_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Category] ADD 
	CONSTRAINT [DF_CSK_Store_Category_categoryGUID] DEFAULT (newid()) FOR [categoryGUID],
	CONSTRAINT [DF_CMRC_ProductCategories_parentID] DEFAULT (0) FOR [parentID],
	CONSTRAINT [DF_CMRC_ProductCategories_listOrder] DEFAULT (1) FOR [listOrder],
	CONSTRAINT [DF_CSK_Store_Category_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Category_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Image] ADD 
	CONSTRAINT [DF_CMRC_ProductImages_isDefault] DEFAULT (0) FOR [listOrder],
	CONSTRAINT [DF_CSK_Store_Image_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Image_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Manufacturer] ADD 
	CONSTRAINT [DF_CSK_Store_Manufacturer_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Manufacturer_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Order] ADD 
	CONSTRAINT [DF_CSK_Store_Order_orderGuid] DEFAULT (newid()) FOR [orderGUID],
	CONSTRAINT [DF_CMRC_Orders_OrderDate_1] DEFAULT (getdate()) FOR [orderDate],
	CONSTRAINT [DF_CMRC_Orders_OrderStatusID] DEFAULT (0) FOR [orderStatusID],
	CONSTRAINT [DF_CMRC_Orders_OrderSubTotal] DEFAULT (0) FOR [subTotalAmount],
	CONSTRAINT [DF_CMRC_Orders_Shipping_1] DEFAULT (0) FOR [shippingAmount],
	CONSTRAINT [DF_CMRC_Orders_HandlingAmount] DEFAULT (0) FOR [handlingAmount],
	CONSTRAINT [DF_CMRC_Orders_Tax_1] DEFAULT (0) FOR [taxAmount],
	CONSTRAINT [DF_CMRC_Orders_taxRate] DEFAULT (0) FOR [taxRate],
	CONSTRAINT [DF_CMRC_Orders_discountAmount] DEFAULT (0) FOR [discountAmount],
	CONSTRAINT [DF_CSK_Store_Order_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Order_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_OrderItem] ADD 
	CONSTRAINT [DF_CSK_Store_OrderItem_isShipped] DEFAULT (0) FOR [isShipped],
	CONSTRAINT [DF_CSK_Store_OrderItem_rating] DEFAULT (4) FOR [rating],
	CONSTRAINT [DF_CSK_Store_OrderItem_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_OrderItem_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn],
	CONSTRAINT [DF_CSK_Store_OrderItem_isLastAdded] DEFAULT (0) FOR [isLastAdded]
GO

ALTER TABLE [dbo].[CSK_Store_OrderNote] ADD 
	CONSTRAINT [DF_CSK_Store_OrderNote_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_OrderNote_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_OrderStatus] ADD 
	CONSTRAINT [DF_CSK_Store_OrderStatus_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_OrderStatus_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn],
	CONSTRAINT [aaaaaCMRC_OrderStatus_PK] PRIMARY KEY  NONCLUSTERED 
	(
		[OrderStatusID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[CSK_Store_Product] ADD 
	CONSTRAINT [DF_CSK_Store_Product_productGUID] DEFAULT (newid()) FOR [productGUID],
	CONSTRAINT [DF_CMRC_Products_manufacturerID] DEFAULT (1) FOR [manufacturerID],
	CONSTRAINT [DF_CMRC_Products_statusID] DEFAULT (1) FOR [statusID],
	CONSTRAINT [DF_CMRC_Products_productTypeID] DEFAULT (1) FOR [productTypeID],
	CONSTRAINT [DF_CMRC_Products_shippingTypeID] DEFAULT (1) FOR [shippingTypeID],
	CONSTRAINT [DF_CMRC_Products_shipTimeID] DEFAULT (1) FOR [shipEstimateID],
	CONSTRAINT [DF_CMRC_Products_taxTypeID] DEFAULT (1) FOR [taxTypeID],
	CONSTRAINT [DF_CMRC_Products_weight] DEFAULT (0) FOR [weight],
	CONSTRAINT [DF_CMRC_Products_currencyCode] DEFAULT ('USD') FOR [currencyCode],
	CONSTRAINT [DF_CMRC_Products_length] DEFAULT (0) FOR [length],
	CONSTRAINT [DF_CMRC_Products_height] DEFAULT (0) FOR [height],
	CONSTRAINT [DF_CMRC_Products_width] DEFAULT (0) FOR [width],
	CONSTRAINT [DF_CMRC_Products_dimensionUnit] DEFAULT ('inches') FOR [dimensionUnit],
	CONSTRAINT [DF_CMRC_Products_isDeleted] DEFAULT (0) FOR [isDeleted],
	CONSTRAINT [DF_CMRC_Products_listOrder] DEFAULT (1) FOR [listOrder],
	CONSTRAINT [DF_CMRC_Products_RatingSum] DEFAULT (4) FOR [ratingSum],
	CONSTRAINT [DF_CMRC_Products_totalRatingSum] DEFAULT (1) FOR [totalRatingVotes],
	CONSTRAINT [DF_CSK_Store_Product_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Product_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ProductDescriptor] ADD 
	CONSTRAINT [DF_CSK_Store_ProductDescriptor_isBulletedList] DEFAULT (0) FOR [isBulletedList],
	CONSTRAINT [DF_CSK_Store_ProductDescriptor_listOrder] DEFAULT (1) FOR [listOrder]
GO

ALTER TABLE [dbo].[CSK_Store_ProductRating] ADD 
	CONSTRAINT [DF_CSK_Store_Rating_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Rating_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ProductReview] ADD 
	CONSTRAINT [DF_CMRC_Reviews_Title] DEFAULT ('') FOR [Title],
	CONSTRAINT [DF_CMRC_Reviews_Body] DEFAULT ('') FOR [Body],
	CONSTRAINT [DF_CMRC_Reviews_PostDate] DEFAULT (getdate()) FOR [PostDate],
	CONSTRAINT [DF_CMRC_Reviews_AuthorName] DEFAULT ('') FOR [AuthorName],
	CONSTRAINT [DF_CMRC_ProductReviews_Rating] DEFAULT (0) FOR [Rating],
	CONSTRAINT [DF_CMRC_Reviews_IsApproved] DEFAULT (0) FOR [IsApproved],
	CONSTRAINT [DF_CSK_Store_Review_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Review_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ProductReviewFeedback] ADD 
	CONSTRAINT [DF_CMRC_ProductReviewFeedback_UserName] DEFAULT ('') FOR [UserName],
	CONSTRAINT [DF_CMRC_ReviewHelpfulness_Helpful] DEFAULT (0) FOR [IsHelpful],
	CONSTRAINT [DF_CSK_Store_ReviewFeedback_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_ReviewFeedback_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ProductStatus] ADD 
	CONSTRAINT [DF_CSK_Store_ProductStatus_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_ProductStatus_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ProductType] ADD 
	CONSTRAINT [DF_CSK_Store_ProductType_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_ProductType_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] ADD 
	CONSTRAINT [DF_CMRC_Products_Categories_listOrder] DEFAULT (1) FOR [listOrder],
	CONSTRAINT [DF_CMRC_Products_Categories_isFeatured] DEFAULT (0) FOR [isFeatured],
	CONSTRAINT [DF_CSK_Store_Product_Category_Map_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Product_Category_Map_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ShippingEstimate] ADD 
	CONSTRAINT [DF_CMRC_ShipEstimates_leadTimeDays] DEFAULT (1) FOR [leadTimeDays],
	CONSTRAINT [DF_CSK_Store_ShippingEstimate_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_ShippingEstimate_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_ShippingType] ADD 
	CONSTRAINT [DF_CMRC_ShippingType_isDownloadable] DEFAULT (0) FOR [isDownloadable],
	CONSTRAINT [DF_CSK_Store_ShippingType_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_ShippingType_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_Transaction] ADD 
	CONSTRAINT [DF_CMRC_OrderTransactions_transactionDate] DEFAULT (getdate()) FOR [transactionDate],
	CONSTRAINT [DF_CMRC_OrderTransactions_transationTypeID] DEFAULT (1) FOR [transactionTypeID],
	CONSTRAINT [DF_CMRC_OrderTransactions_amount] DEFAULT (0) FOR [amount],
	CONSTRAINT [DF_CSK_Store_Transaction_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_Transaction_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Store_TransactionType] ADD 
	CONSTRAINT [DF_CSK_Store_TransactionType_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Store_TransactionType_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Tax_Rate] ADD 
	CONSTRAINT [DF_CSK_Tax_Rate_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Tax_Rate_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Tax_Type] ADD 
	CONSTRAINT [DF_CMRC_TaxTypes_isExempt] DEFAULT (0) FOR [isExempt],
	CONSTRAINT [DF_CSK_Tax_Type_createdOn] DEFAULT (getdate()) FOR [createdOn],
	CONSTRAINT [DF_CSK_Tax_Type_modifiedOn] DEFAULT (getdate()) FOR [modifiedOn]
GO

ALTER TABLE [dbo].[CSK_Promo] ADD 
	CONSTRAINT [FK_CMRC_PROMOS_CMRC_PROMO_Campaigns] FOREIGN KEY 
	(
		[campaignID]
	) REFERENCES [dbo].[CSK_Promo_Campaign] (
		[campaignID]
	)
GO

ALTER TABLE [dbo].[CSK_Promo_Product_Bundle_Map] ADD 
	CONSTRAINT [FK_CMRC_Products_Bundles_CMRC_Bundles] FOREIGN KEY 
	(
		[bundleID]
	) REFERENCES [dbo].[CSK_Promo_Bundle] (
		[bundleID]
	),
	CONSTRAINT [FK_CMRC_Products_Bundles_CMRC_Products] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	)
GO

ALTER TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] ADD 
	CONSTRAINT [FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	),
	CONSTRAINT [FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product1] FOREIGN KEY 
	(
		[crossProductID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	)
GO

ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] ADD 
	CONSTRAINT [FK_CMRC_Products_Promos_CMRC_Products] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	),
	CONSTRAINT [FK_CMRC_Products_Promos_CMRC_PROMOS] FOREIGN KEY 
	(
		[promoID]
	) REFERENCES [dbo].[CSK_Promo] (
		[promoID]
	)
GO

ALTER TABLE [dbo].[CSK_Stats_Tracker] ADD 
	CONSTRAINT [FK_CMRC_STATS_Tracker_CMRC_STATS_Behavior] FOREIGN KEY 
	(
		[behaviorID]
	) REFERENCES [dbo].[CSK_Stats_Behavior] (
		[behaviorID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_Attribute] ADD 
	CONSTRAINT [FK_CMRC_ProductAttributes_CMRC_ProductAttributeTypes] FOREIGN KEY 
	(
		[attributeTypeID]
	) REFERENCES [dbo].[CSK_Store_AttributeType] (
		[attributeTypeID]
	),
	CONSTRAINT [FK_CMRC_ProductAttributes_CMRC_Products] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_Image] ADD 
	CONSTRAINT [FK_CMRC_ProductImages_CMRC_Products] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_OrderItem] ADD 
	CONSTRAINT [FK_CSK_Store_OrderItem_CSK_Store_Order] FOREIGN KEY 
	(
		[orderID]
	) REFERENCES [dbo].[CSK_Store_Order] (
		[orderID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_OrderNote] ADD 
	CONSTRAINT [FK_CSK_Store_OrderNote_CSK_Store_Order] FOREIGN KEY 
	(
		[orderID]
	) REFERENCES [dbo].[CSK_Store_Order] (
		[orderID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_Product] ADD 
	CONSTRAINT [FK_CMRC_Products_CMRC_Manufacturers] FOREIGN KEY 
	(
		[manufacturerID]
	) REFERENCES [dbo].[CSK_Store_Manufacturer] (
		[manufacturerID]
	),
	CONSTRAINT [FK_CMRC_Products_CMRC_ProductStatus] FOREIGN KEY 
	(
		[statusID]
	) REFERENCES [dbo].[CSK_Store_ProductStatus] (
		[statusID]
	),
	CONSTRAINT [FK_CMRC_Products_CMRC_ProductType] FOREIGN KEY 
	(
		[productTypeID]
	) REFERENCES [dbo].[CSK_Store_ProductType] (
		[productTypeID]
	),
	CONSTRAINT [FK_CMRC_Products_CMRC_ShipEstimates] FOREIGN KEY 
	(
		[shipEstimateID]
	) REFERENCES [dbo].[CSK_Store_ShippingEstimate] (
		[shipEstimateID]
	),
	CONSTRAINT [FK_CMRC_Products_CMRC_ShippingType] FOREIGN KEY 
	(
		[shippingTypeID]
	) REFERENCES [dbo].[CSK_Store_ShippingType] (
		[shippingTypeID]
	),
	CONSTRAINT [FK_CMRC_Products_CMRC_TaxTypes] FOREIGN KEY 
	(
		[taxTypeID]
	) REFERENCES [dbo].[CSK_Tax_Type] (
		[taxTypeID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_ProductDescriptor] ADD 
	CONSTRAINT [FK_CSK_Store_ProductDescriptor_CSK_Store_Product] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] ADD 
	CONSTRAINT [FK_CMRC_Products_Categories_CMRC_ProductCategories] FOREIGN KEY 
	(
		[categoryID]
	) REFERENCES [dbo].[CSK_Store_Category] (
		[categoryID]
	),
	CONSTRAINT [FK_CMRC_Products_Categories_CMRC_Products] FOREIGN KEY 
	(
		[productID]
	) REFERENCES [dbo].[CSK_Store_Product] (
		[productID]
	)
GO

ALTER TABLE [dbo].[CSK_Store_Transaction] ADD 
	CONSTRAINT [FK_CMRC_OrderTransactions_CMRC_OrderTransactionTypes] FOREIGN KEY 
	(
		[transactionTypeID]
	) REFERENCES [dbo].[CSK_Store_TransactionType] (
		[transactionTypeID]
	),
	CONSTRAINT [FK_CSK_Store_Transaction_CSK_Store_Order] FOREIGN KEY 
	(
		[orderID]
	) REFERENCES [dbo].[CSK_Store_Order] (
		[orderID]
	)
GO

ALTER TABLE [dbo].[CategoryLog] ADD 
	CONSTRAINT [FK_CategoryLog_Category] FOREIGN KEY 
	(
		[CategoryID]
	) REFERENCES [dbo].[Category] (
		[CategoryID]
	),
	CONSTRAINT [FK_CategoryLog_Log] FOREIGN KEY 
	(
		[LogID]
	) REFERENCES [dbo].[Log] (
		[LogID]
	)
GO

