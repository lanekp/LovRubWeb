SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[WordCount]') AND xtype in (N'FN', N'IF', N'TF'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[WordCount]
(@Word VARCHAR(15),
@Phrase VARCHAR(1000))
RETURNS SMALLINT
AS
BEGIN

/* If @Word or @Phrase is NULL the function returns 0 */
IF @Word IS NULL OR @Phrase IS NULL RETURN 0

/* @BiggerWord is a string one character longer than @Word */
DECLARE @BiggerWord VARCHAR(21)
SELECT @BiggerWord = @Word + ''x''

/* Replace @Word with @BiggerWord in @Phrase */
DECLARE @BiggerPhrase VARCHAR(2000)
SELECT @BiggerPhrase = REPLACE (@Phrase, @Word, @BiggerWord)

/* The length difference between @BiggerPhrase and @phrase
   is the number we''''re looking for */
RETURN LEN(@BiggerPhrase) - LEN(@Phrase)
END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GetParentCategory]') AND xtype in (N'FN', N'IF', N'TF'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetParentCategory]
	(
	@categoryID int
	)
RETURNS int
AS
	BEGIN
	DECLARE @parentID int
	DECLARE @category varchar(50)
	DECLARE @loopCount int
	DECLARE @thisID int
	
	SET @parentID=9999
	
	SET @loopCount=1;
	while(@parentID IS NOT NULL AND @loopCount<10)
	BEGIN
		SELECT @parentID=parentID,
		@thisID=categoryID  
		FROM 
		CMRC_ProductCategories 
		WHERE categoryID=@categoryID
		
		SET @categoryID=@parentID
		SET @loopCount=@loopCount+1
	END
	
	RETURN @thisID
	END
' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GetLastViewedSKUs]') AND xtype in (N'FN', N'IF', N'TF'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetLastViewedSKUs]
	(
	@userName nvarchar(50)
	)
RETURNS @skus TABLE (sku nvarchar(50), holder int)
AS
	BEGIN
		INSERT INTO @skus(sku, holder)
		SELECT TOP 50 productsku,0 FROM CSK_Stats_Tracker
		WHERE behaviorID=2 AND userName=@userName
		ORDER BY CreatedOn DESC
		INSERT INTO @skus
		SELECT DISTINCT sku,1 FROM @skus
		DELETE FROM @skus WHERE holder=0
	RETURN
	END' 
END

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GetChildren]') AND xtype in (N'FN', N'IF', N'TF'))
BEGIN
execute dbo.sp_executesql @statement = N'CREATE FUNCTION [dbo].[GetChildren] (@Id int) 
RETURNS @result TABLE (Id int, ParentId int, Level smallint) 
AS 
BEGIN 
DECLARE @Level smallint 
-- get the top level node (magic requirement) 
-- get starting node 
SET @Level = 1 
INSERT @result 
SELECT categoryID, ParentId, @Level FROM CSK_Store_Category WHERE categoryID = @Id 
WHILE @Level < 1000 BEGIN -- weak condition to catch infinite recursion 
-- get child nodes of current level''s nodes 
INSERT @result 
SELECT t.categoryID, t.ParentId, @Level + 1 FROM CSK_Store_Category t 
JOIN @result r ON t.ParentId = r.Id AND @Level = r.Level 
-- no child nodes ==&gt; all done 
IF @@ROWCOUNT = 0 BREAK 
-- advance one level 
SET @Level = @Level + 1 
END 
RETURN 
END 
' 
END

