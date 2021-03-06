USE [master]
GO
/****** Object:  Database [onlineShopping]    Script Date: 11/27/2019 9:14:10 AM ******/
CREATE DATABASE [onlineShopping]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'onlineShopping', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\onlineShopping.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'onlineShopping_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\onlineShopping_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [onlineShopping] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [onlineShopping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [onlineShopping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [onlineShopping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [onlineShopping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [onlineShopping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [onlineShopping] SET ARITHABORT OFF 
GO
ALTER DATABASE [onlineShopping] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [onlineShopping] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [onlineShopping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [onlineShopping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [onlineShopping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [onlineShopping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [onlineShopping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [onlineShopping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [onlineShopping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [onlineShopping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [onlineShopping] SET  ENABLE_BROKER 
GO
ALTER DATABASE [onlineShopping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [onlineShopping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [onlineShopping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [onlineShopping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [onlineShopping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [onlineShopping] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [onlineShopping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [onlineShopping] SET RECOVERY FULL 
GO
ALTER DATABASE [onlineShopping] SET  MULTI_USER 
GO
ALTER DATABASE [onlineShopping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [onlineShopping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [onlineShopping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [onlineShopping] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'onlineShopping', N'ON'
GO
USE [onlineShopping]
GO
/****** Object:  Table [dbo].[adminTable]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[adminTable](
	[adminId] [int] NOT NULL,
	[adminPassword] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[adminId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[cart]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cart](
	[cartId] [int] IDENTITY(765,7) NOT NULL,
	[userId] [varchar](10) NULL,
	[itemId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[cartId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[categoryDetail]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[categoryDetail](
	[categoryId] [int] NOT NULL,
	[categoryName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[categoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[orderDetail]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderDetail](
	[orderDetailsId] [int] IDENTITY(1,1) NOT NULL,
	[orderId] [int] NULL,
	[itemId] [int] NULL,
	[quantity] [int] NOT NULL,
	[cost] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[orderDetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orderTable]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[orderTable](
	[orderId] [int] IDENTITY(344,6) NOT NULL,
	[orderDate] [date] NOT NULL,
	[customerId] [varchar](10) NULL,
	[totalPrice] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[orderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[productDescription]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[productDescription](
	[itemId] [int] IDENTITY(101,1) NOT NULL,
	[categoryId] [int] NULL,
	[productName] [varchar](50) NOT NULL,
	[productDescription] [varchar](2000) NULL,
	[stock] [int] NOT NULL,
	[color] [varchar](20) NULL,
	[backImage] [nvarchar](max) NULL,
	[frontImage] [nvarchar](max) NULL,
	[sideImage] [nvarchar](max) NULL,
	[rating] [int] NULL,
	[actualCost] [int] NOT NULL,
	[discount] [int] NULL,
	[currentCost] [int] NOT NULL,
	[brand] [varchar](50) NULL,
	[size] [varchar](15) NULL,
	[approvalStatus] [varchar](5) NULL,
	[retailerId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[registrationTable]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[registrationTable](
	[phoneNo] [varchar](10) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[emailId] [varchar](50) NOT NULL,
	[address] [varchar](90) NULL,
PRIMARY KEY CLUSTERED 
(
	[phoneNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[retailer]    Script Date: 11/27/2019 9:14:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[retailer](
	[retailerId] [int] IDENTITY(1001,2) NOT NULL,
	[phoneNo] [varchar](10) NOT NULL,
	[Password] [varchar](15) NOT NULL,
	[name] [varchar](30) NOT NULL,
	[emailId] [varchar](50) NOT NULL,
	[address] [varchar](90) NULL,
PRIMARY KEY CLUSTERED 
(
	[retailerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD FOREIGN KEY([itemId])
REFERENCES [dbo].[productDescription] ([itemId])
GO
ALTER TABLE [dbo].[cart]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[registrationTable] ([phoneNo])
GO
ALTER TABLE [dbo].[orderDetail]  WITH CHECK ADD  CONSTRAINT [foreign_work] FOREIGN KEY([itemId])
REFERENCES [dbo].[productDescription] ([itemId])
GO
ALTER TABLE [dbo].[orderDetail] CHECK CONSTRAINT [foreign_work]
GO
ALTER TABLE [dbo].[orderDetail]  WITH CHECK ADD  CONSTRAINT [foreign_works] FOREIGN KEY([orderId])
REFERENCES [dbo].[orderTable] ([orderId])
GO
ALTER TABLE [dbo].[orderDetail] CHECK CONSTRAINT [foreign_works]
GO
ALTER TABLE [dbo].[orderTable]  WITH CHECK ADD FOREIGN KEY([customerId])
REFERENCES [dbo].[registrationTable] ([phoneNo])
GO
ALTER TABLE [dbo].[productDescription]  WITH CHECK ADD FOREIGN KEY([categoryId])
REFERENCES [dbo].[categoryDetail] ([categoryId])
GO
ALTER TABLE [dbo].[productDescription]  WITH CHECK ADD FOREIGN KEY([retailerId])
REFERENCES [dbo].[retailer] ([retailerId])
GO
USE [master]
GO
ALTER DATABASE [onlineShopping] SET  READ_WRITE 
GO
