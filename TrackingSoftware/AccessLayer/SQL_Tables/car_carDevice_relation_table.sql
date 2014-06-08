USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[car_carDevice_relation_table]    Script Date: 06/08/2014 18:24:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[car_carDevice_relation_table](
	[carId] [int] NOT NULL,
	[carDeviceId] [int] NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[car_carDevice_relation_table]  WITH CHECK ADD FOREIGN KEY([carDeviceId])
REFERENCES [dbo].[carDevices_table] ([id])
GO

ALTER TABLE [dbo].[car_carDevice_relation_table]  WITH CHECK ADD FOREIGN KEY([carId])
REFERENCES [dbo].[cars_table] ([id])
GO

ALTER TABLE [dbo].[car_carDevice_relation_table] ADD  DEFAULT (getdate()) FOR [startDate]
GO

ALTER TABLE [dbo].[car_carDevice_relation_table] ADD  DEFAULT (NULL) FOR [endDate]
GO


