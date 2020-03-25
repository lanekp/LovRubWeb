/****** Object:  ForeignKey [FK_aspnet_Membership_aspnet_Applications]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Membership_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK_aspnet_Membership_aspnet_Applications]
GO
/****** Object:  ForeignKey [FK_aspnet_Membership_aspnet_Users]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Membership_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]'))
ALTER TABLE [dbo].[aspnet_Membership] DROP CONSTRAINT [FK_aspnet_Membership_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_aspnet_Paths_aspnet_Applications]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Paths_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]'))
ALTER TABLE [dbo].[aspnet_Paths] DROP CONSTRAINT [FK_aspnet_Paths_aspnet_Applications]
GO
/****** Object:  ForeignKey [FK_aspnet_PersonalizationAllUsers_aspnet_Paths]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_PersonalizationAllUsers_aspnet_Paths]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]'))
ALTER TABLE [dbo].[aspnet_PersonalizationAllUsers] DROP CONSTRAINT [FK_aspnet_PersonalizationAllUsers_aspnet_Paths]
GO
/****** Object:  ForeignKey [FK_aspnet_PersonalizationPerUser_aspnet_Paths]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_PersonalizationPerUser_aspnet_Paths]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK_aspnet_PersonalizationPerUser_aspnet_Paths]
GO
/****** Object:  ForeignKey [FK_aspnet_PersonalizationPerUser_aspnet_Users]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_PersonalizationPerUser_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]'))
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] DROP CONSTRAINT [FK_aspnet_PersonalizationPerUser_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_aspnet_Profile_aspnet_Users]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Profile_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]'))
ALTER TABLE [dbo].[aspnet_Profile] DROP CONSTRAINT [FK_aspnet_Profile_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_aspnet_Roles_aspnet_Applications]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Roles_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]'))
ALTER TABLE [dbo].[aspnet_Roles] DROP CONSTRAINT [FK_aspnet_Roles_aspnet_Applications]
GO
/****** Object:  ForeignKey [FK_aspnet_Users_aspnet_Applications]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_Users_aspnet_Applications]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_Users]'))
ALTER TABLE [dbo].[aspnet_Users] DROP CONSTRAINT [FK_aspnet_Users_aspnet_Applications]
GO
/****** Object:  ForeignKey [FK_aspnet_UsersInRoles_aspnet_Roles]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_UsersInRoles_aspnet_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Roles]
GO
/****** Object:  ForeignKey [FK_aspnet_UsersInRoles_aspnet_Users]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_aspnet_UsersInRoles_aspnet_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]'))
ALTER TABLE [dbo].[aspnet_UsersInRoles] DROP CONSTRAINT [FK_aspnet_UsersInRoles_aspnet_Users]
GO
/****** Object:  ForeignKey [FK_CategoryLog_Category]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoryLog_Category]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoryLog]'))
ALTER TABLE [dbo].[CategoryLog] DROP CONSTRAINT [FK_CategoryLog_Category]
GO
/****** Object:  ForeignKey [FK_CategoryLog_Log]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CategoryLog_Log]') AND parent_object_id = OBJECT_ID(N'[dbo].[CategoryLog]'))
ALTER TABLE [dbo].[CategoryLog] DROP CONSTRAINT [FK_CategoryLog_Log]
GO
/****** Object:  ForeignKey [FK_CMRC_PROMOS_CMRC_PROMO_Campaigns]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_PROMOS_CMRC_PROMO_Campaigns]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo]'))
ALTER TABLE [dbo].[CSK_Promo] DROP CONSTRAINT [FK_CMRC_PROMOS_CMRC_PROMO_Campaigns]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_Bundles_CMRC_Bundles]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_Bundles_CMRC_Bundles]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_Bundle_Map]'))
ALTER TABLE [dbo].[CSK_Promo_Product_Bundle_Map] DROP CONSTRAINT [FK_CMRC_Products_Bundles_CMRC_Bundles]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_Bundles_CMRC_Products]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_Bundles_CMRC_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_Bundle_Map]'))
ALTER TABLE [dbo].[CSK_Promo_Product_Bundle_Map] DROP CONSTRAINT [FK_CMRC_Products_Bundles_CMRC_Products]
GO
/****** Object:  ForeignKey [FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_CrossSell_Map]'))
ALTER TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] DROP CONSTRAINT [FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product]
GO
/****** Object:  ForeignKey [FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product1]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product1]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_CrossSell_Map]'))
ALTER TABLE [dbo].[CSK_Promo_Product_CrossSell_Map] DROP CONSTRAINT [FK_CSK_Promo_Product_CrossSell_Map_CSK_Store_Product1]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_Promos_CMRC_Products]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_Promos_CMRC_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_Promo_Map]'))
ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] DROP CONSTRAINT [FK_CMRC_Products_Promos_CMRC_Products]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_Promos_CMRC_PROMOS]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_Promos_CMRC_PROMOS]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_Promo_Map]'))
ALTER TABLE [dbo].[CSK_Promo_Product_Promo_Map] DROP CONSTRAINT [FK_CMRC_Products_Promos_CMRC_PROMOS]
GO
/****** Object:  ForeignKey [FK_CMRC_STATS_Tracker_CMRC_STATS_Behavior]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_STATS_Tracker_CMRC_STATS_Behavior]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Stats_Tracker]'))
ALTER TABLE [dbo].[CSK_Stats_Tracker] DROP CONSTRAINT [FK_CMRC_STATS_Tracker_CMRC_STATS_Behavior]
GO
/****** Object:  ForeignKey [FK_CMRC_ProductAttributes_CMRC_ProductAttributeTypes]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_ProductAttributes_CMRC_ProductAttributeTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Attribute]'))
ALTER TABLE [dbo].[CSK_Store_Attribute] DROP CONSTRAINT [FK_CMRC_ProductAttributes_CMRC_ProductAttributeTypes]
GO
/****** Object:  ForeignKey [FK_CMRC_ProductAttributes_CMRC_Products]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_ProductAttributes_CMRC_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Attribute]'))
ALTER TABLE [dbo].[CSK_Store_Attribute] DROP CONSTRAINT [FK_CMRC_ProductAttributes_CMRC_Products]
GO
/****** Object:  ForeignKey [FK_CMRC_ProductImages_CMRC_Products]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_ProductImages_CMRC_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Image]'))
ALTER TABLE [dbo].[CSK_Store_Image] DROP CONSTRAINT [FK_CMRC_ProductImages_CMRC_Products]
GO
/****** Object:  ForeignKey [FK_CSK_Store_OrderItem_CSK_Store_Order]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CSK_Store_OrderItem_CSK_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_OrderItem]'))
ALTER TABLE [dbo].[CSK_Store_OrderItem] DROP CONSTRAINT [FK_CSK_Store_OrderItem_CSK_Store_Order]
GO
/****** Object:  ForeignKey [FK_CSK_Store_OrderNote_CSK_Store_Order]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CSK_Store_OrderNote_CSK_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_OrderNote]'))
ALTER TABLE [dbo].[CSK_Store_OrderNote] DROP CONSTRAINT [FK_CSK_Store_OrderNote_CSK_Store_Order]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_CMRC_Manufacturers]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_CMRC_Manufacturers]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]'))
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT [FK_CMRC_Products_CMRC_Manufacturers]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_CMRC_ProductStatus]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_CMRC_ProductStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]'))
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT [FK_CMRC_Products_CMRC_ProductStatus]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_CMRC_ProductType]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_CMRC_ProductType]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]'))
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT [FK_CMRC_Products_CMRC_ProductType]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_CMRC_ShipEstimates]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_CMRC_ShipEstimates]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]'))
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT [FK_CMRC_Products_CMRC_ShipEstimates]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_CMRC_ShippingType]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_CMRC_ShippingType]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]'))
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT [FK_CMRC_Products_CMRC_ShippingType]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_CMRC_TaxTypes]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_CMRC_TaxTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]'))
ALTER TABLE [dbo].[CSK_Store_Product] DROP CONSTRAINT [FK_CMRC_Products_CMRC_TaxTypes]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_Categories_CMRC_ProductCategories]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_Categories_CMRC_ProductCategories]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_Category_Map]'))
ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] DROP CONSTRAINT [FK_CMRC_Products_Categories_CMRC_ProductCategories]
GO
/****** Object:  ForeignKey [FK_CMRC_Products_Categories_CMRC_Products]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_Products_Categories_CMRC_Products]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_Category_Map]'))
ALTER TABLE [dbo].[CSK_Store_Product_Category_Map] DROP CONSTRAINT [FK_CMRC_Products_Categories_CMRC_Products]
GO
/****** Object:  ForeignKey [FK_CSK_Store_ProductDescriptor_CSK_Store_Product]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CSK_Store_ProductDescriptor_CSK_Store_Product]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductDescriptor]'))
ALTER TABLE [dbo].[CSK_Store_ProductDescriptor] DROP CONSTRAINT [FK_CSK_Store_ProductDescriptor_CSK_Store_Product]
GO
/****** Object:  ForeignKey [FK_CMRC_OrderTransactions_CMRC_OrderTransactionTypes]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CMRC_OrderTransactions_CMRC_OrderTransactionTypes]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Transaction]'))
ALTER TABLE [dbo].[CSK_Store_Transaction] DROP CONSTRAINT [FK_CMRC_OrderTransactions_CMRC_OrderTransactionTypes]
GO
/****** Object:  ForeignKey [FK_CSK_Store_Transaction_CSK_Store_Order]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CSK_Store_Transaction_CSK_Store_Order]') AND parent_object_id = OBJECT_ID(N'[dbo].[CSK_Store_Transaction]'))
ALTER TABLE [dbo].[CSK_Store_Transaction] DROP CONSTRAINT [FK_CSK_Store_Transaction_CSK_Store_Order]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_GetCountOfState]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_GetCountOfState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_GetCountOfState]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_ResetSharedState]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_ResetSharedState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetSharedState]
GO
/****** Object:  UserDefinedFunction [dbo].[GetParentCategory]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetParentCategory]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetParentCategory]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_ResetUserState]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_ResetUserState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_ResetUserState]
GO
/****** Object:  UserDefinedFunction [dbo].[GetLastViewedSKUs]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetLastViewedSKUs]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetLastViewedSKUs]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_GetPageSettings]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_ResetPageSettings]
GO
/****** Object:  View [dbo].[vCoupons]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vCoupons]'))
DROP VIEW [dbo].[vCoupons]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_GetPageSettings]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser_GetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationPerUser_GetPageSettings]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_SetPageSettings]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser_SetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationPerUser_SetPageSettings]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Content_Get]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Content_Get]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Content_Get]
GO
/****** Object:  Table [dbo].[CSK_Store_Ad]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Ad]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Ad]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Personalization_GetApplicationId]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Personalization_GetApplicationId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Personalization_GetApplicationId]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Content_Insert]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Content_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Content_Insert]
GO
/****** Object:  Table [dbo].[CSK_Store_Ad_Text]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Ad_Text]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Ad_Text]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteInactiveProfiles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_DeleteInactiveProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_DeleteInactiveProfiles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Content_Save]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Content_Save]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Content_Save]
GO
/****** Object:  Table [dbo].[CSK_Store_Address]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Address]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Address]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_DeleteProfiles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_DeleteProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_DeleteProfiles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Content_Update]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Content_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Content_Update]
GO
/****** Object:  Table [dbo].[CSK_Store_Attribute]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Attribute]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Attribute]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_GetNumberOfInactiveProfiles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Coupons_GetAllCouponTypes]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Coupons_GetAllCouponTypes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Coupons_GetAllCouponTypes]
GO
/****** Object:  Table [dbo].[CSK_Store_AttributeTemplate]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_AttributeTemplate]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_AttributeTemplate]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetProfiles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_GetProfiles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_GetProfiles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Coupons_GetCoupon]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Coupons_GetCoupon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Coupons_GetCoupon]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationPerUser_ResetPageSettings]
GO
/****** Object:  StoredProcedure [dbo].[AddCategory]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddCategory]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AddCategory]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_GetProperties]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_GetProperties]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_GetProperties]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Coupons_GetCouponType]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Coupons_GetCouponType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Coupons_GetCouponType]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAllUsers_SetPageSettings]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Profile_SetProperties]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile_SetProperties]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Profile_SetProperties]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Coupons_SaveCoupon]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Coupons_SaveCoupon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Coupons_SaveCoupon]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_RegisterSchemaVersion]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_RegisterSchemaVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_RegisterSchemaVersion]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Coupons_SaveCouponType]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Coupons_SaveCouponType]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Coupons_SaveCouponType]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_CreateRole]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_CreateRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_CreateRole]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_AddProduct]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_AddProduct]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_AddProduct]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_DeleteRole]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_DeleteRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_DeleteRole]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_Bundle_AddProduct]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Bundle_AddProduct]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_Bundle_AddProduct]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_GetAllRoles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_GetAllRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_GetAllRoles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_Bundle_GetAvailableProducts]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Bundle_GetAvailableProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_Bundle_GetAvailableProducts]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Roles_RoleExists]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles_RoleExists]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Roles_RoleExists]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_Bundle_GetByProductID]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Bundle_GetByProductID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_Bundle_GetByProductID]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RemoveAllRoleMembers]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Setup_RemoveAllRoleMembers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Setup_RemoveAllRoleMembers]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_Bundle_GetSelectedProducts]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Bundle_GetSelectedProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_Bundle_GetSelectedProducts]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Setup_RestorePermissions]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Setup_RestorePermissions]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Setup_RestorePermissions]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_EnsureOrderCoupon]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_EnsureOrderCoupon]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_EnsureOrderCoupon]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_AddUsersToRoles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_AddUsersToRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_AddUsersToRoles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_ProductMatrix]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_ProductMatrix]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_ProductMatrix]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UnRegisterSchemaVersion]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UnRegisterSchemaVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UnRegisterSchemaVersion]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_GetProductList]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_GetProductList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_GetProductList]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_FindUsersInRole]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_FindUsersInRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_FindUsersInRole]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Promo_RemoveProducts]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_RemoveProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Promo_RemoveProducts]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetUsersInRoles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_GetUsersInRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_GetUsersInRoles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Shipping_GetRates_Air]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Shipping_GetRates_Air]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Shipping_GetRates_Air]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_GetRolesForUser]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_GetRolesForUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_GetRolesForUser]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Shipping_GetRates]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Shipping_GetRates]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Shipping_GetRates]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_IsUserInRole]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_IsUserInRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_IsUserInRole]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Shipping_GetRates_Ground]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Shipping_GetRates_Ground]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Shipping_GetRates_Ground]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_UsersInRoles_RemoveUsersFromRoles]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Stats_FavoriteCategories]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_FavoriteCategories]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Stats_FavoriteCategories]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_CreateUser]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users_CreateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Users_CreateUser]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Stats_FavoriteProducts]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_FavoriteProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Stats_FavoriteProducts]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Users_DeleteUser]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users_DeleteUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Users_DeleteUser]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Stats_Tracker_GetByBehaviorID]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_Tracker_GetByBehaviorID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Stats_Tracker_GetByBehaviorID]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_WebEvent_LogEvent]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_LogEvent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_WebEvent_LogEvent]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Stats_Tracker_GetByProductAndBehavior]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_Tracker_GetByProductAndBehavior]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Stats_Tracker_GetByProductAndBehavior]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Stats_Tracker_SynchTrackingCookie]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_Tracker_SynchTrackingCookie]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Stats_Tracker_SynchTrackingCookie]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_AddItemToCart]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_AddItemToCart]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_AddItemToCart]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_CategoryGetActive]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_CategoryGetActive]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_CategoryGetActive]
GO
/****** Object:  Table [dbo].[CSK_Util_Country]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Util_Country]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Util_Country]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Category_GetByProductID]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category_GetByProductID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Category_GetByProductID]
GO
/****** Object:  Table [dbo].[CSK_Util_Currency]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Util_Currency]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Util_Currency]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_GetByCategoryName]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_GetByCategoryName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_GetByCategoryName]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_GetByManufacturerID]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_GetByManufacturerID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_GetByManufacturerID]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_GetByPriceRange]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_GetByPriceRange]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_GetByPriceRange]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_GetMostPopular]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_GetMostPopular]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_GetMostPopular]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_GetPostAddMulti]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_GetPostAddMulti]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_GetPostAddMulti]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_SmartSearch]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_SmartSearch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_SmartSearch]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Tax_CalculateAmountByState]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Tax_CalculateAmountByState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Tax_CalculateAmountByState]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Tax_CalculateAmountByZIP]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Tax_CalculateAmountByZIP]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Tax_CalculateAmountByZIP]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Tax_GetTaxRate]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Tax_GetTaxRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Tax_GetTaxRate]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Tax_SaveZipRate]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Tax_SaveZipRate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Tax_SaveZipRate]
GO
/****** Object:  StoredProcedure [dbo].[ClearLogs]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ClearLogs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ClearLogs]
GO
/****** Object:  StoredProcedure [dbo].[InsertCategoryLog]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCategoryLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertCategoryLog]
GO
/****** Object:  StoredProcedure [dbo].[WriteLog]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WriteLog]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[WriteLog]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Category_GetPageByGUIDMulti]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category_GetPageByGUIDMulti]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Category_GetPageByGUIDMulti]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Category_GetPageMulti]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category_GetPageMulti]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Category_GetPageMulti]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Config_GetList]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Config_GetList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Config_GetList]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Order_Query]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Order_Query]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Order_Query]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_AddRating]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_AddRating]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_AddRating]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_DeletePermanent]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_DeletePermanent]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_DeletePermanent]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Category_GetPageByNameMulti]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category_GetPageByNameMulti]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Category_GetPageByNameMulti]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_CheckSchemaVersion]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_CheckSchemaVersion]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_CheckSchemaVersion]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_ChangePasswordQuestionAndAnswer]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_CreateUser]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_CreateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_CreateUser]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByEmail]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_FindUsersByEmail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_FindUsersByEmail]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_FindUsersByName]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_FindUsersByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_FindUsersByName]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetAllUsers]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetAllUsers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetAllUsers]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetNumberOfUsersOnline]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetNumberOfUsersOnline]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetNumberOfUsersOnline]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPassword]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetPassword]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetPasswordWithFormat]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetPasswordWithFormat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetPasswordWithFormat]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByEmail]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetUserByEmail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetUserByEmail]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByName]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetUserByName]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetUserByName]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_GetUserByUserId]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_GetUserByUserId]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_GetUserByUserId]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_ResetPassword]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_ResetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_ResetPassword]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_SetPassword]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_SetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_SetPassword]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UnlockUser]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_UnlockUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_UnlockUser]
GO
/****** Object:  Table [dbo].[CSK_Content_Group]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Content_Group]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Content_Group]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUser]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_UpdateUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_UpdateUser]
GO
/****** Object:  View [dbo].[vw_aspnet_Applications]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Applications]'))
DROP VIEW [dbo].[vw_aspnet_Applications]
GO
/****** Object:  View [dbo].[vw_aspnet_Roles]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Roles]'))
DROP VIEW [dbo].[vw_aspnet_Roles]
GO
/****** Object:  View [dbo].[vw_aspnet_Users]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Users]'))
DROP VIEW [dbo].[vw_aspnet_Users]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Paths]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_Paths]'))
DROP VIEW [dbo].[vw_aspnet_WebPartState_Paths]
GO
/****** Object:  View [dbo].[vw_aspnet_MembershipUsers]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_MembershipUsers]'))
DROP VIEW [dbo].[vw_aspnet_MembershipUsers]
GO
/****** Object:  View [dbo].[vw_aspnet_Profiles]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_Profiles]'))
DROP VIEW [dbo].[vw_aspnet_Profiles]
GO
/****** Object:  View [dbo].[vw_aspnet_UsersInRoles]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_UsersInRoles]'))
DROP VIEW [dbo].[vw_aspnet_UsersInRoles]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_Shared]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_Shared]'))
DROP VIEW [dbo].[vw_aspnet_WebPartState_Shared]
GO
/****** Object:  View [dbo].[vw_aspnet_WebPartState_User]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vw_aspnet_WebPartState_User]'))
DROP VIEW [dbo].[vw_aspnet_WebPartState_User]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_AnyDataInTables]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_AnyDataInTables]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_AnyDataInTables]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Membership_UpdateUserInfo]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership_UpdateUserInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Membership_UpdateUserInfo]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_DeleteAllState]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_DeleteAllState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_DeleteAllState]
GO
/****** Object:  Table [dbo].[CSK_Messaging_Mailer]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Messaging_Mailer]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Messaging_Mailer]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_PersonalizationAdministration_FindState]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAdministration_FindState]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_PersonalizationAdministration_FindState]
GO
/****** Object:  Table [dbo].[CSK_Store_AttributeType]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_AttributeType]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_AttributeType]
GO
/****** Object:  Table [dbo].[CSK_Store_ProductType]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductType]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ProductType]
GO
/****** Object:  Table [dbo].[CSK_Store_TransactionType]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_TransactionType]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_TransactionType]
GO
/****** Object:  Table [dbo].[CSK_Promo_Campaign]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Campaign]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Promo_Campaign]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationAllUsers]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationAllUsers]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_PersonalizationAllUsers]
GO
/****** Object:  Table [dbo].[aspnet_Users]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Users]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Users]
GO
/****** Object:  Table [dbo].[aspnet_PersonalizationPerUser]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_PersonalizationPerUser]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_PersonalizationPerUser]
GO
/****** Object:  Table [dbo].[CSK_Stats_Tracker]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_Tracker]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Stats_Tracker]
GO
/****** Object:  Table [dbo].[CSK_Promo_Bundle]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Bundle]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Promo_Bundle]
GO
/****** Object:  Table [dbo].[CSK_CouponTypes]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_CouponTypes]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_CouponTypes]
GO
/****** Object:  Table [dbo].[CSK_Coupons]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Coupons]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Coupons]
GO
/****** Object:  Table [dbo].[CSK_Promo]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Promo]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Paths_CreatePath]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths_CreatePath]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Paths_CreatePath]
GO
/****** Object:  StoredProcedure [dbo].[aspnet_Applications_CreateApplication]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications_CreateApplication]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[aspnet_Applications_CreateApplication]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[CSK_Stats_Behavior]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Stats_Behavior]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Stats_Behavior]
GO
/****** Object:  Table [dbo].[CSK_Content_Text]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Content_Text]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Content_Text]
GO
/****** Object:  Table [dbo].[aspnet_Profile]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Profile]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Profile]
GO
/****** Object:  Table [dbo].[aspnet_SchemaVersions]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_SchemaVersions]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_SchemaVersions]
GO
/****** Object:  Table [dbo].[aspnet_Roles]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Roles]
GO
/****** Object:  Table [dbo].[CSK_Promo_Product_Promo_Map]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_Promo_Map]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Promo_Product_Promo_Map]
GO
/****** Object:  Table [dbo].[aspnet_UsersInRoles]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_UsersInRoles]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_UsersInRoles]
GO
/****** Object:  Table [dbo].[CSK_Promo_Product_Bundle_Map]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_Bundle_Map]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Promo_Product_Bundle_Map]
GO
/****** Object:  Table [dbo].[CSK_Store_Order]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Order]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Order]
GO
/****** Object:  Table [dbo].[CSK_Store_OrderNote]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_OrderNote]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_OrderNote]
GO
/****** Object:  Table [dbo].[CSK_Store_OrderItem]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_OrderItem]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_OrderItem]
GO
/****** Object:  Table [dbo].[CSK_Shipping_Rate]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Shipping_Rate]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Shipping_Rate]
GO
/****** Object:  Table [dbo].[aspnet_Membership]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Membership]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Membership]
GO
/****** Object:  Table [dbo].[aspnet_WebEvent_Events]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_WebEvent_Events]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_WebEvent_Events]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Category_GetCrumbs]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category_GetCrumbs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Category_GetCrumbs]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Category_GetAllSubs]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category_GetAllSubs]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Category_GetAllSubs]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Log]') AND type in (N'U'))
DROP TABLE [dbo].[Log]
GO
/****** Object:  Table [dbo].[CSK_Store_Config]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Config]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Config]
GO
/****** Object:  Table [dbo].[CSK_Store_OrderStatus]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_OrderStatus]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_OrderStatus]
GO
/****** Object:  Table [dbo].[CSK_Store_Transaction]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Transaction]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Transaction]
GO
/****** Object:  Table [dbo].[CSK_Store_ProductRating]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductRating]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ProductRating]
GO
/****** Object:  Table [dbo].[CSK_Store_ProductReview]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductReview]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ProductReview]
GO
/****** Object:  Table [dbo].[CSK_Store_ProductDescriptor]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductDescriptor]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ProductDescriptor]
GO
/****** Object:  Table [dbo].[CSK_Store_ProductReviewFeedback]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductReviewFeedback]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ProductReviewFeedback]
GO
/****** Object:  StoredProcedure [dbo].[CSK_Store_Product_GetByCategoryID]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_GetByCategoryID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CSK_Store_Product_GetByCategoryID]
GO
/****** Object:  View [dbo].[ProductCrossSells]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[ProductCrossSells]'))
DROP VIEW [dbo].[ProductCrossSells]
GO
/****** Object:  UserDefinedFunction [dbo].[WordCount]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WordCount]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[WordCount]
GO
/****** Object:  Table [dbo].[CSK_Tax_Rate]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Tax_Rate]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Tax_Rate]
GO
/****** Object:  Table [dbo].[CSK_Util_ZipCode]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Util_ZipCode]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Util_ZipCode]
GO
/****** Object:  Table [dbo].[CategoryLog]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CategoryLog]') AND type in (N'U'))
DROP TABLE [dbo].[CategoryLog]
GO
/****** Object:  Table [dbo].[aspnet_Paths]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Paths]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Paths]
GO
/****** Object:  Table [dbo].[CSK_Promo_Product_CrossSell_Map]    Script Date: 09/26/2007 16:28:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Promo_Product_CrossSell_Map]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Promo_Product_CrossSell_Map]
GO
/****** Object:  Table [dbo].[aspnet_Applications]    Script Date: 09/26/2007 16:28:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[aspnet_Applications]') AND type in (N'U'))
DROP TABLE [dbo].[aspnet_Applications]
GO
/****** Object:  View [dbo].[vwProduct]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwProduct]'))
DROP VIEW [dbo].[vwProduct]
GO
/****** Object:  Table [dbo].[CSK_Store_Product_Category_Map]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product_Category_Map]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Product_Category_Map]
GO
/****** Object:  UserDefinedFunction [dbo].[GetChildren]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetChildren]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[GetChildren]
GO
/****** Object:  Table [dbo].[CSK_Store_Product]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Product]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Product]
GO
/****** Object:  Table [dbo].[CSK_Store_Category]    Script Date: 09/26/2007 16:28:22 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Category]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Category]
GO
/****** Object:  Table [dbo].[CSK_Store_ProductStatus]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ProductStatus]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ProductStatus]
GO
/****** Object:  Table [dbo].[CSK_Store_Manufacturer]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Manufacturer]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Manufacturer]
GO
/****** Object:  Table [dbo].[CSK_Store_Image]    Script Date: 09/26/2007 16:28:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_Image]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_Image]
GO
/****** Object:  Table [dbo].[CSK_Store_ShippingType]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ShippingType]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ShippingType]
GO
/****** Object:  Table [dbo].[CSK_Store_ShippingEstimate]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Store_ShippingEstimate]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Store_ShippingEstimate]
GO
/****** Object:  Table [dbo].[CSK_Tax_Type]    Script Date: 09/26/2007 16:28:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CSK_Tax_Type]') AND type in (N'U'))
DROP TABLE [dbo].[CSK_Tax_Type]
GO
/****** Object:  Schema [aspnet_Membership_BasicAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Membership_BasicAccess')
DROP SCHEMA [aspnet_Membership_BasicAccess]
GO
/****** Object:  Schema [aspnet_Membership_FullAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Membership_FullAccess')
DROP SCHEMA [aspnet_Membership_FullAccess]
GO
/****** Object:  Schema [aspnet_Membership_ReportingAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Membership_ReportingAccess')
DROP SCHEMA [aspnet_Membership_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Personalization_BasicAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Personalization_BasicAccess')
DROP SCHEMA [aspnet_Personalization_BasicAccess]
GO
/****** Object:  Schema [aspnet_Personalization_FullAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Personalization_FullAccess')
DROP SCHEMA [aspnet_Personalization_FullAccess]
GO
/****** Object:  Schema [aspnet_Personalization_ReportingAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Personalization_ReportingAccess')
DROP SCHEMA [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Profile_BasicAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Profile_BasicAccess')
DROP SCHEMA [aspnet_Profile_BasicAccess]
GO
/****** Object:  Schema [aspnet_Profile_FullAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Profile_FullAccess')
DROP SCHEMA [aspnet_Profile_FullAccess]
GO
/****** Object:  Schema [aspnet_Profile_ReportingAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Profile_ReportingAccess')
DROP SCHEMA [aspnet_Profile_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Roles_BasicAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Roles_BasicAccess')
DROP SCHEMA [aspnet_Roles_BasicAccess]
GO
/****** Object:  Schema [aspnet_Roles_FullAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Roles_FullAccess')
DROP SCHEMA [aspnet_Roles_FullAccess]
GO
/****** Object:  Schema [aspnet_Roles_ReportingAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_Roles_ReportingAccess')
DROP SCHEMA [aspnet_Roles_ReportingAccess]
GO
/****** Object:  Schema [aspnet_WebEvent_FullAccess]    Script Date: 09/26/2007 16:28:19 ******/
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'aspnet_WebEvent_FullAccess')
DROP SCHEMA [aspnet_WebEvent_FullAccess]
GO

