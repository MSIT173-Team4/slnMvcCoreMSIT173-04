using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prjMvcCoreMSIC173.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tAuditLog",
                columns: table => new
                {
                    fLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fAdminUserId = table.Column<int>(type: "int", nullable: false),
                    fTargetRecipeId = table.Column<int>(type: "int", nullable: false),
                    fAction = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fExecutedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tAuditLo__3CD1938B75982076", x => x.fLogId);
                });

            migrationBuilder.CreateTable(
                name: "tBrand",
                columns: table => new
                {
                    fBrandId = table.Column<int>(type: "int", nullable: false),
                    fBrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.fBrandId);
                });

            migrationBuilder.CreateTable(
                name: "tCoupon",
                columns: table => new
                {
                    fCouponId = table.Column<int>(type: "int", nullable: false),
                    fSeller_Id = table.Column<int>(type: "int", nullable: true),
                    fName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fScopeType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fDiscountType = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fDiscountValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fMinPurchaseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fMaxDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    fStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fIsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.fCouponId);
                });

            migrationBuilder.CreateTable(
                name: "tIngredient",
                columns: table => new
                {
                    fIngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fCategory = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fCaloriesPerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fStandardUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tIngredi__3A47A04554E34ADB", x => x.fIngredientId);
                });

            migrationBuilder.CreateTable(
                name: "tOrder",
                columns: table => new
                {
                    fOrderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fOrderNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fUsers_Id = table.Column<int>(type: "int", nullable: false),
                    fSeller_Id = table.Column<int>(type: "int", nullable: false),
                    fOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fShippingFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fShippingDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fProductDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fTotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fRecipientName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fRecipientPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fShippingAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fShippingMethod = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fIsShippingConfirmed = table.Column<bool>(type: "bit", nullable: false, comment: "賣家是否已確認/列印出貨單（0 未確認 1 已確認/已列印）"),
                    fOrderStatus = table.Column<int>(type: "int", nullable: false, comment: "訂單狀態：0 待處理 / 1 已成立 / 2 已完成 / 3 已取消"),
                    fPaymentStatus = table.Column<int>(type: "int", nullable: false, comment: "付款狀態：0 待付款 / 1 已付款 / 2 待退款 / 3 已退款"),
                    fShippingStatus = table.Column<int>(type: "int", nullable: false, comment: "運送狀態：0 待出貨 / 1 運送中 / 2 已送達 / 3 運送失敗 / 4 退回包裹運送中 / 5 賣家已取回退件"),
                    fCancellationStatus = table.Column<int>(type: "int", nullable: false, comment: "取消狀態：0 無取消申請 / 1 待回覆 / 2 已取消 / 3 拒絕取消"),
                    fReturnStatus = table.Column<int>(type: "int", nullable: false, comment: "退貨狀態：0 無退貨 / 1 待處理 / 2 已處理")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.fOrderID);
                });

            migrationBuilder.CreateTable(
                name: "tProductsCategory",
                columns: table => new
                {
                    fCategoryID = table.Column<int>(type: "int", nullable: false),
                    fCategoriesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsCategory", x => x.fCategoryID);
                    table.ForeignKey(
                        name: "FK_ProductsCategory_ProductsCategory",
                        column: x => x.fParentCategoryId,
                        principalTable: "tProductsCategory",
                        principalColumn: "fCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "tRecipe",
                columns: table => new
                {
                    fRecipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fAuthorUserId = table.Column<int>(type: "int", nullable: false),
                    fTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fDefaultServings = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    fCoverImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    fTotalCookingMinutes = table.Column<int>(type: "int", nullable: false),
                    fViewCount = table.Column<int>(type: "int", nullable: false),
                    fStatus = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    fIsAiGenerated = table.Column<bool>(type: "bit", nullable: false),
                    fCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    fUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRecipe__EF3B24C700A1C89D", x => x.fRecipeId);
                });

            migrationBuilder.CreateTable(
                name: "tRestaurantCategory",
                columns: table => new
                {
                    fCategoryID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fCreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF_RestaurantCategory_CreatedTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRestaur__53E607D33243056A", x => x.fCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "tStatus",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tStatus__D9F8227CCB85E5C0", x => x.fId);
                });

            migrationBuilder.CreateTable(
                name: "tTag",
                columns: table => new
                {
                    fTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fTagName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    fCategory = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tTag__036309757A066FA3", x => x.fTagId);
                });

            migrationBuilder.CreateTable(
                name: "tUser",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUsername = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fNickname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    fPassword = table.Column<byte[]>(type: "varbinary(40)", maxLength: 40, nullable: false),
                    fEmail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fId_num = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fPhone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fGender = table.Column<bool>(type: "bit", nullable: false),
                    fAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fProfileImg = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    fIsActive = table.Column<bool>(type: "bit", nullable: false),
                    fCreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fLastLogin = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tUser__D9F8227CA4B2B9CC", x => x.fId);
                });

            migrationBuilder.CreateTable(
                name: "tUserFollow",
                columns: table => new
                {
                    fFollowerId = table.Column<int>(type: "int", nullable: false),
                    fFolloweeId = table.Column<int>(type: "int", nullable: false),
                    fCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollows", x => new { x.fFollowerId, x.fFolloweeId });
                });

            migrationBuilder.CreateTable(
                name: "tUserPantry",
                columns: table => new
                {
                    fPantryItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUserId = table.Column<int>(type: "int", nullable: false),
                    fIngredientId = table.Column<int>(type: "int", nullable: false),
                    fStockQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fExpiryDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tUserPan__762E20883F09334E", x => x.fPantryItemId);
                    table.ForeignKey(
                        name: "FK_UserPantry_Ingredients",
                        column: x => x.fIngredientId,
                        principalTable: "tIngredient",
                        principalColumn: "fIngredientId");
                });

            migrationBuilder.CreateTable(
                name: "tOrderDiscount",
                columns: table => new
                {
                    fOrderDiscountId = table.Column<int>(type: "int", nullable: false),
                    fOrderID = table.Column<long>(type: "bigint", nullable: false),
                    fCouponId = table.Column<int>(type: "int", nullable: false),
                    fDiscountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fDiscountScope = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fDiscountType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    fAppliedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDiscounts", x => x.fOrderDiscountId);
                    table.ForeignKey(
                        name: "FK_OrderDiscounts_Coupons",
                        column: x => x.fCouponId,
                        principalTable: "tCoupon",
                        principalColumn: "fCouponId");
                    table.ForeignKey(
                        name: "FK_OrderDiscounts_Orders",
                        column: x => x.fOrderID,
                        principalTable: "tOrder",
                        principalColumn: "fOrderID");
                });

            migrationBuilder.CreateTable(
                name: "tProduct",
                columns: table => new
                {
                    fProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fProductNo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fSeller_Id = table.Column<int>(type: "int", nullable: false),
                    fProductsCategoryID = table.Column<int>(type: "int", nullable: false),
                    fProductname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fStock = table.Column<int>(type: "int", nullable: false),
                    fPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fBrandId = table.Column<int>(type: "int", nullable: true),
                    fManufacturingDate = table.Column<DateOnly>(type: "date", nullable: false),
                    fExpirationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    fProductDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fAttributesJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fProductStatus = table.Column<byte>(type: "tinyint", nullable: true, comment: "商品狀態：0 審核中 / 1 架上商品 / 2 已售完 / 3 未上架 / 4 已違規"),
                    fReportCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.fProductID);
                    table.ForeignKey(
                        name: "FK_Products_Brands",
                        column: x => x.fBrandId,
                        principalTable: "tBrand",
                        principalColumn: "fBrandId");
                    table.ForeignKey(
                        name: "FK_Products_ProductsCategories",
                        column: x => x.fProductsCategoryID,
                        principalTable: "tProductsCategory",
                        principalColumn: "fCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "tRecipeIngredient",
                columns: table => new
                {
                    fRecipeId = table.Column<int>(type: "int", nullable: false),
                    fIngredientId = table.Column<int>(type: "int", nullable: false),
                    fRequiredQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    fUnit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.fRecipeId, x.fIngredientId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients",
                        column: x => x.fIngredientId,
                        principalTable: "tIngredient",
                        principalColumn: "fIngredientId");
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes",
                        column: x => x.fRecipeId,
                        principalTable: "tRecipe",
                        principalColumn: "fRecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tRecipeLike",
                columns: table => new
                {
                    fUserId = table.Column<int>(type: "int", nullable: false),
                    fRecipeId = table.Column<int>(type: "int", nullable: false),
                    fCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeLikes", x => new { x.fUserId, x.fRecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeLikes_Recipes",
                        column: x => x.fRecipeId,
                        principalTable: "tRecipe",
                        principalColumn: "fRecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tRecipeRecreation",
                columns: table => new
                {
                    fRecreationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fRecipeId = table.Column<int>(type: "int", nullable: false),
                    fUserId = table.Column<int>(type: "int", nullable: false),
                    fRecreationImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    fNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fServingsCooked = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    fCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRecipeR__5F32237EC6D73112", x => x.fRecreationId);
                    table.ForeignKey(
                        name: "FK_RecipeRecreations_Recipes",
                        column: x => x.fRecipeId,
                        principalTable: "tRecipe",
                        principalColumn: "fRecipeId");
                });

            migrationBuilder.CreateTable(
                name: "tRecipeStep",
                columns: table => new
                {
                    fStepId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fRecipeId = table.Column<int>(type: "int", nullable: false),
                    fStepNumber = table.Column<int>(type: "int", nullable: false),
                    fInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    fTimerSeconds = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRecipeS__D4B885FFF71D234F", x => x.fStepId);
                    table.ForeignKey(
                        name: "FK_RecipeSteps_Recipes",
                        column: x => x.fRecipeId,
                        principalTable: "tRecipe",
                        principalColumn: "fRecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tRestaurant",
                columns: table => new
                {
                    fRestaurantID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fGooglePlaceID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    fCategoryID = table.Column<long>(type: "bigint", nullable: false),
                    fName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    fLatitude = table.Column<decimal>(type: "decimal(10,7)", nullable: false),
                    fLongitude = table.Column<decimal>(type: "decimal(10,7)", nullable: false),
                    fPhone = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    fDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fGoogleRating = table.Column<decimal>(type: "decimal(2,1)", nullable: true),
                    fGoogleReviewCount = table.Column<int>(type: "int", nullable: false),
                    fBusinessStatus = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, defaultValue: "Operational")
                        .Annotation("Relational:DefaultConstraintName", "DF_Restaurant_BusinessStatus"),
                    fIsRecommend = table.Column<bool>(type: "bit", nullable: false),
                    fCreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF_Restaurant_CreatedTime"),
                    fUpdatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRestaur__B18244B3A32FA8C5", x => x.fRestaurantID);
                    table.ForeignKey(
                        name: "FK_Restaurant_Category",
                        column: x => x.fCategoryID,
                        principalTable: "tRestaurantCategory",
                        principalColumn: "fCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "tRecipeTag",
                columns: table => new
                {
                    fRecipeId = table.Column<int>(type: "int", nullable: false),
                    fTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTags", x => new { x.fRecipeId, x.fTagId });
                    table.ForeignKey(
                        name: "FK_RecipeTags_Recipes",
                        column: x => x.fRecipeId,
                        principalTable: "tRecipe",
                        principalColumn: "fRecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Tags",
                        column: x => x.fTagId,
                        principalTable: "tTag",
                        principalColumn: "fTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tApply",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUserId = table.Column<int>(type: "int", nullable: false),
                    fStoreName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fStoreDescription = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    fIdNum = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    fIdCard = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    fStatus = table.Column<int>(type: "int", nullable: false),
                    fApplyDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tApply__D9F8227C94FB5E86", x => x.fId);
                    table.ForeignKey(
                        name: "FK_tApply_tUser",
                        column: x => x.fUserId,
                        principalTable: "tUser",
                        principalColumn: "fId");
                });

            migrationBuilder.CreateTable(
                name: "tPostTable",
                columns: table => new
                {
                    fPostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUser_Id = table.Column<int>(type: "int", nullable: false),
                    fTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    fPostContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fLikes = table.Column<int>(type: "int", nullable: false),
                    fViews = table.Column<int>(type: "int", nullable: false),
                    fPostDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fPostState = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                        .Annotation("Relational:DefaultConstraintName", "DF_PostTable_fPostState")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTable", x => x.fPostID);
                    table.ForeignKey(
                        name: "FK_PostTable_User",
                        column: x => x.fUser_Id,
                        principalTable: "tUser",
                        principalColumn: "fId");
                });

            migrationBuilder.CreateTable(
                name: "tRecipeFavorite",
                columns: table => new
                {
                    fUserId = table.Column<int>(type: "int", nullable: false),
                    fRecipeId = table.Column<int>(type: "int", nullable: false),
                    fCreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeFavorites", x => new { x.fUserId, x.fRecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeFavorite_User",
                        column: x => x.fUserId,
                        principalTable: "tUser",
                        principalColumn: "fId");
                    table.ForeignKey(
                        name: "FK_RecipeFavorites_Recipes",
                        column: x => x.fRecipeId,
                        principalTable: "tRecipe",
                        principalColumn: "fRecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tSeller",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUserId = table.Column<int>(type: "int", nullable: false),
                    fName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fDescription = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    fStatus = table.Column<int>(type: "int", nullable: false),
                    fApplyDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tSeller__D9F8227CC2CEEF95", x => x.fId);
                    table.ForeignKey(
                        name: "FK_tSeller_tStatus",
                        column: x => x.fStatus,
                        principalTable: "tStatus",
                        principalColumn: "fId");
                    table.ForeignKey(
                        name: "FK_tSeller_tUser",
                        column: x => x.fUserId,
                        principalTable: "tUser",
                        principalColumn: "fId");
                });

            migrationBuilder.CreateTable(
                name: "tTrip",
                columns: table => new
                {
                    fTripID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUsers_ID = table.Column<int>(type: "int", nullable: false),
                    fTripName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fTripDate = table.Column<DateOnly>(type: "date", nullable: false),
                    fStartTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    fDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    fStatus = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, defaultValue: "Draft")
                        .Annotation("Relational:DefaultConstraintName", "DF_Trip_Status"),
                    fCreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF_Trip_CreatedTime"),
                    fUpdatedTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tTrip__704F7E1DFE254E51", x => x.fTripID);
                    table.ForeignKey(
                        name: "FK_Trip_Users_",
                        column: x => x.fUsers_ID,
                        principalTable: "tUser",
                        principalColumn: "fId");
                });

            migrationBuilder.CreateTable(
                name: "t_Product_Favorite",
                columns: table => new
                {
                    fFavoriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUsers_Id = table.Column<int>(type: "int", nullable: false),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.fFavoriteID);
                    table.ForeignKey(
                        name: "FK_Favorites_Products",
                        column: x => x.fProductID,
                        principalTable: "tProduct",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateTable(
                name: "tOrderDetail",
                columns: table => new
                {
                    fOrderDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fOrderID = table.Column<long>(type: "bigint", nullable: false),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fQuantity = table.Column<int>(type: "int", nullable: false),
                    fUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.fOrderDetailsID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.fOrderID,
                        principalTable: "tOrder",
                        principalColumn: "fOrderID");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products",
                        column: x => x.fProductID,
                        principalTable: "tProduct",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateTable(
                name: "tProductImage",
                columns: table => new
                {
                    fProductImageID = table.Column<int>(type: "int", nullable: false),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    fSortOrder = table.Column<short>(type: "smallint", nullable: false),
                    fCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImage", x => x.fProductImageID);
                    table.ForeignKey(
                        name: "FK_ProductImage_Products",
                        column: x => x.fProductID,
                        principalTable: "tProduct",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateTable(
                name: "tShoppingCart",
                columns: table => new
                {
                    fCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUsers_Id = table.Column<int>(type: "int", nullable: false),
                    fSeller_Id = table.Column<int>(type: "int", nullable: false),
                    fProductId = table.Column<int>(type: "int", nullable: false),
                    fQuantity = table.Column<int>(type: "int", nullable: false),
                    fCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.fCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_Products",
                        column: x => x.fProductId,
                        principalTable: "tProduct",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateTable(
                name: "tMapFavorite",
                columns: table => new
                {
                    fFavoriteID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUsers_ID = table.Column<int>(type: "int", nullable: false),
                    fRestaurantID = table.Column<long>(type: "bigint", nullable: false),
                    fCreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF_Favorite_CreatedTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tMapFavo__BAA205373544AC73", x => x.fFavoriteID);
                    table.ForeignKey(
                        name: "FK_Favorite_Restaurant",
                        column: x => x.fRestaurantID,
                        principalTable: "tRestaurant",
                        principalColumn: "fRestaurantID");
                    table.ForeignKey(
                        name: "FK_Favorite_Users_",
                        column: x => x.fUsers_ID,
                        principalTable: "tUser",
                        principalColumn: "fId");
                });

            migrationBuilder.CreateTable(
                name: "tRecommendation",
                columns: table => new
                {
                    fRecommendationID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fRestaurantID = table.Column<long>(type: "bigint", nullable: false),
                    fTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fPriority = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                        .Annotation("Relational:DefaultConstraintName", "DF_Recommendation_Priority"),
                    fStartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    fEndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    fIsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                        .Annotation("Relational:DefaultConstraintName", "DF_Recommendation_IsActive")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRecomme__A41CD6C95F3659E0", x => x.fRecommendationID);
                    table.ForeignKey(
                        name: "FK_Recommendation_Restaurant",
                        column: x => x.fRestaurantID,
                        principalTable: "tRestaurant",
                        principalColumn: "fRestaurantID");
                });

            migrationBuilder.CreateTable(
                name: "tRestaurantImage",
                columns: table => new
                {
                    fImageID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fRestaurantID = table.Column<long>(type: "bigint", nullable: false),
                    fImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    fImageType = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false, defaultValue: "Google")
                        .Annotation("Relational:DefaultConstraintName", "DF_RestaurantImage_ImageType")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tRestaur__39CAEC2A27FDBB83", x => x.fImageID);
                    table.ForeignKey(
                        name: "FK_RestaurantImage_Restaurant",
                        column: x => x.fRestaurantID,
                        principalTable: "tRestaurant",
                        principalColumn: "fRestaurantID");
                });

            migrationBuilder.CreateTable(
                name: "tMessageTable",
                columns: table => new
                {
                    fMessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fPostID = table.Column<int>(type: "int", nullable: false),
                    fUser_Id = table.Column<int>(type: "int", nullable: false),
                    fReplyMessageID = table.Column<int>(type: "int", nullable: false),
                    fMessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fLikes = table.Column<int>(type: "int", nullable: false),
                    fViews = table.Column<int>(type: "int", nullable: false),
                    fMessageDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    fMessageState = table.Column<byte>(type: "tinyint", nullable: false, defaultValue: (byte)1)
                        .Annotation("Relational:DefaultConstraintName", "DF_MessageTable_fMessageState")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageTable", x => x.fMessageID);
                    table.ForeignKey(
                        name: "FK_MessageTable_PostTable",
                        column: x => x.fPostID,
                        principalTable: "tPostTable",
                        principalColumn: "fPostID");
                    table.ForeignKey(
                        name: "FK_MessageTable_User",
                        column: x => x.fUser_Id,
                        principalTable: "tUser",
                        principalColumn: "fId");
                });

            migrationBuilder.CreateTable(
                name: "tTripRestaurant",
                columns: table => new
                {
                    fTripRestaurantID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fTripID = table.Column<long>(type: "bigint", nullable: false),
                    fRestaurantID = table.Column<long>(type: "bigint", nullable: false),
                    fSortOrder = table.Column<int>(type: "int", nullable: false),
                    fVisitTime = table.Column<TimeOnly>(type: "time", nullable: true),
                    fStayMinutes = table.Column<int>(type: "int", nullable: true),
                    fNote = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    fCreatedTime = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                        .Annotation("Relational:DefaultConstraintName", "DF_TripRestaurant_CreatedTime")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tTripRes__6D75C5210DB38984", x => x.fTripRestaurantID);
                    table.ForeignKey(
                        name: "FK_TripRestaurant_Restaurant",
                        column: x => x.fRestaurantID,
                        principalTable: "tRestaurant",
                        principalColumn: "fRestaurantID");
                    table.ForeignKey(
                        name: "FK_TripRestaurant_Trip",
                        column: x => x.fTripID,
                        principalTable: "tTrip",
                        principalColumn: "fTripID");
                });

            migrationBuilder.CreateTable(
                name: "tProductReview",
                columns: table => new
                {
                    fReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fOrderDetailsID = table.Column<int>(type: "int", nullable: false),
                    fProductID = table.Column<int>(type: "int", nullable: false),
                    fUsers_Id = table.Column<int>(type: "int", nullable: false),
                    fRating = table.Column<byte>(type: "tinyint", nullable: false),
                    fComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.fReviewID);
                    table.ForeignKey(
                        name: "FK_ProductReviews_OrderDetails",
                        column: x => x.fOrderDetailsID,
                        principalTable: "tOrderDetail",
                        principalColumn: "fOrderDetailsID");
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products",
                        column: x => x.fProductID,
                        principalTable: "tProduct",
                        principalColumn: "fProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_Product_Favorite_fProductID",
                table: "t_Product_Favorite",
                column: "fProductID");

            migrationBuilder.CreateIndex(
                name: "UQ_Favorites_User_Product",
                table: "t_Product_Favorite",
                columns: new[] { "fUsers_Id", "fProductID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tApply_fUserId",
                table: "tApply",
                column: "fUserId");

            migrationBuilder.CreateIndex(
                name: "UQ_Coupon_Code",
                table: "tCoupon",
                column: "fCode",
                unique: true,
                filter: "[fCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tMapFavorite_fRestaurantID",
                table: "tMapFavorite",
                column: "fRestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_tMapFavorite_fUsers_ID",
                table: "tMapFavorite",
                column: "fUsers_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tMessageTable_fPostID",
                table: "tMessageTable",
                column: "fPostID");

            migrationBuilder.CreateIndex(
                name: "IX_tMessageTable_fUser_Id",
                table: "tMessageTable",
                column: "fUser_Id");

            migrationBuilder.CreateIndex(
                name: "UQ_Orders_OrderNo",
                table: "tOrder",
                column: "fOrderNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tOrderDetail_fOrderID",
                table: "tOrderDetail",
                column: "fOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrderDetail_fProductID",
                table: "tOrderDetail",
                column: "fProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tOrderDiscount_fCouponId",
                table: "tOrderDiscount",
                column: "fCouponId");

            migrationBuilder.CreateIndex(
                name: "IX_tOrderDiscount_fOrderID",
                table: "tOrderDiscount",
                column: "fOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tPostTable_fUser_Id",
                table: "tPostTable",
                column: "fUser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_tProduct_fBrandId",
                table: "tProduct",
                column: "fBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_tProduct_fProductsCategoryID",
                table: "tProduct",
                column: "fProductsCategoryID");

            migrationBuilder.CreateIndex(
                name: "UQ_Products_ProductNo",
                table: "tProduct",
                column: "fProductNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tProductImage_fProductID",
                table: "tProductImage",
                column: "fProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tProductReview_fProductID",
                table: "tProductReview",
                column: "fProductID");

            migrationBuilder.CreateIndex(
                name: "UQ_ProductReviews_OrderDetailsID",
                table: "tProductReview",
                column: "fOrderDetailsID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tProductsCategory_fParentCategoryId",
                table: "tProductsCategory",
                column: "fParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecipeFavorite_fRecipeId",
                table: "tRecipeFavorite",
                column: "fRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecipeIngredient_fIngredientId",
                table: "tRecipeIngredient",
                column: "fIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecipeLike_fRecipeId",
                table: "tRecipeLike",
                column: "fRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecipeRecreation_fRecipeId",
                table: "tRecipeRecreation",
                column: "fRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecipeStep_fRecipeId",
                table: "tRecipeStep",
                column: "fRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecipeTag_fTagId",
                table: "tRecipeTag",
                column: "fTagId");

            migrationBuilder.CreateIndex(
                name: "IX_tRecommendation_fRestaurantID",
                table: "tRecommendation",
                column: "fRestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_tRestaurant_fCategoryID",
                table: "tRestaurant",
                column: "fCategoryID");

            migrationBuilder.CreateIndex(
                name: "UQ_Restaurant_GooglePlaceID",
                table: "tRestaurant",
                column: "fGooglePlaceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tRestaurantImage_fRestaurantID",
                table: "tRestaurantImage",
                column: "fRestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_tSeller_fStatus",
                table: "tSeller",
                column: "fStatus");

            migrationBuilder.CreateIndex(
                name: "IX_tSeller_fUserId",
                table: "tSeller",
                column: "fUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tShoppingCart_fProductId",
                table: "tShoppingCart",
                column: "fProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tTrip_fUsers_ID",
                table: "tTrip",
                column: "fUsers_ID");

            migrationBuilder.CreateIndex(
                name: "IX_tTripRestaurant_fRestaurantID",
                table: "tTripRestaurant",
                column: "fRestaurantID");

            migrationBuilder.CreateIndex(
                name: "UQ_TripRestaurant_SortOrder",
                table: "tTripRestaurant",
                columns: new[] { "fTripID", "fSortOrder" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__tUser__E609A9E550B0079B",
                table: "tUser",
                column: "fEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tUserPantry_fIngredientId",
                table: "tUserPantry",
                column: "fIngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Product_Favorite");

            migrationBuilder.DropTable(
                name: "tApply");

            migrationBuilder.DropTable(
                name: "tAuditLog");

            migrationBuilder.DropTable(
                name: "tMapFavorite");

            migrationBuilder.DropTable(
                name: "tMessageTable");

            migrationBuilder.DropTable(
                name: "tOrderDiscount");

            migrationBuilder.DropTable(
                name: "tProductImage");

            migrationBuilder.DropTable(
                name: "tProductReview");

            migrationBuilder.DropTable(
                name: "tRecipeFavorite");

            migrationBuilder.DropTable(
                name: "tRecipeIngredient");

            migrationBuilder.DropTable(
                name: "tRecipeLike");

            migrationBuilder.DropTable(
                name: "tRecipeRecreation");

            migrationBuilder.DropTable(
                name: "tRecipeStep");

            migrationBuilder.DropTable(
                name: "tRecipeTag");

            migrationBuilder.DropTable(
                name: "tRecommendation");

            migrationBuilder.DropTable(
                name: "tRestaurantImage");

            migrationBuilder.DropTable(
                name: "tSeller");

            migrationBuilder.DropTable(
                name: "tShoppingCart");

            migrationBuilder.DropTable(
                name: "tTripRestaurant");

            migrationBuilder.DropTable(
                name: "tUserFollow");

            migrationBuilder.DropTable(
                name: "tUserPantry");

            migrationBuilder.DropTable(
                name: "tPostTable");

            migrationBuilder.DropTable(
                name: "tCoupon");

            migrationBuilder.DropTable(
                name: "tOrderDetail");

            migrationBuilder.DropTable(
                name: "tRecipe");

            migrationBuilder.DropTable(
                name: "tTag");

            migrationBuilder.DropTable(
                name: "tStatus");

            migrationBuilder.DropTable(
                name: "tRestaurant");

            migrationBuilder.DropTable(
                name: "tTrip");

            migrationBuilder.DropTable(
                name: "tIngredient");

            migrationBuilder.DropTable(
                name: "tOrder");

            migrationBuilder.DropTable(
                name: "tProduct");

            migrationBuilder.DropTable(
                name: "tRestaurantCategory");

            migrationBuilder.DropTable(
                name: "tUser");

            migrationBuilder.DropTable(
                name: "tBrand");

            migrationBuilder.DropTable(
                name: "tProductsCategory");
        }
    }
}
