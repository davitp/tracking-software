USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[car_driver_table]    Script Date: 06/01/2014 15:57:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[car_driver_table](
	[carId] [int] NOT NULL,
	[driverId] [int] NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[car_driver_table]  WITH CHECK ADD  CONSTRAINT [car_foreignKey] FOREIGN KEY([carId])
REFERENCES [dbo].[cars_table] ([id])
GO

ALTER TABLE [dbo].[car_driver_table] CHECK CONSTRAINT [car_foreignKey]
GO

ALTER TABLE [dbo].[car_driver_table]  WITH CHECK ADD  CONSTRAINT [driver_foreignKey] FOREIGN KEY([driverId])
REFERENCES [dbo].[drivers_table] ([id])
GO

ALTER TABLE [dbo].[car_driver_table] CHECK CONSTRAINT [driver_foreignKey]
GO


