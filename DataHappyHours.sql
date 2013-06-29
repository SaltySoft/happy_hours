USE [HappyHours]
GO
SET IDENTITY_INSERT [dbo].[T_User] ON 

INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (24, N'Admin', N'admin@site.com', N'X03MO1qnZdYdgyfeuILPmQ==', 0)
INSERT [dbo].[T_User] ([id], [username], [email], [password], [admin]) VALUES (25, N'User', N'user@site.com', N'7hHLsZBS5AsHqsDKBgwj7g==', 0)
SET IDENTITY_INSERT [dbo].[T_User] OFF
SET IDENTITY_INSERT [dbo].[T_Cocktail] ON 

INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url], [edited]) VALUES (1045, N'Mojito', 1, 2, 24, N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'/Images/Cocktails/drink4-mojito20130629032229828.jpg', 1)
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url], [edited]) VALUES (1046, N'Piña Colada', 2, 1, 24, N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'/Images/Cocktails/pina-colada-cocktail-50-big20130629032426109.jpg', 1)
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url], [edited]) VALUES (1047, N'Hurricane', 2, 2, 24, N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'/Images/Cocktails/Hurricane_at_Pat_O''Brien''s20130629032604010.JPG', 1)
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url], [edited]) VALUES (1048, N'Martini', 1, 3, 24, N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'/Images/Cocktails/450px-The_perfect_martini20130629032801604.jpg', 1)
INSERT [dbo].[T_Cocktail] ([id], [name], [difficulty], [duration], [creator_id], [description], [recipe], [picture_url], [edited]) VALUES (1049, N'Curacao Punch', 1, 1, 24, N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'Rhoncus odio lacus in? Magnis placerat a! Ac nec vel in turpis, cras in ac, dapibus. In ut, mus pulvinar lectus ut, et pid, ultricies duis purus ac diam aenean, porta turpis, etiam aenean integer. Elit, proin arcu vut, sed mattis mauris, massa mattis nunc integer placerat, etiam adipiscing dis? Pid, adipiscing diam lacus pellentesque cras est. Nunc nunc pulvinar ultrices lundium adipiscing! Tincidunt etiam amet eu in. Lundium enim nisi pid rhoncus nunc egestas porta placerat elit! Enim montes, non? Tortor vel nec, elementum penatibus enim tincidunt, mid augue. Egestas, tincidunt, nec dis penatibus proin elit tortor tristique dolor? Platea phasellus, sit ridiculus, urna. Ridiculus vel lundium montes purus! Placerat sagittis rhoncus eros, arcu! Est? Sociis sit. Sagittis natoque.', N'/Images/Cocktails/images (2)20130629033031246.jpg', 1)
SET IDENTITY_INSERT [dbo].[T_Cocktail] OFF
SET IDENTITY_INSERT [dbo].[T_Ingredient] ON 

INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (8, N'Vodka', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (9, N'Gin (dry)', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (10, N'Cognac', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (11, N'Tequila', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (12, N'Rhum blanc', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (13, N'Amaretto', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (14, N'Curaçao bleu', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (15, N'Vermouth blanc', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (16, N'Champagne', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (17, N'Whisky', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (18, N'Kahlua', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (19, N'Cointreau', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (20, N'Baileys irish cream', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (21, N'Malibu', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (22, N'Rhum', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (23, N'Liqueur d''orange', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (24, N'Campari', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (25, N'Vermouth rouge', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (26, N'Grand Marnier', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (27, N'Liqueur d''abricot', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (28, N'bitter angostura', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (29, N'Midori', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (30, N'Rhum ambré', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (31, N'Pisang ambon', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (32, N'Crème de banane', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (33, N'Whisky (bourbon)', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (34, N'Triple sec', 1)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (35, N'Jus de citron', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (36, N'Jus d''orange', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (37, N'Jus d''ananas', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (38, N'Sirop de grenadine', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (39, N'Jus de lime', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (40, N'Sucre', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (41, N'Crème laitière légère', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (42, N'Jus de pamplemousse', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (43, N'Sirop de sucre', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (44, N'Soda', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (45, N'Lait', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (46, N'Jus de cannegerge rouge', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (47, N'Citron', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (48, N'Tonic', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (49, N'Jus de fruit de la passion', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (50, N'Ginger ale', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (51, N'Crème laitière épaisse', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (52, N'Café', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (53, N'Oeuf', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (54, N'Limonade', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (55, N'Sirop de fraise', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (56, N'Eau', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (57, N'Crème laitière fouettée', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (58, N'Sirop d''amande', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (59, N'Jus de pomme', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (60, N'Club soda', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (61, N'Eau gazeuse', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (62, N'Menthe', 0)
INSERT [dbo].[T_Ingredient] ([id], [name], [alcool]) VALUES (63, N'', 0)
SET IDENTITY_INSERT [dbo].[T_Ingredient] OFF
SET IDENTITY_INSERT [dbo].[T_CocktailsIngredients] ON 

INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2068, 1045, 62)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2069, 1045, 12)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2070, 1045, 47)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2071, 1046, 22)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2072, 1046, 37)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2073, 1047, 22)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2074, 1047, 36)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2075, 1048, 9)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2076, 1048, 15)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2077, 1049, 60)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2078, 1049, 36)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2079, 1049, 22)
INSERT [dbo].[T_CocktailsIngredients] ([id], [cocktail_id], [ingredient_id]) VALUES (2080, 1049, 10)
SET IDENTITY_INSERT [dbo].[T_CocktailsIngredients] OFF
SET IDENTITY_INSERT [dbo].[T_Favorite] ON 

INSERT [dbo].[T_Favorite] ([id], [cocktail_id], [user_id]) VALUES (2046, 1045, 24)
INSERT [dbo].[T_Favorite] ([id], [cocktail_id], [user_id]) VALUES (2047, 1046, 24)
INSERT [dbo].[T_Favorite] ([id], [cocktail_id], [user_id]) VALUES (2048, 1048, 24)
INSERT [dbo].[T_Favorite] ([id], [cocktail_id], [user_id]) VALUES (2049, 1046, 25)
INSERT [dbo].[T_Favorite] ([id], [cocktail_id], [user_id]) VALUES (2050, 1047, 25)
INSERT [dbo].[T_Favorite] ([id], [cocktail_id], [user_id]) VALUES (2051, 1049, 25)
SET IDENTITY_INSERT [dbo].[T_Favorite] OFF
