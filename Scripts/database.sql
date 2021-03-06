
USE [cecropia]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 20/5/2018 7:51:47 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sku] [nvarchar](20) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[QuantityStock] [numeric](18, 2) NOT NULL,
	[FinalPrice] [numeric](18, 2) NOT NULL,
	[RegularPrice] [numeric](18, 2) NOT NULL,
	[ApplyTaxes] [bit] NOT NULL,
	[TaxRate] [numeric](18, 2) NOT NULL,
	[Location] [int] NOT NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Product]    Script Date: 20/5/2018 7:51:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Product]
  @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Product WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[GetAll_Product]    Script Date: 20/5/2018 7:51:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Jaime
-- Create date: 05-18-2018
-- Description:	Get All productos
-- =============================================
CREATE PROCEDURE [dbo].[GetAll_Product]

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Product where QuantityStock > 0
END
GO
/****** Object:  StoredProcedure [dbo].[GetById_Product]    Script Date: 20/5/2018 7:51:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Jaime
-- Create date: 05-18-2018
-- Description:	Get product by id
-- =============================================
CREATE PROCEDURE [dbo].[GetById_Product]
  @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Product WHERE Id=@Id
END
GO
/****** Object:  StoredProcedure [dbo].[Insert_Product]    Script Date: 20/5/2018 7:51:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Jaime
-- Create date: 05-18-2018
-- Description:	Insert product
-- =============================================
CREATE PROCEDURE [dbo].[Insert_Product]
     @Id int output
	,@Sku nvarchar(20)
    ,@Description nvarchar(250)
    ,@QuantityStock numeric(18,2)
    ,@FinalPrice numeric(18,2)
    ,@RegularPrice numeric(18,2)
    ,@ApplyTaxes bit
    ,@TaxRate numeric(18,2)
    ,@Location int
    ,@Image varbinary(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



INSERT INTO [dbo].[Product]
           ([Sku]
           ,[Description]
           ,[QuantityStock]
           ,[FinalPrice]
           ,[RegularPrice]
           ,[ApplyTaxes]
           ,[TaxRate]
           ,[Location]
           ,[Image])
     VALUES
           ( @Sku 
			,@Description 
			,@QuantityStock
			,@FinalPrice
			,@RegularPrice 
			,@ApplyTaxes 
			,@TaxRate
			,@Location 
			,@Image )



			SET @Id = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[Update_Product]    Script Date: 20/5/2018 7:51:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jorge Jaime
-- Create date: 05-18-2018
-- Description:	Update product
-- =============================================
CREATE PROCEDURE [dbo].[Update_Product]
	 @Id int
	,@Sku nvarchar(20)
    ,@Description nvarchar(250)
    ,@QuantityStock numeric(18,2)
    ,@FinalPrice numeric(18,2)
    ,@RegularPrice numeric(18,2)
    ,@ApplyTaxes bit
    ,@TaxRate numeric(18,2)
    ,@Location int
    ,@Image varbinary(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;


UPDATE [dbo].[Product]
   SET [Sku] = @Sku
      ,[Description] = @Description
      ,[QuantityStock] = @QuantityStock
      ,[FinalPrice] = @FinalPrice
      ,[RegularPrice] = @RegularPrice
      ,[ApplyTaxes] = @ApplyTaxes
      ,[TaxRate] = @TaxRate
      ,[Location] = @Location
      ,[Image] =  @Image 
 WHERE Id = @Id




END
