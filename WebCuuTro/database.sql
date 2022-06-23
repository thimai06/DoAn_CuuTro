USE [master]
GO
/****** Object:  Database [DB_Cuutro]    Script Date: 6/24/2022 1:57:05 AM ******/
CREATE DATABASE [DB_Cuutro]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_Cuutro', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Cuutro.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_Cuutro_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DB_Cuutro_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_Cuutro] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_Cuutro].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_Cuutro] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_Cuutro] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_Cuutro] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_Cuutro] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_Cuutro] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_Cuutro] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_Cuutro] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_Cuutro] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_Cuutro] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_Cuutro] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_Cuutro] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_Cuutro] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_Cuutro] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_Cuutro] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_Cuutro] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_Cuutro] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_Cuutro] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_Cuutro] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_Cuutro] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_Cuutro] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_Cuutro] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_Cuutro] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_Cuutro] SET RECOVERY FULL 
GO
ALTER DATABASE [DB_Cuutro] SET  MULTI_USER 
GO
ALTER DATABASE [DB_Cuutro] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_Cuutro] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_Cuutro] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_Cuutro] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_Cuutro] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_Cuutro] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DB_Cuutro] SET QUERY_STORE = OFF
GO
USE [DB_Cuutro]
GO
/****** Object:  Table [dbo].[categorize]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorize](
	[ID_cate] [varchar](10) NOT NULL,
	[Name_cate] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_cate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Details_receipt]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details_receipt](
	[ID_receipt] [int] NULL,
	[ID_product] [varchar](10) NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Details_registration]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Details_registration](
	[ID_product] [varchar](10) NULL,
	[ID_re] [int] NULL,
	[Quantity] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[ID_district] [varchar](10) NOT NULL,
	[Name_district] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_district] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pesonal]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pesonal](
	[ID_user] [varchar](255) NOT NULL,
	[ID_type] [varchar](2) NULL,
	[Personal_name] [nvarchar](255) NULL,
	[ID_card] [char](12) NULL,
	[Address] [nvarchar](250) NULL,
	[Gender] [nvarchar](3) NULL,
	[Phone] [char](10) NULL,
	[password] [varchar](255) NOT NULL,
	[status] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ID_product] [varchar](10) NOT NULL,
	[ID_cate] [varchar](10) NULL,
	[Name_product] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_product] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proof]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proof](
	[ID_proof] [int] IDENTITY(1,1) NOT NULL,
	[ID_relieft] [int] NULL,
	[Link] [varchar](255) NULL,
	[Type] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_proof] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receipt]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receipt](
	[ID_receipt] [int] IDENTITY(1,1) NOT NULL,
	[ID_relieft] [int] NULL,
	[ID_user] [varchar](255) NULL,
	[Date] [date] NULL,
	[Nguoitang] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_receipt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration_form]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration_form](
	[ID_re] [int] IDENTITY(1,1) NOT NULL,
	[ID_user] [varchar](255) NOT NULL,
	[ID_relieft] [int] NOT NULL,
	[Status] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_re] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relief]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relief](
	[ID_relieft] [int] IDENTITY(1,1) NOT NULL,
	[ID_rc] [varchar](10) NOT NULL,
	[ID_ward] [varchar](10) NOT NULL,
	[Time_sent_post] [datetime] NULL,
	[Content] [nvarchar](max) NULL,
	[Content_thank] [nvarchar](max) NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[Start_date] [date] NULL,
	[End_date] [date] NULL,
	[map] [varchar](255) NULL,
	[note] [varchar](255) NULL,
	[status] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_relieft] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Relief_classification]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Relief_classification](
	[ID_rc] [varchar](10) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_rc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role_Type]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role_Type](
	[ID_type] [varchar](2) NOT NULL,
	[Name_role] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 6/24/2022 1:57:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ward](
	[ID_ward] [varchar](10) NOT NULL,
	[ID_district] [varchar](10) NULL,
	[Name_ward] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_ward] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[categorize] ([ID_cate], [Name_cate]) VALUES (N'AQ', N'Áo Quần')
GO
INSERT [dbo].[categorize] ([ID_cate], [Name_cate]) VALUES (N'T', N'Tiền')
GO
INSERT [dbo].[categorize] ([ID_cate], [Name_cate]) VALUES (N'TP', N'Thực Phẩm')
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (4, N'11', 10)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (4, N'13', 10)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (4, N'12', 20)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (4, N'14', 25)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (5, N'11', 10)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (5, N'12', 15)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (5, N'13', 15)
GO
INSERT [dbo].[Details_receipt] ([ID_receipt], [ID_product], [Quantity]) VALUES (5, N'14', 20)
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[District] ([ID_district], [Name_district]) VALUES (N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'anh.tt', N'5', N'Tạ Trường Anh', N'216390111234', N'Bình Định', N'nam', N'0795399636', N'@Minhtuan1806', N'1')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'khong.vth', N'1', N'Võ Tấn Hoàng Không', N'202222601234', N'Hà Nội', N'Nữ', N'0795519636', N'123', N'1')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'my.ttt', N'5', N'Trần Thị Thanh My', N'206111101234', N'Hà Nội', N'Nữ', N'0795590636', N'@Minhtuan1806', N'1')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'ngoc.ltb', N'5', N'Lương Thị Bảo Ngọc', N'206390111234', N'Đà Nẵng', N'Nữ', N'0795399636', N'@Minhtuan1806', N'1')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'nha.vq', NULL, N'Võ Quang Nhả', NULL, N'Quảng trị', N'Nam', N'1111111111', N'yeubephuong', NULL)
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'thinh.nt', N'5', N'Nguyễn Tấn Thịnh', N'206390602234', N'Hà Nội', N'Nam', N'0795592636', N'@Minhtuan1806', N'1')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'tuan.nhm', N'5', N'Nguyễn Hữu Minh Tuấn', N'206390601234', N'Quảng Nam', N'Nam', N'0795599636', N'@Minhtuan1806', N'1')
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'vong.nh', NULL, N'Nguyễn Hữu Vọng', N'999999999999', N'Quảng Nam', N'nam', N'012365478 ', N'123', NULL)
GO
INSERT [dbo].[Pesonal] ([ID_user], [ID_type], [Personal_name], [ID_card], [Address], [Gender], [Phone], [password], [status]) VALUES (N'vu.lt', NULL, N'Lê Tự Vũ', N'222222222222', N'Quảng trị', N'Nam', N'1111111111', N'123', NULL)
GO
INSERT [dbo].[Product] ([ID_product], [ID_cate], [Name_product]) VALUES (N'11', N'AQ', N'Quần áo')
GO
INSERT [dbo].[Product] ([ID_product], [ID_cate], [Name_product]) VALUES (N'12', N'TP', N'Bánh mỳ')
GO
INSERT [dbo].[Product] ([ID_product], [ID_cate], [Name_product]) VALUES (N'13', N'TP', N'Cá hộp')
GO
INSERT [dbo].[Product] ([ID_product], [ID_cate], [Name_product]) VALUES (N'14', N'TP', N'Cam')
GO
INSERT [dbo].[Product] ([ID_product], [ID_cate], [Name_product]) VALUES (N'15', N'T', N'Tiền')
GO
SET IDENTITY_INSERT [dbo].[Receipt] ON 
GO
INSERT [dbo].[Receipt] ([ID_receipt], [ID_relieft], [ID_user], [Date], [Nguoitang]) VALUES (4, 4, NULL, CAST(N'2022-06-24' AS Date), N'Đào Mạnh Quân')
GO
INSERT [dbo].[Receipt] ([ID_receipt], [ID_relieft], [ID_user], [Date], [Nguoitang]) VALUES (5, 4, NULL, CAST(N'2022-06-24' AS Date), N'Đào Mạnh Quân')
GO
SET IDENTITY_INSERT [dbo].[Receipt] OFF
GO
SET IDENTITY_INSERT [dbo].[Relief] ON 
GO
INSERT [dbo].[Relief] ([ID_relieft], [ID_rc], [ID_ward], [Time_sent_post], [Content], [Content_thank], [Title], [Description], [Start_date], [End_date], [map], [note], [status]) VALUES (4, N'CTTT', N'20335', CAST(N'2022-06-24T00:18:52.790' AS DateTime), N'Do ảnh hưởng của rãnh áp thấp, gây mưa diện rộng trên địa bàn tỉnh Cao Bằng, mưa vừa, mưa to cục bộ, có nơi mưa rất to làm ngập úng, sạt lở đất đá gây thiệt hại về người, nhà cửa và hoa màu của nhân dân.', N'Sạt lở bất ngờ ở huyện Nam Trà My
Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người.', N'Cứu trợ bão lũ Điện Bàn', N'thì vậy đó', CAST(N'2022-06-18' AS Date), CAST(N'2022-07-18' AS Date), NULL, NULL, N'1')
GO
INSERT [dbo].[Relief] ([ID_relieft], [ID_rc], [ID_ward], [Time_sent_post], [Content], [Content_thank], [Title], [Description], [Start_date], [End_date], [map], [note], [status]) VALUES (5, N'CTDB', N'20338', CAST(N'2022-06-24T00:18:52.790' AS DateTime), N'Called though excuse length ye needed it he having. Whatever throwing we on resolved entrance together graceful. Mrs assured add private married removed believe did she no he several excited am. peculiar families sensible.', N'Sạt lở bất ngờ ở huyện Nam Trà My
Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người.', N'Water Facilities for People', N'thì vậy đó', CAST(N'2022-06-18' AS Date), CAST(N'2022-07-01' AS Date), NULL, NULL, N'1')
GO
INSERT [dbo].[Relief] ([ID_relieft], [ID_rc], [ID_ward], [Time_sent_post], [Content], [Content_thank], [Title], [Description], [Start_date], [End_date], [map], [note], [status]) VALUES (6, N'CTTT', N'20341', CAST(N'2022-06-24T00:18:52.790' AS DateTime), N'Called though excuse length ye needed it he having. Whatever throwing we on resolved entrance together graceful. Mrs assured add private married removed believe did she no he several excited am. peculiar families sensible.', N'Sạt lở bất ngờ ở huyện Nam Trà My
Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người. Một vụ sạt lở bất ngờ đã xảy ra khoảng 9 giờ ngày 24/10 ở thị trấn Tắc Pỏ, xã Trà Mai, huyện miền núi cao Nam Trà My, tỉnh Quảng Nam khiến ít nhất sáu ngôi nhà bị hư hỏng, rất may không có thiệt hại về người.', N'Lifeskills for Children in South Africa', N'thì vậy đó', CAST(N'2022-06-20' AS Date), CAST(N'2022-07-18' AS Date), NULL, NULL, N'1')
GO
SET IDENTITY_INSERT [dbo].[Relief] OFF
GO
INSERT [dbo].[Relief_classification] ([ID_rc], [Description]) VALUES (N'CTDB', N'B?ch b?nh')
GO
INSERT [dbo].[Relief_classification] ([ID_rc], [Description]) VALUES (N'CTGD', N'Gia dình khó khan')
GO
INSERT [dbo].[Relief_classification] ([ID_rc], [Description]) VALUES (N'CTTT', N'Thiên tai')
GO
INSERT [dbo].[Role_Type] ([ID_type], [Name_role]) VALUES (N'1', N'Root')
GO
INSERT [dbo].[Role_Type] ([ID_type], [Name_role]) VALUES (N'2', N'Thành phố')
GO
INSERT [dbo].[Role_Type] ([ID_type], [Name_role]) VALUES (N'3', N'Huyện')
GO
INSERT [dbo].[Role_Type] ([ID_type], [Name_role]) VALUES (N'4', N'Phường')
GO
INSERT [dbo].[Role_Type] ([ID_type], [Name_role]) VALUES (N'5', N'Khách')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20335', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20338', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20341', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20344', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20347', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20350', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20353', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20356', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20359', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20362', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20364', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20365', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20368', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20371', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20374', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20375', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20377', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20380', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20383', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20386', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20387', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20389', N'502', N'Thành phố Tam Kỳ')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20392', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20395', N'518', N'Huyện Phú Ninh')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20398', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20401', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20404', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20407', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20410', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20413', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20416', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20419', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20422', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20425', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20428', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20431', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20434', N'503', N'Thành phố Hội An')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20437', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20440', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20443', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20446', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20449', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20452', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20455', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20458', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20461', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20464', N'504', N'Huyện Tây Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20467', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20470', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20473', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20476', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20479', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20482', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20485', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20488', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20491', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20494', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20497', N'505', N'Huyện Đông Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20500', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20503', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20506', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20509', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20512', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20515', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20518', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20521', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20524', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20527', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20530', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20533', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20536', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20539', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20542', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20545', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20547', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20548', N'506', N'Huyện Đại Lộc')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20551', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20554', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20557', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20560', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20561', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20562', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20563', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20566', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20569', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20572', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20575', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20578', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20579', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20580', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20581', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20584', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20587', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20590', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20593', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20596', N'507', N'Thị xã Điện Bàn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20599', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20602', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20605', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20608', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20611', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20614', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20617', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20620', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20623', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20626', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20629', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20632', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20635', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20638', N'508', N'Huyện Duy Xuyên')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20641', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20644', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20647', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20650', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20651', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20653', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20656', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20659', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20662', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20665', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20668', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20669', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20671', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20672', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20674', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20677', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20680', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20683', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20686', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20689', N'509', N'Huyện Quế Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20692', N'519', N'Huyện Nông Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20695', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20698', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20699', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20701', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20702', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20704', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20705', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20707', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20710', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20713', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20716', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20719', N'510', N'Huyện Nam Giang')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20722', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20725', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20728', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20729', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20731', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20734', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20737', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20740', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20743', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20746', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20749', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20752', N'511', N'Huyện Phước Sơn')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20755', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20758', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20761', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20764', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20767', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20770', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20773', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20776', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20779', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20782', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20785', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20788', N'512', N'Huyện Hiệp Đức')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20791', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20794', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20797', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20800', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20803', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20806', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20809', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20812', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20815', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20818', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20821', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20822', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20824', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20827', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20830', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20833', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20836', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20839', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20842', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20845', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20848', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20851', N'513', N'Huyện Thăng Bình')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20854', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20857', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20860', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20863', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20866', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20869', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20872', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20875', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20878', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20881', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20884', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20887', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20890', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20893', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20896', N'514', N'Huyện Tiên Phước')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20899', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20900', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20902', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20905', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20908', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20911', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20914', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20917', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20920', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20923', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20926', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20929', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20932', N'515', N'Huyện Bắc Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20935', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20938', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20941', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20944', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20947', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20950', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20953', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20956', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20959', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20962', N'516', N'Huyện Nam Trà My')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20965', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20968', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20971', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20974', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20977', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20980', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20983', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20984', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20986', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20989', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20992', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20995', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'20998', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'21001', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'21004', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'21005', N'517', N'Huyện Núi Thành')
GO
INSERT [dbo].[Ward] ([ID_ward], [ID_district], [Name_ward]) VALUES (N'21007', N'517', N'Huyện Núi Thành')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Pesonal__701794A1ADDA66A8]    Script Date: 6/24/2022 1:57:05 AM ******/
ALTER TABLE [dbo].[Pesonal] ADD UNIQUE NONCLUSTERED 
(
	[ID_card] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pesonal] ADD  DEFAULT ('5') FOR [ID_type]
