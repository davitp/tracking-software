USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[cars_table]    Script Date: 05/26/2014 21:11:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[cars_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[driverId] [int] NOT NULL,
	[carDeviceId] [int] NOT NULL,
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

ALTER TABLE [dbo].[cars_table]  WITH CHECK ADD  CONSTRAINT [driver_id_references_to_drivers_table] FOREIGN KEY([driverId])
REFERENCES [dbo].[drivers_table] ([id])
GO

ALTER TABLE [dbo].[cars_table] CHECK CONSTRAINT [driver_id_references_to_drivers_table]
GO

