USE [master]
GO
/****** Object:  Database [Limestone]    Script Date: 12/25/2021 2:25:32 AM ******/
CREATE DATABASE [Limestone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SA\MSSQL\DATA\test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SA\MSSQL\DATA\test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Limestone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Limestone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Limestone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Limestone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Limestone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Limestone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Limestone] SET ARITHABORT OFF 
GO
ALTER DATABASE [Limestone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Limestone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Limestone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Limestone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Limestone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Limestone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Limestone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Limestone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Limestone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Limestone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Limestone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Limestone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Limestone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Limestone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Limestone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Limestone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Limestone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Limestone] SET RECOVERY FULL 
GO
ALTER DATABASE [Limestone] SET  MULTI_USER 
GO
ALTER DATABASE [Limestone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Limestone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Limestone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Limestone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Limestone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Limestone] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Limestone', N'ON'
GO
ALTER DATABASE [Limestone] SET QUERY_STORE = OFF
GO
USE [Limestone]
GO
/****** Object:  Table [dbo].[ContractData]    Script Date: 12/25/2021 2:25:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PhaseOfContract] [nvarchar](50) NULL,
	[OriginalAmountCurrency] [nvarchar](10) NULL,
	[OriginalAmountValue] [decimal](18, 0) NULL,
	[InstallmentAmountCurrency] [nvarchar](10) NULL,
	[InstallmentAmountValue] [decimal](18, 0) NULL,
	[CurrentBalanceCurrency] [nvarchar](10) NULL,
	[CurrentBalanceValue] [decimal](18, 0) NULL,
	[OverdueBalanceCurrency] [nvarchar](10) NULL,
	[OverdueBalanceValue] [decimal](18, 0) NULL,
	[DateOfLastPayment] [datetime] NULL,
	[NextPaymentDate] [datetime] NULL,
	[DateAccountOpened] [datetime] NULL,
	[RealEndDate] [datetime] NULL,
	[ContractCode] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Individual]    Script Date: 12/25/2021 2:25:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Individual](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](20) NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [nvarchar](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[NationalId] [nvarchar](50) NULL,
	[ContractCode] [nvarchar](20) NULL,
 CONSTRAINT [PK__Individu__3214EC07E65C97CE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubjectRole]    Script Date: 12/25/2021 2:25:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerCode] [nvarchar](20) NULL,
	[RoleOfCustomer] [nvarchar](20) NULL,
	[GuaranteeAmountCurrency] [nvarchar](10) NULL,
	[GuaranteeAmountValue] [decimal](18, 0) NULL,
	[ContractCode] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Limestone] SET  READ_WRITE 
GO
