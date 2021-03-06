USE [master]
GO
/****** Object:  Database [Appointment_Log]    Script Date: 24/5/2021 9:02:53 AM ******/
CREATE DATABASE [Appointment_Log]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Appointment_Log', FILENAME = N'/var/opt/mssql/Appointment_Log.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Appointment_Log_log', FILENAME = N'/var/opt/mssql/Appointment_Log_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

GO
ALTER DATABASE [Appointment_Log] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Appointment_Log].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Appointment_Log] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Appointment_Log] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Appointment_Log] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Appointment_Log] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Appointment_Log] SET ARITHABORT OFF 
GO
ALTER DATABASE [Appointment_Log] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Appointment_Log] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Appointment_Log] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Appointment_Log] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Appointment_Log] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Appointment_Log] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Appointment_Log] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Appointment_Log] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Appointment_Log] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Appointment_Log] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Appointment_Log] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Appointment_Log] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Appointment_Log] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Appointment_Log] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Appointment_Log] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Appointment_Log] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Appointment_Log] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Appointment_Log] SET RECOVERY FULL 
GO
ALTER DATABASE [Appointment_Log] SET  MULTI_USER 
GO
ALTER DATABASE [Appointment_Log] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Appointment_Log] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Appointment_Log] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Appointment_Log] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Appointment_Log] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Appointment_Log', N'ON'
GO
ALTER DATABASE [Appointment_Log] SET QUERY_STORE = OFF
GO
USE [Appointment_Log]
GO
/****** Object:  Table [dbo].[APILog]    Script Date: 24/5/2021 9:02:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[APILog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Level] [nvarchar](20) NOT NULL,
	[TimeStamp] [datetime2](7) NULL,
	[Exception] [nvarchar](max) NULL,
	[RequestMethod] [nvarchar](10) NULL,
	[RequestPath] [nvarchar](max) NULL,
	[RequestBody] [nvarchar](max) NULL,
	[ResponseStatusCode] [int] NULL,
	[ResponseBody] [nvarchar](max) NULL,
	[ElapsedMs] [float] NULL,
	[UserName] [nvarchar](100) NULL,
	[MachineName] [nvarchar](max) NULL,
	[ProcessId] [int] NOT NULL,
	[ThreadId] [int] NOT NULL,
	[Environment] [nvarchar](20) NULL,
 CONSTRAINT [PK_APILog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Appointment_Log] SET  READ_WRITE 
GO
