USE [master]
GO
/****** Object:  Database [TestTask]    Script Date: 7/12/2022 1:51:15 AM ******/
CREATE DATABASE [TestTask]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestTask', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVERABSAR\MSSQL\DATA\TestTask.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestTask_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVERABSAR\MSSQL\DATA\TestTask_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestTask] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestTask].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestTask] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestTask] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestTask] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestTask] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestTask] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestTask] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestTask] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TestTask] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestTask] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestTask] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestTask] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestTask] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestTask] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestTask] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestTask] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestTask] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestTask] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestTask] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestTask] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestTask] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestTask] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestTask] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestTask] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestTask] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestTask] SET  MULTI_USER 
GO
ALTER DATABASE [TestTask] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestTask] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestTask] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestTask] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TestTask]
GO
/****** Object:  StoredProcedure [dbo].[CreateCustomer]    Script Date: 7/12/2022 1:51:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Kunwer Absar>
-- Create date: <Create Date, 07/11/2022 ,>
-- Description:	<Description, add Customer in DB,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateCustomer]
	   @CustomerName varchar(100),
	   @CustomerAddress varchar(250)
	
AS
BEGIN
INSERT INTO Customer  (
	   CustomerName,
	   CustomerAddress
	   )
    VALUES (
	   @CustomerName,
	   @CustomerAddress
	   )
END

GO
/****** Object:  StoredProcedure [dbo].[CreateOrders]    Script Date: 7/12/2022 1:51:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Kunwer Absar>
-- Create date: <Create Date, 07/11/2022 ,>
-- Description:	<Description, add Customer Order in DB,>
-- =============================================
CREATE PROCEDURE [dbo].[CreateOrders]
	   @OrderDiscription varchar(250),
	   @OrderAmount INT,
	   @customerID int
	 
AS
BEGIN
INSERT INTO Orders  (
	   OrderDiscription,
	   OrderDate,
	   OrderAmount,
	   CustomerID
	   )
    VALUES (
	   @OrderDiscription,
	   GETDATE(),
	   @OrderAmount,
	   @customerID
	   )
END
GO
/****** Object:  StoredProcedure [dbo].[GetOrderDetails]    Script Date: 7/12/2022 1:51:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Kunwer Absar>
-- Create date: <Create Date, 07/11/2022 ,>
-- Description:	<Description, get order details from DB,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOrderDetails]
	 
AS
BEGIN
Select O.OrderAmount, o.OrderDate,o.OrderDiscription,o.OrderNo, c.CustomerName,c.CustomerAddress from Orders o 
Left outer join Customer c on c.CustomerID=O.CustomerID
End

GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/12/2022 1:51:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](100) NOT NULL,
	[CustomerAddress] [varchar](250) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 7/12/2022 1:51:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderNo] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [datetime] NOT NULL,
	[OrderDiscription] [varchar](250) NULL,
	[OrderAmount] [int] NOT NULL,
	[CustomerID] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [TestTask] SET  READ_WRITE 
GO
