USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[userRoles_table]    Script Date: 05/26/2014 21:12:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[userRoles_table](
	[roleId] [int] IDENTITY(1,1) NOT NULL,
	[roleName] [varchar](20) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

