--寫產品類別的資料
USE [midprjDb2]
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (1, N'食品', NULL)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (2, N'用品', NULL)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (11, N'鮮食', 1)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (12, N'乾貨', 1)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (13, N'零食', 1)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (14, N'飲料', 1)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (21, N'工具', 2)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (22, N'模具', 2)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (23, N'包裝', 2)
GO
INSERT [dbo].[tProductsCategory] ([fCategoryID], [fCategoriesName], [fParentCategoryId]) VALUES (24, N'設備', 2)
GO


--寫入會員假資料
INSERT INTO [dbo].[tUser] (
    [fUsername], [fNickname], [fPassword], [fEmail], 
    [fId_num], [fPhone], [fGender], [fAddress], 
    [fProfileImg], [fIsActive], [fCreateDate], [fLastLogin]
)
VALUES 
(
    'seller01', '小林', HASHBYTES('SHA2_256', 'Password123!'), 'seller01@example.com',
    'A123456789', '0912345678', 1, '台北市信義區忠孝東路五段100號',
    'https://example.com/images/user1.jpg', 1, '2026-06-01 10:00:00', '2026-08-15 14:30:00'
),
(
    'seller02', '雅涵', HASHBYTES('SHA2_256', 'Password123!'), 'seller02@example.com',
    'F223456789', '0987654321', 0, '新北市板橋區縣民大道二段7號',
    'https://example.com/images/user2.jpg', 1, '2026-06-05 11:30:00', '2026-08-16 09:15:00'
);

--寫入狀態假資料

INSERT INTO [dbo].[tStatus] ([fName])
VALUES 
('正常營運'),  -- 生成 fId = 1 (對應之前 tSeller 的 fStatus = 1)
('待審核'),    -- 生成 fId = 2
('已停權'),    -- 生成 fId = 3
('審核拒絕');  -- 生成 fId = 4

INSERT INTO [dbo].[tStatus] ([fName])
VALUES 
('正常營運'),
('待審核'),
('已停權'),
('審核拒絕');


--寫入商家資料
INSERT INTO [dbo].[tSeller] (
    [fUserId], [fName], [fDescription], [fStatus], [fApplyDate]
)
VALUES 
(
    1, '林家頂級生鮮行', '專營頂級安格斯黑牛、冷壓果汁與各類嚴選鮮食食材。', 1, '2026-06-02 14:00:00'
),
(
    2, '涵美烘焙生活館', '嚴選日本與台灣頂級烘焙模具、料理工具與專業設備。', 1, '2026-06-06 16:30:00'
);


--寫入品牌資料
-- =============================================
-- 若 dbo.tBrand 的 fBrandId 有設定 IDENTITY(1,1)：
-- =============================================
INSERT INTO [dbo].[tBrand] ([fBrandName])
VALUES 
(N'極鮮工坊'),    -- 自動生成 fBrandId = 1 (對應生鮮、鮮食、優質食品類)
(N'焙匠生活');    -- 自動生成 fBrandId = 2 (對應烘焙器具、模具、設備類)


--寫入產品資料★記得商家代號目前是用2.3
-- =============================================
-- 1. 食品類別 (ParentCategoryID = 1)
-- =============================================

