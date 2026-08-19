
SET IDENTITY_INSERT [dbo].[tRestaurant] ON
INSERT INTO [dbo].[tRestaurant] ([fRestaurantID], [fGooglePlaceID], [fCategoryID], [fName], [fAddress], [fLatitude], [fLongitude], [fPhone], [fDescription], [fGoogleRating], [fGoogleReviewCount], [fBusinessStatus], [fIsRecommend], [fCreatedTime], [fUpdatedTime]) VALUES (1, N'', 5, N'肉肉鮮本舖', N'新北市板橋區明翠里四維路112巷22號', CAST(0.0000000 AS Decimal(10, 7)), CAST(0.0000000 AS Decimal(10, 7)), N'02 2256 6686', N'冷凍食品商店，專賣冷凍肉品、海鮮、日本和牛、美國頂級牛肉、香草豬、台灣黑毛豬、土雞肉、仿土雞肉、羊肉、櫻桃鴨肉、生蠔、大閘蟹、水果、團購商品、韓國進口燒酒、日本韓國進口食材調味料、中秋烤肉、燒烤食材、火鍋肉片、燒烤肉片、烤肉架、木炭、木碳。', NULL, 0, N'周一至周日  10:30-21:30', 0, N'2026-08-17 17:14:48', NULL)
INSERT INTO [dbo].[tRestaurant] ([fRestaurantID], [fGooglePlaceID], [fCategoryID], [fName], [fAddress], [fLatitude], [fLongitude], [fPhone], [fDescription], [fGoogleRating], [fGoogleReviewCount], [fBusinessStatus], [fIsRecommend], [fCreatedTime], [fUpdatedTime]) VALUES (6, N'0', 1, N'大家發食品原料廣場', N'台灣新北市板橋區振興里三民路一段101號', CAST(0.0000000 AS Decimal(10, 7)), CAST(0.0000000 AS Decimal(10, 7)), N'02 8953 9111', N'大型商店，販售品項豐富的烘焙食材和設備。', NULL, 0, N'周一至周日 09:30–22:00', 0, N'2026-08-17 17:38:06', NULL)
INSERT INTO [dbo].[tRestaurant] ([fRestaurantID], [fGooglePlaceID], [fCategoryID], [fName], [fAddress], [fLatitude], [fLongitude], [fPhone], [fDescription], [fGoogleRating], [fGoogleReviewCount], [fBusinessStatus], [fIsRecommend], [fCreatedTime], [fUpdatedTime]) VALUES (8, N'22818b62dd1f4281b4e17e78657752dd', 1, N'香欣食品行', N'新北市板橋區留侯里福德街51號', CAST(0.0000000 AS Decimal(10, 7)), CAST(0.0000000 AS Decimal(10, 7)), N'02 8968 1807', N'專營進口南北貨 及食品雜貨', NULL, 0, N'周一至周日  07:00 - 20:00', 0, N'2026-08-17 17:49:07', NULL)
SET IDENTITY_INSERT [dbo].[tRestaurant] OFF


SET IDENTITY_INSERT [dbo].[tRestaurantCategory] ON
INSERT INTO [dbo].[tRestaurantCategory] ([fCategoryID], [fCategoryName], [fDescription], [fCreatedTime]) VALUES (1, N'食材', N'賣烹飪用食材的店家，例如:香料、調味料等', N'2026-08-17 17:09:35')
INSERT INTO [dbo].[tRestaurantCategory] ([fCategoryID], [fCategoryName], [fDescription], [fCreatedTime]) VALUES (2, N'用具', N'賣廚具的店家', N'2026-08-17 17:09:37')
INSERT INTO [dbo].[tRestaurantCategory] ([fCategoryID], [fCategoryName], [fDescription], [fCreatedTime]) VALUES (3, N'大賣場、超商', N'如Costco、全聯、7-11等', N'2026-08-17 17:09:50')
INSERT INTO [dbo].[tRestaurantCategory] ([fCategoryID], [fCategoryName], [fDescription], [fCreatedTime]) VALUES (4, N'傳統市場', N'傳統早市', N'2026-08-17 17:10:17')
INSERT INTO [dbo].[tRestaurantCategory] ([fCategoryID], [fCategoryName], [fDescription], [fCreatedTime]) VALUES (5, N'肉舖', N'專賣肉類的店家', N'2026-08-17 17:11:25')
INSERT INTO [dbo].[tRestaurantCategory] ([fCategoryID], [fCategoryName], [fDescription], [fCreatedTime]) VALUES (6, N'餐廳', N'吃飯的地方', N'2026-08-17 17:12:42')
SET IDENTITY_INSERT [dbo].[tRestaurantCategory] OFF


