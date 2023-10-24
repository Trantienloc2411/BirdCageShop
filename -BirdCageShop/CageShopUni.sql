USE [master]
GO
/****** Object:  Database [CageShopUni]    Script Date: 9/28/2023 7:39:14 AM ******/
CREATE DATABASE [CageShopUni]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountName] [varchar](50) NULL,
	[DiscountStart] [date] NULL,
	[DiscountFinish] [date] NULL,
	[Discount] [decimal](5, 2) NULL,
	[DiscountStatus] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[OrderID] [int] NULL,
	[RatingID] [int] NULL,
	[FeedBackName] [varchar](50) NULL,
	[FeedBackContent] [text] NULL,
	[Rating] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[DetailID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NULL,
	[CageID] [int] NULL,
	[DetailPrice] [decimal](8, 2) NULL,
	[DetailQuantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[OrderStatus] [varchar](20) NULL,
	[OrderPrice] [decimal](8, 2) NULL,
	[OrderDate] [date] NULL,
	[OrderAdress] [varchar](100) NULL,
	[OrderName] [varchar](50) NULL,
	[OrderPhone] [varchar](20) NULL,
	[PaymentID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[PaymentID] [int] IDENTITY(1,1) NOT NULL,
	[PaymentName] [nvarchar](50) NULL,
 CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[CageID] [int] IDENTITY(1,1) NOT NULL,
	[CageName] [varchar](50) NULL,
	[CategoryID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](8, 2) NULL,
	[DiscountID] [int] NULL,
	[CageIMG] [image] NULL,
	[Material] [nvarchar](50) NULL,
	[Size] [nvarchar](50) NULL,
	[Bar] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[CageStatus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/28/2023 7:39:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserPassword] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [varchar](100) NULL,
	[UserIMG] [image] NULL,
	[DoB] [date] NULL,
	[Status] [varchar](20) NULL,
	[RoleID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (1, N'Cage', N'A cage is the most common type of bird housing. It is typically made of metal or plastic and has a wire mesh or bars to allow for ventilation and visibility. Cages come in a variety of sizes and shapes to accommodate different types of birds.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (2, N'Aviary', N'An aviary is a large, open-air enclosure that is typically used to house multiple birds. Aviaries can be made of wood, metal, or plastic and can be freestanding or attached to a building.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (3, N'Flight Cage', N'A flight cage is a large, spacious cage that is designed to allow birds to fly. Flight cages are typically made of metal and have a wire mesh or bars that are spaced closely together to prevent birds from escaping.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (4, N'Show Cage', N'A show cage is a type of cage that is specifically designed for displaying birds in competitions. Show cages are typically made of wood or metal and have a variety of features that make them attractive, such as decorative trim and perches.')
GO
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (5, N'Travel Cage', N' A travel cage is a small, portable cage that is used to transport birds. Travel cages are typically made of plastic or metal and have a secure door to prevent birds from escaping.')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (1, N'Discount for Cage (5%)', CAST(N'2023-09-18' AS Date), CAST(N'2023-11-24' AS Date), CAST(0.05 AS Decimal(5, 2)), N'Ongoing')
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (2, N'Discount for Cage (15%)', CAST(N'2023-05-20' AS Date), CAST(N'2023-09-19' AS Date), CAST(0.15 AS Decimal(5, 2)), N'Ended')
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (1002, N'Discount for Travel Cage (10%)', CAST(N'2023-09-20' AS Date), CAST(N'2023-11-24' AS Date), CAST(0.10 AS Decimal(5, 2)), N'Not Start')
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (1003, N'Discount for Show Cage (20%)', CAST(N'2023-09-18' AS Date), CAST(N'2023-11-24' AS Date), CAST(0.20 AS Decimal(5, 2)), N'Ongoing')
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (1004, N'Discount for Aviary (20%)', CAST(N'2023-05-14' AS Date), CAST(N'2023-09-15' AS Date), CAST(0.20 AS Decimal(5, 2)), N'Ended')
GO
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (4, 1002, 2, 1, N'Materia very durability', N'This product is very good, I should buy one more. Keep it up!!!!', 4.5)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (5, 2, 1, 3, N'This shipping very slow', N'I ordered this age 3 weeks ago. But now still pending. What wrong with this! LMAO', 2)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (6, 1002, 2, 2, N'Material is not good', N'This material of this product still not hard. I can be curved when delivery!!!', 3)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (7, 1003, 3, 4, N'Bad', N'That''s bad!!! I wouldnt buy it anymore. ', 1)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (8, 1004, 4, 5, N'Excellent!!!!', N'This cage 10 out of 10! Keep it up.!!!!', 5)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (9, 1004, 5, 6, N'Not Bad', N'This cage still good but not better than Show Cage 02', 2.5)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (10, 1004, 5, 7, N'Bad', N'The space between the door with column too big, you should fix it!!!', 2)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (11, 1004, 5, 8, N'Too Expensive!!!', N'If with this money, I would recommend you buy Cage 04.', 2.5)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (12, 1006, 6, 9, N'Too Expensive!!!', N'Cost an arm and a leg !!!1', 2)
GO
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (13, 1006, 6, 10, N'Nice', N'Hope it will delivery soonnn!!!!', 5)
GO
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (1, 1, 1, CAST(3000.00 AS Decimal(8, 2)), 1)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (2, 2, 2, CAST(2999.00 AS Decimal(8, 2)), 1)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (3, 2, 8, CAST(5999.00 AS Decimal(8, 2)), 1)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (4, 3, 14, CAST(3000.00 AS Decimal(8, 2)), 2)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (5, 4, 8, CAST(5999.00 AS Decimal(8, 2)), 3)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (6, 5, 4, CAST(1999.00 AS Decimal(8, 2)), 2)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (7, 5, 6, CAST(3999.00 AS Decimal(8, 2)), 1)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (8, 5, 12, CAST(1999.00 AS Decimal(8, 2)), 4)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (10, 6, 1, CAST(3000.00 AS Decimal(8, 2)), 2)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (11, 6, 4, CAST(1999.00 AS Decimal(8, 2)), 3)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (12, 6, 7, CAST(2499.00 AS Decimal(8, 2)), 1)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity]) VALUES (13, 6, 12, CAST(1999.00 AS Decimal(8, 2)), 1)
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID]) VALUES (1, 2, N'Pending', CAST(2850.00 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'San Francisco, USA', N'TRAN TIEN LOC', N'0382381141', NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID]) VALUES (2, 1002, N'Deliveried', CAST(7798.20 AS Decimal(8, 2)), CAST(N'2023-09-14' AS Date), N'13 Ward, Go Vap, HCMC', N'TRAN THANH TIEN', N'0819477503', NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID]) VALUES (3, 1003, N'Delivered', CAST(5700.00 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'HCMC', N'NGUYEN VAN Q ', N'011111', NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID]) VALUES (4, 1004, N'Delivering', CAST(14397.60 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'HCMC', N'TRAN VAN B', N'011111', NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID]) VALUES (5, 1004, N'Delivered', CAST(14593.65 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'HCMC', N'TRAN VAN A', N'011111', NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID]) VALUES (6, 1006, N'Delivering', CAST(14895.65 AS Decimal(8, 2)), CAST(N'2023-09-17' AS Date), N'HCMC', N'PHAN VAN ANH', N'011111', NULL)
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (1, N'Cage 03', 1, 281, CAST(3000.00 AS Decimal(8, 2)), 1, NULL, N'Wood', N'S', 40, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (2, N'Aviary 01', 2, 110, CAST(2999.00 AS Decimal(8, 2)), NULL, NULL, N'Metal', N'L', 60, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (3, N'Flight Cage 01', 3, 11, CAST(3999.00 AS Decimal(8, 2)), NULL, NULL, N'Metal', N'XXL', 90, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (4, N'Show Cage 01', 4, 201, CAST(1999.00 AS Decimal(8, 2)), 1003, NULL, N'Plastic', N'XL', 35, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (5, N'Travel Cage 01', 5, 20, CAST(4999.00 AS Decimal(8, 2)), NULL, NULL, N'Wood', N'L', 80, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (6, N'Cage 02', 1, 0, CAST(3999.00 AS Decimal(8, 2)), 1, NULL, N'Wood', N'S', 75, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (7, N'Aviary 02', 2, 2, CAST(2499.00 AS Decimal(8, 2)), NULL, NULL, N'Wood', N'L', 60, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (8, N'Show Cage 02', 3, 31, CAST(5999.00 AS Decimal(8, 2)), 1003, NULL, N'Wood', N'XXL', 110, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (9, N'Travel Cage 03', 5, 0, CAST(899.00 AS Decimal(8, 2)), NULL, NULL, N'Plastic', N'L', 60, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (10, N'Show Cage 03', 4, 21, CAST(6999.00 AS Decimal(8, 2)), NULL, NULL, N'Wood', N'XL', 85, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (11, N'Cage 04', 1, 21, CAST(799.00 AS Decimal(8, 2)), 1, NULL, N'Plastic', N'S', 35, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (12, N'Cage 06', 1, 100, CAST(1999.00 AS Decimal(8, 2)), 1, NULL, N'Steel', N'S', 45, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (13, N'Cage 05', 1, 121, CAST(2999.00 AS Decimal(8, 2)), 1, NULL, N'Wood', N'S', 40, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (14, N'Cage 09', 1, 1000, CAST(3000.00 AS Decimal(8, 2)), 1, NULL, N'Wood', N'S', 45, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [CageIMG], [Material], [Size], [Bar], [Description], [CageStatus]) VALUES (1002, N'Travel Cage 05', 5, 40, CAST(3000.00 AS Decimal(8, 2)), NULL, NULL, N'Plastic', N'L', 30, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', NULL)
GO
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (1, N'User')
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (2, N'Adminstrator')
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (3, N'Shopkeeper')
GO
INSERT [dbo].[Role] ([RoleID], [RoleName]) VALUES (4, NULL)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (1, N'admin', N'admin123', N'admin@gmail.com', N'033162813', NULL, NULL, CAST(N'1999-08-12' AS Date), N'Active', 2)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (2, N'User2912', N'2912', N'user@gmail.com', N'0382381141', N'San Francisco, USA', NULL, CAST(N'1983-12-01' AS Date), N'Active', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (3, N'ShopCageHCM', N'123', N'shopkeeper@gmail.com', N'085385823', N'Quan 3, HCMC', NULL, CAST(N'1992-10-21' AS Date), N'Active', 3)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (4, N'ShopCageThuDuc', N'111', N'shopcagethuduc@gmail.com', N'0424424884', N'Phuoc Long B, Thu Duc, Ho Chi Minh', NULL, CAST(N'1993-07-01' AS Date), N'Suspended', 3)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (5, N'User11', N'1', N'user11@gmail.com', N'034348233', N'11 Ward, Binh Thanh', NULL, CAST(N'1984-03-20' AS Date), N'Suspended', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (1002, N'user1', N'1', N'user1@gmail.com', N'0819477503', N'13 Ward, Go Vap, HCMC', NULL, CAST(N'1988-11-23' AS Date), N'Active', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (1003, N'UserV', N'1', NULL, N'011111', N'HCMC', NULL, NULL, N'Active', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (1004, N'UserV2', N'1', NULL, N'0111111', N'HCMC', NULL, NULL, N'Active ', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (1005, N'UserV3', N'1', NULL, N'0232333', N'HCMC', NULL, NULL, N'Active', 1)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [UserIMG], [DoB], [Status], [RoleID]) VALUES (1006, N'UserV4', N'1', NULL, N'034234234', N'HCMC', NULL, NULL, N'Active', 1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Users]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([CageID])
REFERENCES [dbo].[Product] ([CageID])
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentMethod] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[PaymentMethod] ([PaymentID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentMethod]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discount] ([DiscountID])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
USE [master]
GO
ALTER DATABASE [CageShopUni] SET  READ_WRITE 
GO
