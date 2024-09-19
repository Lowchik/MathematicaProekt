CREATE TABLE [dbo].[User]
(
	[User_ID] INT NOT NULL PRIMARY KEY, 
    [Email] NCHAR(10) NULL, 
    [Password] NCHAR(10) NULL, 
    [Staff_ID] INT NOT NULL FOREIGN KEY REFERENCES [Staff]([Staff_ID]), 
)
