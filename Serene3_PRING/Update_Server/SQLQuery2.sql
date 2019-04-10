
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [CK_UnitsOnOrder]
GO

ALTER TABLE [dbo].[Products] DROP CONSTRAINT [CK_UnitsInStock]
GO

ALTER TABLE [dbo].[Products] DROP CONSTRAINT [CK_ReorderLevel]
GO

ALTER TABLE [dbo].[Products] DROP CONSTRAINT [CK_Products_UnitPrice]
GO

ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [CK_UnitPrice]
GO

ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [CK_Quantity]
GO

ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [CK_Discount]
GO

ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [CK_Birthdate]
GO

ALTER TABLE [dbo].[Territories] DROP CONSTRAINT [FK_Territories_Region]
GO

ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Suppliers]
GO

ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_Categories]
GO

ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Shippers]
GO

ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Employees]
GO

ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Customers]
GO

ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Products]
GO

ALTER TABLE [dbo].[Order Details] DROP CONSTRAINT [FK_Order_Details_Orders]
GO

ALTER TABLE [dbo].[EmployeeTerritories] DROP CONSTRAINT [FK_EmployeeTerritories_Territories]
GO

ALTER TABLE [dbo].[EmployeeTerritories] DROP CONSTRAINT [FK_EmployeeTerritories_Employees]
GO

ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_Employees]
GO

ALTER TABLE [dbo].[CustomerDetails] DROP CONSTRAINT [FK_CustomerDetails_LastContactedBy]
GO

ALTER TABLE [dbo].[CustomerCustomerDemo] DROP CONSTRAINT [FK_CustomerCustomerDemo_Customers]
GO

ALTER TABLE [dbo].[CustomerCustomerDemo] DROP CONSTRAINT [FK_CustomerCustomerDemo]
GO

ALTER TABLE [dbo].[CustomerDetails] DROP CONSTRAINT [DF_CustomerDetails_SendBulletin]
GO

/****** Object:  Table [dbo].[VersionInfo]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[VersionInfo]
GO

/****** Object:  Table [dbo].[Territories]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Territories]
GO

/****** Object:  Table [dbo].[Suppliers]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Suppliers]
GO

/****** Object:  Table [dbo].[Shippers]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Shippers]
GO

/****** Object:  Table [dbo].[Region]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Region]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Products]
GO

/****** Object:  Table [dbo].[ProductLog]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[ProductLog]
GO

/****** Object:  Table [dbo].[ProductLang]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[ProductLang]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Orders]
GO

/****** Object:  Table [dbo].[Order Details]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Order Details]
GO

/****** Object:  Table [dbo].[Notes]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Notes]
GO

/****** Object:  Table [dbo].[EmployeeTerritories]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[EmployeeTerritories]
GO

/****** Object:  Table [dbo].[Employees]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Employees]
GO

/****** Object:  Table [dbo].[DragDropSample]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[DragDropSample]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Customers]
GO

/****** Object:  Table [dbo].[CustomerRepresentatives]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[CustomerRepresentatives]
GO

/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[CustomerDetails]
GO

/****** Object:  Table [dbo].[CustomerDemographics]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[CustomerDemographics]
GO

/****** Object:  Table [dbo].[CustomerCustomerDemo]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[CustomerCustomerDemo]
GO

/****** Object:  Table [dbo].[CategoryLang]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[CategoryLang]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 25/04/2018 3:50:11 PM ******/
DROP TABLE [dbo].[Categories]
GO

