USE [Microservices]
GO

/****** Object:  Table [dbo].[Persons]    Script Date: 29.01.2021 21:51:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Thumbnail] [nvarchar](100) NULL,
	[FirstName] [nvarchar](100) NULL,
	[LastName] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[Street] [nvarchar](100) NULL,
	[Email] [nvarchar](100) NULL,
	[Gender] [nvarchar](100) NULL,
	[Quote] [nvarchar](300) NULL,
	[Poem] [nvarchar](2000) NULL,
	[Distance] [float] NULL
) ON [PRIMARY]
GO


