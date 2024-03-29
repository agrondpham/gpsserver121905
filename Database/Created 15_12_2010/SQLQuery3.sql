USE [GPSDatabase]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/15/2010 23:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[ID_User] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Fullname] [varchar](100) NOT NULL,
	[Mobile] [int] NULL,
	[Company] [text] NULL,
	[Cop_Phone] [int] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID_User] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Devices]    Script Date: 12/15/2010 23:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Devices](
	[IMED_Device] [int] NOT NULL,
	[ID_User] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
(
	[IMED_Device] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GPS_Data]    Script Date: 12/15/2010 23:39:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GPS_Data](
	[ID_Data] [int] IDENTITY(1,1) NOT NULL,
	[IMED_Device] [int] NOT NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[Speed] [float] NULL,
	[Received_Data] [varchar](100) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_GPS_Data] PRIMARY KEY CLUSTERED 
(
	[ID_Data] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Devices_Users]    Script Date: 12/15/2010 23:39:44 ******/
ALTER TABLE [dbo].[Devices]  WITH CHECK ADD  CONSTRAINT [FK_Devices_Users] FOREIGN KEY([ID_User])
REFERENCES [dbo].[Users] ([ID_User])
GO
ALTER TABLE [dbo].[Devices] CHECK CONSTRAINT [FK_Devices_Users]
GO
/****** Object:  ForeignKey [FK_GPS_Data_Devices]    Script Date: 12/15/2010 23:39:44 ******/
ALTER TABLE [dbo].[GPS_Data]  WITH CHECK ADD  CONSTRAINT [FK_GPS_Data_Devices] FOREIGN KEY([IMED_Device])
REFERENCES [dbo].[Devices] ([IMED_Device])
GO
ALTER TABLE [dbo].[GPS_Data] CHECK CONSTRAINT [FK_GPS_Data_Devices]
GO
