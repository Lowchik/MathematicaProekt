CREATE TABLE [dbo].[Pacient]
(
	[Pacient_ID] INT NOT NULL PRIMARY KEY, 
    [FistName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [Birthday] DATE NULL, 
    [Snils] INT NULL, 
    [date] DATE NULL, 
    [time] TIME NULL, 
    [Doctor] VARCHAR(50) NULL
)
