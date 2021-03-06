USE [master]
GO

/****** Object:  Database [Microservices]    Script Date: 29.01.2021 21:51:17 ******/
CREATE DATABASE [Microservices]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Microservices', FILENAME = N'/var/opt/mssql/data/Microservices.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Microservices_log', FILENAME = N'/var/opt/mssql/data/Microservices_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Microservices].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Microservices] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Microservices] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Microservices] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Microservices] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Microservices] SET ARITHABORT OFF 
GO

ALTER DATABASE [Microservices] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Microservices] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Microservices] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Microservices] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Microservices] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Microservices] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Microservices] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Microservices] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Microservices] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Microservices] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Microservices] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Microservices] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Microservices] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Microservices] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Microservices] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Microservices] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Microservices] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Microservices] SET RECOVERY FULL 
GO

ALTER DATABASE [Microservices] SET  MULTI_USER 
GO

ALTER DATABASE [Microservices] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Microservices] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Microservices] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Microservices] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Microservices] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Microservices] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Microservices] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Microservices] SET  READ_WRITE 
GO


