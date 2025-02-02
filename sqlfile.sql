USE [ShopeeFoodApp]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Percentage] [float] NOT NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[id] [varchar](5) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[ProvinceId] [varchar](5) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[StoreId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[PhoneNumber] [varchar](20) NULL,
	[AddressId] [int] NULL,
	[StoreAddress] [varchar](255) NULL,
	[Note] [varchar](100) NULL,
	[OrderDate] [datetime2](7) NULL,
	[Status] [int] NULL,
	[TotalMoney] [float] NULL,
	[RecipientName] [varchar](50) NULL,
	[StoreName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NULL,
	[ProductName] [varchar](100) NULL,
	[Price] [float] NULL,
	[Amount] [int] NULL,
	[TotalMoney] [float] NULL,
	[ProductImage] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SubCategoryId] [int] NOT NULL,
	[StoreId] [int] NOT NULL,
	[DiscountId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [float] NOT NULL,
	[Image] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CategoryId] [int] NULL,
	[ExpireAt] [datetime2](7) NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product_Menu]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Menu](
	[MenuId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Description] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[id] [varchar](5) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[type] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[OpenTime] [time](7) NOT NULL,
	[CloseTime] [time](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[SubCategoryId] [int] NULL,
	[CategoryId] [int] NULL,
	[MaxPrice] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StoreAddress]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StoreAddress](
	[id] [int] NOT NULL,
	[StoreId] [int] NULL,
	[Street] [varchar](255) NULL,
	[WardId] [varchar](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategory]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[CategoryId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Status] [tinyint] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[PasswordResetToken] [nvarchar](max) NULL,
	[PasswordResetTokenExpiry] [datetime2](7) NULL,
	[IsEmailVerified] [bit] NOT NULL,
	[VerificationEmailToken] [nvarchar](max) NULL,
	[VerificationEmailTokenExpiry] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAddress]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAddress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Street] [nvarchar](255) NULL,
	[WardId] [nvarchar](50) NULL,
	[NameReminiscent] [nvarchar](255) NULL,
	[PhoneNumber] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 9/13/2024 11:24:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ward](
	[id] [varchar](5) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[type] [varchar](30) NOT NULL,
	[DistrictId] [varchar](5) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240725024515_InitDbBase', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240725030511_AddFKForStoreAndDiscount', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240725034111_SeedDataToTable', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240725041106_CreateCateAndSubTable', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240729150931_addTokenAndExpired', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240801034354_UpdateUserTable', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240806043121_UpdateProductTable', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240807025028_updateUserData', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240807094322_updateProductsTable', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240808031007_updateSubCate', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240808033054_updateSubCate1', N'8.0.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240808035923_removeProduct', N'8.0.7')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (1, N'Food', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2024-08-15T15:38:32.0876347' AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (2, N'Fresh', CAST(N'2024-07-30T10:45:03.0861983' AS DateTime2), CAST(N'2024-08-07T10:45:03.0862020' AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (3, N'Liquid/Beer', CAST(N'2024-07-10T10:45:03.0873569' AS DateTime2), CAST(N'2024-07-27T10:45:03.0873582' AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (4, N'Flowers', CAST(N'2024-07-31T10:45:03.0874172' AS DateTime2), CAST(N'2024-07-16T10:45:03.0874179' AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (5, N'Mart', CAST(N'2024-08-07T10:45:03.0874639' AS DateTime2), CAST(N'2024-07-13T10:45:03.0874646' AS DateTime2))
INSERT [dbo].[Category] ([Id], [Name], [CreatedAt], [UpdatedAt]) VALUES (6, N'Medicines', CAST(N'2024-07-17T10:45:03.0875022' AS DateTime2), CAST(N'2024-07-10T10:45:03.0875028' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Discount] ON 

INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (1, N'Discount 1', 29, CAST(N'2024-07-17T11:45:13.5686865' AS DateTime2), CAST(N'2024-08-12T11:45:13.5687608' AS DateTime2), N'Description for Discount 1', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (2, N'Discount 2', 18, CAST(N'2024-07-19T11:45:13.5877091' AS DateTime2), CAST(N'2024-08-16T11:45:13.5877113' AS DateTime2), N'Description for Discount 2', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (3, N'Discount 3', 20, CAST(N'2024-07-18T11:45:13.5878927' AS DateTime2), CAST(N'2024-08-21T11:45:13.5878933' AS DateTime2), N'Description for Discount 3', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (4, N'Discount 4', 12, CAST(N'2024-07-22T11:45:13.5879887' AS DateTime2), CAST(N'2024-08-18T11:45:13.5879895' AS DateTime2), N'Description for Discount 4', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (5, N'Discount 5', 35, CAST(N'2024-07-20T11:45:13.5880591' AS DateTime2), CAST(N'2024-08-14T11:45:13.5880597' AS DateTime2), N'Description for Discount 5', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (6, N'Discount 6', 12, CAST(N'2024-07-16T11:45:13.5881161' AS DateTime2), CAST(N'2024-08-20T11:45:13.5881166' AS DateTime2), N'Description for Discount 6', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (7, N'Discount 7', 16, CAST(N'2024-07-23T11:45:13.5882006' AS DateTime2), CAST(N'2024-08-21T11:45:13.5882013' AS DateTime2), N'Description for Discount 7', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (8, N'Discount 8', 9, CAST(N'2024-07-20T11:45:13.5882500' AS DateTime2), CAST(N'2024-08-17T11:45:13.5882506' AS DateTime2), N'Description for Discount 8', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (9, N'Discount 9', 13, CAST(N'2024-07-21T11:45:13.5883337' AS DateTime2), CAST(N'2024-08-20T11:45:13.5883343' AS DateTime2), N'Description for Discount 9', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (10, N'Discount 10', 39, CAST(N'2024-07-16T11:45:13.5884209' AS DateTime2), CAST(N'2024-08-14T11:45:13.5884215' AS DateTime2), N'Description for Discount 10', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (11, N'Discount 11', 8, CAST(N'2024-07-19T11:45:13.5884674' AS DateTime2), CAST(N'2024-08-09T11:45:13.5884679' AS DateTime2), N'Description for Discount 11', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (12, N'Discount 12', 24, CAST(N'2024-07-16T11:45:13.5885215' AS DateTime2), CAST(N'2024-08-14T11:45:13.5885219' AS DateTime2), N'Description for Discount 12', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (13, N'Discount 13', 47, CAST(N'2024-07-22T11:45:13.5885749' AS DateTime2), CAST(N'2024-08-10T11:45:13.5885754' AS DateTime2), N'Description for Discount 13', 1, N'https://down-bs-vn.img.susercontent.com/vn-11134512-7r98o-ly4kirq58gjn65@resize_ss320x320!')
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (14, N'Discount 14', 1, CAST(N'2024-07-19T11:45:13.5886239' AS DateTime2), CAST(N'2024-08-12T11:45:13.5886244' AS DateTime2), N'Description for Discount 14', 1, NULL)
INSERT [dbo].[Discount] ([Id], [Name], [Percentage], [StartDate], [EndDate], [Description], [Status], [Image]) VALUES (15, N'Discount 15', 10, CAST(N'2024-07-17T11:45:13.5887014' AS DateTime2), CAST(N'2024-08-09T11:45:13.5887020' AS DateTime2), N'Description for Discount 15', 1, NULL)
SET IDENTITY_INSERT [dbo].[Discount] OFF
GO
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'001', N'Ba Dinh', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'002', N'Hoan Kiem', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'003', N'Tay Ho', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'004', N'Long Bien', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'005', N'Cau Giay', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'006', N'Dong Da', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'007', N'Hai Ba Trung', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'008', N'Hoang Mai', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'009', N'Thanh Xuan', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'016', N'Soc Son', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'017', N'Dong Anh', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'018', N'Gia Lam', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'019', N'Nam Tu Liem', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'020', N'Thanh Tri', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'021', N'Bac Tu Liem', N'District', N'01')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'024', N'Ha Giang', N'City', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'026', N'Dong Van', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'027', N'Meo Vac', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'028', N'Yen Minh', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'029', N'Quan Ba', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'030', N'Vi Xuyen', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'031', N'Bac Me', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'032', N'Hoang Su Phi', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'033', N'Xin Man', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'034', N'Bac Quang', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'035', N'Quang Binh', N'District', N'02')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'040', N'Cao Bang', N'City', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'042', N'Bao Lam', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'043', N'Bao Lac', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'044', N'Thong Nong', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'045', N'Ha Quang', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'046', N'Tra Linh', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'047', N'Trung Khanh', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'048', N'Ha Lang', N'District', N'04')
INSERT [dbo].[District] ([id], [name], [type], [ProvinceId]) VALUES (N'049', N'Quang Uyen', N'District', N'04')
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([Id], [Name], [StoreId], [Description]) VALUES (1, N'Crispy Chicken with Kimchi Sauce – Delicious, Rich Korean Flavor', 1, N'Crispy Chicken with Kimchi Sauce – Delicious, Rich Korean Flavor')
INSERT [dbo].[Menu] ([Id], [Name], [StoreId], [Description]) VALUES (2, N'Lunch Menu', 1, N'Midday meals including sandwiches, salads, and soups')
INSERT [dbo].[Menu] ([Id], [Name], [StoreId], [Description]) VALUES (3, N'Dinner Menu', 2, N'Evening meals with a variety of main courses and desserts')
INSERT [dbo].[Menu] ([Id], [Name], [StoreId], [Description]) VALUES (4, N'Beverages', 2, N'Selection of drinks including soft drinks, juices, and wines')
INSERT [dbo].[Menu] ([Id], [Name], [StoreId], [Description]) VALUES (5, N'Special Offers', 3, N'Discounted items and combo deals available this week')
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [UserId], [PhoneNumber], [AddressId], [StoreAddress], [Note], [OrderDate], [Status], [TotalMoney], [RecipientName], [StoreName]) VALUES (30, 1, N'0345234545', 2, N'Nguyen Van Cu, Phuc Xa, Ba Dinh, Ha Noi', N'Leave the package at the front door', CAST(N'2024-09-12T15:30:29.4002991' AS DateTime2), 0, 76000, N'gfdgsdfg', N'Store 1 update')
INSERT [dbo].[Order] ([Id], [UserId], [PhoneNumber], [AddressId], [StoreAddress], [Note], [OrderDate], [Status], [TotalMoney], [RecipientName], [StoreName]) VALUES (31, 1, N'0123164152', 1, N'Nguyen Van Cu, Phuc Xa, Ba Dinh, Ha Noi', N'Leave the package at the front door', CAST(N'2024-09-12T15:30:59.4425782' AS DateTime2), 0, 118000, N'User', N'Store 1 update')
INSERT [dbo].[Order] ([Id], [UserId], [PhoneNumber], [AddressId], [StoreAddress], [Note], [OrderDate], [Status], [TotalMoney], [RecipientName], [StoreName]) VALUES (32, 1, N'0345234545', 2, N'Nguyen Van Cu, Phuc Xa, Ba Dinh, Ha Noi', N'Leave the package at the front door', CAST(N'2024-09-12T17:13:31.8417155' AS DateTime2), 0, 336000, N'gfdgsdfg', N'Texas Chiken')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (1, 19, N'Product 2', 29990, 1, 29990, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsval603wzwk22@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (2, 19, N'Product 1', 19990, 2, 39980, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu55i11bqmx52@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (3, 20, N'Product 1', 23000, 1, 23000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu55i11bqmx52@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (4, 20, N'Product 2', 30000, 2, 60000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsval603wzwk22@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (5, 29, N'Product 3', 15000, 2, 30000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv6lmyt8xj847@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (6, 29, N'Product 2', 30000, 1, 30000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsval603wzwk22@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (7, 30, N'Product 1', 23000, 2, 46000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu55i11bqmx52@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (8, 30, N'Product 2', 30000, 1, 30000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsval603wzwk22@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (9, 31, N'Product 4', 50000, 1, 50000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv21q8k90uxa6@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (10, 31, N'Product 3', 15000, 1, 15000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv6lmyt8xj847@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (11, 31, N'Product 2', 30000, 1, 30000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsval603wzwk22@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (12, 31, N'Product 1', 23000, 1, 23000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu55i11bqmx52@resize_ss280x175!@crop_w280_h175_cT')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (13, 32, N'1 Crispy Chicken with Kimchi Sauce', 49000, 2, 98000, N'https://down-bs-vn.img.susercontent.com/vn-11134517-7r98o-lvsbzggavx7e33')
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [ProductName], [Price], [Amount], [TotalMoney], [ProductImage]) VALUES (14, 32, N'Combo - Crispy Chicken with Kimchi Sauce', 119000, 2, 238000, N'https://down-bs-vn.img.susercontent.com/vn-11134517-7r98o-lvsc09cslae25a')
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (1, 2, 1, 1, N'1 Crispy Chicken with Kimchi Sauce', 49000, N'https://down-bs-vn.img.susercontent.com/vn-11134517-7r98o-lvsbzggavx7e33', N'- 1 Piece of crispy chicken with kimchi sauce - 1 Tomato sauce', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 2)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (2, 2, 1, 2, N'Combo - Crispy Chicken with Kimchi Sauce', 119000, N'https://down-bs-vn.img.susercontent.com/vn-11134517-7r98o-lvsc09cslae25a', N'- 2 pieces of crispy chicken with kimchi sauce - 1 standard size mixed cabbage - 1 soft drink - 1 chili sauce + 1 tomato sauce', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 3)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (3, 4, 3, 4, N'Bánh Cuộn Kim Long – Cỡ Tiêu Chuẩn', 49000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv6lmyt8xj847@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 3', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 2, NULL, 4)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (4, 5, 9, 3, N'Kim Long Roll Cake – Large Size', 50000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv21q8k90uxa6@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 4', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 5)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (5, 2, 8, 5, N'Product 5', 30000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu7tuh1ods423@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 5', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 4)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (6, 4, 9, 7, N'Product 6', 35000, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'Description for Product 6', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 2, NULL, 3)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (7, 3, 2, 5, N'Product 7', 16000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu55i11bqmx52@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 7', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 2)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (8, 1, 15, 2, N'Product 8', 57000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu6zq1im07td5@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 8', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 3)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (9, 4, 3, 1, N'Product 9', 28000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv77fpov6vt2b@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 9', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 2, NULL, 4)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (10, 5, 10, 3, N'Product 10', 60000, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'Description for Product 10', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 5)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (11, 3, 2, 2, N'Product 11', 23000, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'Description for Product 11', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 3, NULL, 3)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (12, 2, 16, 1, N'Product 12', 17000, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'Description for Product 12', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 3, NULL, 4)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (13, 3, 6, 3, N'Product 13', 30000, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'Description for Product 13', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 4, NULL, 2)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (14, 3, 5, 2, N'Product 14', 24000, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'Description for Product 14', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 5)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (15, 2, 14, 1, N'Product 15', 39000, N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu6zq1im07td5@resize_ss280x175!@crop_w280_h175_cT', N'Description for Product 15', CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), CAST(N'2024-08-08T11:05:31.3600000' AS DateTime2), 1, NULL, 2)
INSERT [dbo].[Product] ([Id], [SubCategoryId], [StoreId], [DiscountId], [Name], [Price], [Image], [Description], [CreatedAt], [UpdatedAt], [CategoryId], [ExpireAt], [Quantity]) VALUES (17, 4, 1, 1, N'string', 0, N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!', N'string', CAST(N'2024-08-15T11:14:12.3458750' AS DateTime2), CAST(N'2024-08-15T11:14:12.3458764' AS DateTime2), 1, NULL, 3)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (1, 1, N'A classic breakfast combo including coffee and croissant')
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (1, 2, N'Healthy breakfast with oatmeal and fresh fruit')
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (2, 3, N'Grilled chicken sandwich with a side of salad')
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (2, 4, N'Vegetarian lunch special with quinoa and roasted vegetables')
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (3, 5, N'Steak dinner with mashed potatoes and gravy')
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (4, 1, N'Refreshing lemonade made from fresh lemons')
INSERT [dbo].[Product_Menu] ([MenuId], [ProductId], [Description]) VALUES (5, 3, N'Combo deal: Buy 1 pizza, get 1 drink free')
GO
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'01', N'Ha Noi', N'City')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'02', N'Ha Giang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'04', N'Cao Bang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'06', N'Bac Kan', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'08', N'Tuyen Quang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'10', N'Lao Cai', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'11', N'Dien Bien', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'12', N'Lai Chau', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'14', N'Son La', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'15', N'Yen Bai', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'17', N'Hoa Binh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'19', N'Thai Nguyen', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'20', N'Lang Son', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'22', N'Quang Ninh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'24', N'Bac Giang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'25', N'Phu Tho', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'26', N'Vinh Phuc', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'27', N'Bac Ninh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'30', N'Hai Duong', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'31', N'Hai Phong', N'City')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'33', N'Hung Yen', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'34', N'Thai Binh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'35', N'Ha Nam', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'36', N'Nam Dinh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'37', N'Ninh Binh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'38', N'Thanh Hoa', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'40', N'Nghe An', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'42', N'Ha Tinh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'44', N'Quang Binh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'45', N'Quang Tri', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'46', N'Thua Thien Hue', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'48', N'Da Nang', N'City')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'49', N'Quang Nam', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'51', N'Quang Ngai', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'52', N'Binh Dinh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'54', N'Phu Yen', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'56', N'Khanh Hoa', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'58', N'Ninh Thuan', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'60', N'Binh Thuan', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'62', N'Kon Tum', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'64', N'Gia Lai', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'66', N'Dak Lak', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'67', N'Dak Nong', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'68', N'Lam Dong', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'70', N'Binh Phuoc', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'72', N'Tay Ninh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'74', N'Binh Duong', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'75', N'Dong Nai', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'77', N'Ba Ria - Vung Tau', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'79', N'Ho Chi Minh', N'City')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'80', N'Long An', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'82', N'Tien Giang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'83', N'Ben Tre', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'84', N'Tra Vinh', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'86', N'Vinh Long', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'87', N'Dong Thap', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'89', N'An Giang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'91', N'Kien Giang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'92', N'Can Tho', N'City')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'93', N'Hau Giang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'94', N'Soc Trang', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'95', N'Bac Lieu', N'Province')
INSERT [dbo].[Province] ([id], [name], [type]) VALUES (N'96', N'Ca Mau', N'Province')
GO
SET IDENTITY_INSERT [dbo].[Store] ON 

INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (1, N'Texas Chiken', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lstys79d6hsp9b@resize_ss280x175!@crop_w280_h175_cT', CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time), N'Description for Store 1', 2, 1, 20.12)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (2, N'Fruit Crush', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv4fbrusnmhb7@resize_ss280x175!@crop_w280_h175_cT', CAST(N'08:30:00' AS Time), CAST(N'17:30:00' AS Time), N'Description for Store 2', 4, 1, 15.3)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (3, N'Yumi Fruit', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv21q8k90uxa6@resize_ss280x175!@crop_w280_h175_cT', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'Description for Store 3', 4, 1, 30.5)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (4, N'Xingfu Cha milk tea', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsvceni400wp09@resize_ss280x175!@crop_w280_h175_cT', CAST(N'09:30:00' AS Time), CAST(N'18:30:00' AS Time), N'Description for Store 4', 3, 1, 16.3)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (5, N'Vermicelli with tofu and shrimp paste', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv1xzn77mhlad@resize_ss280x175!@crop_w280_h175_cT', CAST(N'10:00:00' AS Time), CAST(N'19:00:00' AS Time), N'Description for Store 5', 2, 1, 18)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (6, N'BonChon Chicken', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv77fpov6vt2b@resize_ss280x175!@crop_w280_h175_cT', CAST(N'10:30:00' AS Time), CAST(N'19:30:00' AS Time), N'Description for Store 6', 2, 1, 12.1)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (7, N'Chicken rice, porridge & salad', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsu6x6gym478be@resize_ss280x175!@crop_w280_h175_cT', CAST(N'11:00:00' AS Time), CAST(N'20:00:00' AS Time), N'Description for Store 7', 2, 1, 23)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (8, N'Hello Chicken - Chicken balls and chicken sandwich', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsvciltrq655f2@resize_ss280x175!@crop_w280_h175_cT', CAST(N'11:30:00' AS Time), CAST(N'20:30:00' AS Time), N'Description for Store 8', 3, 1, 27.54)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (9, N'Boom - Coffee & milk tea', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lxcmh12renkr92@resize_ss280x175!@crop_w280_h175_cT', CAST(N'12:00:00' AS Time), CAST(N'21:00:00' AS Time), N'Description for Store 9', 3, 1, 16.8)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (10, N'Dairy Queen Ice Cream', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lze9ri6i2rf129@resize_ss280x175!@crop_w280_h175_cT', CAST(N'12:30:00' AS Time), CAST(N'21:30:00' AS Time), N'Description for Store 10', 6, 1, 32.16)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (11, N'Sweensen''s Ice Cream', N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsv6lmyt8xj847@resize_ss280x175!@crop_w280_h175_cT', CAST(N'13:00:00' AS Time), CAST(N'22:00:00' AS Time), N'Description for Store 11', 6, 1, 13.15)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (12, N'Nam Vang noodles', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv733mr9ti13f@resize_ss280x175!@crop_w280_h175_cT', CAST(N'13:30:00' AS Time), CAST(N'22:30:00' AS Time), N'Description for Store 12', 2, 1, 24.25)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (13, N'Vermicelli with crab and beef stew', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsu8fx8mmsnt5d@resize_ss280x175!@crop_w280_h175_cT', CAST(N'14:00:00' AS Time), CAST(N'23:00:00' AS Time), N'Description for Store 13', 2, 1, 18.3)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (14, N'Rinkaffe - Healthy smoothie juice', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv1u8xybwrd00@resize_ss280x175!@crop_w280_h175_cT', CAST(N'14:30:00' AS Time), CAST(N'23:30:00' AS Time), N'Description for Store 14', 4, 1, 29.92)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (15, N'Vermicelli and tofu on street vendor''s stall', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lsv27mh3o0qs91@resize_ss280x175!@crop_w280_h175_cT', CAST(N'15:00:00' AS Time), CAST(N'00:00:00' AS Time), N'Description for Store 15', 2, 1, 33.55)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (16, N'Xing Fu Tang Vietnam', N'https://down-bs-vn.img.susercontent.com/vn-11134513-7r98o-lyka9na2j6oxb9@resize_ss280x175!@crop_w280_h175_cT', CAST(N'15:00:00' AS Time), CAST(N'00:00:00' AS Time), N'Description for Store 15', 3, 1, 53.4)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (18, N'Store 17', N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu6zq1im07td5@resize_ss280x175!@crop_w280_h175_cT', CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time), N'Description for Store 11', 4, 2, 40.6)
INSERT [dbo].[Store] ([Id], [Name], [Image], [OpenTime], [CloseTime], [Description], [SubCategoryId], [CategoryId], [MaxPrice]) VALUES (19, N'Store 18', N'https://down-tx-vn.img.susercontent.com/vn-11134513-7r98o-lsu55i11bqmx52@resize_ss280x175!@crop_w280_h175_cT', CAST(N'09:00:00' AS Time), CAST(N'18:00:00' AS Time), N'Description for Store 3', 5, 3, 50.45)
SET IDENTITY_INSERT [dbo].[Store] OFF
GO
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (1, 1, N'Nguyen Van Cu', N'00001')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (2, 2, N'Le Thanh Nghi', N'00037')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (3, 3, N'Pham Hung', N'00094')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (4, 4, N'Tran Dai Nghia', N'00157')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (5, 5, N'Hoang Mai', N'00184')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (6, 6, N'Truong Chinh', N'00244')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (7, 7, N'Cau Giay', N'00259')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (8, 8, N'Xuan Thuy', N'00001')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (9, 9, N'Thanh cong', N'00037')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (10, 10, N'Kim Ma', N'00094')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (11, 11, N'Lang Ha', N'00121')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (12, 12, N'Nguyen Trai', N'00001')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (13, 13, N'Quang Trung', N'00244')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (14, 14, N'Nguyen Chi Thanh', N'00001')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (15, 15, N'Tran Hung Dao', N'00094')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (16, 16, N'Thanh Cong', N'00064')
INSERT [dbo].[StoreAddress] ([id], [StoreId], [Street], [WardId]) VALUES (17, 17, N'Hello World', N'00001')
GO
SET IDENTITY_INSERT [dbo].[SubCategory] ON 

INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (1, N'All', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (2, N'Food', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (3, N'Drink', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (4, N'Vege', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (5, N'Cakes', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (6, N'Desert', 1)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (15, N'All', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (16, N'Vegan', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (17, N'Fruit', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (18, N'Meat/Egg', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (19, N'Seafood', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (20, N'Vegetables', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (21, N'Rice/Noodle', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (22, N'Canned Foods/Drinks', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (23, N'Spice', 2)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (24, N'SubCategory 9', 5)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (25, N'SubCategory 10', 5)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (26, N'SubCategory 11', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (27, N'SubCategory 12', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (28, N'SubCategory 13', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (29, N'SubCategory 14', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (30, N'SubCategory 15', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (31, N'SubCategory 16', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (32, N'SubCategory 17', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (33, N'SubCategory 18', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (34, N'SubCategory 19', 6)
INSERT [dbo].[SubCategory] ([Id], [Name], [CategoryId]) VALUES (35, N'SubCategory 20', 5)
SET IDENTITY_INSERT [dbo].[SubCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (1, 1, N'Dang Duc Tin', 1, N'0123456789', N'ductindang1009@gmail.com', N'Abcd#12345', N'data:image/jpeg;base64,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', 1, CAST(N'2024-07-14T11:45:13.4992039' AS DateTime2), CAST(N'2024-09-12T14:03:25.9920275' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (2, 1, N'User 2', 0, N'123264152', N'nguyenanhnghia81@gmail.com', N'222', N'data:image/jpeg;base64,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', 1, CAST(N'2024-07-01T11:45:13.5202015' AS DateTime2), CAST(N'2024-07-19T11:45:13.5202035' AS DateTime2), N'MKp5IlZzpWIef/qebRXZEo2ezcZ7n7sJ6D88KaRs1vc=', CAST(N'2024-07-30T03:37:55.8424589' AS DateTime2), 0, N'CV2FJ5/7bKMILoz1GAprBsR0NdErxYM5yHLcKofz5Aw=', CAST(N'2024-08-14T09:27:18.2133017' AS DateTime2))
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (3, 1, N'User 3', 1, N'123364153', N'ductindang.100903@gmail.com', N'333', N'Avatar for User 3', 1, CAST(N'2024-07-21T11:45:13.5202942' AS DateTime2), CAST(N'2024-06-27T11:45:13.5202947' AS DateTime2), N'eKsQq7pAx0gQD2cxtTkJIa6I5jltBSoMgel8nhKTg7A=', CAST(N'2024-07-30T03:47:03.9184005' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (4, 1, N'User 4', 0, N'123464154', N'nghiangongcuongvai@gmail.com', N'444', N'Avatar for User 4', 1, CAST(N'2024-07-11T11:45:13.5203375' AS DateTime2), CAST(N'2024-07-01T11:45:13.5203380' AS DateTime2), N'oiScAR0Sg+utLLccHBiPHC0HrQEyIHyQ8qD8ZBTQSY8=', CAST(N'2024-07-30T03:38:36.1464555' AS DateTime2), 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (5, 1, N'User 5', 0, N'123564155', N'user555@Example.com', N'555', N'Avatar for User 5', 1, CAST(N'2024-07-18T11:45:13.5203781' AS DateTime2), CAST(N'2024-07-21T11:45:13.5203785' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (6, 1, N'User 6', 1, N'123664156', N'user666@Example.com', N'666', N'https://avatars.githubusercontent.com/u/100546291?v=4', 1, CAST(N'2024-07-10T11:45:13.5204144' AS DateTime2), CAST(N'2024-06-29T11:45:13.5204148' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (7, 1, N'User 7', 1, N'123764157', N'user777@Example.com', N'777', N'Avatar for User 7', 1, CAST(N'2024-07-23T11:45:13.5204654' AS DateTime2), CAST(N'2024-07-16T11:45:13.5204660' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (8, 1, N'User 8', 0, N'123864158', N'user888@Example.com', N'888', N'Avatar for User 8', 1, CAST(N'2024-07-09T11:45:13.5205064' AS DateTime2), CAST(N'2024-07-10T11:45:13.5205068' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (9, 1, N'User 9', 0, N'123964159', N'user999@Example.com', N'999', N'Avatar for User 9', 1, CAST(N'2024-07-06T11:45:13.5205455' AS DateTime2), CAST(N'2024-07-05T11:45:13.5205459' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (10, 1, N'User 10', 0, N'12310641510', N'user101010@Example.com', N'101010', N'Avatar for User 10', 1, CAST(N'2024-07-04T11:45:13.5205827' AS DateTime2), CAST(N'2024-06-29T11:45:13.5205831' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (11, 1, N'User 11', 0, N'12311641511', N'user111111@Example.com', N'111111', N'Avatar for User 11', 1, CAST(N'2024-06-28T11:45:13.5206285' AS DateTime2), CAST(N'2024-07-13T11:45:13.5206291' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (12, 1, N'User 12', 1, N'12312641512', N'user121212@Example.com', N'121212', N'Avatar for User 12', 1, CAST(N'2024-07-18T11:45:13.5206669' AS DateTime2), CAST(N'2024-07-14T11:45:13.5206674' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (13, 1, N'User 13', 1, N'12313641513', N'user131313@Example.com', N'131313', N'Avatar for User 13', 1, CAST(N'2024-07-08T11:45:13.5207309' AS DateTime2), CAST(N'2024-07-16T11:45:13.5207314' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (14, 1, N'User 14', 0, N'12314641514', N'user141414@Example.com', N'141414', N'Avatar for User 14', 1, CAST(N'2024-07-24T11:45:13.5207740' AS DateTime2), CAST(N'2024-07-19T11:45:13.5207745' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (15, 1, N'User 15', 0, N'12315641515', N'user151515@Example.com', N'151515', N'Avatar for User 15', 1, CAST(N'2024-07-17T11:45:13.5208158' AS DateTime2), CAST(N'2024-07-07T11:45:13.5208163' AS DateTime2), N'', NULL, 0, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (28, 0, N'string', 0, N'string', N'ductindang1009@gmail.com', N'string', N'string', 0, CAST(N'2024-08-07T03:18:52.0430000' AS DateTime2), CAST(N'2024-08-07T03:18:52.0430000' AS DateTime2), N'string', CAST(N'2024-08-07T03:18:52.0430000' AS DateTime2), 1, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (29, 1, N'Laptop HP 128GB', 0, N'0335637514', N'ductindang1009@gmail.com', N'Acs123#4', NULL, 1, CAST(N'2024-08-07T10:43:41.0348814' AS DateTime2), CAST(N'2024-08-07T10:43:41.0349295' AS DateTime2), NULL, NULL, 0, N'syDfd6YWLcBgrd3bA4gCnorD9+nrtlHNVdV2RcVo/z0=', CAST(N'2024-08-07T10:43:41.0647768' AS DateTime2))
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (31, 1, N'Laptop HP 128GB', 0, N'0335637514', N'ductindang1009@gmail.com', N'asdS1#fd', NULL, 1, CAST(N'2024-08-07T11:15:22.6856842' AS DateTime2), CAST(N'2024-08-07T11:15:23.2289755' AS DateTime2), NULL, NULL, 1, NULL, NULL)
INSERT [dbo].[User] ([Id], [RoleId], [FullName], [Gender], [PhoneNumber], [Email], [Password], [Avatar], [Status], [CreatedAt], [UpdatedAt], [PasswordResetToken], [PasswordResetTokenExpiry], [IsEmailVerified], [VerificationEmailToken], [VerificationEmailTokenExpiry]) VALUES (32, 1, N'Laptop HP 128GB', 0, N'0335637514', N'ductindang01009@gmail.com', N'123dA#rw', NULL, 1, CAST(N'2024-08-15T11:32:08.4417671' AS DateTime2), CAST(N'2024-08-15T11:32:08.4418027' AS DateTime2), NULL, NULL, 0, N'R1V39niYJ9bi+frVjhNWVAQmKO09fIpYRGH9w73SLWM=', CAST(N'2024-08-15T11:32:08.5173021' AS DateTime2))
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAddress] ON 

INSERT [dbo].[UserAddress] ([Id], [UserId], [Street], [WardId], [NameReminiscent], [PhoneNumber]) VALUES (1, 1, N'23 tran binh trong', N'00004', N'User', N'0123164152')
INSERT [dbo].[UserAddress] ([Id], [UserId], [Street], [WardId], [NameReminiscent], [PhoneNumber]) VALUES (2, 1, N'gfdsgdfg', N'00006', N'gfdgsdfg', N'0345234545')
SET IDENTITY_INSERT [dbo].[UserAddress] OFF
GO
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00001', N'Phuc Xa', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00004', N'Truc Bach', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00006', N'Vinh Phuc', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00007', N'Cong Vi', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00008', N'Lieu Giai', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00010', N'Nguyen Trung Truc', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00013', N'Quan Thanh', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00016', N'Ngoc Ha', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00019', N'Dien Bien', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00022', N'Doi Can', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00025', N'Ngoc Khanh', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00028', N'Kim Ma', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00031', N'Giang Vo', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00034', N'Thanh Cong', N'Ward', N'001')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00037', N'Phuc Tan', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00040', N'Dong Xuan', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00043', N'Hang Ma', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00046', N'Hang Buom', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00049', N'Hang Dao', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00052', N'Hang Bo', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00055', N'Cua Dong', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00058', N'Ly Thai To', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00061', N'Hang Bac', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00064', N'Hang Gai', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00067', N'Chuong Duong Do', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00070', N'Hang Trong', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00073', N'Cua Nam', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00076', N'Hang Bong', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00079', N'Trang Tien', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00082', N'Tran Hung Dao', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00085', N'Phan Chu Trinh', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00088', N'Hang Bai', N'Ward', N'002')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00091', N'Phu Thuong', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00094', N'Nhat Tan', N'Ward', N'024')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00097', N'Tu Lien', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00100', N'Quang An', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00103', N'Xuan La', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00106', N'Yen Phu', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00109', N'Buoi', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00112', N'Thuy Khue', N'Ward', N'003')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00115', N'Thuong Thanh', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00118', N'Ngoc Thuy', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00121', N'Giang Bien', N'Ward', N'040')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00124', N'Duc Giang', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00127', N'Viet Hung', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00130', N'Gia Thuy', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00133', N'Ngoc Lam', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00136', N'Phuc Loi', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00139', N'Bo De', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00142', N'Sai Dong', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00145', N'Long Bien', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00148', N'Thach Ban', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00151', N'Phuc Dong', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00154', N'Cu Khoi', N'Ward', N'004')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00157', N'Nghia Do', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00160', N'Nghia Tan', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00163', N'Mai Dich', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00166', N'Dich Vong', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00167', N'Dich Vong Hau', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00169', N'Quan Hoa', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00172', N'Yen Hoa', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00175', N'Trung Hoa', N'Ward', N'005')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00178', N'Cat Linh', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00181', N'Van Mieu', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00184', N'Quoc Tu Giam', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00187', N'Lang Thuong', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00190', N'O Cho Dua', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00193', N'Van Chuong', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00196', N'Hang Bot', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00199', N'Lang Ha', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00202', N'Kham Thien', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00205', N'Tho Quan', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00208', N'Nam Dong', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00211', N'Trung Phung', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00214', N'Quang Trung', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00217', N'Trung Liet', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00220', N'Phuong Lien', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00223', N'Thinh Quang', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00226', N'Trung Tu', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00229', N'Kim Lien', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00232', N'Phuong Mai', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00235', N'Nga Tu So', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00238', N'Khuong Thuong', N'Ward', N'006')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00241', N'Nguyen Du', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00244', N'Bach Dang', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00247', N'Pham Dinh Ho', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00250', N'Bui Thi Xuan', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00253', N'Ngo Thi Nham', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00256', N'Le Dai Hanh', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00259', N'Dong Nhan', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00262', N'Pho Hue', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00265', N'Dong Mac', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00268', N'Thanh Luong', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00271', N'Thanh Nhan', N'Ward', N'007')
INSERT [dbo].[Ward] ([id], [name], [type], [DistrictId]) VALUES (N'00274', N'Cau Den', N'Ward', N'007')
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsEmailVerified]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Discount] FOREIGN KEY([DiscountId])
REFERENCES [dbo].[Discount] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Discount]
GO
