using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjMvcCore第四組.Models;

public partial class MidprjDb2Context : DbContext
{
    public MidprjDb2Context()
    {
    }

    public MidprjDb2Context(DbContextOptions<MidprjDb2Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TApply> TApplies { get; set; }

    public virtual DbSet<TAuditLog> TAuditLogs { get; set; }

    public virtual DbSet<TBrand> TBrands { get; set; }

    public virtual DbSet<TCoupon> TCoupons { get; set; }

    public virtual DbSet<TIngredient> TIngredients { get; set; }

    public virtual DbSet<TMapFavorite> TMapFavorites { get; set; }

    public virtual DbSet<TMessageTable> TMessageTables { get; set; }

    public virtual DbSet<TOrder> TOrders { get; set; }

    public virtual DbSet<TOrderDetail> TOrderDetails { get; set; }

    public virtual DbSet<TOrderDiscount> TOrderDiscounts { get; set; }

    public virtual DbSet<TPostTable> TPostTables { get; set; }

    public virtual DbSet<TProduct> TProducts { get; set; }

    public virtual DbSet<TProductFavorite> TProductFavorites { get; set; }

    public virtual DbSet<TProductImage> TProductImages { get; set; }

    public virtual DbSet<TProductReview> TProductReviews { get; set; }

    public virtual DbSet<TProductsCategory> TProductsCategories { get; set; }

    public virtual DbSet<TRecipe> TRecipes { get; set; }

    public virtual DbSet<TRecipeFavorite> TRecipeFavorites { get; set; }

    public virtual DbSet<TRecipeIngredient> TRecipeIngredients { get; set; }

    public virtual DbSet<TRecipeLike> TRecipeLikes { get; set; }

    public virtual DbSet<TRecipeRecreation> TRecipeRecreations { get; set; }

    public virtual DbSet<TRecipeStep> TRecipeSteps { get; set; }

    public virtual DbSet<TRecommendation> TRecommendations { get; set; }

    public virtual DbSet<TRestaurant> TRestaurants { get; set; }

    public virtual DbSet<TRestaurantCategory> TRestaurantCategories { get; set; }

    public virtual DbSet<TRestaurantImage> TRestaurantImages { get; set; }

    public virtual DbSet<TSeller> TSellers { get; set; }

    public virtual DbSet<TShoppingCart> TShoppingCarts { get; set; }

    public virtual DbSet<TStatus> TStatuses { get; set; }

    public virtual DbSet<TTag> TTags { get; set; }

    public virtual DbSet<TTrip> TTrips { get; set; }

    public virtual DbSet<TTripRestaurant> TTripRestaurants { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

    public virtual DbSet<TUserFollow> TUserFollows { get; set; }

    public virtual DbSet<TUserPantry> TUserPantries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=midprjDb2;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TApply>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tApply__D9F8227C94FB5E86");

            entity.ToTable("tApply");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FApplyDate)
                .HasColumnType("datetime")
                .HasColumnName("fApplyDate");
            entity.Property(e => e.FIdCard)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fIdCard");
            entity.Property(e => e.FIdNum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fIdNum");
            entity.Property(e => e.FStatus).HasColumnName("fStatus");
            entity.Property(e => e.FStoreDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fStoreDescription");
            entity.Property(e => e.FStoreName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fStoreName");
            entity.Property(e => e.FUserId).HasColumnName("fUserId");

            entity.HasOne(d => d.FUser).WithMany(p => p.TApplies)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tApply_tUser");
        });

        modelBuilder.Entity<TAuditLog>(entity =>
        {
            entity.HasKey(e => e.FLogId).HasName("PK__tAuditLo__3CD1938B75982076");

            entity.ToTable("tAuditLog");

            entity.Property(e => e.FLogId).HasColumnName("fLogId");
            entity.Property(e => e.FAction)
                .HasMaxLength(50)
                .HasColumnName("fAction");
            entity.Property(e => e.FAdminUserId).HasColumnName("fAdminUserId");
            entity.Property(e => e.FExecutedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fExecutedAt");
            entity.Property(e => e.FReason).HasColumnName("fReason");
            entity.Property(e => e.FTargetRecipeId).HasColumnName("fTargetRecipeId");

            entity.HasOne(d => d.FAdminUser).WithMany(p => p.TAuditLogs)
                .HasForeignKey(d => d.FAdminUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLog_User");

            entity.HasOne(d => d.FTargetRecipe).WithMany(p => p.TAuditLogs)
                .HasForeignKey(d => d.FTargetRecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLog_Recipe");
        });

        modelBuilder.Entity<TBrand>(entity =>
        {
            entity.HasKey(e => e.FBrandId).HasName("PK_Brand");

            entity.ToTable("tBrand");

            entity.Property(e => e.FBrandId).HasColumnName("fBrandId");
            entity.Property(e => e.FBrandName)
                .HasMaxLength(50)
                .HasColumnName("fBrandName");
        });

        modelBuilder.Entity<TCoupon>(entity =>
        {
            entity.HasKey(e => e.FCouponId).HasName("PK_Coupon");

            entity.ToTable("tCoupon");

            entity.HasIndex(e => e.FCode, "UQ_Coupon_Code").IsUnique();

            entity.Property(e => e.FCouponId).HasColumnName("fCouponId");
            entity.Property(e => e.FCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fCode");
            entity.Property(e => e.FDiscountType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fDiscountType");
            entity.Property(e => e.FDiscountValue)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fDiscountValue");
            entity.Property(e => e.FEndDate).HasColumnName("fEndDate");
            entity.Property(e => e.FIsActive).HasColumnName("fIsActive");
            entity.Property(e => e.FMaxDiscountAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fMaxDiscountAmount");
            entity.Property(e => e.FMinPurchaseAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fMinPurchaseAmount");
            entity.Property(e => e.FName)
                .HasMaxLength(100)
                .HasColumnName("fName");
            entity.Property(e => e.FScopeType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fScopeType");
            entity.Property(e => e.FSellerId).HasColumnName("fSeller_Id");
            entity.Property(e => e.FStartDate).HasColumnName("fStartDate");

            entity.HasOne(d => d.FSeller).WithMany(p => p.TCoupons)
                .HasForeignKey(d => d.FSellerId)
                .HasConstraintName("FK_Coupon_Seller");
        });

        modelBuilder.Entity<TIngredient>(entity =>
        {
            entity.HasKey(e => e.FIngredientId).HasName("PK__tIngredi__3A47A04554E34ADB");

            entity.ToTable("tIngredient");

            entity.Property(e => e.FIngredientId).HasColumnName("fIngredientId");
            entity.Property(e => e.FCaloriesPerUnit)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fCaloriesPerUnit");
            entity.Property(e => e.FCategory)
                .HasMaxLength(20)
                .HasColumnName("fCategory");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .HasColumnName("fName");
            entity.Property(e => e.FStandardUnit)
                .HasMaxLength(10)
                .HasColumnName("fStandardUnit");
        });

        modelBuilder.Entity<TMapFavorite>(entity =>
        {
            entity.HasKey(e => e.FFavoriteId).HasName("PK__tMapFavo__BAA205373544AC73");

            entity.ToTable("tMapFavorite");

            entity.Property(e => e.FFavoriteId).HasColumnName("fFavoriteID");
            entity.Property(e => e.FCreatedTime)
                .HasDefaultValueSql("(getdate())", "DF_Favorite_CreatedTime")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedTime");
            entity.Property(e => e.FRestaurantId).HasColumnName("fRestaurantID");
            entity.Property(e => e.FUsersId).HasColumnName("fUsers_ID");

            entity.HasOne(d => d.FRestaurant).WithMany(p => p.TMapFavorites)
                .HasForeignKey(d => d.FRestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorite_Restaurant");

            entity.HasOne(d => d.FUsers).WithMany(p => p.TMapFavorites)
                .HasForeignKey(d => d.FUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorite_Users_");
        });

        modelBuilder.Entity<TMessageTable>(entity =>
        {
            entity.HasKey(e => e.FMessageId).HasName("PK_MessageTable");

            entity.ToTable("tMessageTable");

            entity.Property(e => e.FMessageId).HasColumnName("fMessageID");
            entity.Property(e => e.FLikes).HasColumnName("fLikes");
            entity.Property(e => e.FMessageContent).HasColumnName("fMessageContent");
            entity.Property(e => e.FMessageDate)
                .HasColumnType("datetime")
                .HasColumnName("fMessageDate");
            entity.Property(e => e.FMessageState)
                .HasDefaultValue((byte)1, "DF_MessageTable_fMessageState")
                .HasColumnName("fMessageState");
            entity.Property(e => e.FPostId).HasColumnName("fPostID");
            entity.Property(e => e.FReplyMessageId).HasColumnName("fReplyMessageID");
            entity.Property(e => e.FUserId).HasColumnName("fUser_Id");

            entity.HasOne(d => d.FPost).WithMany(p => p.TMessageTables)
                .HasForeignKey(d => d.FPostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageTable_PostTable");

            entity.HasOne(d => d.FUser).WithMany(p => p.TMessageTables)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MessageTable_User");
        });

        modelBuilder.Entity<TOrder>(entity =>
        {
            entity.HasKey(e => e.FOrderId).HasName("PK_Orders");

            entity.ToTable("tOrder");

            entity.HasIndex(e => e.FOrderNo, "UQ_Orders_OrderNo").IsUnique();

            entity.Property(e => e.FOrderId).HasColumnName("fOrderID");
            entity.Property(e => e.FCancellationStatus)
                .HasComment("取消狀態：0 無取消申請 / 1 待回覆 / 2 已取消 / 3 拒絕取消")
                .HasColumnName("fCancellationStatus");
            entity.Property(e => e.FIsShippingConfirmed)
                .HasComment("賣家是否已確認/列印出貨單（0 未確認 1 已確認/已列印）")
                .HasColumnName("fIsShippingConfirmed");
            entity.Property(e => e.FOrderDate).HasColumnName("fOrderDate");
            entity.Property(e => e.FOrderNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fOrderNo");
            entity.Property(e => e.FOrderStatus)
                .HasComment("訂單狀態：0 待處理 / 1 已成立 / 2 已完成 / 3 已取消")
                .HasColumnName("fOrderStatus");
            entity.Property(e => e.FPaymentStatus)
                .HasComment("付款狀態：0 待付款 / 1 已付款 / 2 待退款 / 3 已退款")
                .HasColumnName("fPaymentStatus");
            entity.Property(e => e.FProductDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fProductDiscount");
            entity.Property(e => e.FRecipientName)
                .HasMaxLength(50)
                .HasColumnName("fRecipientName");
            entity.Property(e => e.FRecipientPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fRecipientPhone");
            entity.Property(e => e.FReturnStatus)
                .HasComment("退貨狀態：0 無退貨 / 1 待處理 / 2 已處理")
                .HasColumnName("fReturnStatus");
            entity.Property(e => e.FSellerId).HasColumnName("fSeller_Id");
            entity.Property(e => e.FShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("fShippingAddress");
            entity.Property(e => e.FShippingDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fShippingDiscount");
            entity.Property(e => e.FShippingFee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fShippingFee");
            entity.Property(e => e.FShippingMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fShippingMethod");
            entity.Property(e => e.FShippingStatus)
                .HasComment("運送狀態：0 待出貨 / 1 運送中 / 2 已送達 / 3 運送失敗 / 4 退回包裹運送中 / 5 賣家已取回退件")
                .HasColumnName("fShippingStatus");
            entity.Property(e => e.FTotalAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fTotalAmount");
            entity.Property(e => e.FUsersId).HasColumnName("fUsers_Id");

            entity.HasOne(d => d.FSeller).WithMany(p => p.TOrders)
                .HasForeignKey(d => d.FSellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Seller");

            entity.HasOne(d => d.FUsers).WithMany(p => p.TOrders)
                .HasForeignKey(d => d.FUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<TOrderDetail>(entity =>
        {
            entity.HasKey(e => e.FOrderDetailsId).HasName("PK_OrderDetails");

            entity.ToTable("tOrderDetail");

            entity.Property(e => e.FOrderDetailsId).HasColumnName("fOrderDetailsID");
            entity.Property(e => e.FOrderId).HasColumnName("fOrderID");
            entity.Property(e => e.FProductId).HasColumnName("fProductID");
            entity.Property(e => e.FQuantity).HasColumnName("fQuantity");
            entity.Property(e => e.FUnitPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fUnitPrice");

            entity.HasOne(d => d.FOrder).WithMany(p => p.TOrderDetails)
                .HasForeignKey(d => d.FOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.FProduct).WithMany(p => p.TOrderDetails)
                .HasForeignKey(d => d.FProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<TOrderDiscount>(entity =>
        {
            entity.HasKey(e => e.FOrderDiscountId).HasName("PK_OrderDiscounts");

            entity.ToTable("tOrderDiscount");

            entity.Property(e => e.FOrderDiscountId).HasColumnName("fOrderDiscountId");
            entity.Property(e => e.FAppliedAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fAppliedAmount");
            entity.Property(e => e.FCouponId).HasColumnName("fCouponId");
            entity.Property(e => e.FDiscountName)
                .HasMaxLength(100)
                .HasColumnName("fDiscountName");
            entity.Property(e => e.FDiscountScope)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fDiscountScope");
            entity.Property(e => e.FDiscountType)
                .HasMaxLength(20)
                .HasColumnName("fDiscountType");
            entity.Property(e => e.FOrderId).HasColumnName("fOrderID");

            entity.HasOne(d => d.FCoupon).WithMany(p => p.TOrderDiscounts)
                .HasForeignKey(d => d.FCouponId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDiscounts_Coupons");

            entity.HasOne(d => d.FOrder).WithMany(p => p.TOrderDiscounts)
                .HasForeignKey(d => d.FOrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDiscounts_Orders");
        });

        modelBuilder.Entity<TPostTable>(entity =>
        {
            entity.HasKey(e => e.FPostId).HasName("PK_PostTable");

            entity.ToTable("tPostTable");

            entity.Property(e => e.FPostId).HasColumnName("fPostID");
            entity.Property(e => e.FLikes).HasColumnName("fLikes");
            entity.Property(e => e.FPostContent).HasColumnName("fPostContent");
            entity.Property(e => e.FPostDate)
                .HasColumnType("datetime")
                .HasColumnName("fPostDate");
            entity.Property(e => e.FPostState)
                .HasDefaultValue((byte)1, "DF_PostTable_fPostState")
                .HasColumnName("fPostState");
            entity.Property(e => e.FTitle)
                .HasMaxLength(50)
                .HasColumnName("fTitle");
            entity.Property(e => e.FUserId).HasColumnName("fUser_Id");
            entity.Property(e => e.FViews).HasColumnName("fViews");

            entity.HasOne(d => d.FUser).WithMany(p => p.TPostTables)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PostTable_User");
        });

        modelBuilder.Entity<TProduct>(entity =>
        {
            entity.HasKey(e => e.FProductId).HasName("PK_Products");

            entity.ToTable("tProduct");

            entity.HasIndex(e => e.FProductNo, "UQ_Products_ProductNo").IsUnique();

            entity.Property(e => e.FProductId).HasColumnName("fProductID");
            entity.Property(e => e.FAttributesJson).HasColumnName("fAttributesJson");
            entity.Property(e => e.FBrandId).HasColumnName("fBrandId");
            entity.Property(e => e.FDescription).HasColumnName("fDescription");
            entity.Property(e => e.FExpirationDate).HasColumnName("fExpirationDate");
            entity.Property(e => e.FManufacturingDate).HasColumnName("fManufacturingDate");
            entity.Property(e => e.FPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fPrice");
            entity.Property(e => e.FProductDate).HasColumnName("fProductDate");
            entity.Property(e => e.FProductNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fProductNo");
            entity.Property(e => e.FProductStatus)
                .HasComment("商品狀態：0 審核中 / 1 架上商品 / 2 已售完 / 3 未上架 / 4 已違規")
                .HasColumnName("fProductStatus");
            entity.Property(e => e.FProductname)
                .HasMaxLength(100)
                .HasColumnName("fProductname");
            entity.Property(e => e.FProductsCategoryId).HasColumnName("fProductsCategoryID");
            entity.Property(e => e.FReportCount).HasColumnName("fReportCount");
            entity.Property(e => e.FSellerId).HasColumnName("fSeller_Id");
            entity.Property(e => e.FStock).HasColumnName("fStock");

            entity.HasOne(d => d.FBrand).WithMany(p => p.TProducts)
                .HasForeignKey(d => d.FBrandId)
                .HasConstraintName("FK_Products_Brands");

            entity.HasOne(d => d.FProductsCategory).WithMany(p => p.TProducts)
                .HasForeignKey(d => d.FProductsCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductsCategories");

            entity.HasOne(d => d.FSeller).WithMany(p => p.TProducts)
                .HasForeignKey(d => d.FSellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Seller");
        });

        modelBuilder.Entity<TProductFavorite>(entity =>
        {
            entity.HasKey(e => e.FFavoriteId).HasName("PK_Favorites");

            entity.ToTable("t_Product_Favorite");

            entity.HasIndex(e => new { e.FUsersId, e.FProductId }, "UQ_Favorites_User_Product").IsUnique();

            entity.Property(e => e.FFavoriteId).HasColumnName("fFavoriteID");
            entity.Property(e => e.FCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedDate");
            entity.Property(e => e.FProductId).HasColumnName("fProductID");
            entity.Property(e => e.FUsersId).HasColumnName("fUsers_Id");

            entity.HasOne(d => d.FProduct).WithMany(p => p.TProductFavorites)
                .HasForeignKey(d => d.FProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Favorites_Products");

            entity.HasOne(d => d.FUsers).WithMany(p => p.TProductFavorites)
                .HasForeignKey(d => d.FUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductFavorite_User");
        });

        modelBuilder.Entity<TProductImage>(entity =>
        {
            entity.HasKey(e => e.FProductImageId).HasName("PK_ProductImage");

            entity.ToTable("tProductImage");

            entity.Property(e => e.FProductImageId).HasColumnName("fProductImageID");
            entity.Property(e => e.FCreatedDate).HasColumnName("fCreatedDate");
            entity.Property(e => e.FImageUrl)
                .HasMaxLength(255)
                .HasColumnName("fImageUrl");
            entity.Property(e => e.FProductId).HasColumnName("fProductID");
            entity.Property(e => e.FSortOrder).HasColumnName("fSortOrder");

            entity.HasOne(d => d.FProduct).WithMany(p => p.TProductImages)
                .HasForeignKey(d => d.FProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductImage_Products");
        });

        modelBuilder.Entity<TProductReview>(entity =>
        {
            entity.HasKey(e => e.FReviewId).HasName("PK_ProductReviews");

            entity.ToTable("tProductReview");

            entity.HasIndex(e => e.FOrderDetailsId, "UQ_ProductReviews_OrderDetailsID").IsUnique();

            entity.Property(e => e.FReviewId).HasColumnName("fReviewID");
            entity.Property(e => e.FComment).HasColumnName("fComment");
            entity.Property(e => e.FCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedDate");
            entity.Property(e => e.FOrderDetailsId).HasColumnName("fOrderDetailsID");
            entity.Property(e => e.FProductId).HasColumnName("fProductID");
            entity.Property(e => e.FRating).HasColumnName("fRating");
            entity.Property(e => e.FUsersId).HasColumnName("fUsers_Id");

            entity.HasOne(d => d.FOrderDetails).WithOne(p => p.TProductReview)
                .HasForeignKey<TProductReview>(d => d.FOrderDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReviews_OrderDetails");

            entity.HasOne(d => d.FProduct).WithMany(p => p.TProductReviews)
                .HasForeignKey(d => d.FProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReviews_Products");

            entity.HasOne(d => d.FUsers).WithMany(p => p.TProductReviews)
                .HasForeignKey(d => d.FUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductReview_User");
        });

        modelBuilder.Entity<TProductsCategory>(entity =>
        {
            entity.HasKey(e => e.FCategoryId).HasName("PK_ProductsCategory");

            entity.ToTable("tProductsCategory");

            entity.Property(e => e.FCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("fCategoryID");
            entity.Property(e => e.FCategoriesName)
                .HasMaxLength(50)
                .HasColumnName("fCategoriesName");
            entity.Property(e => e.FParentCategoryId).HasColumnName("fParentCategoryId");

            entity.HasOne(d => d.FParentCategory).WithMany(p => p.InverseFParentCategory)
                .HasForeignKey(d => d.FParentCategoryId)
                .HasConstraintName("FK_ProductsCategory_ProductsCategory");
        });

        modelBuilder.Entity<TRecipe>(entity =>
        {
            entity.HasKey(e => e.FRecipeId).HasName("PK__tRecipe__EF3B24C700A1C89D");

            entity.ToTable("tRecipe");

            entity.Property(e => e.FRecipeId).HasColumnName("fRecipeId");
            entity.Property(e => e.FAuthorUserId).HasColumnName("fAuthorUserId");
            entity.Property(e => e.FCoverImageUrl)
                .HasMaxLength(500)
                .HasColumnName("fCoverImageUrl");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FDefaultServings)
                .HasDefaultValue(2)
                .HasColumnName("fDefaultServings");
            entity.Property(e => e.FDescription).HasColumnName("fDescription");
            entity.Property(e => e.FIsAiGenerated).HasColumnName("fIsAiGenerated");
            entity.Property(e => e.FStatus)
                .HasDefaultValue(1)
                .HasColumnName("fStatus");
            entity.Property(e => e.FTitle)
                .HasMaxLength(100)
                .HasColumnName("fTitle");
            entity.Property(e => e.FTotalCookingMinutes).HasColumnName("fTotalCookingMinutes");
            entity.Property(e => e.FUpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fUpdatedAt");
            entity.Property(e => e.FViewCount).HasColumnName("fViewCount");

            entity.HasOne(d => d.FAuthorUser).WithMany(p => p.TRecipes)
                .HasForeignKey(d => d.FAuthorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recipe_User");

            entity.HasMany(d => d.FTags).WithMany(p => p.FRecipes)
                .UsingEntity<Dictionary<string, object>>(
                    "TRecipeTag",
                    r => r.HasOne<TTag>().WithMany()
                        .HasForeignKey("FTagId")
                        .HasConstraintName("FK_RecipeTags_Tags"),
                    l => l.HasOne<TRecipe>().WithMany()
                        .HasForeignKey("FRecipeId")
                        .HasConstraintName("FK_RecipeTags_Recipes"),
                    j =>
                    {
                        j.HasKey("FRecipeId", "FTagId").HasName("PK_RecipeTags");
                        j.ToTable("tRecipeTag");
                        j.IndexerProperty<int>("FRecipeId").HasColumnName("fRecipeId");
                        j.IndexerProperty<int>("FTagId").HasColumnName("fTagId");
                    });
        });

        modelBuilder.Entity<TRecipeFavorite>(entity =>
        {
            entity.HasKey(e => new { e.FUserId, e.FRecipeId }).HasName("PK_RecipeFavorites");

            entity.ToTable("tRecipeFavorite");

            entity.Property(e => e.FUserId).HasColumnName("fUserId");
            entity.Property(e => e.FRecipeId).HasColumnName("fRecipeId");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedAt");

            entity.HasOne(d => d.FRecipe).WithMany(p => p.TRecipeFavorites)
                .HasForeignKey(d => d.FRecipeId)
                .HasConstraintName("FK_RecipeFavorites_Recipes");

            entity.HasOne(d => d.FUser).WithMany(p => p.TRecipeFavorites)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeFavorite_User");
        });

        modelBuilder.Entity<TRecipeIngredient>(entity =>
        {
            entity.HasKey(e => new { e.FRecipeId, e.FIngredientId }).HasName("PK_RecipeIngredients");

            entity.ToTable("tRecipeIngredient");

            entity.Property(e => e.FRecipeId).HasColumnName("fRecipeId");
            entity.Property(e => e.FIngredientId).HasColumnName("fIngredientId");
            entity.Property(e => e.FRequiredQuantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fRequiredQuantity");
            entity.Property(e => e.FUnit)
                .HasMaxLength(10)
                .HasColumnName("fUnit");

            entity.HasOne(d => d.FIngredient).WithMany(p => p.TRecipeIngredients)
                .HasForeignKey(d => d.FIngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_Ingredients");

            entity.HasOne(d => d.FRecipe).WithMany(p => p.TRecipeIngredients)
                .HasForeignKey(d => d.FRecipeId)
                .HasConstraintName("FK_RecipeIngredients_Recipes");
        });

        modelBuilder.Entity<TRecipeLike>(entity =>
        {
            entity.HasKey(e => new { e.FUserId, e.FRecipeId }).HasName("PK_RecipeLikes");

            entity.ToTable("tRecipeLike");

            entity.Property(e => e.FUserId).HasColumnName("fUserId");
            entity.Property(e => e.FRecipeId).HasColumnName("fRecipeId");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedAt");

            entity.HasOne(d => d.FRecipe).WithMany(p => p.TRecipeLikes)
                .HasForeignKey(d => d.FRecipeId)
                .HasConstraintName("FK_RecipeLikes_Recipes");

            entity.HasOne(d => d.FUser).WithMany(p => p.TRecipeLikes)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeLike_User");
        });

        modelBuilder.Entity<TRecipeRecreation>(entity =>
        {
            entity.HasKey(e => e.FRecreationId).HasName("PK__tRecipeR__5F32237EC6D73112");

            entity.ToTable("tRecipeRecreation");

            entity.Property(e => e.FRecreationId).HasColumnName("fRecreationId");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedAt");
            entity.Property(e => e.FNotes).HasColumnName("fNotes");
            entity.Property(e => e.FRecipeId).HasColumnName("fRecipeId");
            entity.Property(e => e.FRecreationImageUrl)
                .HasMaxLength(500)
                .HasColumnName("fRecreationImageUrl");
            entity.Property(e => e.FServingsCooked)
                .HasDefaultValue(1)
                .HasColumnName("fServingsCooked");
            entity.Property(e => e.FUserId).HasColumnName("fUserId");

            entity.HasOne(d => d.FRecipe).WithMany(p => p.TRecipeRecreations)
                .HasForeignKey(d => d.FRecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeRecreations_Recipes");

            entity.HasOne(d => d.FUser).WithMany(p => p.TRecipeRecreations)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeRecreation_User");
        });

        modelBuilder.Entity<TRecipeStep>(entity =>
        {
            entity.HasKey(e => e.FStepId).HasName("PK__tRecipeS__D4B885FFF71D234F");

            entity.ToTable("tRecipeStep");

            entity.Property(e => e.FStepId).HasColumnName("fStepId");
            entity.Property(e => e.FImageUrl)
                .HasMaxLength(500)
                .HasColumnName("fImageUrl");
            entity.Property(e => e.FInstruction).HasColumnName("fInstruction");
            entity.Property(e => e.FRecipeId).HasColumnName("fRecipeId");
            entity.Property(e => e.FStepNumber).HasColumnName("fStepNumber");
            entity.Property(e => e.FTimerSeconds).HasColumnName("fTimerSeconds");

            entity.HasOne(d => d.FRecipe).WithMany(p => p.TRecipeSteps)
                .HasForeignKey(d => d.FRecipeId)
                .HasConstraintName("FK_RecipeSteps_Recipes");
        });

        modelBuilder.Entity<TRecommendation>(entity =>
        {
            entity.HasKey(e => e.FRecommendationId).HasName("PK__tRecomme__A41CD6C95F3659E0");

            entity.ToTable("tRecommendation");

            entity.Property(e => e.FRecommendationId).HasColumnName("fRecommendationID");
            entity.Property(e => e.FContent).HasColumnName("fContent");
            entity.Property(e => e.FEndDate).HasColumnName("fEndDate");
            entity.Property(e => e.FIsActive)
                .HasDefaultValue(true, "DF_Recommendation_IsActive")
                .HasColumnName("fIsActive");
            entity.Property(e => e.FPriority)
                .HasDefaultValue(1, "DF_Recommendation_Priority")
                .HasColumnName("fPriority");
            entity.Property(e => e.FRestaurantId).HasColumnName("fRestaurantID");
            entity.Property(e => e.FStartDate).HasColumnName("fStartDate");
            entity.Property(e => e.FTitle)
                .HasMaxLength(100)
                .HasColumnName("fTitle");

            entity.HasOne(d => d.FRestaurant).WithMany(p => p.TRecommendations)
                .HasForeignKey(d => d.FRestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recommendation_Restaurant");
        });

        modelBuilder.Entity<TRestaurant>(entity =>
        {
            entity.HasKey(e => e.FRestaurantId).HasName("PK__tRestaur__B18244B3A32FA8C5");

            entity.ToTable("tRestaurant");

            entity.HasIndex(e => e.FGooglePlaceId, "UQ_Restaurant_GooglePlaceID").IsUnique();

            entity.Property(e => e.FRestaurantId).HasColumnName("fRestaurantID");
            entity.Property(e => e.FAddress)
                .HasMaxLength(300)
                .HasColumnName("fAddress");
            entity.Property(e => e.FBusinessStatus)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Operational", "DF_Restaurant_BusinessStatus")
                .HasColumnName("fBusinessStatus");
            entity.Property(e => e.FCategoryId).HasColumnName("fCategoryID");
            entity.Property(e => e.FCreatedTime)
                .HasDefaultValueSql("(getdate())", "DF_Restaurant_CreatedTime")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedTime");
            entity.Property(e => e.FDescription).HasColumnName("fDescription");
            entity.Property(e => e.FGooglePlaceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fGooglePlaceID");
            entity.Property(e => e.FGoogleRating)
                .HasColumnType("decimal(2, 1)")
                .HasColumnName("fGoogleRating");
            entity.Property(e => e.FGoogleReviewCount).HasColumnName("fGoogleReviewCount");
            entity.Property(e => e.FIsRecommend).HasColumnName("fIsRecommend");
            entity.Property(e => e.FLatitude)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("fLatitude");
            entity.Property(e => e.FLongitude)
                .HasColumnType("decimal(10, 7)")
                .HasColumnName("fLongitude");
            entity.Property(e => e.FName)
                .HasMaxLength(100)
                .HasColumnName("fName");
            entity.Property(e => e.FPhone)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fPhone");
            entity.Property(e => e.FUpdatedTime)
                .HasColumnType("datetime")
                .HasColumnName("fUpdatedTime");

            entity.HasOne(d => d.FCategory).WithMany(p => p.TRestaurants)
                .HasForeignKey(d => d.FCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_Category");
        });

        modelBuilder.Entity<TRestaurantCategory>(entity =>
        {
            entity.HasKey(e => e.FCategoryId).HasName("PK__tRestaur__53E607D33243056A");

            entity.ToTable("tRestaurantCategory");

            entity.Property(e => e.FCategoryId).HasColumnName("fCategoryID");
            entity.Property(e => e.FCategoryName)
                .HasMaxLength(50)
                .HasColumnName("fCategoryName");
            entity.Property(e => e.FCreatedTime)
                .HasDefaultValueSql("(getdate())", "DF_RestaurantCategory_CreatedTime")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedTime");
            entity.Property(e => e.FDescription)
                .HasMaxLength(255)
                .HasColumnName("fDescription");
        });

        modelBuilder.Entity<TRestaurantImage>(entity =>
        {
            entity.HasKey(e => e.FImageId).HasName("PK__tRestaur__39CAEC2A27FDBB83");

            entity.ToTable("tRestaurantImage");

            entity.Property(e => e.FImageId).HasColumnName("fImageID");
            entity.Property(e => e.FImageType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Google", "DF_RestaurantImage_ImageType")
                .HasColumnName("fImageType");
            entity.Property(e => e.FImageUrl)
                .HasMaxLength(500)
                .HasColumnName("fImageUrl");
            entity.Property(e => e.FRestaurantId).HasColumnName("fRestaurantID");

            entity.HasOne(d => d.FRestaurant).WithMany(p => p.TRestaurantImages)
                .HasForeignKey(d => d.FRestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RestaurantImage_Restaurant");
        });

        modelBuilder.Entity<TSeller>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tSeller__D9F8227CC2CEEF95");

            entity.ToTable("tSeller");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FApplyDate)
                .HasColumnType("datetime")
                .HasColumnName("fApplyDate");
            entity.Property(e => e.FDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("fDescription");
            entity.Property(e => e.FName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fName");
            entity.Property(e => e.FStatus).HasColumnName("fStatus");
            entity.Property(e => e.FUserId).HasColumnName("fUserId");

            entity.HasOne(d => d.FStatusNavigation).WithMany(p => p.TSellers)
                .HasForeignKey(d => d.FStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSeller_tStatus");

            entity.HasOne(d => d.FUser).WithMany(p => p.TSellers)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tSeller_tUser");
        });

        modelBuilder.Entity<TShoppingCart>(entity =>
        {
            entity.HasKey(e => e.FCartItemId).HasName("PK_ShoppingCarts");

            entity.ToTable("tShoppingCart");

            entity.Property(e => e.FCartItemId).HasColumnName("fCartItemId");
            entity.Property(e => e.FCreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedDate");
            entity.Property(e => e.FProductId).HasColumnName("fProductId");
            entity.Property(e => e.FQuantity).HasColumnName("fQuantity");
            entity.Property(e => e.FSellerId).HasColumnName("fSeller_Id");
            entity.Property(e => e.FUsersId).HasColumnName("fUsers_Id");

            entity.HasOne(d => d.FProduct).WithMany(p => p.TShoppingCarts)
                .HasForeignKey(d => d.FProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCarts_Products");

            entity.HasOne(d => d.FSeller).WithMany(p => p.TShoppingCarts)
                .HasForeignKey(d => d.FSellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCart_Seller");

            entity.HasOne(d => d.FUsers).WithMany(p => p.TShoppingCarts)
                .HasForeignKey(d => d.FUsersId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShoppingCart_User");
        });

        modelBuilder.Entity<TStatus>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tStatus__D9F8227CCB85E5C0");

            entity.ToTable("tStatus");

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fName");
        });

        modelBuilder.Entity<TTag>(entity =>
        {
            entity.HasKey(e => e.FTagId).HasName("PK__tTag__036309757A066FA3");

            entity.ToTable("tTag");

            entity.Property(e => e.FTagId).HasColumnName("fTagId");
            entity.Property(e => e.FCategory)
                .HasMaxLength(20)
                .HasColumnName("fCategory");
            entity.Property(e => e.FTagName)
                .HasMaxLength(30)
                .HasColumnName("fTagName");
        });

        modelBuilder.Entity<TTrip>(entity =>
        {
            entity.HasKey(e => e.FTripId).HasName("PK__tTrip__704F7E1DFE254E51");

            entity.ToTable("tTrip");

            entity.Property(e => e.FTripId).HasColumnName("fTripID");
            entity.Property(e => e.FCreatedTime)
                .HasDefaultValueSql("(getdate())", "DF_Trip_CreatedTime")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedTime");
            entity.Property(e => e.FDescription)
                .HasMaxLength(500)
                .HasColumnName("fDescription");
            entity.Property(e => e.FStartTime).HasColumnName("fStartTime");
            entity.Property(e => e.FStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("Draft", "DF_Trip_Status")
                .HasColumnName("fStatus");
            entity.Property(e => e.FTripDate)
                .HasColumnType("datetime")
                .HasColumnName("fTripDate");
            entity.Property(e => e.FTripName)
                .HasMaxLength(100)
                .HasColumnName("fTripName");
            entity.Property(e => e.FUpdatedTime)
                .HasColumnType("datetime")
                .HasColumnName("fUpdatedTime");
            entity.Property(e => e.FUsersId).HasColumnName("fUsers_ID");

            entity.HasOne(d => d.FUsers).WithMany(p => p.TTrips)
                .HasForeignKey(d => d.FUsersId)
                .HasConstraintName("FK_Trip_Users_");
        });

        modelBuilder.Entity<TTripRestaurant>(entity =>
        {
            entity.HasKey(e => e.FTripRestaurantId).HasName("PK__tTripRes__6D75C5210DB38984");

            entity.ToTable("tTripRestaurant");

            entity.HasIndex(e => new { e.FTripId, e.FSortOrder }, "UQ_TripRestaurant_SortOrder").IsUnique();

            entity.Property(e => e.FTripRestaurantId).HasColumnName("fTripRestaurantID");
            entity.Property(e => e.FCreatedTime)
                .HasDefaultValueSql("(getdate())", "DF_TripRestaurant_CreatedTime")
                .HasColumnType("datetime")
                .HasColumnName("fCreatedTime");
            entity.Property(e => e.FNote)
                .HasMaxLength(200)
                .HasColumnName("fNote");
            entity.Property(e => e.FRestaurantId).HasColumnName("fRestaurantID");
            entity.Property(e => e.FSortOrder).HasColumnName("fSortOrder");
            entity.Property(e => e.FStayMinutes).HasColumnName("fStayMinutes");
            entity.Property(e => e.FTripId).HasColumnName("fTripID");
            entity.Property(e => e.FVisitTime).HasColumnName("fVisitTime");

            entity.HasOne(d => d.FRestaurant).WithMany(p => p.TTripRestaurants)
                .HasForeignKey(d => d.FRestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TripRestaurant_Restaurant");

            entity.HasOne(d => d.FTrip).WithMany(p => p.TTripRestaurants)
                .HasForeignKey(d => d.FTripId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TripRestaurant_Trip");
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__tUser__D9F8227CA4B2B9CC");

            entity.ToTable("tUser");

            entity.HasIndex(e => e.FEmail, "UQ__tUser__E609A9E550B0079B").IsUnique();

            entity.Property(e => e.FId).HasColumnName("fId");
            entity.Property(e => e.FAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fAddress");
            entity.Property(e => e.FCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("fCreateDate");
            entity.Property(e => e.FEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fEmail");
            entity.Property(e => e.FGender).HasColumnName("fGender");
            entity.Property(e => e.FIdNum)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fId_num");
            entity.Property(e => e.FIsActive).HasColumnName("fIsActive");
            entity.Property(e => e.FLastLogin)
                .HasColumnType("datetime")
                .HasColumnName("fLastLogin");
            entity.Property(e => e.FNickname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fNickname");
            entity.Property(e => e.FPassword)
                .HasMaxLength(40)
                .HasColumnName("fPassword");
            entity.Property(e => e.FPhone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("fPhone");
            entity.Property(e => e.FProfileImg)
                .IsUnicode(false)
                .HasColumnName("fProfileImg");
            entity.Property(e => e.FUsername)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fUsername");
        });

        modelBuilder.Entity<TUserFollow>(entity =>
        {
            entity.HasKey(e => new { e.FFollowerId, e.FFolloweeId }).HasName("PK_UserFollows");

            entity.ToTable("tUserFollow");

            entity.Property(e => e.FFollowerId).HasColumnName("fFollowerId");
            entity.Property(e => e.FFolloweeId).HasColumnName("fFolloweeId");
            entity.Property(e => e.FCreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fCreatedAt");

            entity.HasOne(d => d.FFollowee).WithMany(p => p.TUserFollowFFollowees)
                .HasForeignKey(d => d.FFolloweeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFollow_User2");

            entity.HasOne(d => d.FFollower).WithMany(p => p.TUserFollowFFollowers)
                .HasForeignKey(d => d.FFollowerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFollow_User");
        });

        modelBuilder.Entity<TUserPantry>(entity =>
        {
            entity.HasKey(e => e.FPantryItemId).HasName("PK__tUserPan__762E20883F09334E");

            entity.ToTable("tUserPantry");

            entity.Property(e => e.FPantryItemId).HasColumnName("fPantryItemId");
            entity.Property(e => e.FExpiryDate).HasColumnName("fExpiryDate");
            entity.Property(e => e.FIngredientId).HasColumnName("fIngredientId");
            entity.Property(e => e.FStockQuantity)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("fStockQuantity");
            entity.Property(e => e.FUserId).HasColumnName("fUserId");

            entity.HasOne(d => d.FIngredient).WithMany(p => p.TUserPantries)
                .HasForeignKey(d => d.FIngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPantry_Ingredients");

            entity.HasOne(d => d.FUser).WithMany(p => p.TUserPantries)
                .HasForeignKey(d => d.FUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPantry_User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
