USE [HappyHours]
GO
SET IDENTITY_INSERT [dbo].[T_User] ON 

INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (1, N'Toto', N'toto@gmail.com', N'toto', 0)
INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (2, N'Tata', N'tata@hotmail.fr', N'tata', 0)
SET IDENTITY_INSERT [dbo].[T_User] OFF
