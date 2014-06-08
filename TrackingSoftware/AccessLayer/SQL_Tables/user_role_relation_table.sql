USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[user_role_relation_table]    Script Date: 06/08/2014 18:29:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[user_role_relation_table](
	[userId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
UNIQUE NONCLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[user_role_relation_table]  WITH CHECK ADD FOREIGN KEY([roleId])
REFERENCES [dbo].[userRoles_table] ([id])
GO

ALTER TABLE [dbo].[user_role_relation_table]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[users_table] ([id])
GO

