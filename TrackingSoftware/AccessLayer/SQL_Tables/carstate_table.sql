USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[carstate_table]    Script Date: 05/26/2014 21:11:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[carstate_table](
	[carId] [int] NOT NULL,
	[needToChangeOil] [bit] NOT NULL,
	[fuelLevel] [float] NOT NULL,
	[latitude] [float] NOT NULL,
	[longitude] [float] NOT NULL,
	[speed] [int] NOT NULL,
	[time_when] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[carstate_table]  WITH CHECK ADD  CONSTRAINT [carId_reference_to_cars_table] FOREIGN KEY([carId])
REFERENCES [dbo].[cars_table] ([id])
GO

ALTER TABLE [dbo].[carstate_table] CHECK CONSTRAINT [carId_reference_to_cars_table]
GO

