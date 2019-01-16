USE [Northwind]
GO

/****** Object:  View [dbo].[vwOrders]    Script Date: 1/13/2019 9:12:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE view [dbo].[vwOrders] AS
	select o.OrderID
		,o.CustomerID
		,o.EmployeeID
		,o.OrderDate
		,o.RequiredDate
		,o.Freight
		,o.ShippedDate
		,o.ShipName
		,o.ShipAddress
		,o.ShipCity
		,o.ShipRegion
		,o.ShipPostalCode
		,o.ShipCountry
	from Northwind.dbo.Orders o
GO


