USE [Northwind]
GO

/****** Object:  StoredProcedure [dbo].[sp_Orders]    Script Date: 1/13/2019 9:15:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Orders]
AS
	select * from Northwind.dbo.vwOrders
GO


