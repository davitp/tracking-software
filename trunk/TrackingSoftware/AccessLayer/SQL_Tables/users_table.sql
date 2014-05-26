USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[users_table]    Script Date: 05/26/2014 21:12:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[users_table](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[roleId] [int] NOT NULL,
	[username] [varchar](20) NOT NULL,
	[passwd] [varchar](30) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[users_table]  WITH CHECK ADD  CONSTRAINT [roleId_references_userRoles_table] FOREIGN KEY([roleId])
REFERENCES [dbo].[userRoles_table] ([roleId])
GO

ALTER TABLE [dbo].[users_table] CHECK CONSTRAINT [roleId_references_userRoles_table]
GO

