INSERT INTO [dbo].[Pacient] ([Pacient_ID], [FistName], [LastName], [Birthday], [Snils], [date], [time], [Doctor]) VALUES (1, N'казиноа', N'додепович', N'1990-02-15', 666777999, N'2011-11-11', N'11:11:00', N'Хирург')

INSERT INTO [dbo].[Staff] ([Staff_ID], [FirstName], [LastName], [Post]) VALUES (1, N'Санятео', N'Сашетксий ', N'Хирург')
INSERT INTO [dbo].[Staff] ([Staff_ID], [FirstName], [LastName], [Post]) VALUES (2, N'Никитский', N'Никте', N'Окулист')

INSERT INTO [dbo].[User] ([User_ID], [Email], [Password], [Staff_ID]) VALUES (1, N'nikita', N'123', 1)
INSERT INTO [dbo].[User] ([User_ID], [Email], [Password], [Staff_ID]) VALUES (2, N'fedr', N'321', 2)
