--CREATE DATABASE [OrderPurchase_DS];
USE [OrderPurchase_DS]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] NOT NULL,
	[RefId] [varchar](25) NULL,
	[PONO] [varchar](30) NULL,
	[PODate] [datetime] NULL,
	[Supplier] [varchar](30) NULL,
	[ExpectedDate] [datetime] NULL,
	[Remarks] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order_Quantity]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order_Quantity](
	[OrderId] [int] NULL,
	[QuantityId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quantity]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quantity](
	[Id] [int] NOT NULL,
	[ItemName] [varchar](25) NULL,
	[Qty] [int] NULL,
	[Rate] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (1, N'001', N'1001', CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'Supplier 1', CAST(N'2024-06-02T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (2, N'002', N'1002', CAST(N'2024-06-02T00:00:00.000' AS DateTime), N'Supplier 1', CAST(N'2024-06-03T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (3, N'003', N'1980', CAST(N'2024-05-26T00:00:00.000' AS DateTime), N'Supplier 3', CAST(N'2024-05-27T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (4, N'004', N'1009', CAST(N'2024-06-03T00:00:00.000' AS DateTime), N'Supplier 2', CAST(N'2024-06-29T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (5, N'005', N'1780', CAST(N'2024-06-01T00:00:00.000' AS DateTime), N'Supplier 1', CAST(N'2024-06-29T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (6, N'006', N'100123', CAST(N'2024-06-16T00:00:00.000' AS DateTime), N'Supplier 2', CAST(N'2024-06-26T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (7, N'007', N'2340', CAST(N'2024-06-16T00:00:00.000' AS DateTime), N'Supplier 2', CAST(N'2024-06-29T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (8, N'008', N'9981', CAST(N'2024-06-02T00:00:00.000' AS DateTime), N'Supplier 2', CAST(N'2024-06-26T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (9, N'009', N'19239', CAST(N'2024-06-02T00:00:00.000' AS DateTime), N'Supplier 2', CAST(N'2024-06-27T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order] ([Id], [RefId], [PONO], [PODate], [Supplier], [ExpectedDate], [Remarks]) VALUES (10, N'0010', N'97613', CAST(N'2024-06-29T00:00:00.000' AS DateTime), N'Supplier 2', CAST(N'2024-06-30T00:00:00.000' AS DateTime), N'')
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (1, 1)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (1, 2)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (2, 3)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (3, 4)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (3, 5)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (4, 6)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (4, 7)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (4, 8)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (5, 9)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (5, 10)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (6, 11)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (6, 12)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (7, 13)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (7, 14)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (8, 15)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (8, 16)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (9, 17)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (10, 18)
GO
INSERT [dbo].[Order_Quantity] ([OrderId], [QuantityId]) VALUES (10, 19)
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (1, N'Item1', 1, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (2, N'Item2', 2, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (3, N'Item3', 4, CAST(4000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (4, N'Item2', 2, CAST(190 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (5, N'Item3', 4, CAST(4000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (6, N'Item1', 1, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (7, N'Item3', 2, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (8, N'Item2', 3, CAST(3000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (9, N'Item1', 23, CAST(2300 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (10, N'Item3', 24, CAST(2400 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (11, N'Item1', 2, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (12, N'Item3', 3, CAST(3050 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (13, N'Item1', 2, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (14, N'Item3', 30, CAST(4901 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (15, N'Item1', 23, CAST(23000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (16, N'Item3', 3, CAST(3000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (17, N'Item2', 2, CAST(2000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (18, N'Item1', 1, CAST(1000 AS Decimal(18, 0)))
GO
INSERT [dbo].[Quantity] ([Id], [ItemName], [Qty], [Rate]) VALUES (19, N'Item2', 2, CAST(2000 AS Decimal(18, 0)))
GO
ALTER TABLE [dbo].[Order_Quantity]  WITH NOCHECK ADD FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[Order_Quantity]  WITH NOCHECK ADD FOREIGN KEY([QuantityId])
REFERENCES [dbo].[Quantity] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[DeleteOrderInfo]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteOrderInfo]
    @OrderId INT
AS
BEGIN
   create table #Order_Quantity(
		orderId int,
		quantityId int
   )
   insert into #Order_Quantity
   Select OrderId,QuantityId from Order_Quantity where OrderId = @OrderId
   delete from Order_Quantity where OrderId in (select orderId from #Order_Quantity)
   delete from Quantity where Id in (select quantityId from #Order_Quantity)
   delete from [Order] where Id = @OrderId
   drop table #Order_Quantity
   Select 'Deleted Successfully'
END
GO
/****** Object:  StoredProcedure [dbo].[GetLatestOrderId]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLatestOrderId]
    
AS
BEGIN
    Select Max(Id) from [Order]
END
GO
/****** Object:  StoredProcedure [dbo].[GetLatestQuantityId]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLatestQuantityId]
    
AS
BEGIN
    Select Max(Id) from Quantity
END
GO
/****** Object:  StoredProcedure [dbo].[GetLatestRefId]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetLatestRefId]
    
AS
BEGIN
   declare @MaxId int
   Select @MaxId = Max(Id) from [Order]
   select RIGHT('00'+ CAST(cast(RefId as Int)+1 AS VARCHAR),1000) from [Order] where Id = @MaxId
END


GO
/****** Object:  StoredProcedure [dbo].[GetOrderById]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderById]
    @OrderId INT
AS
BEGIN
    select * from [Order] where Id = @OrderId
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderCounts]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderCounts]
    @Search varchar(25)
AS
BEGIN
	if @Search is null
	begin
	select count(Id) from [Order]
	end
	else
	begin
		select count(Id) from [Order] where (RefId like CONCAT('%', trim(@Search), '%')
		or  PONO like CONCAT('%', trim(@Search), '%')
		or  PODate like CONCAT('%', trim(@Search), '%')
		or Supplier like CONCAT('%', trim(@Search), '%')
		or ExpectedDate like CONCAT('%', trim(@Search), '%')
		or Remarks like CONCAT('%', trim(@Search), '%'))
	end
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderList]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrderList]
    @Search varchar(25),
	@page int
AS
BEGIN	
	declare @lower int;
	declare @upper int;
	set @upper = @page*3;
	if (@page = 1)
	begin set @lower = 1 end
	else
	begin set @lower= (@upper-3)+1 end
	if @Search is null
	begin
		if(@page is null)
		begin 
		select * from [Order] order by CAST(RefId AS INT)
		end
		else
		begin
		select * from [Order]  where Id between @lower and @upper
		order by CAST(RefId AS INT)
		end
	end
	else
	begin
		with cte as(
		select *,ROW_NUMBER() over(order by CAST(RefId AS INT)) as RowNo from [Order] where (RefId like CONCAT('%', trim(@Search), '%')
		or  PONO like CONCAT('%', trim(@Search), '%')
		or  PODate like CONCAT('%', trim(@Search), '%')
		or Supplier like CONCAT('%', trim(@Search), '%')
		or ExpectedDate like CONCAT('%', trim(@Search), '%')
		or Remarks like CONCAT('%', trim(@Search), '%'))
		)

		select * from cte where RowNo between @lower and @upper
		--and Id between @lower and @upper
	end

END
GO
/****** Object:  StoredProcedure [dbo].[GetQuantityItemByOrderId]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetQuantityItemByOrderId]
    @OrderId INT
AS
BEGIN
    select q.Id,q.ItemName,q.Qty,q.Rate from Order_Quantity oq
	inner join Quantity q
	on oq.QuantityId = q.Id
	and oq.OrderId = @OrderId
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrder]
    @Id int,
	@RefId varchar(25),
	@PONO varchar(30),
	@PODate varchar(25),
	@Supplier varchar(30),
	@ExpectedDate varchar(30),
	@Remarks varchar(1000)
AS
BEGIN
	Begin try
	insert into [Order] (Id,RefId,PONO,PODate,Supplier,ExpectedDate,Remarks) 
	values(@Id,@RefId,@PONO,@PODate,@Supplier,@ExpectedDate,@Remarks)
	Select 'Data Inserted Successfully' as Operation
	end try
	begin catch
	Select 'Data Not Inserted Successfully' as Operation
	end catch
End
GO
/****** Object:  StoredProcedure [dbo].[SaveOrder_Purchase_Mapping]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveOrder_Purchase_Mapping]
    @OrderId int,
	@QuantityId int
AS
BEGIN
	Begin try
	insert into [Order_Quantity] (OrderId,QuantityId) 
	values(@OrderId,@QuantityId)
	Select 'Mapping Successfully Occurred' as Operation
	end try
	Begin Catch
	Select 'Mapping Not Successfully Occurred' as Operation
	end Catch
End
GO
/****** Object:  StoredProcedure [dbo].[StoreUpdatedQty]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoreUpdatedQty]
    @OrderId INT
AS
BEGIN
	create table #QuantityIds(
		QuantityId int
	);
	insert into #QuantityIds
    select QuantityId from Order_Quantity where OrderId = @OrderId
	delete from Order_Quantity where QuantityId in (select QuantityId from #QuantityIds)
	delete from Quantity where Id in (select QuantityId from #QuantityIds)
	drop table #QuantityIds
	Select 'Previous Quantity Deleted Successfully'
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 6/30/2024 11:39:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateOrder]
    @Id int,
	@RefId varchar(25),
	@PONO varchar(30),
	@PODate varchar(25),
	@Supplier varchar(30),
	@ExpectedDate varchar(30),
	@Remarks varchar(1000)
AS
BEGIN
   Begin Try
   Update [Order] set  PONO = @PONO, PODate = @PODate, Supplier = @Supplier
   ,ExpectedDate=@ExpectedDate
   ,Remarks = @Remarks
   where Id = @Id
   Select 'Data Updated Successfully'
   End Try
   Begin Catch
   Select 'Data Not Updated Successfully'
   End Catch
END
GO
