USE [AssetManagment2]
GO
/****** Object:  Table [dbo].[Asset]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asset](
	[Asset_ID] [int] NOT NULL,
	[Asset_Name] [varchar](50) NULL,
	[Asset_Desc] [varchar](200) NULL,
	[Asset_InventoryNumber] [int] NULL,
	[Asset_TagMacAddress] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Asset] PRIMARY KEY CLUSTERED 
(
	[Asset_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetGroup]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetGroup](
	[AssetGroup_ID] [int] NOT NULL,
	[Asset_ID] [int] NOT NULL,
	[Group_ID] [int] NOT NULL,
 CONSTRAINT [PK_AssetGroup] PRIMARY KEY CLUSTERED 
(
	[AssetGroup_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Group_ID] [int] NOT NULL,
	[Group_Icon] [image] NULL,
	[Group_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Group_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionHistory]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionHistory](
	[Position_ID] [int] NOT NULL,
	[Position_X] [float] NULL,
	[Position_Y] [float] NULL,
	[Position_Date] [datetime] NULL,
	[Position_TagMacAddress] [varchar](50) NULL,
 CONSTRAINT [PK_PositionHistory] PRIMARY KEY CLUSTERED 
(
	[Position_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Tag_MacAddress] [varchar](50) NOT NULL,
	[Tag_BatteryStatus] [int] NULL,
	[Tag_InventoryNumber] [int] NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Tag_MacAddress] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Technology]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technology](
	[TechnologyTag_ID] [int] NOT NULL,
	[Tag_ID] [varchar](50) NOT NULL,
	[TechID] [int] NULL,
 CONSTRAINT [PK_Technology] PRIMARY KEY CLUSTERED 
(
	[TechnologyTag_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TechnologyType]    Script Date: 2022-02-22 4:32:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TechnologyType](
	[Technology_ID] [int] NOT NULL,
	[Technology_Name] [varchar](50) NULL,
 CONSTRAINT [PK_TechnologyType] PRIMARY KEY CLUSTERED 
(
	[Technology_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asset]  WITH CHECK ADD  CONSTRAINT [FK_Asset_Tag] FOREIGN KEY([Asset_TagMacAddress])
REFERENCES [dbo].[Tag] ([Tag_MacAddress])
GO
ALTER TABLE [dbo].[Asset] CHECK CONSTRAINT [FK_Asset_Tag]
GO
ALTER TABLE [dbo].[AssetGroup]  WITH CHECK ADD  CONSTRAINT [FK_AssetGroup_Asset] FOREIGN KEY([Asset_ID])
REFERENCES [dbo].[Asset] ([Asset_ID])
GO
ALTER TABLE [dbo].[AssetGroup] CHECK CONSTRAINT [FK_AssetGroup_Asset]
GO
ALTER TABLE [dbo].[AssetGroup]  WITH CHECK ADD  CONSTRAINT [FK_AssetGroup_group] FOREIGN KEY([Group_ID])
REFERENCES [dbo].[Group] ([Group_ID])
GO
ALTER TABLE [dbo].[AssetGroup] CHECK CONSTRAINT [FK_AssetGroup_group]
GO
ALTER TABLE [dbo].[PositionHistory]  WITH CHECK ADD  CONSTRAINT [FK_position_Tag] FOREIGN KEY([Position_TagMacAddress])
REFERENCES [dbo].[Tag] ([Tag_MacAddress])
GO
ALTER TABLE [dbo].[PositionHistory] CHECK CONSTRAINT [FK_position_Tag]
GO
ALTER TABLE [dbo].[Tag]  WITH CHECK ADD  CONSTRAINT [FK_Tag_Asset] FOREIGN KEY([Tag_MacAddress])
REFERENCES [dbo].[Tag] ([Tag_MacAddress])
GO
ALTER TABLE [dbo].[Tag] CHECK CONSTRAINT [FK_Tag_Asset]
GO
ALTER TABLE [dbo].[Technology]  WITH CHECK ADD  CONSTRAINT [FK_Technology_tag] FOREIGN KEY([Tag_ID])
REFERENCES [dbo].[Tag] ([Tag_MacAddress])
GO
ALTER TABLE [dbo].[Technology] CHECK CONSTRAINT [FK_Technology_tag]
GO
ALTER TABLE [dbo].[Technology]  WITH CHECK ADD  CONSTRAINT [FK_Technology_TechType] FOREIGN KEY([TechID])
REFERENCES [dbo].[TechnologyType] ([Technology_ID])
GO
ALTER TABLE [dbo].[Technology] CHECK CONSTRAINT [FK_Technology_TechType]
GO
