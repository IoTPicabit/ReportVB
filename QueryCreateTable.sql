USE [master]
GO

DECLARE @chkdirectory VARCHAR(1000);
SET @chkdirectory = 'C:\ReportsTools\DATA';
DECLARE @folder_exists as int
DECLARE @file_results table(file_exists int,file_is_a_directory int,parent_directory_exists int)
INSERT INTO @file_results
(file_exists, file_is_a_directory, parent_directory_exists)
EXEC MASTER.dbo.xp_fileexist @chkdirectory

SELECT @folder_exists = file_is_a_directory
FROM @file_results

--script to create directory        
IF @folder_exists = 0
BEGIN
EXECUTE master.dbo.xp_create_subdir @chkdirectory
	PRINT @chkdirectory +  ' created on  ' + @@servername
END       
ELSE


--Borrar base de datos si existe
DECLARE @nombreBaseDatos NVARCHAR(255);
SET @nombreBaseDatos = 'DB_ReportsTools';

IF EXISTS (SELECT name FROM sys.databases WHERE name = @nombreBaseDatos)
BEGIN
    DECLARE @sql NVARCHAR(MAX);
	SET @sql = 'ALTER DATABASE ' + QUOTENAME(@nombreBaseDatos) + ' SET SINGLE_USER WITH ROLLBACK IMMEDIATE; ' +
            'DROP DATABASE ' + QUOTENAME(@nombreBaseDatos);
    EXEC sp_executesql @sql;
	-- Habilita xp_cmdshell
	EXEC sp_configure 'show advanced options', 1;
	RECONFIGURE;
	EXEC sp_configure 'xp_cmdshell', 1;
	RECONFIGURE;
	DECLARE @cmd NVARCHAR(1000);
	SET @cmd = 'del /Q ' + @chkdirectory + '\*.*'; 
	PRINT @cmd
	EXEC xp_cmdshell @cmd, no_output;
	-- Deshabilita xp_cmdshell
	EXEC sp_configure 'xp_cmdshell', 0;
	RECONFIGURE;
	EXEC sp_configure 'show advanced options', 0;
	RECONFIGURE;
    PRINT 'La base de datos ' + @nombreBaseDatos + ' ha sido eliminada.';
END

--Crear base de datos
CREATE DATABASE [DB_ReportsTools]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_ReportsTools', FILENAME = N'C:\ReportsTools\DATA\DB_ReportsTools' , SIZE = 2976384KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DB_ReportsTools_log', FILENAME = N'C:\ReportsTools\DATA\DB_ReportsTools_log' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_ReportsTools].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [DB_ReportsTools] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET ARITHABORT OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET AUTO_SHRINK ON 
GO

ALTER DATABASE [DB_ReportsTools] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [DB_ReportsTools] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [DB_ReportsTools] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET  DISABLE_BROKER 
GO

ALTER DATABASE [DB_ReportsTools] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [DB_ReportsTools] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [DB_ReportsTools] SET  MULTI_USER 
GO

ALTER DATABASE [DB_ReportsTools] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [DB_ReportsTools] SET DB_CHAINING OFF 
GO

ALTER DATABASE [DB_ReportsTools] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [DB_ReportsTools] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [DB_ReportsTools] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [DB_ReportsTools] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [DB_ReportsTools] SET QUERY_STORE = OFF
GO

ALTER DATABASE [DB_ReportsTools] SET  READ_WRITE 
GO



