USE [master]
GO
/****** Object:  Database [CageShopUni_ala]    Script Date: 11/11/2023 9:27:55 AM ******/
CREATE DATABASE [CageShopUni_ala]
USE [CageShopUni_ala]
GO
/****** Object:  Table [dbo].[Accessory]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accessory](
	[AccessoryID] [int] IDENTITY(1,1) NOT NULL,
	[AccessoryName] [nvarchar](50) NULL,
	[AccessoryPrice] [float] NULL,
	[AccessoryDescription] [nvarchar](255) NULL,
	[AccessoryQuantity] [int] NULL,
	[AccessoryStatus] [int] NULL,
	[CategoryID] [int] NULL,
	[DiscountID] [int] NULL,
	[AccessoryIMG] [nvarchar](max) NULL,
 CONSTRAINT [PK_Accessories] PRIMARY KEY CLUSTERED 
(
	[AccessoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK__Category__19093A2B117C88DF] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[DiscountID] [int] IDENTITY(1,1) NOT NULL,
	[DiscountName] [nvarchar](50) NULL,
	[DiscountStart] [date] NULL,
	[DiscountFinish] [date] NULL,
	[Discount] [decimal](5, 2) NULL,
	[DiscountStatus] [varchar](20) NULL,
 CONSTRAINT [PK__Discount__E43F6DF6FBB06ADC] PRIMARY KEY CLUSTERED 
(
	[DiscountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[OrderID] [int] NULL,
	[RatingID] [int] NULL,
	[FeedBackName] [nvarchar](50) NULL,
	[FeedBackContent] [text] NULL,
	[Rating] [float] NULL,
 CONSTRAINT [PK__Feedback__6A4BEDF6BB4C2459] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/11/2023 9:27:55 AM ******/
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
	[AccessoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[DetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/11/2023 9:27:55 AM ******/
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
	[OrderAdress] [nvarchar](100) NULL,
	[OrderName] [nvarchar](50) NULL,
	[OrderPhone] [varchar](20) NULL,
	[PaymentID] [int] NULL,
	[Note] [nvarchar](255) NULL,
 CONSTRAINT [PK__Orders__C3905BAF3AD396CC] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 11/11/2023 9:27:55 AM ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[CageID] [int] IDENTITY(1,1) NOT NULL,
	[CageName] [nvarchar](50) NULL,
	[CategoryID] [int] NULL,
	[Quantity] [int] NULL,
	[Price] [decimal](8, 2) NULL,
	[DiscountID] [int] NULL,
	[Material] [nvarchar](50) NULL,
	[Size] [nvarchar](50) NULL,
	[Bar] [int] NULL,
	[Description] [nvarchar](max) NULL,
	[CageStatus] [int] NULL,
	[CageIMG] [nvarchar](max) NULL,
 CONSTRAINT [PK__Product__792D9FBA31E8206C] PRIMARY KEY CLUSTERED 
(
	[CageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NULL,
 CONSTRAINT [PK__Role__8AFACE3ABFC3AE1B] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/11/2023 9:27:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[UserPassword] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](20) NULL,
	[Address] [nvarchar](100) NULL,
	[DoB] [date] NULL,
	[Status] [varchar](20) NULL,
	[RoleID] [int] NULL,
	[Gender] [nchar](10) NULL,
	[UserIMG] [nvarchar](max) NULL,
 CONSTRAINT [PK__Users__1788CCACD54997FB] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Accessory] ON 
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (1, N'Cửa lồng chim', 2000, N'Phụ kiện thay thế cửa lồng chim', 1, 1, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (2, N'Nắp lồng chim ', 1200, N'Phụ kiện thay nắp lồng chim', 12, 1, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (3, N'Cây trang trí', 1393, N'Phụ kiện tạo địa hình giúp chim gần gũi với thiên nhiên hơn', 31, 1, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (4, N'Khung lồng chim', 2990, N'Khung lồng chim (dành cho tự "độ" lồng mới) có kích thước 40x40x40 (DxRxC)', 60, 1, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (5, N'Nắp lồng chim 1', 1199, N'Nắp lồng chim có thể dùng che nắng(mưa) cho chim giúp chim có khả năng sinh sống cao hơn', 40, 0, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (6, N'Nắp lồng chim 2', 1200, N'Nắp lồng chim có thể dùng che nắng(mưa) cho chim giúp chim có khả năng sinh sống cao hơn', 100, 1, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (7, N'Khay thức ăn 1', 2000, N'Khay thức ăn giúp chim có thể ăn tránh lãng phí nguồn thức ăn của nó ', 300, 1, 6, NULL, NULL)
GO
INSERT [dbo].[Accessory] ([AccessoryID], [AccessoryName], [AccessoryPrice], [AccessoryDescription], [AccessoryQuantity], [AccessoryStatus], [CategoryID], [DiscountID], [AccessoryIMG]) VALUES (8, N'Khay uống nước', 1599, N'Khay uống nước giúp chim có khả năng uống nước mà không lo bị bẩn và cặn đồ ăn ', 210, 1, 6, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Accessory] OFF
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
INSERT [dbo].[Category] ([CategoryID], [CategoryName], [Description]) VALUES (6, N'Ph? kiên', N'Phụ kiện dành cho lồng chim')
GO
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (1, N'Discount for Cage (5%)', CAST(N'2023-09-18' AS Date), CAST(N'2023-11-24' AS Date), CAST(0.05 AS Decimal(5, 2)), N'Ongoing')
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (2, N'Discount for Cage (15%)', CAST(N'2023-05-20' AS Date), CAST(N'2023-09-19' AS Date), CAST(0.15 AS Decimal(5, 2)), N'Ended')
GO
INSERT [dbo].[Discount] ([DiscountID], [DiscountName], [DiscountStart], [DiscountFinish], [Discount], [DiscountStatus]) VALUES (1002, N'Discount for Travel Cage (10%)', CAST(N'2023-09-20' AS Date), CAST(N'2023-11-24' AS Date), CAST(0.10 AS Decimal(5, 2)), N'Ongoing')
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
INSERT [dbo].[Feedback] ([FeedbackID], [UserID], [OrderID], [RatingID], [FeedBackName], [FeedBackContent], [Rating]) VALUES (14, 1002, 21, NULL, N'Sản phẩm này tốt lắm m.n ơi', N'10d?m', 5)
GO
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (1, 1, 1, CAST(3000.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (2, 2, 2, CAST(2999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (3, 2, 8, CAST(5999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (4, 3, 14, CAST(3000.00 AS Decimal(8, 2)), 2, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (5, 4, 8, CAST(5999.00 AS Decimal(8, 2)), 3, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (6, 5, 4, CAST(1999.00 AS Decimal(8, 2)), 2, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (7, 5, 6, CAST(3999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (8, 5, 12, CAST(1999.00 AS Decimal(8, 2)), 4, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (10, 6, 1, CAST(3000.00 AS Decimal(8, 2)), 2, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (11, 6, 4, CAST(1999.00 AS Decimal(8, 2)), 3, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (12, 6, 7, CAST(2499.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (13, 6, 12, CAST(1999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (36, 15, 5, CAST(4999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (37, 16, 4, CAST(1599.20 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (38, 16, 5, CAST(4999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (39, 16, 7, CAST(2499.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (40, 17, 1, CAST(2850.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (41, 17, 5, CAST(4999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (42, 17, 3, CAST(3999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (43, 17, 7, CAST(2499.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (44, 18, 1, CAST(2850.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (45, 18, 5, CAST(4999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (46, 18, 3, CAST(3999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (47, 18, 7, CAST(2499.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (48, 19, 5, CAST(4999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (49, 20, 1, CAST(2850.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (50, 20, 2, CAST(2999.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (51, 21, 1, CAST(2850.00 AS Decimal(8, 2)), 1, NULL)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (52, 21, NULL, CAST(2000.00 AS Decimal(8, 2)), 1, 1)
GO
INSERT [dbo].[OrderDetail] ([DetailID], [OrderID], [CageID], [DetailPrice], [DetailQuantity], [AccessoryID]) VALUES (53, 22, 1, CAST(3000.00 AS Decimal(8, 2)), 4, NULL)
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (1, 2, N'Pending', CAST(2850.00 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'San Francisco, USA', N'TRAN TIEN LOC', N'0382381141', NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (2, 1002, N'Delivered', CAST(7798.20 AS Decimal(8, 2)), CAST(N'2023-09-14' AS Date), N'13 Ward, Go Vap, HCMC', N'TRAN THANH TIEN', N'0819477503', NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (3, 1003, N'Delivered', CAST(5700.00 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'HCMC', N'NGUYEN VAN Q ', N'011111', NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (4, 1004, N'Delivering', CAST(14397.60 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'HCMC', N'TRAN VAN B', N'011111', NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (5, 1004, N'Delivered', CAST(14593.65 AS Decimal(8, 2)), CAST(N'2023-09-18' AS Date), N'HCMC', N'TRAN VAN A', N'011111', NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (6, 1006, N'Delivering', CAST(14895.65 AS Decimal(8, 2)), CAST(N'2023-09-17' AS Date), N'HCMC', N'PHAN VAN ANH', N'011111', NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (15, 1002, N'Canceling', CAST(0.00 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, N'New York')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (16, 1002, N'Pending', CAST(9107.20 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, N'')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (17, 1002, N'Pending', CAST(14357.00 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, N'')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (18, 1002, N'Pending', CAST(14357.00 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, N'')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (19, 1002, N'Pending', CAST(5009.00 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, N'')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (20, 1002, N'Canceling', CAST(5859.00 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, N'')
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (21, 1002, N'Delivered', CAST(4860.00 AS Decimal(8, 2)), CAST(N'2023-11-03' AS Date), N'13 Ward, Go Vap, HCMC', N'user1', N'0819477503', 1, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (22, 1002, N'Cart', CAST(3000.00 AS Decimal(8, 2)), CAST(N'2023-11-06' AS Date), NULL, N'Trần Tiến Lộc', NULL, NULL, NULL)
GO
INSERT [dbo].[Orders] ([OrderID], [UserID], [OrderStatus], [OrderPrice], [OrderDate], [OrderAdress], [OrderName], [OrderPhone], [PaymentID], [Note]) VALUES (23, 1002, N'Canceling', CAST(10.00 AS Decimal(8, 2)), CAST(N'2023-11-07' AS Date), N'13 Ward, Go Vap, HCMC', N'Trần Tiến Lộc', N'0819477503', 1, N'')
GO
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentMethod] ON 
GO
INSERT [dbo].[PaymentMethod] ([PaymentID], [PaymentName]) VALUES (1, N'COD')
GO
INSERT [dbo].[PaymentMethod] ([PaymentID], [PaymentName]) VALUES (2, N'Banking Online')
GO
SET IDENTITY_INSERT [dbo].[PaymentMethod] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (1, N'LỒNG HOẠ MI CHẠM NGŨ LÂN VỜN', 1, 281, CAST(2890.00 AS Decimal(8, 2)), 1, N'Gỗ', N'S', 56, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/43536-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (2, N'LỒNG HOẠ MI CHẠM NHO SÓC', 2, 110, CAST(2999.00 AS Decimal(8, 2)), NULL, N'Nhôm', N'L', 60, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/qrq-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (3, N'LỒNG HOẠ MI CHẠM TAM QUỐC', 3, 11, CAST(3999.00 AS Decimal(8, 2)), NULL, N'Nhôm', N'XXL', 90, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/8333-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (4, N'LỒNG KHUYÊN CHẠM BÁT TIÊN', 4, 201, CAST(1999.00 AS Decimal(8, 2)), 1003, N'Nhựa', N'XL', 35, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/long-chao-mao-17-nan-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (5, N'LỒNG KHUYÊN CHẠM LONG PHỤNG', 5, 20, CAST(4999.00 AS Decimal(8, 2)), NULL, N'Gỗ', N'L', 80, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/2223444-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (6, N'LỒNG KHUYÊN CHẠM BÁT MÃ PHONG THỦY', 1, 0, CAST(3999.00 AS Decimal(8, 2)), 1, N'Gỗ', N'S', 75, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 0, N'Content/Image/9999-1-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (7, N'LỒNG CHIM YẾN, KHUYÊN, CHÒE ĐẤT LÀM BẰNG NHỰA', 2, 2, CAST(2499.00 AS Decimal(8, 2)), NULL, N'Gỗ', N'L', 60, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/wwwr-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (8, N'LỒNG YẾN, CHÒE ĐẤT CHẠM RỒNG', 3, 31, CAST(5999.00 AS Decimal(8, 2)), 1003, N'Gỗ', N'XXL', 110, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/long-mi-hot-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (9, N'LỒNG CHIM CHÀO MÀO CHẠM RỒNG', 5, 0, CAST(899.00 AS Decimal(8, 2)), NULL, N'Nhựa', N'L', 60, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/sds-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (10, N'LỒNG HOẠ MI CHẠM LOUIS VUITTON', 4, 21, CAST(6999.00 AS Decimal(8, 2)), NULL, N'Gỗ', N'XL', 85, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 0, N'Content/Image/66-1-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (11, N'LỒNG CHIM HỌA MI CHẠM - TÍCH TRIỆN CHIẾN', 1, 21, CAST(799.00 AS Decimal(8, 2)), 1, N'Nhựa', N'S', 35, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/6665555-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (12, N'LỒNG KHUYÊN CHẠM LƯ ĐỈNH', 1, 100, CAST(1999.00 AS Decimal(8, 2)), 1, N'Thép', N'S', 45, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/252-2-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (13, N'LỒNG KHUYÊN CHẠM ĐỐT TRÚC', 1, 121, CAST(2999.00 AS Decimal(8, 2)), 1, N'Gỗ', N'S', 40, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/kk-2-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (14, N'LỒNG KHUYÊN LÁ ĐỀ KỸ', 1, 1000, CAST(3000.00 AS Decimal(8, 2)), 1, N'Gỗ', N'S', 45, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/nnn-1-220x300.jpg')
GO
INSERT [dbo].[Product] ([CageID], [CageName], [CategoryID], [Quantity], [Price], [DiscountID], [Material], [Size], [Bar], [Description], [CageStatus], [CageIMG]) VALUES (1002, N'LỒNG KHUYÊN CHẠM SONG LONG', 5, 40, CAST(3000.00 AS Decimal(8, 2)), NULL, N'Gỗ', N'L', 30, N'Lồng chim gỗ 40 nan là loại lồng chim phổ biến, được làm từ chất liệu gỗ tự nhiên, có 40 nan bằng nhau, tạo thành một hình tròn hoặc vuông. Loại lồng này có kích thước vừa phải, phù hợp với nhiều loại chim khác nhau. ', 1, N'Content/Image/65757-220x300.jpg')
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
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1, N'admin', N'admin123', N'admin@gmail.com', N'033162813', NULL, CAST(N'1999-08-12' AS Date), N'Active', 2, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (2, N'User2912', N'2912', N'user@gmail.com', N'0382381141', N'San Francisco, USA', CAST(N'1983-12-01' AS Date), N'Active', 1, N'Female    ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (3, N'ShopCageHCM', N'123', N'shopkeeper@gmail.com', N'085385823', N'Quan 3, HCMC', CAST(N'1992-10-21' AS Date), N'Active', 3, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (4, N'ShopCageThuDuc', N'111', N'shopcagethuduc@gmail.com', N'0424424884', N'Phuoc Long B, Thu Duc, Ho Chi Minh', CAST(N'1993-07-01' AS Date), N'Suspended', 3, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (5, N'User11', N'1', N'user11@gmail.com', N'034348233', N'11 Ward, Binh Thanh', CAST(N'1984-03-20' AS Date), N'Suspended', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1002, N'Trần Tiến Lộc', N'1', N'user1@gmail.com', N'0819477503', N'13 Ward, Go Vap, HCMC', CAST(N'1988-11-23' AS Date), N'Active', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1003, N'UserV', N'1', N'1@gmail.com', N'011111', N'HCMC', CAST(N'2000-07-01' AS Date), N'Active', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1004, N'UserV2', N'1', N'2@gmail.com', N'0111111', N'HCMC', CAST(N'1999-12-23' AS Date), N'Active ', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1005, N'UserV3', N'1', N'3@gmail.com', N'0232333', N'HCMC', CAST(N'1996-07-19' AS Date), N'Active', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1006, N'UserV4', N'1', N'4@gmail.com', N'034234234', N'HCMC', CAST(N'2003-11-24' AS Date), N'Active', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1009, N'Tran Tien Loc', N'1', N'onlyaccgame2411@gmail.com', N'0334464451', N'Thu Duc HCMC', CAST(N'2003-11-24' AS Date), N'Active', 1, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1012, N'aaed', N'1', N'd@gmail.com', N'0353023282', N'dsads', CAST(N'2023-10-28' AS Date), N'Active', NULL, N'Male      ', NULL)
GO
INSERT [dbo].[Users] ([UserID], [UserName], [UserPassword], [Email], [Phone], [Address], [DoB], [Status], [RoleID], [Gender], [UserIMG]) VALUES (1013, N'Đăng Quang', N'1', N'bus@do.com', NULL, NULL, NULL, N'Active', 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Accessory]  WITH CHECK ADD  CONSTRAINT [FK_Accessory_Category] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Accessory] CHECK CONSTRAINT [FK_Accessory_Category]
GO
ALTER TABLE [dbo].[Accessory]  WITH CHECK ADD  CONSTRAINT [FK_Accessory_Discount] FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discount] ([DiscountID])
GO
ALTER TABLE [dbo].[Accessory] CHECK CONSTRAINT [FK_Accessory_Discount]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK__Feedback__OrderI__33D4B598] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK__Feedback__OrderI__33D4B598]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Users]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__CageI__35BCFE0A] FOREIGN KEY([CageID])
REFERENCES [dbo].[Product] ([CageID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__CageI__35BCFE0A]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__36B12243] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK__OrderDeta__Order__36B12243]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Accessory] FOREIGN KEY([AccessoryID])
REFERENCES [dbo].[Accessory] ([AccessoryID])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Accessory]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_PaymentMethod] FOREIGN KEY([PaymentID])
REFERENCES [dbo].[PaymentMethod] ([PaymentID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_PaymentMethod]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Categor__38996AB5] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Categor__38996AB5]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK__Product__Discoun__398D8EEE] FOREIGN KEY([DiscountID])
REFERENCES [dbo].[Discount] ([DiscountID])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK__Product__Discoun__398D8EEE]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK__Users__RoleID__3A81B327] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK__Users__RoleID__3A81B327]
GO
USE [master]
GO
ALTER DATABASE [CageShopUni_ala] SET  READ_WRITE 
GO
