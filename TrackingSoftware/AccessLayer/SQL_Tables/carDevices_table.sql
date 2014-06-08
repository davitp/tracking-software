USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[carDevices_table]    Script Date: 06/08/2014 18:27:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[carDevices_table](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[simNumber] [varchar](20) NOT NULL,
	[deviceModel] [varchar](20) NOT NULL,
UNIQUE NONCLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[carDevices_table] ADD  CONSTRAINT [DF_carDevices_table_simNumber]  DEFAULT ('NoSimNumber') FOR [simNumber]
GO

ALTER TABLE [dbo].[carDevices_table] ADD  CONSTRAINT [DF_carDevices_table_deviceModel]  DEFAULT ('NoModel') FOR [deviceModel]
GO