USE [DB_ReportsTools]
GO
/****** Object:  Index [IX_TagIndex]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_TagIndex] ON [dbo].[DigTfunTAutFloatTable]
GO
/****** Object:  Index [IX_TagIndex]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_TagIndex] ON [dbo].[DigNmanTAutFloatTable]
GO
/****** Object:  Index [IX_TagIndex]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_TagIndex] ON [dbo].[AnaVtotFloatTable]
GO
/****** Object:  Index [IX_TagIndexDatetime]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_TagIndexDatetime] ON [dbo].[AnaVinsFloatTable]
GO
/****** Object:  Table [dbo].[DigTfunTManTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTManTagTable]
GO
/****** Object:  Table [dbo].[DigTfunTManReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTManReportTable]
GO
/****** Object:  Table [dbo].[DigTfunTManFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTManFloatTable]
GO
/****** Object:  Table [dbo].[DigTfunTAutTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTAutTagTable]
GO
/****** Object:  Table [dbo].[DigTfunTAutStringTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTAutStringTable]
GO
/****** Object:  Table [dbo].[DigTfunTAutReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTAutReportTable]
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_DateAndTime] ON [dbo].[DigTfunTAutFloatTable] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[DigTfunTAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunTAutFloatTable]
GO
/****** Object:  Table [dbo].[DigTfunPManTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunPManTagTable]
GO
/****** Object:  Table [dbo].[DigTfunPManReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunPManReportTable]
GO
/****** Object:  Table [dbo].[DigTfunPManFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunPManFloatTable]
GO
/****** Object:  Table [dbo].[DigTfunPAutTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunPAutTagTable]
GO
/****** Object:  Table [dbo].[DigTfunPAutReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunPAutReportTable]
GO
/****** Object:  Table [dbo].[DigTfunPAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigTfunPAutFloatTable]
GO
/****** Object:  Table [dbo].[DigNmanTManTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTManTagTable]
GO
/****** Object:  Table [dbo].[DigNmanTManReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTManReportTable]
GO
/****** Object:  Table [dbo].[DigNmanTManFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTManFloatTable]
GO
/****** Object:  Table [dbo].[DigNmanTAutTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTAutTagTable]
GO
/****** Object:  Table [dbo].[DigNmanTAutStringTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTAutStringTable]
GO
/****** Object:  Table [dbo].[DigNmanTAutReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTAutReportTable]
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_DateAndTime] ON [dbo].[DigNmanTAutFloatTable] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[DigNmanTAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanTAutFloatTable]
GO
/****** Object:  Table [dbo].[DigNmanPManTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanPManTagTable]
GO
/****** Object:  Table [dbo].[DigNmanPManReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanPManReportTable]
GO
/****** Object:  Table [dbo].[DigNmanPManFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanPManFloatTable]
GO
/****** Object:  Table [dbo].[DigNmanPAutTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanPAutTagTable]
GO
/****** Object:  Table [dbo].[DigNmanPAutReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanPAutReportTable]
GO
/****** Object:  Table [dbo].[DigNmanPAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[DigNmanPAutFloatTable]
GO
/****** Object:  Table [dbo].[AnaVtotTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVtotTagTable]
GO
/****** Object:  Table [dbo].[AnaVtotStringTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVtotStringTable]
GO
/****** Object:  Table [dbo].[AnaVtotReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVtotReportTable]
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_DateAndTime] ON [dbo].[AnaVtotFloatTable] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[AnaVtotFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVtotFloatTable]
GO
/****** Object:  Table [dbo].[AnaVinsTagTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVinsTagTable]
GO
/****** Object:  Table [dbo].[AnaVinsStringTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVinsStringTable]
GO
/****** Object:  Table [dbo].[AnaVinsReportTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVinsReportTable]
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
DROP INDEX IF EXISTS [IX_DateAndTime] ON [dbo].[AnaVinsFloatTable] WITH ( ONLINE = OFF )
GO
/****** Object:  Table [dbo].[AnaVinsFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
DROP TABLE IF EXISTS [dbo].[AnaVinsFloatTable]
GO
/****** Object:  User [SQL_User_App]    Script Date: 24/01/2024 14:07:56 ******/
DROP USER IF EXISTS [SQL_User_App]
GO
USE [master]
GO
/****** Object:  Login [SQL_User_App]    Script Date: 24/01/2024 14:07:56 ******/
IF  EXISTS (SELECT * FROM sys.server_principals WHERE name = N'SQL_User_App')
DROP LOGIN [SQL_User_App]
GO

/****** Object:  Login [SQL_User_App]    Script Date: 24/01/2024 14:07:56 ******/
CREATE LOGIN [SQL_User_App] WITH PASSWORD=N'creacontrol', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [SQL_User_App] ENABLE
GO

