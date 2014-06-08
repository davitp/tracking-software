USE [TrackingSoftwareDB]
GO

/****** Object:  Table [dbo].[carsState_table]    Script Date: 06/08/2014 18:28:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[carsState_table](
	[carId] [int] NOT NULL,
	[fuelLevel] [float] NOT NULL,
	[speed] [int] NOT NULL,
	[changeOil] [bit] NOT NULL,
	[latitude] [float] NOT NULL,
	[longitude] [float] NOT NULL,
	[stateTime] [datetime] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[carsState_table]  WITH CHECK ADD FOREIGN KEY([carId])
REFERENCES [dbo].[cars_table] ([id])
GO

ALTER TABLE [dbo].[carsState_table] ADD  DEFAULT ((0)) FOR [fuelLevel]
GO

ALTER TABLE [dbo].[carsState_table] ADD  DEFAULT ((0)) FOR [speed]
GO

ALTER TABLE [dbo].[carsState_table] ADD  DEFAULT ((0)) FOR [changeOil]
GO

ALTER TABLE [dbo].[carsState_table] ADD  DEFAULT ((0)) FOR [latitude]
GO

ALTER TABLE [dbo].[carsState_table] ADD  DEFAULT ((0)) FOR [longitude]
GO

ALTER TABLE [dbo].[carsState_table] ADD  DEFAULT (getdate()) FOR [stateTime]
GO

