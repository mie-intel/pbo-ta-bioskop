﻿CREATE TABLE [dbo].[Table]
(
	[Id] NTEXT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Rate] INT NOT NULL,
	[Price] INT NOT NULL, 
    [Date] NVARCHAR(50) NOT NULL, 
    [Description] NTEXT NOT NULL, 
    [SeatA1] NTEXT NULL,
	[SeatA2] NTEXT NULL, 
	[SeatA3] NTEXT NULL, 
	[SeatB1] NTEXT NULL, 
	[SeatB2] NTEXT NULL,
	[SeatB3] NTEXT NULL
)