USE [DB_ReportsTools]
GO
/****** Object:  User [SQL_User_App]    Script Date: 24/01/2024 14:07:56 ******/
CREATE USER [SQL_User_App] WITH DEFAULT_SCHEMA=[dbo] 
GO
ALTER USER [SQL_User_App] WITH LOGIN = SQL_User_App
GO
ALTER ROLE [db_owner] ADD MEMBER [SQL_User_App]
GO
/****** Object:  Table [dbo].[AnaVinsFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnaVinsFloatTable](
	[DateAndTime] [datetime] NULL,
	[Millitm] [smallint] NULL,
	[TagIndex] [smallint] NULL,
	[Val] [float] NULL,
	[Status] [nvarchar](1) NULL,
	[Marker] [nvarchar](1) NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[AnaVinsFloatTable] TO  SCHEMA OWNER 
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
CREATE CLUSTERED INDEX [IX_DateAndTime] ON [dbo].[AnaVinsFloatTable]
(
	[DateAndTime] DESC,
	[TagIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnaVinsReportTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnaVinsReportTable](
	[TagDescription] [nvarchar](255) NULL,
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NOT NULL,
	[TagUnit] [nvarchar](5) NULL,
	[OrdenFinal] [int] NULL,
 CONSTRAINT [PK_AnaVinsReportTable] PRIMARY KEY CLUSTERED 
(
	[TagIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[AnaVinsReportTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[AnaVinsTagTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnaVinsTagTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NULL,
	[TagType] [smallint] NULL,
	[TagDataType] [smallint] NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[AnaVinsTagTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[AnaVtotFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnaVtotFloatTable](
	[DateAndTime] [datetime] NULL,
	[Millitm] [smallint] NULL,
	[TagIndex] [smallint] NULL,
	[Val] [float] NULL,
	[Status] [nvarchar](1) NULL,
	[Marker] [nvarchar](1) NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[AnaVtotFloatTable] TO  SCHEMA OWNER 
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
CREATE CLUSTERED INDEX [IX_DateAndTime] ON [dbo].[AnaVtotFloatTable]
(
	[DateAndTime] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnaVtotReportTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnaVtotReportTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NOT NULL,
	[TagDescription] [nvarchar](255) NULL,
	[TagUnit] [nvarchar](5) NULL,
	[OrdenFinal] [int] NULL,
 CONSTRAINT [PK_AnaVtotReportTable] PRIMARY KEY CLUSTERED 
(
	[TagIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[AnaVtotReportTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[AnaVtotTagTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnaVtotTagTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NULL,
	[TagType] [smallint] NULL,
	[TagDataType] [smallint] NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[AnaVtotTagTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[DigNmanPAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  Table [dbo].[DigNmanTAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigNmanTAutFloatTable](
	[DateAndTime] [datetime] NULL,
	[Millitm] [smallint] NULL,
	[TagIndex] [smallint] NULL,
	[Val] [float] NULL,
	[Status] [nvarchar](1) NULL,
	[Marker] [nvarchar](1) NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[DigNmanTAutFloatTable] TO  SCHEMA OWNER 
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
CREATE CLUSTERED INDEX [IX_DateAndTime] ON [dbo].[DigNmanTAutFloatTable]
(
	[DateAndTime] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigNmanTAutReportTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigNmanTAutReportTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NOT NULL,
	[TagDescription] [nvarchar](255) NULL,
	[OrdenFinal] [int] NULL,
 CONSTRAINT [PK_DigNmanTAutReportTable] PRIMARY KEY CLUSTERED 
(
	[TagIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[DigNmanTAutReportTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[DigNmanTAutTagTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigNmanTAutTagTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NULL,
	[TagType] [smallint] NULL,
	[TagDataType] [smallint] NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[DigNmanTAutTagTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[DigTfunTAutFloatTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigTfunTAutFloatTable](
	[DateAndTime] [datetime] NULL,
	[Millitm] [smallint] NULL,
	[TagIndex] [smallint] NULL,
	[Val] [float] NULL,
	[Status] [nvarchar](1) NULL,
	[Marker] [nvarchar](1) NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[DigTfunTAutFloatTable] TO  SCHEMA OWNER 
GO
/****** Object:  Index [IX_DateAndTime]    Script Date: 24/01/2024 14:07:56 ******/
CREATE CLUSTERED INDEX [IX_DateAndTime] ON [dbo].[DigTfunTAutFloatTable]
(
	[DateAndTime] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DigTfunTAutReportTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigTfunTAutReportTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NOT NULL,
	[TagDescription] [nvarchar](255) NULL,
	[OrdenFinal] [int] NULL,
 CONSTRAINT [PK_DigTfunTAutReportTable] PRIMARY KEY CLUSTERED 
(
	[TagIndex] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[DigTfunTAutReportTable] TO  SCHEMA OWNER 
GO
/****** Object:  Table [dbo].[DigTfunTAutTagTable]    Script Date: 24/01/2024 14:07:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DigTfunTAutTagTable](
	[TagName] [nvarchar](255) NULL,
	[TagIndex] [smallint] NULL,
	[TagType] [smallint] NULL,
	[TagDataType] [smallint] NULL
) ON [PRIMARY]
GO
ALTER AUTHORIZATION ON [dbo].[DigTfunTAutTagTable] TO  SCHEMA OWNER 
GO

/****** Object:  Index [IX_TagIndexDatetime]    Script Date: 24/01/2024 14:07:56 ******/
CREATE NONCLUSTERED INDEX [IX_TagIndexDatetime] ON [dbo].[AnaVinsFloatTable]
(
	[TagIndex] ASC,
	[DateAndTime] ASC
)
INCLUDE([Val],[Status],[Marker]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TagIndex]    Script Date: 24/01/2024 14:07:56 ******/
CREATE NONCLUSTERED INDEX [IX_TagIndex] ON [dbo].[AnaVtotFloatTable]
(
	[TagIndex] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TagIndex]    Script Date: 24/01/2024 14:07:56 ******/
CREATE NONCLUSTERED INDEX [IX_TagIndex] ON [dbo].[DigNmanTAutFloatTable]
(
	[TagIndex] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_TagIndex]    Script Date: 24/01/2024 14:07:56 ******/
CREATE NONCLUSTERED INDEX [IX_TagIndex] ON [dbo].[DigTfunTAutFloatTable]
(
	[TagIndex] DESC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO

PRINT 'La base de datos ha sido creada con éxito.';