GO
ALTER TABLE [dbo].[Receipt] ADD  DEFAULT (getdate()) FOR [Date]
GO
ALTER TABLE [dbo].[Relief] ADD  DEFAULT (getdate()) FOR [Time_sent_post]
GO
ALTER TABLE [dbo].[Relief] ADD  DEFAULT (getdate()) FOR [Start_date]
GO
ALTER TABLE [dbo].[Details_receipt]  WITH CHECK ADD  CONSTRAINT [dtpr] FOREIGN KEY([ID_product])
REFERENCES [dbo].[Product] ([ID_product])
GO
ALTER TABLE [dbo].[Details_receipt] CHECK CONSTRAINT [dtpr]
GO
ALTER TABLE [dbo].[Details_receipt]  WITH CHECK ADD  CONSTRAINT [fk_dtrc] FOREIGN KEY([ID_receipt])
REFERENCES [dbo].[Receipt] ([ID_receipt])
GO
ALTER TABLE [dbo].[Details_receipt] CHECK CONSTRAINT [fk_dtrc]
GO
ALTER TABLE [dbo].[Details_registration]  WITH CHECK ADD  CONSTRAINT [fk_pr] FOREIGN KEY([ID_product])
REFERENCES [dbo].[Product] ([ID_product])
GO
ALTER TABLE [dbo].[Details_registration] CHECK CONSTRAINT [fk_pr]
GO
ALTER TABLE [dbo].[Details_registration]  WITH CHECK ADD  CONSTRAINT [fk_redt] FOREIGN KEY([ID_re])
REFERENCES [dbo].[Registration_form] ([ID_re])
GO
ALTER TABLE [dbo].[Details_registration] CHECK CONSTRAINT [fk_redt]
GO
ALTER TABLE [dbo].[Pesonal]  WITH CHECK ADD FOREIGN KEY([ID_type])
REFERENCES [dbo].[Role_Type] ([ID_type])
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD FOREIGN KEY([ID_cate])
REFERENCES [dbo].[categorize] ([ID_cate])
GO
ALTER TABLE [dbo].[Proof]  WITH CHECK ADD FOREIGN KEY([ID_relieft])
REFERENCES [dbo].[Relief] ([ID_relieft])
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD FOREIGN KEY([ID_relieft])
REFERENCES [dbo].[Relief] ([ID_relieft])
GO
ALTER TABLE [dbo].[Receipt]  WITH CHECK ADD FOREIGN KEY([ID_user])
REFERENCES [dbo].[Pesonal] ([ID_user])
GO
ALTER TABLE [dbo].[Registration_form]  WITH CHECK ADD  CONSTRAINT [fk_re] FOREIGN KEY([ID_relieft])
REFERENCES [dbo].[Relief] ([ID_relieft])
GO
ALTER TABLE [dbo].[Registration_form] CHECK CONSTRAINT [fk_re]
GO
ALTER TABLE [dbo].[Registration_form]  WITH CHECK ADD  CONSTRAINT [fk_usrf] FOREIGN KEY([ID_user])
REFERENCES [dbo].[Pesonal] ([ID_user])
GO
ALTER TABLE [dbo].[Registration_form] CHECK CONSTRAINT [fk_usrf]
GO
ALTER TABLE [dbo].[Relief]  WITH CHECK ADD  CONSTRAINT [fk_rc] FOREIGN KEY([ID_rc])
REFERENCES [dbo].[Relief_classification] ([ID_rc])
GO
ALTER TABLE [dbo].[Relief] CHECK CONSTRAINT [fk_rc]
GO
ALTER TABLE [dbo].[Relief]  WITH CHECK ADD  CONSTRAINT [fk_xa] FOREIGN KEY([ID_ward])
REFERENCES [dbo].[Ward] ([ID_ward])
GO
ALTER TABLE [dbo].[Relief] CHECK CONSTRAINT [fk_xa]
GO
ALTER TABLE [dbo].[Ward]  WITH CHECK ADD FOREIGN KEY([ID_district])
REFERENCES [dbo].[District] ([ID_district])
GO
USE [master]
GO
ALTER DATABASE [DB_Cuutro] SET  READ_WRITE 
GO
