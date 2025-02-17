USE [master]
GO
/****** Object:  Database [QL_T_MN]    Script Date: 11/04/2024 5:45:19 CH ******/
CREATE DATABASE [QL_T_MN]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QL_T_MN', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_T_MN.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QL_T_MN_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\QL_T_MN_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QL_T_MN] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_T_MN].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_T_MN] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QL_T_MN] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QL_T_MN] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QL_T_MN] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QL_T_MN] SET ARITHABORT OFF 
GO
ALTER DATABASE [QL_T_MN] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QL_T_MN] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QL_T_MN] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QL_T_MN] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QL_T_MN] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QL_T_MN] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QL_T_MN] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QL_T_MN] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QL_T_MN] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QL_T_MN] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QL_T_MN] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QL_T_MN] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QL_T_MN] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QL_T_MN] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QL_T_MN] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QL_T_MN] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QL_T_MN] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QL_T_MN] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QL_T_MN] SET  MULTI_USER 
GO
ALTER DATABASE [QL_T_MN] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QL_T_MN] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QL_T_MN] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QL_T_MN] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QL_T_MN] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QL_T_MN] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QL_T_MN] SET QUERY_STORE = ON
GO
ALTER DATABASE [QL_T_MN] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QL_T_MN]
GO
/****** Object:  User [TN207User]    Script Date: 11/04/2024 5:45:21 CH ******/
CREATE USER [TN207User] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [abc]    Script Date: 11/04/2024 5:45:21 CH ******/
CREATE USER [abc] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/04/2024 5:45:22 CH ******/
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
/****** Object:  Table [dbo].[co_mon_hoc]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[co_mon_hoc](
	[MA_MON] [varchar](10) NOT NULL,
	[MA_LOAI] [varchar](10) NOT NULL,
 CONSTRAINT [PK_CO_MON_HOC] PRIMARY KEY CLUSTERED 
(
	[MA_MON] ASC,
	[MA_LOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIANG DAY]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIANG DAY](
	[HOC_KY] [int] NOT NULL,
	[NAM_HOC] [int] NOT NULL,
	[MA_GV] [varchar](10) NOT NULL,
	[MA_LOP] [varchar](10) NOT NULL,
 CONSTRAINT [PK_GIANG DAY] PRIMARY KEY CLUSTERED 
(
	[HOC_KY] ASC,
	[NAM_HOC] ASC,
	[MA_GV] ASC,
	[MA_LOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GIAO VIEN]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GIAO VIEN](
	[MA_GV] [varchar](10) NOT NULL,
	[TEN_GV] [nvarchar](50) NOT NULL,
	[CHUC_VU] [nvarchar](30) NOT NULL,
	[SDT_GV] [varchar](11) NOT NULL,
	[AvatarGV] [varchar](150) NULL,
	[DiaChi] [ntext] NOT NULL,
	[GioiTinh] [bit] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOC_KY_NAM_HOC]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOC_KY_NAM_HOC](
	[HOC_KY] [int] NOT NULL,
	[NAM_HOC] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hoc_lop]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hoc_lop](
	[MA_LOP] [varchar](10) NOT NULL,
	[MA_TE] [varchar](10) NOT NULL,
 CONSTRAINT [PK_HOC_LOP] PRIMARY KEY CLUSTERED 
(
	[MA_LOP] ASC,
	[MA_TE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAI_LOP]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAI_LOP](
	[MA_LOAI] [varchar](10) NOT NULL,
	[TEN_LOAI] [nvarchar](30) NOT NULL,
	[DO_TUOI_BAT_DAU] [int] NOT NULL,
	[DO_TUOI_KET_THUC] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOP]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOP](
	[MA_LOP] [varchar](10) NOT NULL,
	[MA_LOAI] [varchar](10) NOT NULL,
	[MA_PHONG] [varchar](10) NOT NULL,
	[TEN_LOP] [nvarchar](30) NOT NULL,
	[SI_SO] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MON HOC]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MON HOC](
	[MA_MON] [varchar](10) NOT NULL,
	[TEN_MON] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHIEU LIEN LAC]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEU LIEN LAC](
	[MA_TE] [varchar](10) NOT NULL,
	[Thang] [char](10) NOT NULL,
	[Nam] [char](10) NOT NULL,
	[Loi_Nhan_Xet] [ntext] NOT NULL,
 CONSTRAINT [PK_PHIEU LIEN LAC] PRIMARY KEY CLUSTERED 
(
	[MA_TE] ASC,
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHONG HOC]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHONG HOC](
	[MA_PHONG] [varchar](10) NOT NULL,
	[TEN_PHONG] [nvarchar](30) NOT NULL,
	[SUC_CHUA] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PHU HUYNH]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHU HUYNH](
	[MA_PH] [varchar](10) NOT NULL,
	[TEN_PH] [nvarchar](50) NOT NULL,
	[SDT_PHUHUYNH] [varchar](11) NOT NULL,
	[DIA_CHI_PH] [nvarchar](100) NOT NULL,
	[GioiTinh] [bit] NOT NULL,
	[NgaySinh] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THE TRANG]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THE TRANG](
	[MA_TE] [varchar](10) NOT NULL,
	[Thang] [char](10) NOT NULL,
	[Nam] [char](10) NOT NULL,
	[Chieu_cao] [float] NOT NULL,
	[Can_nang] [float] NOT NULL,
 CONSTRAINT [PK_THE TRANG] PRIMARY KEY CLUSTERED 
(
	[MA_TE] ASC,
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THOI GIAN]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THOI GIAN](
	[Thang] [char](10) NOT NULL,
	[Nam] [char](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TRE EM]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRE EM](
	[MA_TE] [varchar](10) NOT NULL,
	[MA_PH] [varchar](10) NOT NULL,
	[TEN_TE] [nvarchar](50) NOT NULL,
	[GIOI_TINH] [bit] NOT NULL,
	[AvatarTE] [varchar](150) NOT NULL,
	[NgaySinhTE] [date] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[maPH] [varchar](10) NULL,
	[maGV] [varchar](10) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 11/04/2024 5:45:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240322125454_InitDB', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240322160012_IdentityDb', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240322160845_UpdateIdentity', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240322161934_UpdateGVPH', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240322162437_UpdateGVPH2', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240322163014_UpdateGVPH3', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240323030421_AddAvatarGV', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240404141610_UpdateGVField', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240405070342_UpdatePHTEField', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240405070519_AddNgaySinhTe', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240410032910_updateTypeDB', N'8.0.3')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240410033934_updateTypeDB2', N'8.0.3')
GO
INSERT [dbo].[co_mon_hoc] ([MA_MON], [MA_LOAI]) VALUES (N'M01', N'LL01')
INSERT [dbo].[co_mon_hoc] ([MA_MON], [MA_LOAI]) VALUES (N'M02', N'LL03')
GO
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2024, N'GV07', N'L010')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2024, N'GV07', N'L011')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2024, N'GV09', N'L012')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2024, N'GV01', N'L013')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV01', N'L014')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV03', N'L015')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV05', N'L016')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV07', N'L017')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV06', N'L018')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV08', N'L019')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV010', N'L020')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV011', N'L021')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV013', N'L022')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV012', N'L023')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2023, N'GV09', N'L024')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV07', N'L025')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV03', N'L026')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV01', N'L027')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV05', N'L028')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV08', N'L029')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV06', N'L030')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV012', N'L031')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV09', N'L032')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV010', N'L033')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV013', N'L034')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2023, N'GV011', N'L035')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (2, 2024, N'GV014', N'L037')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2024, N'GV09', N'L07')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2024, N'GV05', N'L08')
INSERT [dbo].[GIANG DAY] ([HOC_KY], [NAM_HOC], [MA_GV], [MA_LOP]) VALUES (1, 2024, N'GV06', N'L09')
GO
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV01', N'Nguyen Thi Bich Ngoc', N'Giao Vien Lop', N'0956872791', N'avatar1_7baa.jpg', N'Phường Xuân Khánh, Ninh Kiều, Cần Thơ', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV012', N'Tran Thi Thuy Dung', N'Giao Vien Lop', N'0974821922', N'avatar4_bbdc.jpg', N'Tiền Giang', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV03', N'Le Thi Yen A', N'Giao Vien Lop', N'0974821973', N'avatar13_972c.jpg', N'Quan Ninh Kieu, Can Tho', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV013', N'Tran Hoang Nam', N'Giao Vien Lop', N'0928182938', N'avatar15_ebd1.jpg', N'Cần Thơ', 1)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV05', N'Nguyen Thi Bich B', N'Giao Vien Lop', N'0956872793', N'avatar5_52c1.jpg', N'Quan Ninh Kieu, Can Tho', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV06', N'Bui Thi My C', N'Giao Vien Lop', N'0956872796', N'avatar6_86d9.jpg', N'Quan Ninh Kieu, Can Tho', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV07', N'Nguyen Thi D', N'Giao Vien Lop', N'0978291021', N'avatar7_dff6.jpg', N'Quan Ninh Kieu, Can Tho', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV09', N'Nguyen Xuan A', N'Giao Vien Lop', N'0956872797', N'avatar9_0b1f.jpg', N'Quan Ninh Kieu, Can Tho', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV010', N'Nguyen Xuan B', N'Giao Vien Lop', N'0956872722', N'avatar10_bd58.jpg', N'Quan Ninh Kieu, Can Tho', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV011', N'Nguyen Thi Anh Xuan ', N'Giao Vien Lop', N'0962819233', N'avatar11_0f19.jpg', N'Quan Bình Thủy, Cần Thơ', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV014', N'Nguyen Mai Mai', N'Giao Vien Lop', N'0956872794', N'avatar16_75ae.jpg', N'Ninh Kiều, Cần Thơ', 0)
INSERT [dbo].[GIAO VIEN] ([MA_GV], [TEN_GV], [CHUC_VU], [SDT_GV], [AvatarGV], [DiaChi], [GioiTinh]) VALUES (N'GV08', N'Nguyen Hoang Nam', N'Giao Vien Lop', N'0978412345', N'avatar8_22aa.jpg', N'Quan Ninh Kieu, Can Tho', 1)
GO
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2020)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2021)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2022)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2023)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2024)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2025)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (1, 2026)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2020)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2021)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2022)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2023)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2024)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2025)
INSERT [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC]) VALUES (2, 2026)
GO
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L011', N'TE010')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L037', N'TE011')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L07', N'TE011')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L07', N'TE02')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L011', N'TE05')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L013', N'TE06')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L07', N'TE06')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L011', N'TE07')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L011', N'TE08')
INSERT [dbo].[hoc_lop] ([MA_LOP], [MA_TE]) VALUES (N'L011', N'TE09')
GO
INSERT [dbo].[LOAI_LOP] ([MA_LOAI], [TEN_LOAI], [DO_TUOI_BAT_DAU], [DO_TUOI_KET_THUC]) VALUES (N'LL01', N'Lop Mam', 3, 4)
INSERT [dbo].[LOAI_LOP] ([MA_LOAI], [TEN_LOAI], [DO_TUOI_BAT_DAU], [DO_TUOI_KET_THUC]) VALUES (N'LL02', N'Lop Choi', 4, 5)
INSERT [dbo].[LOAI_LOP] ([MA_LOAI], [TEN_LOAI], [DO_TUOI_BAT_DAU], [DO_TUOI_KET_THUC]) VALUES (N'LL03', N'Lop La', 5, 6)
GO
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L012', N'LL02', N'PH09', N'Lop Hoc 12', 5)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L013', N'LL01', N'PH08', N'Lop Hoc 13', 6)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L037', N'LL01', N'PH010', N'Lop Hoc 15', 15)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L014', N'LL03', N'PH01', N'Lop Hoc 14', 20)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L07', N'LL01', N'PH02', N'Lop Hoc 07', 24)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L08', N'LL01', N'PH03', N'Lop Hoc 08', 31)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L09', N'LL02', N'PH07', N'Lop Hoc 09', 27)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L010', N'LL02', N'PH05', N'Lop Hoc 10', 24)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L011', N'LL03', N'PH09', N'Lop Hoc 11', 26)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L015', N'LL02', N'PH02', N'Lop Hoc 15', 21)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L016', N'LL02', N'PH03', N'Lop Hoc 16', 22)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L017', N'LL02', N'PH04', N'Lop Hoc 17', 22)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L018', N'LL01', N'PH05', N'Lop Hoc 18', 23)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L019', N'LL01', N'PH06', N'Lop Hoc 19', 20)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L020', N'LL02', N'PH07', N'Lop Hoc 21', 19)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L021', N'LL03', N'PH08', N'Lop Hoc 22', 23)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L022', N'LL01', N'PH09', N'Lop Hoc 23', 24)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L023', N'LL02', N'PH010', N'Lop Hoc 24', 18)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L024', N'LL03', N'PH011', N'Lop Hoc 25', 24)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L025', N'LL03', N'PH01', N'Lop Hoc 25', 20)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L026', N'LL02', N'PH02', N'Lop Hoc 26', 21)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L027', N'LL02', N'PH03', N'Lop Hoc 27', 22)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L028', N'LL02', N'PH04', N'Lop Hoc 28', 22)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L029', N'LL01', N'PH05', N'Lop Hoc 29', 23)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L030', N'LL01', N'PH06', N'Lop Hoc 30', 20)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L031', N'LL02', N'PH07', N'Lop Hoc 31', 19)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L032', N'LL03', N'PH08', N'Lop Hoc 32', 23)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L033', N'LL01', N'PH09', N'Lop Hoc 33', 24)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L034', N'LL02', N'PH010', N'Lop Hoc 34', 18)
INSERT [dbo].[LOP] ([MA_LOP], [MA_LOAI], [MA_PHONG], [TEN_LOP], [SI_SO]) VALUES (N'L035', N'LL03', N'PH011', N'Lop Hoc 35', 24)
GO
INSERT [dbo].[MON HOC] ([MA_MON], [TEN_MON]) VALUES (N'M01', N'Múa nhảy hát')
INSERT [dbo].[MON HOC] ([MA_MON], [TEN_MON]) VALUES (N'M02', N'Thủ Công')
GO
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'1         ', N'2023      ', N'Bé chăm học, học giỏi, nghe lời cô')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'1         ', N'2024      ', N'Bé chưa nhận dạng tốt các chữ cái B C D')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'10        ', N'2023      ', N'Bé học chăm, ngoan, tiến bộ')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'11        ', N'2023      ', N'Bé biết san sẻ với các bạn trong lớp')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'12        ', N'2023      ', N'Bé tham gia hoạt động trồng cây tốt')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'2         ', N'2023      ', N'Bé hiền, chăm ngoan, hay nhường các bạn')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'2         ', N'2024      ', N'Bé có tư duy bố cục')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'3         ', N'2023      ', N'Bé ngoan, tuy nhiên hay khóc nhè')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'3         ', N'2024      ', N'Bé có năng khiếu trong lĩnh vực sắp xếp bố cục')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'4         ', N'2023      ', N'Bé có tiến bộ, vâng lời cô giáo')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'5         ', N'2023      ', N'Bé có tư duy tốt, phân biệt được các hình dạng, màu sắc')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'6         ', N'2023      ', N'Bé học chăm, tích cực phát biểu')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'7         ', N'2023      ', N'Bé ngoan, nghe lời cô, được cái bạn yêu mến')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'8         ', N'2023      ', N'Bé nhận dạng tốt các chữ cái A, Ă, Â')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE02', N'9         ', N'2023      ', N'Bé dễ thương, quan tâm người khác')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'1         ', N'2023      ', N'Bé chăm học, học giỏi')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'1         ', N'2024      ', N'Bé nhận dạng tốt các chữ cái B C D')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'10        ', N'2023      ', N'Bé có tiến bộ, biết nhường các bạn')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'11        ', N'2023      ', N'Bé biết san sẻ với các bạn trong lớp')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'12        ', N'2023      ', N'Bé biết yêu thương động vật')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'2         ', N'2023      ', N'Bé học giỏi, nhưng hay đánh nhau với bạn')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'2         ', N'2024      ', N'Bé tô màu chưa tốt, tuy nhiên bé có tư duy trong lĩnh vực toán học')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'3         ', N'2023      ', N'Bé ngoan hơn, nhưng vẫn còn đánh bạn')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'3         ', N'2024      ', N'Bé có năng khiếu trong lĩnh vự tư duy')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'4         ', N'2023      ', N'Bé có tiến bộ, vâng lời cô giáo')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'5         ', N'2023      ', N'Bé có tư duy tốt, mạnh mẽ')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'6         ', N'2023      ', N'Bé học tốt, ăn hiếp các bạn khác')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'7         ', N'2023      ', N'Bé ủng hộ bạn khác giật tóc bạn trong lớp')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'8         ', N'2023      ', N'Bé nhận dạng tốt các chữ cái A, Ă, Â')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE03', N'9         ', N'2023      ', N'Bé hay đánh trong lớp học')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'1         ', N'2023      ', N'Bé chăm học, học giỏi, nghe lời cô')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'1         ', N'2024      ', N'Bé nhận dạng tốt các chữ cái B C D')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'10        ', N'2023      ', N'Bé học chăm, ngoan, tiến bộ')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'11        ', N'2023      ', N'Bé biết san sẻ với các bạn trong lớp')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'12        ', N'2023      ', N'Bé biết yêu thương động vật, tham gia hoạt động trồng cây tốt')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'2         ', N'2023      ', N'Bé học tốt, năng động')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'2         ', N'2024      ', N'Bé học chăm, ngoan, đáng khen')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'3         ', N'2023      ', N'Bé ngoan, nghe lời cô giáo')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'3         ', N'2024      ', N'Bé có năng khiếu trong lĩnh vực phân biệt')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'4         ', N'2023      ', N'Bé tiến bộ, vâng lời cô giáo')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'4         ', N'2024      ', N'Học Giỏi Chăm Ngoan')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'5         ', N'2023      ', N'Bé có tư duy tốt, phân biệt được các hình dạng, màu sắc')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'6         ', N'2023      ', N'Bé chăm ngoan, các bạn yêu mến')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'7         ', N'2023      ', N'Bé học rất tiến bộ, hòa đồng với các bạn')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'8         ', N'2023      ', N'Bé nhận dạng tốt các chữ cái A, Ă, Â')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE05', N'9         ', N'2023      ', N'Bé hay giúp đỡ trong lớp học')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'1         ', N'2023      ', N'Bé hay đùa giỡn trong giờ học')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'1         ', N'2024      ', N'Bé nhận dạng tốt các chữ cái B C D')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'10        ', N'2023      ', N'Bé tiến bộ, không còn bắt nạt bạn, học ngoan')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'11        ', N'2023      ', N'Bé biết yêu thương với các bạn trong lớp')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'12        ', N'2023      ', N'Bé biết yêu thương động vật, tham gia hoạt động trồng cây tốt')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'2         ', N'2023      ', N'Bé đùa giỡn nhiều, gây mất trật tự')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'2         ', N'2024      ', N'Bé học chăm, ngoa, giỏi')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'3         ', N'2023      ', N'Bé ngoan hơn, nhưng vẫn còn nói chuyện riêng')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'3         ', N'2024      ', N'Bé có tiến bộ rõ rệt, hòa đồng với các bạn')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'4         ', N'2023      ', N'Bé có tiến bộ, vâng lời cô giáo')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'5         ', N'2023      ', N'Bé có tư duy tốt, phân biệt được các hình dạng, màu sắc')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'6         ', N'2023      ', N'Bé học chăm nhưng hay gây mất trật tự')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'7         ', N'2023      ', N'Bé học ngoan, nghe lời cô')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'8         ', N'2023      ', N'Bé nhận dạng tốt các chữ cái A, Ă, Â')
INSERT [dbo].[PHIEU LIEN LAC] ([MA_TE], [Thang], [Nam], [Loi_Nhan_Xet]) VALUES (N'TE06', N'9         ', N'2023      ', N'Bé hay bắt nạt các bạn trong lớp học')
GO
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH01', N'Phong Day 01', 30)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH02', N'Phong Day 02', 25)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH03', N'Phong Day 03', 32)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH04', N'Phong Day 04', 32)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH05', N'Phong Day 05', 27)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH06', N'Phong Day 06', 30)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH07', N'Phong Day 07', 27)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH08', N'Phong Day 08', 35)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH09', N'Phong Day 09', 26)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH010', N'Phong Day 10', 34)
INSERT [dbo].[PHONG HOC] ([MA_PHONG], [TEN_PHONG], [SUC_CHUA]) VALUES (N'PH011', N'Phong Day 11', 30)
GO
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH02', N'Lê Văn C', N'0123456789', N'789 Hai Bà Trưng', 1, CAST(N'2000-03-03' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH03', N'Trần Thành Nhân', N'0789548215', N'hẻm 123, đường 3/2, phường Xuân Khánh, quận Ninh Kiều, TP Cần Thơ', 1, CAST(N'2000-03-03' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH011', N'Lê Văn Tú', N'0913451123', N'Hậu Giang', 1, CAST(N'1996-10-05' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH05', N'Trần Hoàng Nam', N'0921919367', N'TP.Hồ Chí Minh', 1, CAST(N'1999-10-10' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH06', N'Nguyễn Trúc Huyền', N'0921927632', N'Bình Thủy, Cần Thơ', 0, CAST(N'1999-10-20' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH07', N'Tran Khanh Hoang', N'0913451341', N'Can Tho', 1, CAST(N'1995-02-01' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH08', N'Pham Khanh An', N'0927382712', N'Can Tho', 0, CAST(N'1994-05-14' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH09', N'Bui Tuan Hai', N'0983617283', N'Hau Giang', 1, CAST(N'1996-06-24' AS Date))
INSERT [dbo].[PHU HUYNH] ([MA_PH], [TEN_PH], [SDT_PHUHUYNH], [DIA_CHI_PH], [GioiTinh], [NgaySinh]) VALUES (N'PH010', N'Nguyen Khanh Ngan', N'0938172837', N'Can Tho', 0, CAST(N'1993-07-12' AS Date))
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'804ce746-2acf-4477-9999-3e58ae80e7b8', N'Administrator', N'ADMINISTRATOR', NULL)
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c1982e54-9927-4922-a582-03a1bdc33b1f', N'Normal', N'NORMAL', NULL)
GO
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'1         ', N'2023      ', 108, 12)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'1         ', N'2024      ', 112.5, 15.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'10        ', N'2023      ', 111.7, 14.6)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'11        ', N'2023      ', 111.9, 14.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'12        ', N'2023      ', 112.3, 14.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'2         ', N'2023      ', 108.5, 12.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'2         ', N'2024      ', 116.7, 17.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'3         ', N'2023      ', 109.2, 12.3)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'3         ', N'2024      ', 117.2, 17.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'4         ', N'2023      ', 110.7, 12.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'5         ', N'2023      ', 110.2, 13)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'6         ', N'2023      ', 110.5, 13.6)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'7         ', N'2023      ', 110.8, 13.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'8         ', N'2023      ', 111.1, 14.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE02', N'9         ', N'2023      ', 111.5, 14.3)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'1         ', N'2023      ', 112, 17)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'1         ', N'2024      ', 119, 20)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'10        ', N'2023      ', 117, 19.3)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'11        ', N'2023      ', 117.6, 19.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'12        ', N'2023      ', 118.3, 19.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'2         ', N'2023      ', 112.5, 17.3)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'2         ', N'2024      ', 119.7, 21.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'3         ', N'2023      ', 113, 17.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'3         ', N'2024      ', 120, 21.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'4         ', N'2023      ', 113.4, 17.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'5         ', N'2023      ', 113.9, 18)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'6         ', N'2023      ', 114.5, 18.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'7         ', N'2023      ', 115.1, 18.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'8         ', N'2023      ', 115.9, 19)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE03', N'9         ', N'2023      ', 116.2, 19.1)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'1         ', N'2023      ', 115, 18)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'1         ', N'2024      ', 121.9, 20.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'10        ', N'2023      ', 120.3, 19.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'11        ', N'2023      ', 120.9, 19.9)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'12        ', N'2023      ', 121.3, 20.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'2         ', N'2023      ', 115.5, 18.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'2         ', N'2024      ', 122.4, 20.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'3         ', N'2023      ', 116.1, 18.6)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'3         ', N'2024      ', 123.2, 20.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'4         ', N'2023      ', 116.8, 18.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'4         ', N'2024      ', 123.4, 19.1)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'5         ', N'2023      ', 117.2, 18.9)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'6         ', N'2023      ', 117.9, 19)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'7         ', N'2023      ', 118.3, 19.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'8         ', N'2023      ', 118.9, 19.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE05', N'9         ', N'2023      ', 119.5, 19.6)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'1         ', N'2023      ', 110, 15)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'1         ', N'2024      ', 117.2, 16.9)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'10        ', N'2023      ', 115, 16.3)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'11        ', N'2023      ', 115.6, 16.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'12        ', N'2023      ', 116.3, 16.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'2         ', N'2023      ', 110.5, 15.1)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'2         ', N'2024      ', 117.7, 17.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'3         ', N'2023      ', 111.2, 15.2)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'3         ', N'2024      ', 118.2, 17.5)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'4         ', N'2023      ', 111.6, 15.4)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'5         ', N'2023      ', 112.2, 15.6)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'6         ', N'2023      ', 112.9, 15.7)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'7         ', N'2023      ', 113.4, 15.8)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'8         ', N'2023      ', 113.9, 16)
INSERT [dbo].[THE TRANG] ([MA_TE], [Thang], [Nam], [Chieu_cao], [Can_nang]) VALUES (N'TE06', N'9         ', N'2023      ', 114.5, 16.2)
GO
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'1         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'1         ', N'2024      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'10        ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'11        ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'12        ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'2         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'2         ', N'2024      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'3         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'3         ', N'2024      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'4         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'4         ', N'2024      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'5         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'6         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'7         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'8         ', N'2023      ')
INSERT [dbo].[THOI GIAN] ([Thang], [Nam]) VALUES (N'9         ', N'2023      ')
GO
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE02', N'PH02', N'Trần Thành Nam', 1, N'te2_3e14.jpg', CAST(N'2021-10-05' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE03', N'PH03', N'Tran Thi Hoai', 0, N'te4_6fa7.jpg', CAST(N'2020-12-08' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE011', N'PH011', N'Lê Thị Thúy Hạnh', 0, N'te5_af5f.jpg', CAST(N'2021-01-01' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE05', N'PH05', N'Trần Tuấn Anh', 1, N'te4_de29.jpg', CAST(N'2019-06-21' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE06', N'PH06', N'Nguyễn Quỳnh Như', 0, N'te5_dd9e.jpg', CAST(N'2021-10-10' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE07', N'PH07', N'Tran Thi Thuy Hanh', 0, N'te1_776e.jpg', CAST(N'2019-02-02' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE08', N'PH08', N'Pham Tuan Anh', 1, N'te2_ab19.jpg', CAST(N'2019-03-30' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE09', N'PH09', N'Bui Tuan Tu', 1, N'te3_ec9c.jpg', CAST(N'2019-04-04' AS Date))
INSERT [dbo].[TRE EM] ([MA_TE], [MA_PH], [TEN_TE], [GIOI_TINH], [AvatarTE], [NgaySinhTE]) VALUES (N'TE010', N'PH010', N'Pham Khanh Doan', 0, N'te4_95f4.jpg', CAST(N'2019-12-13' AS Date))
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'df28e587-7f1c-4464-a47f-af5e8340fe2c', N'804ce746-2acf-4477-9999-3e58ae80e7b8')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'0505ccae-5a95-464a-88a7-cb950cbdd8c9', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'3555af4d-fca2-48cd-96e3-c8bce0450af9', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'437215b5-4380-49d6-9875-284c0f5cdafa', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'52fe4569-b76c-43f9-b02e-668eacd1b3b1', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'54c2fa43-84f9-4156-b82b-5f302c2bf93c', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'91256ae6-3b39-430c-b33f-0190f943f20d', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'9a1b7e27-cc14-45b4-8ff0-7610bd0b778d', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'b044f448-826e-45c4-851e-89ff71f06685', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'bf91bdfe-ff6e-4d94-9d71-59fd078604ef', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'df28e587-7f1c-4464-a47f-af5e8340fe2c', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'f1a7c834-e6d5-436d-9914-e569ee5f3891', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'f3bdd086-297e-49f8-8e6c-71c3d1148070', N'c1982e54-9927-4922-a582-03a1bdc33b1f')
GO
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0345b6c7-4e61-4a4a-a076-d8af4d5a885c', N'PH05', NULL, N'ph3@gmail.com', N'PH3@GMAIL.COM', N'ph3@gmail.com', N'PH3@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEJFbitt8wsIfTAiATZOQVC+yNOl744RcKBZeAOptCbLgkpbEa/D85jnLVvmja8sz+Q==', N'OBPUZJPARLGM5PJIBQKE6W3PBZUMQFUV', N'7fbe37e4-4e6c-4342-9d2d-a59733f615ac', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0505ccae-5a95-464a-88a7-cb950cbdd8c9', NULL, N'GV013', N'gv12@gmail.com', N'GV12@GMAIL.COM', N'gv12@gmail.com', N'GV12@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEB1pFe1ZiqY07PMMDz0nuK9JrTRHuFOv2dciV94UDhwE2RIhPbkR5MyBtnXJWiTWRA==', N'4Y55YNLNDKKAQ7M5PMOCM7HBYSWXPFEE', N'b5d95909-210e-40cc-9c98-cb794a2ea4dc', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'3555af4d-fca2-48cd-96e3-c8bce0450af9', NULL, N'GV014', N'gv13@gmail.com', N'GV13@GMAIL.COM', N'gv13@gmail.com', N'GV13@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEGP1wJT7nn4Py51ottSKtP0fDl5kmdGFsbeAQNLiWKf9u15Gvpzq1uixbEXu0XhY0A==', N'A2P576UEEAZQ26XIEU7SHB3HQJ22LE7B', N'786e665c-a5aa-4905-92bf-b9d8e3037807', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'42faedd1-8b38-426d-8448-e1afdf0cedb8', N'PH011', NULL, N'ph9@gmail.com', N'PH9@GMAIL.COM', N'ph9@gmail.com', N'PH9@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAELLcjChg7ZWSAePHFtg9PDN+CLqNCuuEH9SE6OpYryf47rkfg/XU+PNBZJsYkAQbpA==', N'N65B2CVTBWOVXAC2SRWI6KDA6H7NZG2E', N'aee2b2b1-b62b-42a2-9cf3-6201050a02fe', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'437215b5-4380-49d6-9875-284c0f5cdafa', NULL, N'GV08', N'gv8@gmail.com', N'GV8@GMAIL.COM', N'gv8@gmail.com', N'GV8@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAECW1XeDGvA+gIIp6tCbtJGE9jVvF50baz+GPZ+ki+oOqVMe/eW4KQPwPZtj6iMWLfw==', N'PKAGSZLFCY2HXEJLYTHEUTMYZPFU7IKV', N'163cb632-79cd-4f69-9f2e-f11650db00ff', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'52fe4569-b76c-43f9-b02e-668eacd1b3b1', NULL, N'GV03', N'gv3@gmail.com', N'GV3@GMAIL.COM', N'gv3@gmail.com', N'GV3@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAELGEa3DI995JUqxEbVmxLaLKhm5GRuWQIUvOCeCjXJq7EfN2uDnPnwKYDsTCkd0BHA==', N'SDB6GN4HVGHXR7GRJF2DIWZPPWTCATOF', N'f1a5833c-3dee-47ca-8b07-feae434425d9', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'54c2fa43-84f9-4156-b82b-5f302c2bf93c', NULL, N'GV06', N'gv6@gmail.com', N'GV6@GMAIL.COM', N'gv6@gmail.com', N'GV6@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEAqkCmtDlHdsMCYNyEvZjC7gBANFnuiSVjpCLOOXvvSb6hi7ll9u+sv5k/iCoVp9+Q==', N'5I7BVJD5BVYLXH5KEAVF4SCRGMKT33PJ', N'9ab4dc07-8a70-4e86-832f-2f02471be329', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'78aaa30c-8606-402f-97bf-8348e3a20000', N'PH07', NULL, N'ph5@gmail.com', N'PH5@GMAIL.COM', N'ph5@gmail.com', N'PH5@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEBQyA0tCfXV2X0h5d7LCEEuGxHt/vjsHcH/ofMWw9Z3ZO4ZYD14uzyX1e1CkXcAZ0g==', N'E34IJJADQE4NMJVANJDGI5VLVWWVDF4H', N'0c2e7edd-0f75-4058-9419-90bdb7205b2a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'91256ae6-3b39-430c-b33f-0190f943f20d', NULL, N'GV07', N'gv7@gmail.com', N'GV7@GMAIL.COM', N'gv7@gmail.com', N'GV7@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAELzrjh4uqoeyMM+hejAjjsVbGHpuMnLf890npePpneLb711PprieqrfB+AMkVH+8Uw==', N'47Z3AW73EXKMOFANRLCPG6MSIGID7WYT', N'5e6559e6-c2eb-4b13-a1f5-db9126f99c5a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9a1b7e27-cc14-45b4-8ff0-7610bd0b778d', NULL, N'GV05', N'gv5@gmail.com', N'GV5@GMAIL.COM', N'gv5@gmail.com', N'GV5@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEJ9Z0DGJ3xKSRB9Wv6+ZiNtjJiO6BUxt/2nvv2b4rNpy+K2Xj+2ohMNYQwtRpXhrkw==', N'UVWFKEXO6MO75FWXRN66QYEUBVMRG2LQ', N'e8720dd2-973c-4857-b872-7d6c8ea9a889', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a035142d-9478-4db0-a6ef-100886787ac3', N'PH08', NULL, N'ph6@gmail.com', N'PH6@GMAIL.COM', N'ph6@gmail.com', N'PH6@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEDJx9lYOwjROgDNt0U+Mj3IvScxTYNbB+8s2SL3htsrPdTe64oAZnNKlXiE/J6Ub+Q==', N'73QI3JLCYUQGI53UQLTTVQOSAS2K2L4W', N'27c2e8c3-282f-487a-835d-e29c2fc91c37', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'aa3de377-e508-40fb-9d37-79ef3d815069', N'PH06', NULL, N'ph4@gmail.com', N'PH4@GMAIL.COM', N'ph4@gmail.com', N'PH4@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEO8xmZ3szr5WnzL3dSJIRC7h1U6OZJ3xeTXJXxwSZ+SC4+pRMyRpoIRfzC/9ha4ppA==', N'AFSHIKDV3F2WBEGCZDZ3J5H6MRX4YA6L', N'91e2e514-9f9a-425d-8eba-c345c873b543', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'b044f448-826e-45c4-851e-89ff71f06685', NULL, N'GV012', N'gv4@gmail.com', N'GV4@GMAIL.COM', N'gv4@gmail.com', N'GV4@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEPxWpyfhnAj3vuDbicQLr/99U7E3HRWHHuoCAH7FfbZZBphilKfJszRMVZgi0OwSYA==', N'EPKB7BJDOBKPM5B4LTRXES4LEDAWMIPW', N'49e23f5e-bd64-4b78-a370-75deb0db315c', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ba2d906b-3622-46da-9ff1-01005ad68465', N'PH09', NULL, N'ph7@gmail.com', N'PH7@GMAIL.COM', N'ph7@gmail.com', N'PH7@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEIwvu99JmGJJVYMhRoGeZon8uSN/gRL5BUau9gzb3JrI3eNWsYqSasqpUiiuv1nz9w==', N'WKRRBFLWQ7CC5HFYHSZDOMUJRN3NW4Y2', N'4588febe-dfa8-4c1d-a20c-ebdff9d0b313', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bf91bdfe-ff6e-4d94-9d71-59fd078604ef', NULL, N'GV010', N'gv10@gmail.com', N'GV10@GMAIL.COM', N'gv10@gmail.com', N'GV10@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEEmZIBPsvf+AjgOxdv/YFUb6xYuEuaP00b83/UfmGLlxGHBfy8EGglEoAhkFCCHMuw==', N'XZUI4LSG6QRVKOJFFIFLMGCHIEIBPSD4', N'fa6aa9b3-4cdf-483e-ab89-f610540417d3', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ce9194fa-6a2b-4283-9cc7-4d7326aebd7b', N'PH010', NULL, N'ph8@gmail.com', N'PH8@GMAIL.COM', N'ph8@gmail.com', N'PH8@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEIlrx5EbbT2cy/GLDHlx32L3pgeQjoD80nbNs/8pOcnJ6nmH6mhh0ubfZPFWcQZtWw==', N'DA7ZZI6HDG2UU36TLPPOKPCXQ6OUGJ3W', N'9967600b-0bb4-4b37-b899-689f152bd731', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'df28e587-7f1c-4464-a47f-af5e8340fe2c', NULL, N'GV01', N'gv1@gmail.com', N'GV1@GMAIL.COM', N'gv1@gmail.com', N'GV1@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEHsUZGJWvqLvhrqpuPaHRsJsh/3JS0TbHNEP7x0fGYHmMSQKMZGh4liBFvb/eXkOXg==', N'UMGRNLWFIWL2DE6JON5BQSIV2N2MOSTY', N'b24649f2-e8d0-4311-a3da-6d97f6be45a4', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f1a7c834-e6d5-436d-9914-e569ee5f3891', NULL, N'GV09', N'gv9@gmail.com', N'GV9@GMAIL.COM', N'gv9@gmail.com', N'GV9@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEFSyp6D4al1k4Kwa26xADG2g6B4oe1J51R97osqXc5/x/lN7AHnzJiwKFf0N/rZRaA==', N'PJRXMD75ESOXGUIADPEZ5WEFF23VEQ7I', N'9797f4f1-24be-4dd8-a086-0044ba66dd95', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [maPH], [maGV], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'f3bdd086-297e-49f8-8e6c-71c3d1148070', NULL, N'GV011', N'gv11@gmail.com', N'GV11@GMAIL.COM', N'gv11@gmail.com', N'GV11@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEMz3XTzAvhlOFBZqOg1Wfy+rVAYO0c9Sz4U9Oct2NMn1Zlff7kylkEaHEdybhzlvuA==', N'2I4REBUMSPYXZXAKDH27S3NM4J6J6RVX', N'7030313e-1ddb-4d4a-8092-85d2811f01c4', NULL, 0, 0, NULL, 1, 0)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CO_MON_HOC_FK]    Script Date: 11/04/2024 5:45:23 CH ******/
CREATE NONCLUSTERED INDEX [CO_MON_HOC_FK] ON [dbo].[co_mon_hoc]
(
	[MA_MON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CO_MON_HOC2_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [CO_MON_HOC2_FK] ON [dbo].[co_mon_hoc]
(
	[MA_LOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [DAY_O_HOC_KY_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [DAY_O_HOC_KY_FK] ON [dbo].[GIANG DAY]
(
	[HOC_KY] ASC,
	[NAM_HOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [GIANG_DAY_O_LOP_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [GIANG_DAY_O_LOP_FK] ON [dbo].[GIANG DAY]
(
	[MA_LOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [GIAO_VIEN_GIANG_DAY_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [GIAO_VIEN_GIANG_DAY_FK] ON [dbo].[GIANG DAY]
(
	[MA_GV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_GIAO VIEN]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[GIAO VIEN] ADD  CONSTRAINT [PK_GIAO VIEN] PRIMARY KEY NONCLUSTERED 
(
	[MA_GV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [PK_HOC_KY_NAM_HOC]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[HOC_KY_NAM_HOC] ADD  CONSTRAINT [PK_HOC_KY_NAM_HOC] PRIMARY KEY NONCLUSTERED 
(
	[HOC_KY] ASC,
	[NAM_HOC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HOC_LOP_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [HOC_LOP_FK] ON [dbo].[hoc_lop]
(
	[MA_LOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HOC_LOP2_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [HOC_LOP2_FK] ON [dbo].[hoc_lop]
(
	[MA_TE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_LOAI_LOP]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[LOAI_LOP] ADD  CONSTRAINT [PK_LOAI_LOP] PRIMARY KEY NONCLUSTERED 
(
	[MA_LOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_LOP]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[LOP] ADD  CONSTRAINT [PK_LOP] PRIMARY KEY NONCLUSTERED 
(
	[MA_LOP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CO_LOAI_LOP_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [CO_LOAI_LOP_FK] ON [dbo].[LOP]
(
	[MA_LOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [HOC_TAI_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [HOC_TAI_FK] ON [dbo].[LOP]
(
	[MA_PHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_MON HOC]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[MON HOC] ADD  CONSTRAINT [PK_MON HOC] PRIMARY KEY NONCLUSTERED 
(
	[MA_MON] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CO_PHIEU_LIEN_LAC_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [CO_PHIEU_LIEN_LAC_FK] ON [dbo].[PHIEU LIEN LAC]
(
	[MA_TE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PHIEU_LIEN_LAC_O_THANG_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [PHIEU_LIEN_LAC_O_THANG_FK] ON [dbo].[PHIEU LIEN LAC]
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_PHONG HOC]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[PHONG HOC] ADD  CONSTRAINT [PK_PHONG HOC] PRIMARY KEY NONCLUSTERED 
(
	[MA_PHONG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_PHU HUYNH]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[PHU HUYNH] ADD  CONSTRAINT [PK_PHU HUYNH] PRIMARY KEY NONCLUSTERED 
(
	[MA_PH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_RoleClaims_RoleId]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_RoleClaims_RoleId] ON [dbo].[RoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[Roles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CO_THE_TRANG_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [CO_THE_TRANG_FK] ON [dbo].[THE TRANG]
(
	[MA_TE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [THE_TRANG_TAI_THOI_GIAN_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [THE_TRANG_TAI_THOI_GIAN_FK] ON [dbo].[THE TRANG]
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_THOI GIAN]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[THOI GIAN] ADD  CONSTRAINT [PK_THOI GIAN] PRIMARY KEY NONCLUSTERED 
(
	[Thang] ASC,
	[Nam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [PK_TRE EM]    Script Date: 11/04/2024 5:45:24 CH ******/
ALTER TABLE [dbo].[TRE EM] ADD  CONSTRAINT [PK_TRE EM] PRIMARY KEY NONCLUSTERED 
(
	[MA_TE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [LA_PHU_HUYNH_FK]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [LA_PHU_HUYNH_FK] ON [dbo].[TRE EM]
(
	[MA_PH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserClaims_UserId]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_UserClaims_UserId] ON [dbo].[UserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserLogins_UserId]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_UserLogins_UserId] ON [dbo].[UserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserRoles_RoleId]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [IX_UserRoles_RoleId] ON [dbo].[UserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[Users]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_maGV]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_maGV] ON [dbo].[Users]
(
	[maGV] ASC
)
WHERE ([maGV] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_maPH]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_maPH] ON [dbo].[Users]
(
	[maPH] ASC
)
WHERE ([maPH] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 11/04/2024 5:45:24 CH ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[Users]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GIAO VIEN] ADD  DEFAULT (N'') FOR [DiaChi]
GO
ALTER TABLE [dbo].[GIAO VIEN] ADD  DEFAULT (CONVERT([bit],(0))) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[PHU HUYNH] ADD  DEFAULT (CONVERT([bit],(0))) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[PHU HUYNH] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [NgaySinh]
GO
ALTER TABLE [dbo].[TRE EM] ADD  DEFAULT (CONVERT([bit],(0))) FOR [GIOI_TINH]
GO
ALTER TABLE [dbo].[TRE EM] ADD  DEFAULT ('') FOR [AvatarTE]
GO
ALTER TABLE [dbo].[TRE EM] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [NgaySinhTE]
GO
ALTER TABLE [dbo].[co_mon_hoc]  WITH CHECK ADD  CONSTRAINT [FK_CO_MON_H_CO_MON_HO_LOAI_LOP] FOREIGN KEY([MA_LOAI])
REFERENCES [dbo].[LOAI_LOP] ([MA_LOAI])
GO
ALTER TABLE [dbo].[co_mon_hoc] CHECK CONSTRAINT [FK_CO_MON_H_CO_MON_HO_LOAI_LOP]
GO
ALTER TABLE [dbo].[co_mon_hoc]  WITH CHECK ADD  CONSTRAINT [FK_CO_MON_H_CO_MON_HO_MON HOC] FOREIGN KEY([MA_MON])
REFERENCES [dbo].[MON HOC] ([MA_MON])
GO
ALTER TABLE [dbo].[co_mon_hoc] CHECK CONSTRAINT [FK_CO_MON_H_CO_MON_HO_MON HOC]
GO
ALTER TABLE [dbo].[GIANG DAY]  WITH CHECK ADD  CONSTRAINT [FK_GIANG DA_DAY_O_HOC_HOC_KY_N] FOREIGN KEY([HOC_KY], [NAM_HOC])
REFERENCES [dbo].[HOC_KY_NAM_HOC] ([HOC_KY], [NAM_HOC])
GO
ALTER TABLE [dbo].[GIANG DAY] CHECK CONSTRAINT [FK_GIANG DA_DAY_O_HOC_HOC_KY_N]
GO
ALTER TABLE [dbo].[GIANG DAY]  WITH CHECK ADD  CONSTRAINT [FK_GIANG DA_GIANG_DAY_LOP] FOREIGN KEY([MA_LOP])
REFERENCES [dbo].[LOP] ([MA_LOP])
GO
ALTER TABLE [dbo].[GIANG DAY] CHECK CONSTRAINT [FK_GIANG DA_GIANG_DAY_LOP]
GO
ALTER TABLE [dbo].[GIANG DAY]  WITH CHECK ADD  CONSTRAINT [FK_GIANG DA_GIAO_VIEN_GIAO VIE] FOREIGN KEY([MA_GV])
REFERENCES [dbo].[GIAO VIEN] ([MA_GV])
GO
ALTER TABLE [dbo].[GIANG DAY] CHECK CONSTRAINT [FK_GIANG DA_GIAO_VIEN_GIAO VIE]
GO
ALTER TABLE [dbo].[hoc_lop]  WITH CHECK ADD  CONSTRAINT [FK_HOC_LOP_HOC_LOP_LOP] FOREIGN KEY([MA_LOP])
REFERENCES [dbo].[LOP] ([MA_LOP])
GO
ALTER TABLE [dbo].[hoc_lop] CHECK CONSTRAINT [FK_HOC_LOP_HOC_LOP_LOP]
GO
ALTER TABLE [dbo].[hoc_lop]  WITH CHECK ADD  CONSTRAINT [FK_HOC_LOP_HOC_LOP2_TRE EM] FOREIGN KEY([MA_TE])
REFERENCES [dbo].[TRE EM] ([MA_TE])
GO
ALTER TABLE [dbo].[hoc_lop] CHECK CONSTRAINT [FK_HOC_LOP_HOC_LOP2_TRE EM]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_CO_LOAI_L_LOAI_LOP] FOREIGN KEY([MA_LOAI])
REFERENCES [dbo].[LOAI_LOP] ([MA_LOAI])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_CO_LOAI_L_LOAI_LOP]
GO
ALTER TABLE [dbo].[LOP]  WITH CHECK ADD  CONSTRAINT [FK_LOP_HOC_TAI_PHONG HO] FOREIGN KEY([MA_PHONG])
REFERENCES [dbo].[PHONG HOC] ([MA_PHONG])
GO
ALTER TABLE [dbo].[LOP] CHECK CONSTRAINT [FK_LOP_HOC_TAI_PHONG HO]
GO
ALTER TABLE [dbo].[PHIEU LIEN LAC]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU LI_CO_PHIEU__TRE EM] FOREIGN KEY([MA_TE])
REFERENCES [dbo].[TRE EM] ([MA_TE])
GO
ALTER TABLE [dbo].[PHIEU LIEN LAC] CHECK CONSTRAINT [FK_PHIEU LI_CO_PHIEU__TRE EM]
GO
ALTER TABLE [dbo].[PHIEU LIEN LAC]  WITH CHECK ADD  CONSTRAINT [FK_PHIEU LI_PHIEU_LIE_THOI GIA] FOREIGN KEY([Thang], [Nam])
REFERENCES [dbo].[THOI GIAN] ([Thang], [Nam])
GO
ALTER TABLE [dbo].[PHIEU LIEN LAC] CHECK CONSTRAINT [FK_PHIEU LI_PHIEU_LIE_THOI GIA]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[THE TRANG]  WITH CHECK ADD  CONSTRAINT [FK_THE TRAN_CO_THE_TR_TRE EM] FOREIGN KEY([MA_TE])
REFERENCES [dbo].[TRE EM] ([MA_TE])
GO
ALTER TABLE [dbo].[THE TRANG] CHECK CONSTRAINT [FK_THE TRAN_CO_THE_TR_TRE EM]
GO
ALTER TABLE [dbo].[THE TRANG]  WITH CHECK ADD  CONSTRAINT [FK_THE TRAN_THE_TRANG_THOI GIA] FOREIGN KEY([Thang], [Nam])
REFERENCES [dbo].[THOI GIAN] ([Thang], [Nam])
GO
ALTER TABLE [dbo].[THE TRANG] CHECK CONSTRAINT [FK_THE TRAN_THE_TRANG_THOI GIA]
GO
ALTER TABLE [dbo].[TRE EM]  WITH CHECK ADD  CONSTRAINT [FK_TRE EM_LA_PH_PHU HUYN] FOREIGN KEY([MA_PH])
REFERENCES [dbo].[PHU HUYNH] ([MA_PH])
GO
ALTER TABLE [dbo].[TRE EM] CHECK CONSTRAINT [FK_TRE EM_LA_PH_PHU HUYN]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_GIAO VIEN_maGV] FOREIGN KEY([maGV])
REFERENCES [dbo].[GIAO VIEN] ([MA_GV])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_GIAO VIEN_maGV]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_PHU HUYNH_maPH] FOREIGN KEY([maPH])
REFERENCES [dbo].[PHU HUYNH] ([MA_PH])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_PHU HUYNH_maPH]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [QL_T_MN] SET  READ_WRITE 
GO
