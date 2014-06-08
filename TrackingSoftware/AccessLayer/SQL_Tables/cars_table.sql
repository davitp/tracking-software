USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[cars_table]    Script Date: 06/08/2014 18:27:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cars_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[color] [varchar](10) NOT NULL,
	[manufacturer] [varchar](40) NOT NULL,
	[model] [varchar](20) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[cars_table] ADD  DEFAULT ('NoColor') FOR [color]
GO

ALTER TABLE [dbo].[cars_table] ADD  DEFAULT ('NoManufacturer') FOR [manufacturer]
GO

ALTER TABLE [dbo].[cars_table] ADD  DEFAULT ('NoModel') FOR [model]
GO

