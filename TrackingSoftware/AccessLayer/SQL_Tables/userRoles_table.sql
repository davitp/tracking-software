USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[userRoles_table]    Script Date: 06/08/2014 18:29:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[userRoles_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rolename] [varchar](20) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[userRoles_table] ADD  DEFAULT ('NoRole') FOR [rolename]
GO