/****** Object:  Role [aspnet_Membership_FullAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Membership_FullAccess' AND type = 'R')
DROP ROLE [aspnet_Membership_FullAccess]
GO
/****** Object:  Role [aspnet_Membership_BasicAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Membership_BasicAccess' AND type = 'R')
DROP ROLE [aspnet_Membership_BasicAccess]
GO
/****** Object:  Role [aspnet_Membership_ReportingAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Membership_ReportingAccess' AND type = 'R')
DROP ROLE [aspnet_Membership_ReportingAccess]
GO
/****** Object:  Role [aspnet_Personalization_FullAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Personalization_FullAccess' AND type = 'R')
DROP ROLE [aspnet_Personalization_FullAccess]
GO
/****** Object:  Role [aspnet_Personalization_BasicAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Personalization_BasicAccess' AND type = 'R')
DROP ROLE [aspnet_Personalization_BasicAccess]
GO
/****** Object:  Role [aspnet_Personalization_ReportingAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Personalization_ReportingAccess' AND type = 'R')
DROP ROLE [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  Role [aspnet_Profile_FullAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Profile_FullAccess' AND type = 'R')
DROP ROLE [aspnet_Profile_FullAccess]
GO
/****** Object:  Role [aspnet_Profile_BasicAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Profile_BasicAccess' AND type = 'R')
DROP ROLE [aspnet_Profile_BasicAccess]
GO
/****** Object:  Role [aspnet_Profile_ReportingAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Profile_ReportingAccess' AND type = 'R')
DROP ROLE [aspnet_Profile_ReportingAccess]
GO
/****** Object:  Role [aspnet_Roles_FullAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Roles_FullAccess' AND type = 'R')
DROP ROLE [aspnet_Roles_FullAccess]
GO
/****** Object:  Role [aspnet_Roles_BasicAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Roles_BasicAccess' AND type = 'R')
DROP ROLE [aspnet_Roles_BasicAccess]
GO
/****** Object:  Role [aspnet_Roles_ReportingAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_Roles_ReportingAccess' AND type = 'R')
DROP ROLE [aspnet_Roles_ReportingAccess]
GO
/****** Object:  Role [aspnet_WebEvent_FullAccess]    Script Date: 09/26/2007 16:28:18 ******/
IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'aspnet_WebEvent_FullAccess' AND type = 'R')
DROP ROLE [aspnet_WebEvent_FullAccess]
GO
