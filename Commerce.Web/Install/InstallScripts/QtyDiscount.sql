ALTER TABLE CSK_Store_OrderItem 
ADD attributesPrice money

GO
CREATE PROCEDURE [dbo].[CSK_Store_AddItemToCart_QtyDiscount]
(
	@userName nvarchar(50),
	@productID int,
	@attributes nvarchar(4000)='',
	@pricePaid money,
	@attributesPrice money,
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
		  attributesPrice, 
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
			@attributesPrice, 
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


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CSK_Store_Product_QtyDiscount](
	[discountID] [int] IDENTITY(1,1) NOT NULL,
	[productID] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[discount] [numeric](18, 0) NOT NULL,
	[isPercent] [bit] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_CSK_Store_Product_QtyDiscount] PRIMARY KEY CLUSTERED 
(
	[discountID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CSK_Store_Product_QtyDiscount]  WITH CHECK ADD CONSTRAINT [FK_CSK_Store_Product_QtyDiscount_CSK_Store_Product] FOREIGN KEY([productID])
REFERENCES [dbo].[CSK_Store_Product] ([productID])

GO
CREATE PROCEDURE [dbo].[CSK_Store_Product_QtyDiscount_Get]
(
	@productID int,
	@quantity int
)
AS
SELECT TOP 1 * 
FROM CSK_Store_Product_QtyDiscount 
WHERE productID = @productID 
AND quantity <= @quantity 
AND isActive = 'True'
ORDER BY quantity DESC

GO
CREATE PROCEDURE [dbo].[CSK_Store_Product_QtyDiscount_GetByProductID]
(
	@productID int
)
AS
SELECT     
	discountID, 
	productID, 
	quantity, 
	discount, 
	isPercent,
	isActive
FROM CSK_Store_Product_QtyDiscount
WHERE productID = @productID ORDER BY quantity ASC

GO
INSERT INTO [dbo].[CSK_Store_Product_QtyDiscount] ([productID],[quantity],[discount],[isPercent],[isActive]) VALUES(5, 3, 15, 1, 1)
INSERT INTO [dbo].[CSK_Store_Product_QtyDiscount] ([productID],[quantity],[discount],[isPercent],[isActive]) VALUES(21, 3, 20, 1, 1)
INSERT INTO [dbo].[CSK_Store_Product_QtyDiscount] ([productID],[quantity],[discount],[isPercent],[isActive]) VALUES(21, 5, 500, 0, 1)
