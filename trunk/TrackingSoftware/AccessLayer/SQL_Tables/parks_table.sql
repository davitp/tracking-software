USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[parks_table]    Script Date: 06/08/2014 18:28:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[parks_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](10) NOT NULL,
	[geodata] [varchar](max) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[parks_table] ADD  DEFAULT ('NoName') FOR [name]
GO

ALTER TABLE [dbo].[parks_table] ADD  DEFAULT ('{0, 0}') FOR [geodata]
GO