/****** Object:  Table [dbo].[Categories]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](15) NOT NULL,
	[Description] [ntext] NULL,
	[Picture] [image] NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CategoryLang]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CategoryLang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
	[CategoryName] [nvarchar](15) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_CategoryLang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CustomerCustomerDemo]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerCustomerDemo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nvarchar](5) NOT NULL,
	[CustomerTypeID] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_CustomerCustomerDemo] PRIMARY KEY NONCLUSTERED 
(
	[CustomerID] ASC,
	[CustomerTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CustomerDemographics]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerDemographics](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerTypeID] [nvarchar](10) NOT NULL,
	[CustomerDesc] [ntext] NULL,
 CONSTRAINT [PK_CustomerDemographics] PRIMARY KEY NONCLUSTERED 
(
	[CustomerTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CustomerDetails]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerDetails](
	[ID] [int] NOT NULL,
	[LastContactDate] [datetime] NULL,
	[LastContactedBy] [int] NULL,
	[Email] [nvarchar](100) NULL,
	[SendBulletin] [bit] NOT NULL,
 CONSTRAINT [PK_CustomerDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[CustomerRepresentatives]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerRepresentatives](
	[RepresentativeID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_CustomerRepresentatives] PRIMARY KEY CLUSTERED 
(
	[RepresentativeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Customers]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[CustomerID] [nvarchar](5) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[DragDropSample]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DragDropSample](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Title] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_DragDropSample] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Employees]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[FirstName] [nvarchar](10) NOT NULL,
	[Title] [nvarchar](30) NULL,
	[TitleOfCourtesy] [nvarchar](25) NULL,
	[BirthDate] [datetime] NULL,
	[HireDate] [datetime] NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[HomePhone] [nvarchar](24) NULL,
	[Extension] [nvarchar](4) NULL,
	[Photo] [image] NULL,
	[Notes] [ntext] NULL,
	[ReportsTo] [int] NULL,
	[PhotoPath] [nvarchar](255) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[EmployeeTerritories]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeTerritories](
	[EmployeeID] [int] NOT NULL,
	[TerritoryID] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_EmployeeTerritories] PRIMARY KEY NONCLUSTERED 
(
	[EmployeeID] ASC,
	[TerritoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Notes]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Notes](
	[NoteID] [bigint] IDENTITY(1,1) NOT NULL,
	[EntityType] [nvarchar](100) NOT NULL,
	[EntityID] [bigint] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[InsertUserId] [int] NOT NULL,
	[InsertDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Notes] PRIMARY KEY CLUSTERED 
(
	[NoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Order Details]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Order Details](
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[UnitPrice] [money] NOT NULL CONSTRAINT [DF_Order_Details_UnitPrice]  DEFAULT ((0)),
	[Quantity] [smallint] NOT NULL CONSTRAINT [DF_Order_Details_Quantity]  DEFAULT ((1)),
	[Discount] [real] NOT NULL CONSTRAINT [DF_Order_Details_Discount]  DEFAULT ((0)),
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Order_Details] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Orders]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [nvarchar](5) NULL,
	[EmployeeID] [int] NULL,
	[OrderDate] [datetime] NULL,
	[RequiredDate] [datetime] NULL,
	[ShippedDate] [datetime] NULL,
	[ShipVia] [int] NULL,
	[Freight] [money] NULL CONSTRAINT [DF_Orders_Freight]  DEFAULT ((0)),
	[ShipName] [nvarchar](40) NULL,
	[ShipAddress] [nvarchar](60) NULL,
	[ShipCity] [nvarchar](15) NULL,
	[ShipRegion] [nvarchar](15) NULL,
	[ShipPostalCode] [nvarchar](10) NULL,
	[ShipCountry] [nvarchar](15) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductLang]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductLang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[LanguageID] [int] NOT NULL,
	[ProductName] [nvarchar](40) NULL,
 CONSTRAINT [PK_ProductLang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[ProductLog]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ProductLog](
	[ProductLogID] [bigint] IDENTITY(1,1) NOT NULL,
	[OperationType] [smallint] NOT NULL,
	[ChangingUserId] [int] NULL,
	[ValidFrom] [datetime] NOT NULL,
	[ValidUntil] [datetime] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductName] [nvarchar](40) NULL,
	[ProductImage] [nvarchar](100) NULL,
	[Discontinued] [bit] NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NULL,
	[UnitPrice] [money] NULL,
	[UnitsInStock] [smallint] NULL,
	[UnitsOnOrder] [smallint] NULL,
	[ReorderLevel] [smallint] NULL,
 CONSTRAINT [PK_ProductLog] PRIMARY KEY CLUSTERED 
(
	[ProductLogID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Products]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](40) NOT NULL,
	[SupplierID] [int] NULL,
	[CategoryID] [int] NULL,
	[QuantityPerUnit] [nvarchar](20) NULL,
	[UnitPrice] [money] NULL CONSTRAINT [DF_Products_UnitPrice]  DEFAULT ((0)),
	[UnitsInStock] [smallint] NULL CONSTRAINT [DF_Products_UnitsInStock]  DEFAULT ((0)),
	[UnitsOnOrder] [smallint] NULL CONSTRAINT [DF_Products_UnitsOnOrder]  DEFAULT ((0)),
	[ReorderLevel] [smallint] NULL CONSTRAINT [DF_Products_ReorderLevel]  DEFAULT ((0)),
	[Discontinued] [bit] NOT NULL CONSTRAINT [DF_Products_Discontinued]  DEFAULT ((0)),
	[ProductImage] [nvarchar](100) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Region]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Region](
	[RegionID] [int] NOT NULL,
	[RegionDescription] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Region] PRIMARY KEY NONCLUSTERED 
(
	[RegionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Shippers]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Shippers](
	[ShipperID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[Phone] [nvarchar](24) NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[ShipperID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Suppliers]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactName] [nvarchar](30) NULL,
	[ContactTitle] [nvarchar](30) NULL,
	[Address] [nvarchar](60) NULL,
	[City] [nvarchar](15) NULL,
	[Region] [nvarchar](15) NULL,
	[PostalCode] [nvarchar](10) NULL,
	[Country] [nvarchar](15) NULL,
	[Phone] [nvarchar](24) NULL,
	[Fax] [nvarchar](24) NULL,
	[HomePage] [ntext] NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Territories]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Territories](
	[TerritoryID] [nvarchar](20) NOT NULL,
	[TerritoryDescription] [nvarchar](50) NOT NULL,
	[RegionID] [int] NOT NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Territories] PRIMARY KEY NONCLUSTERED 
(
	[TerritoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[VersionInfo]    Script Date: 25/04/2018 3:50:11 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VersionInfo](
	[Version] [bigint] NOT NULL,
	[AppliedOn] [datetime] NULL,
	[Description] [nvarchar](1024) NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CustomerDetails] ADD  CONSTRAINT [DF_CustomerDetails_SendBulletin]  DEFAULT ((1)) FOR [SendBulletin]
GO

ALTER TABLE [dbo].[CustomerCustomerDemo]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCustomerDemo] FOREIGN KEY([CustomerTypeID])
REFERENCES [dbo].[CustomerDemographics] ([CustomerTypeID])
GO

ALTER TABLE [dbo].[CustomerCustomerDemo] CHECK CONSTRAINT [FK_CustomerCustomerDemo]
GO

ALTER TABLE [dbo].[CustomerCustomerDemo]  WITH CHECK ADD  CONSTRAINT [FK_CustomerCustomerDemo_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO

ALTER TABLE [dbo].[CustomerCustomerDemo] CHECK CONSTRAINT [FK_CustomerCustomerDemo_Customers]
GO

ALTER TABLE [dbo].[CustomerDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerDetails_LastContactedBy] FOREIGN KEY([LastContactedBy])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[CustomerDetails] CHECK CONSTRAINT [FK_CustomerDetails_LastContactedBy]
GO

ALTER TABLE [dbo].[Employees]  WITH NOCHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([ReportsTo])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO

ALTER TABLE [dbo].[EmployeeTerritories]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTerritories_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeeTerritories] CHECK CONSTRAINT [FK_EmployeeTerritories_Employees]
GO

ALTER TABLE [dbo].[EmployeeTerritories]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeTerritories_Territories] FOREIGN KEY([TerritoryID])
REFERENCES [dbo].[Territories] ([TerritoryID])
GO

ALTER TABLE [dbo].[EmployeeTerritories] CHECK CONSTRAINT [FK_EmployeeTerritories_Territories]
GO

ALTER TABLE [dbo].[Order Details]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_Details_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO

ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [FK_Order_Details_Orders]
GO

ALTER TABLE [dbo].[Order Details]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_Details_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO

ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [FK_Order_Details_Products]
GO

ALTER TABLE [dbo].[Orders]  WITH NOCHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customers] ([CustomerID])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO

ALTER TABLE [dbo].[Orders]  WITH NOCHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO

ALTER TABLE [dbo].[Orders]  WITH NOCHECK ADD  CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY([ShipVia])
REFERENCES [dbo].[Shippers] ([ShipperID])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers]
GO

ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories]
GO

ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Suppliers]
GO

ALTER TABLE [dbo].[Territories]  WITH CHECK ADD  CONSTRAINT [FK_Territories_Region] FOREIGN KEY([RegionID])
REFERENCES [dbo].[Region] ([RegionID])
GO

ALTER TABLE [dbo].[Territories] CHECK CONSTRAINT [FK_Territories_Region]
GO

ALTER TABLE [dbo].[Employees]  WITH NOCHECK ADD  CONSTRAINT [CK_Birthdate] CHECK  (([BirthDate]<getdate()))
GO

ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_Birthdate]
GO

ALTER TABLE [dbo].[Order Details]  WITH NOCHECK ADD  CONSTRAINT [CK_Discount] CHECK  (([Discount]>=(0) AND [Discount]<=(1)))
GO

ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [CK_Discount]
GO

ALTER TABLE [dbo].[Order Details]  WITH NOCHECK ADD  CONSTRAINT [CK_Quantity] CHECK  (([Quantity]>(0)))
GO

ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [CK_Quantity]
GO

ALTER TABLE [dbo].[Order Details]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitPrice] CHECK  (([UnitPrice]>=(0)))
GO

ALTER TABLE [dbo].[Order Details] CHECK CONSTRAINT [CK_UnitPrice]
GO

ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_Products_UnitPrice] CHECK  (([UnitPrice]>=(0)))
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_Products_UnitPrice]
GO

ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_ReorderLevel] CHECK  (([ReorderLevel]>=(0)))
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_ReorderLevel]
GO

ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitsInStock] CHECK  (([UnitsInStock]>=(0)))
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_UnitsInStock]
GO

ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [CK_UnitsOnOrder] CHECK  (([UnitsOnOrder]>=(0)))
GO

ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [CK_UnitsOnOrder]
GO



ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_UserId]
GO

ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_RoleId]
GO

ALTER TABLE [dbo].[UserPermissions] DROP CONSTRAINT [FK_UserPermissions_UserId]
GO

ALTER TABLE [dbo].[RolePermissions] DROP CONSTRAINT [FK_RolePermissions_RoleId]
GO

ALTER TABLE [dbo].[UserPermissions] DROP CONSTRAINT [DF_UserPermissions_Granted]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[Users]
GO

/****** Object:  Table [dbo].[UserRoles]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[UserRoles]
GO

/****** Object:  Table [dbo].[UserPreferences]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[UserPreferences]
GO

/****** Object:  Table [dbo].[UserPermissions]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[UserPermissions]
GO

/****** Object:  Table [dbo].[Roles]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[Roles]
GO

/****** Object:  Table [dbo].[RolePermissions]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[RolePermissions]
GO

/****** Object:  Table [dbo].[Languages]    Script Date: 25/04/2018 3:35:08 PM ******/
DROP TABLE [dbo].[Languages]
GO

