USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[users_table]    Script Date: 06/08/2014 18:29:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[users_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) NOT NULL,
	[passwd] [varchar](25) NOT NULL,
	[fullname] [varchar](50) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[users_table] ADD  DEFAULT ('NoUserame') FOR [username]
GO

ALTER TABLE [dbo].[users_table] ADD  DEFAULT ('NoPassword') FOR [passwd]
GO

ALTER TABLE [dbo].[users_table] ADD  DEFAULT ('NoFullName') FOR [fullname]
GO

