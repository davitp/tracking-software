USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[drivers_table]    Script Date: 06/08/2014 18:28:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[drivers_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](10) NOT NULL,
	[tel] [varchar](40) NOT NULL,
	[salary] [decimal](18, 0) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[drivers_table] ADD  DEFAULT ('NoName') FOR [name]
GO

ALTER TABLE [dbo].[drivers_table] ADD  DEFAULT ('NoTel') FOR [tel]
GO

ALTER TABLE [dbo].[drivers_table] ADD  DEFAULT ((0)) FOR [salary]
GO

