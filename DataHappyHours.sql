USE [HappyHours]
GO
SET IDENTITY_INSERT [dbo].[T_User] ON 

INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (1, N'Toto', N'toto@gmail.com', N'toto', 0)
INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (2, N'Tata', N'tata@hotmail.fr', N'tata', 0)
INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (3, N'testlol', N'testlol@mail', N'testlol', 0)
INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (4, N'fifi', N'fifi@email.com', N'fifipassword', 1)
SET IDENTITY_INSERT [dbo].[T_User] OFF
SET IDENTITY_INSERT [dbo].[T_Cocktail] ON 

INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url]) VALUES (3, N'Mojito', 3, 60, 1, N'Très parfumé, légèrement sucré et avec une pointe d''acidité, ce Cocktail élégant et cosmopolite a fait sa place parmi les grands classiques et c''est aujourd''hui le Cocktail le plus célèbre. ', N'Placer les feuilles de menthe dans le verre, ajoutez le sucre et le jus de citrons.Piler consciencieusement afin d''exprimer l''essence de la menthe sans la broyer. Ajouter le rhum, 4 glaçons, mélangez', N'http://www.aliens-cafe.com/wp-content/uploads/2012/10/mojito.jpg')
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url]) VALUES (4, N'Piña Colada', 2, 2, 1, N'La Piña Colada aurait été créé le 15 août 1954 par un barman de l''hôtel Caribe Hilton de Puerto Rico.La Piña Colada est aujourd''hui la boisson officielle de l''état de Puerto Rico. ', N'4 cl de rhum blanc
6 cl de jus d''ananas et 6 cl de lait de coco ou 12 cl de Piña Colada Caraïbos
2 cl de sirop de canne', N'http://placehold.it/300x300')
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url]) VALUES (5, N'Daïquiri', 1, 1, 1, N'Il n''y a que du rhum, des citrons et du sucre.Ils mélangèrent ces éléments dans un shaker avec de la glace et décidèrent de l''appeler Daïquiri. ', N'6 cl de rhum blanc ou doré
4 cl de nectar de citron vert
2 cl de sirop de canne', N'http://placehold.it/300x300')
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url]) VALUES (8, N'Caïpirinha', 3, 2, 1, N'L''origine de la caiprinha remonte aux années 1800.Au brésil, les locaux aimaient boire du "garapa", un jus de canne à sucre qu''ils faisaient simplement bouillir.Le nom "Caipirinha" désignerait un mélange de "Caipira" et de "Curupirinha".Ces deux termes sont liés: "Caipira" était un terme pour désigner les "paysans", terme issu du mot "Caipora" qui désignait les anciens habitants de la forêt. ', N'Préparez la caïpirinha directement dans un verre.Lavez le citron vert et découpez-le en dés, en supprimant la partie blanche centrale.Placez les morceaux de citron dans le verre, ajoutez le sirop de canne et écrasez le tout à l''aide d''un pilon pour extraire le jus du citron vert.Ajoutez la glace pilée puis versez la cachaça.Mélangez avec un agitateur puis servez avec une paille. ', N'/Images/Cocktails/caipirinha20130626205839162.jpg')
SET IDENTITY_INSERT [dbo].[T_Cocktail] OFF