/****** Object:  Table [dbo].[Languages]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LanguageId] [nvarchar](10) NOT NULL,
	[LanguageName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[RolePermissions]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RolePermissions](
	[RolePermissionId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[PermissionKey] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[RolePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Roles]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[UserPermissions]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserPermissions](
	[UserPermissionId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[PermissionKey] [nvarchar](100) NOT NULL,
	[Granted] [bit] NOT NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[UserPermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[UserPreferences]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserPreferences](
	[UserPreferenceId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[PreferenceType] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserPreferences] PRIMARY KEY CLUSTERED 
(
	[UserPreferenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[UserRoles]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserRoles](
	[UserRoleId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Users]    Script Date: 25/04/2018 3:35:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NULL,
	[Source] [nvarchar](4) NOT NULL,
	[PasswordHash] [nvarchar](86) NOT NULL,
	[PasswordSalt] [nvarchar](10) NOT NULL,
	[LastDirectoryUpdate] [datetime] NULL,
	[UserImage] [nvarchar](100) NULL,
	[InsertDate] [datetime] NOT NULL,
	[InsertUserId] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUserId] [int] NULL,
	[IsActive] [smallint] NOT NULL CONSTRAINT [DF_Users_IsActive]  DEFAULT ((1)),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserPermissions] ADD  CONSTRAINT [DF_UserPermissions_Granted]  DEFAULT ((1)) FOR [Granted]
GO

ALTER TABLE [dbo].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO

ALTER TABLE [dbo].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_RoleId]
GO

ALTER TABLE [dbo].[UserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_UserPermissions_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[UserPermissions] CHECK CONSTRAINT [FK_UserPermissions_UserId]
GO

ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO

ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_RoleId]
GO

ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO

ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_UserId]
GO

SET IDENTITY_INSERT Users ON
GO
INSERT INTO [Users] ([UserId],[Username],[DisplayName],[Email],[Source],[PasswordHash],[PasswordSalt],[LastDirectoryUpdate],[UserImage],[InsertDate],[InsertUserId],[UpdateDate],[UpdateUserId],[IsActive])
VALUES (1,N'admin',N'admin',N'admin@dummy.com',N'site',N'rfqpSPYs0ekFlPyvIRTXsdhE/qrTHFF+kKsAUla7pFkXL4BgLGlTe89GDX5DBysenMDj8AqbIZPybqvusyCjwQ',N'hJf_F',NULL,NULL,'Jan  1 2014 12:00:00:000AM',1,NULL,NULL,1)
GO
SET IDENTITY_INSERT Users OFF
GO
SET IDENTITY_INSERT Languages ON
GO
INSERT INTO [Languages] ([Id],[LanguageId],[LanguageName])
VALUES (1,N'en',N'English')
GO
SET IDENTITY_INSERT Languages OFF
GO
SET IDENTITY_INSERT Languages ON
GO
INSERT INTO [Languages] ([Id],[LanguageId],[LanguageName])
VALUES (11,N'vi-VN',N'Vietnamese (Vietnam)')
GO
SET IDENTITY_INSERT Languages OFF
GO