-- [11 鮮食]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1101', 1, 11, N'特選安格斯黑牛雪花片', N'低溫熟成鮮嫩多汁，火鍋燒烤首選', 50, 380, 1, '2026-08-01', '2026-08-15', '2026-08-01 09:00:00', N'{"weight": "300g", "storage": "冷凍-18度", "origin": "美國"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1102', 2, 11, N'挪威頂級生食級鮭魚菲力', N'產地直送真空包裝，油脂豐厚', 35, 450, 2, '2026-08-05', '2026-08-19', '2026-08-05 10:30:00', N'{"weight": "250g", "storage": "冷凍-18度", "origin": "挪威"}', 1, 0);

INSERT INTO[dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1103', 1, 11, N'產銷履歷有機水耕鮮摘萵苣', N'無農藥水耕栽培，清脆鮮甜', 80, 85, 1, '2026-08-15', '2026-08-25', '2026-08-15 08:00:00', N'{"weight": "200g", "storage": "冷藏4度", "origin": "台灣"}', 1, 0);

-- [12 乾貨]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1201', 2, 12, N'高山特級椴木香菇', N'香氣濃郁厚實飽滿，燉湯必備', 100, 290, 2, '2026-06-01', '2027-06-01', '2026-06-10 14:00:00', N'{"weight": "150g", "storage": "常溫陰涼處", "origin": "台灣"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1202', 1, 12, N'特級頂級北海道干貝', N'天然日曬鮮味濃郁，料理提味首選', 40, 880, 1, '2026-05-15', '2027-05-15', '2026-05-20 11:15:00', N'{"weight": "200g", "storage": "冷藏保存", "origin": "日本"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1203', 2, 12, N'嚴選台灣在地黑豆', N'青仁黑豆低溫烘焙，煮茶料理皆宜', 120, 150, 2, '2026-07-01', '2027-07-01', '2026-07-05 16:20:00', N'{"weight": "500g", "storage": "常溫陰涼處", "origin": "台灣"}', 1, 0);

-- [13 零食]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1301', 1, 13, N'法式經典濃醇可可脆片', N'特級可可粉烘焙，香甜酥脆不膩口', 200, 120, 1, '2026-07-10', '2027-01-10', '2026-07-12 13:00:00', N'{"flavor": "可可", "weight": "180g", "isVegetarian": true}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1302', 2, 13, N'低溫真空慢炸綜合蔬菜脆片', N'保留天然鮮味與膳食纖維，健康無負擔', 150, 160, 2, '2026-08-01', '2027-02-01', '2026-08-03 15:45:00', N'{"flavor": "原味海鹽", "weight": "120g", "isVegetarian": true}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1303', 1, 13, N'海苔薄燒香脆米果', N'嚴選濁水溪好米，手工醬油烘烤', 180, 99, 1, '2026-07-20', '2027-01-20', '2026-07-22 09:30:00', N'{"flavor": "醬油海苔", "weight": "150g", "isVegetarian": true}', 1, 0);

-- [14 飲料]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1401', 2, 14, N'阿里山手採冷泡高山烏龍茶', N'甘醇回甘不苦澀，無糖無香精', 100, 65, 2, '2026-08-10', '2027-02-10', '2026-08-11 10:00:00', N'{"volume": "500ml", "sugar": "無糖", "caffeine": "有"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1402', 1, 14, N'100%冷壓鮮榨青森蘋果汁', N'完熟蘋果直接冷壓，酸甜適中', 80, 180, 1, '2026-07-15', '2027-01-15', '2026-07-16 11:30:00', N'{"volume": "1000ml", "sugar": "天然果糖", "caffeine": "無"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P1403', 2, 14, N'莊園級單品耶加雪菲濾掛咖啡', N'水洗淺焙柑橘花香，香氣優雅', 150, 320, 2, '2026-06-25', '2027-06-25', '2026-06-28 14:10:00', N'{"specs": "10包/盒", "roast": "淺中焙", "caffeine": "有"}', 1, 0);


-- =============================================
-- 2. 用品類別 (ParentCategoryID = 2)
-- =============================================

-- [21 工具]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2101', 1, 21, N'人體工學矽膠耐熱料理刮刀', N'食品級矽膠一體成形，耐熱230度不傷鍋', 90, 199, 1, '2026-05-10', NULL, '2026-07-01 08:30:00', N'{"material": "食品級矽膠", "heatResistance": "230°C", "color": "曜石黑"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2102', 2, 21, N'304不銹鋼精準刻度量匙五件組', N'雙向刻度清晰易讀，烘焙調味精準掌握', 110, 250, 2, '2026-05-15', NULL, '2026-07-05 10:00:00', N'{"material": "304不銹鋼", "pieces": "5件組", "dishwasherSafe": true}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2103', 1, 21, N'多功能手持電動打蛋器', N'五段調速強力馬達，附雙攪拌棒', 60, 599, 1, '2026-06-01', NULL, '2026-07-10 14:40:00', N'{"power": "250W", "warranty": "1年", "speedLevels": 5}', 1, 0);


-- [22 模具]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2201', 2, 22, N'八吋碳鋼活底不沾戚風蛋糕模', N'導熱均勻好脫模，陽極不沾塗層', 75, 360, 2, '2026-04-20', NULL, '2026-06-15 09:20:00', N'{"material": "重型碳鋼", "size": "8吋", "coating": "不沾塗層"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2202', 1, 22, N'波紋吐司盒附蓋 (450g一斤裝)', N'透氣孔設計受熱快速，四角波紋結構', 85, 420, 1, '2026-05-01', NULL, '2026-06-20 16:15:00', N'{"capacity": "450g", "material": "鋁合金", "hasLid": true}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2203', 2, 22, N'12連杯馬芬可麗露連模', N'一體衝壓無縫隙，輕鬆烘烤小點心', 95, 380, 2, '2026-05-18', NULL, '2026-07-02 11:50:00', N'{"cavities": 12, "material": "碳鋼", "coating": "食品級耐高溫塗層"}', 1, 0);


-- [23 包裝]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2301', 1, 23, N'手提開窗牛皮紙點心烘焙盒 (20入)', N'加厚牛皮紙高透PET開窗，送禮美觀', 200, 199, 1, '2026-06-10', NULL, '2026-07-18 13:20:00', N'{"material": "350g牛皮紙", "quantity": "20入/包", "dimension": "16x16x7.5cm"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2302', 2, 23, N'霧面磨砂自黏封口點心餅乾袋 (100入)', N'防潮密封性佳，適合雪Q餅、手工餅乾', 300, 99, 2, '2026-06-20', NULL, '2026-07-25 15:10:00', N'{"material": "複合食品級塑料", "quantity": "100入/包", "size": "7x10cm"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2303', 1, 23, N'經典燙金緞帶捲 (寬2cm 長22m)', N'細緻絲光緞面燙金字樣，質感禮品包裝', 150, 85, 1, '2026-07-01', NULL, '2026-08-01 17:00:00', N'{"material": "聚酯纖維", "length": "22m", "width": "2cm"}', 1, 0);


-- [24 設備]
INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2401', 2, 24, N'專業級45L獨立發酵溫控旋風烤箱', N'上下火獨立調溫，內建發酵與旋風熱風功能', 20, 4800, 2, '2026-03-15', NULL, '2026-06-01 10:00:00', N'{"capacity": "45L", "power": "1500W", "voltage": "110V", "warranty": "2年"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2402', 1, 24, N'商業級7L桌上型不銹鋼攪拌機', N'金屬齒輪傳動結構，三種攪拌配件一機多用', 15, 8900, 1, '2026-04-01', NULL, '2026-06-10 11:30:00', N'{"capacity": "7L", "motor": "直流無刷馬達", "warranty": "1年"}', 1, 0);

INSERT INTO [dbo].[tProduct] ([fProductNo], [fSeller_Id], [fProductsCategoryID], [fProductname], [fDescription], [fStock], [fPrice], [fBrandId], [fManufacturingDate], [fExpirationDate], [fProductDate], [fAttributesJson], [fProductStatus], [fReportCount])
VALUES ('P2403', 2, 24, N'家用觸控多功能乾果烘乾機 (六層)', N'360度立體熱風循環，精準溫控30-90度', 25, 2680, 2, '2026-05-10', NULL, '2026-07-05 14:15:00', N'{"layers": 6, "timer": "24小時", "material": "304不銹鋼層架"}', 1, 0);


--寫入優惠卷

INSERT INTO [tCoupon] (
    [fSeller_Id],
    [fName],
    [fCode],
    [fScopeType],
    [fDiscountType],
    [fDiscountValue],
    [fMinPurchaseAmount],
    [fMaxDiscountAmount],
    [fStartDate],
    [fEndDate],
    [fIsActive]
)
VALUES
-- 1. 全站新會員固定折抵
(NULL, N'新會員首購現折 $100', 'WELCOME2026', 'Platform', 'Fixed', 100.00, 500.00, NULL, '2026-01-01', '2026-12-31 23:59:59', 1),

-- 2. 全站滿額比例折扣（有上限）
(NULL, N'全站年中慶享 88 折', 'MID202688', 'Platform', 'Percentage', 0.88, 1000.00, 300.00, '2026-06-01', '2026-06-30 23:59:59', 1),

-- 3. 運費折抵券
(NULL, N'滿額超取免運券', 'FREESHIP', 'Shipping', 'Fixed', 60.00, 299.00, NULL, '2026-01-01', '2026-12-31 23:59:59', 1),

-- 4. 特定賣家（商家 ID = 1）固定滿額折
(1, N'賣家專屬回饋滿 $400 折 $50', 'SHOP1OFF50', 'Store', 'Fixed', 50.00, 400.00, NULL, '2026-07-01', '2026-09-30 23:59:59', 1),

-- 5. 特定賣家（商家 ID = 2）比例折扣
(2, N'旗艦館限定 9 折券', 'FLAGSHIP90', 'Store', 'Percentage', 0.90, 1500.00, 500.00, '2026-08-01', '2026-08-31 23:59:59', 1),

-- 6. 全站高門檻 VIP 現折券
(NULL, N'VIP 會員滿 $3000 現折 $500', 'VIP500', 'Platform', 'Fixed', 500.00, 3000.00, NULL, '2026-01-01', '2026-12-31 23:59:59', 1);