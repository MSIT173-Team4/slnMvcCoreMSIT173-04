using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjMvcCore第四組.Models {

    public partial class MidprjDbContext : DbContext
    {
        public MidprjDbContext()
        {
        }

        public MidprjDbContext(DbContextOptions<MidprjDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Coupon> Coupons { get; set; }

        public virtual DbSet<Favorite> Favorites { get; set; }

        public virtual DbSet<MapFavorite> MapFavorites { get; set; }

        public virtual DbSet<MessageTable> MessageTables { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; }

        public virtual DbSet<OrderDiscount> OrderDiscounts { get; set; }

        public virtual DbSet<PostTable> PostTables { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<ProductReview> ProductReviews { get; set; }

        public virtual DbSet<ProductsCategory> ProductsCategories { get; set; }

        public virtual DbSet<Recommendation> Recommendations { get; set; }

        public virtual DbSet<Restaurant> Restaurants { get; set; }

        public virtual DbSet<RestaurantCategory> RestaurantCategories { get; set; }

        public virtual DbSet<RestaurantImage> RestaurantImages { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public virtual DbSet<TApply> TApplies { get; set; }

        public virtual DbSet<TSeller> TSellers { get; set; }

        public virtual DbSet<TStatus> TStatuses { get; set; }

        public virtual DbSet<TUser> TUsers { get; set; }

        public virtual DbSet<Trip> Trips { get; set; }

        public virtual DbSet<TripRestaurant> TripRestaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=midprjDB;Integrated Security=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).ValueGeneratedNever();
                entity.Property(e => e.BrandName).HasMaxLength(50);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.ToTable("Coupon");

                entity.HasIndex(e => e.Code, "UQ_Coupon_Code").IsUnique();

                entity.Property(e => e.CouponId).ValueGeneratedNever();
                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DiscountType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MaxDiscountAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.MinPurchaseAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.ScopeType)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.SellerId).HasColumnName("Seller_Id");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasIndex(e => new { e.UsersId, e.ProductId }, "UQ_Favorites_User_Product").IsUnique();

                entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorites_Products");

                entity.HasOne(d => d.Users).WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorites_User");
            });

            modelBuilder.Entity<MapFavorite>(entity =>
            {
                entity.HasKey(e => e.FavoriteId).HasName("PK__Map_Favo__CE74FAF59DD582C1");

                entity.ToTable("Map_Favorite");

                entity.Property(e => e.FavoriteId).HasColumnName("FavoriteID");
                entity.Property(e => e.CreatedTime)
                    .HasDefaultValueSql("(getdate())", "DF_Favorite_CreatedTime")
                    .HasColumnType("datetime");
                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.HasOne(d => d.Restaurant).WithMany(p => p.MapFavorites)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorite_Restaurant");

                entity.HasOne(d => d.Users).WithMany(p => p.MapFavorites)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Favorite_Users_");
            });

            modelBuilder.Entity<MessageTable>(entity =>
            {
                entity.HasKey(e => e.FMessageId);

                entity.ToTable("MessageTable");

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
                entity.Property(e => e.FViews).HasColumnName("fViews");

                entity.HasOne(d => d.FPost).WithMany(p => p.MessageTables)
                    .HasForeignKey(d => d.FPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTable_MessageTable");

                entity.HasOne(d => d.FUser).WithMany(p => p.MessageTables)
                    .HasForeignKey(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MessageTable_User");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderNo, "UQ_Orders_OrderNo").IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.CancellationStatus).HasComment("取消狀態：0 無取消申請 / 1 待回覆 / 2 已取消 / 3 拒絕取消");
                entity.Property(e => e.IsShippingConfirmed).HasComment("賣家是否已確認/列印出貨單（0 未確認 1 已確認/已列印）");
                entity.Property(e => e.OrderNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.OrderStatus).HasComment("訂單狀態：0 待處理 / 1 已成立 / 2 已完成 / 3 已取消");
                entity.Property(e => e.PaymentStatus).HasComment("付款狀態：0 待付款 / 1 已付款 / 2 待退款 / 3 已退款");
                entity.Property(e => e.ProductDiscount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.RecipientName).HasMaxLength(50);
                entity.Property(e => e.RecipientPhone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ReturnStatus).HasComment("退貨狀態：0 無退貨 / 1 待處理 / 2 已處理");
                entity.Property(e => e.SellerId).HasColumnName("Seller_Id");
                entity.Property(e => e.ShippingAddress).HasMaxLength(255);
                entity.Property(e => e.ShippingDiscount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ShippingFee).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ShippingMethod)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ShippingStatus).HasComment("運送狀態：0 待出貨 / 1 運送中 / 2 已送達 / 3 運送失敗 / 4 退回包裹運送中 / 5 賣家已取回退件");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Seller).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Seller");

                entity.HasOne(d => d.Users).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_User");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");
                entity.Property(e => e.OrderId).HasColumnName("OrderID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Orders");

                entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetails_Products");
            });

            modelBuilder.Entity<OrderDiscount>(entity =>
            {
                entity.Property(e => e.OrderDiscountId).ValueGeneratedNever();
                entity.Property(e => e.AppliedAmount).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.DiscountName).HasMaxLength(100);
                entity.Property(e => e.DiscountScope)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.DiscountType).HasMaxLength(20);
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.HasOne(d => d.Coupon).WithMany(p => p.OrderDiscounts)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDiscounts_Coupons");

                entity.HasOne(d => d.Order).WithMany(p => p.OrderDiscounts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDiscounts_Orders");
            });

            modelBuilder.Entity<PostTable>(entity =>
            {
                entity.HasKey(e => e.FPostId);

                entity.ToTable("PostTable");

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

                entity.HasOne(d => d.FUser).WithMany(p => p.PostTables)
                    .HasForeignKey(d => d.FUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostTable_User");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductNo, "UQ_Products_ProductNo").IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.ProductNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ProductStatus).HasComment("商品狀態：0 審核中 / 1 架上商品 / 2 已售完 / 3 未上架 / 4 已違規");
                entity.Property(e => e.Productname).HasMaxLength(100);
                entity.Property(e => e.ProductsCategoryId).HasColumnName("ProductsCategoryID");
                entity.Property(e => e.SellerId).HasColumnName("Seller_Id");

                entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Products_Brands");

                entity.HasOne(d => d.ProductsCategory).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductsCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductsCategories");

                entity.HasOne(d => d.Seller).WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Sellers");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.ProductImageId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductImageID");
                entity.Property(e => e.ImageUrl).HasMaxLength(255);
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_Products");
            });

            modelBuilder.Entity<ProductReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.HasIndex(e => e.OrderDetailsId, "UQ_ProductReviews_OrderDetailsID").IsUnique();

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");
                entity.Property(e => e.ProductId).HasColumnName("ProductID");
                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.OrderDetails).WithOne(p => p.ProductReview)
                    .HasForeignKey<ProductReview>(d => d.OrderDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReviews_OrderDetails");

                entity.HasOne(d => d.Product).WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReviews_Products");

                entity.HasOne(d => d.Users).WithMany(p => p.ProductReviews)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductReviews_User");
            });

            modelBuilder.Entity<ProductsCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("CategoryID");
                entity.Property(e => e.CategoriesName).HasMaxLength(50);

                entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId)
                    .HasConstraintName("FK_ProductsCategories_ProductsCategories");
            });

            modelBuilder.Entity<Recommendation>(entity =>
            {
                entity.HasKey(e => e.RecommendationId).HasName("PK__Recommen__AA15BEC44D67B25C");

                entity.ToTable("Recommendation");

                entity.Property(e => e.RecommendationId).HasColumnName("RecommendationID");
                entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Recommendation_IsActive");
                entity.Property(e => e.Priority).HasDefaultValue(1, "DF_Recommendation_Priority");
                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Restaurant).WithMany(p => p.Recommendations)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recommendation_Restaurant");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.RestaurantId).HasName("PK__Restaura__87454CB53CFC6CA0");

                entity.ToTable("Restaurant");

                entity.HasIndex(e => e.GooglePlaceId, "UQ_Restaurant_GooglePlaceID").IsUnique();

                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
                entity.Property(e => e.Address).HasMaxLength(300);
                entity.Property(e => e.BusinessStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValue("Operational", "DF_Restaurant_BusinessStatus");
                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CreatedTime)
                    .HasDefaultValueSql("(getdate())", "DF_Restaurant_CreatedTime")
                    .HasColumnType("datetime");
                entity.Property(e => e.GooglePlaceId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GooglePlaceID");
                entity.Property(e => e.GoogleRating).HasColumnType("decimal(2, 1)");
                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 7)");
                entity.Property(e => e.Longitude).HasColumnType("decimal(10, 7)");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Phone)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.HasOne(d => d.Category).WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Restaurant_Category");
            });

            modelBuilder.Entity<RestaurantCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId).HasName("PK__Restaura__19093A2BCBE0BCB6");

                entity.ToTable("RestaurantCategory");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
                entity.Property(e => e.CategoryName).HasMaxLength(50);
                entity.Property(e => e.CreatedTime)
                    .HasDefaultValueSql("(getdate())", "DF_RestaurantCategory_CreatedTime")
                    .HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<RestaurantImage>(entity =>
            {
                entity.HasKey(e => e.ImageId).HasName("PK__Restaura__7516F4ECE7EDF5C3");

                entity.ToTable("RestaurantImage");

                entity.Property(e => e.ImageId).HasColumnName("ImageID");
                entity.Property(e => e.ImageType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasDefaultValue("Google", "DF_RestaurantImage_ImageType");
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");

                entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantImages)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantImage_Restaurant");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.HasKey(e => e.CartItemId);

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.SellerId).HasColumnName("Seller_Id");
                entity.Property(e => e.UsersId).HasColumnName("Users_Id");

                entity.HasOne(d => d.Product).WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCarts_Products");

                entity.HasOne(d => d.Seller).WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCarts_Seller");

                entity.HasOne(d => d.Users).WithMany(p => p.ShoppingCarts)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCarts_Users");
            });

            modelBuilder.Entity<TApply>(entity =>
            {
                entity.HasKey(e => e.FId).HasName("PK__tmp_ms_x__D9F8227CD834400B");

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

            modelBuilder.Entity<TSeller>(entity =>
            {
                entity.HasKey(e => e.FId).HasName("PK__tSeller__D9F8227C730AD6E4");

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

            modelBuilder.Entity<TStatus>(entity =>
            {
                entity.HasKey(e => e.FId).HasName("PK__tStatus__D9F8227C6A31E41E");

                entity.ToTable("tStatus");

                entity.Property(e => e.FId).HasColumnName("fId");
                entity.Property(e => e.FName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fName");
            });

            modelBuilder.Entity<TUser>(entity =>
            {
                entity.HasKey(e => e.FId).HasName("PK__tUser__D9F8227CD4656397");

                entity.ToTable("tUser");

                entity.HasIndex(e => e.FEmail, "UQ__tUser__E609A9E526DB020F").IsUnique();

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

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.HasKey(e => e.TripId).HasName("PK__Trip__51DC711E682DE126");

                entity.ToTable("Trip");

                entity.Property(e => e.TripId).HasColumnName("TripID");
                entity.Property(e => e.CreatedTime)
                    .HasDefaultValueSql("(getdate())", "DF_Trip_CreatedTime")
                    .HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValue("Draft", "DF_Trip_Status");
                entity.Property(e => e.TripName).HasMaxLength(100);
                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
                entity.Property(e => e.UsersId).HasColumnName("Users_ID");

                entity.HasOne(d => d.Users).WithMany(p => p.Trips)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Trip_Users_");
            });

            modelBuilder.Entity<TripRestaurant>(entity =>
            {
                entity.HasKey(e => e.TripRestaurantId).HasName("PK__TripRest__2FBCDBA8DB8C0FAE");

                entity.ToTable("TripRestaurant");

                entity.HasIndex(e => new { e.TripId, e.SortOrder }, "UQ_TripRestaurant_SortOrder").IsUnique();

                entity.Property(e => e.TripRestaurantId).HasColumnName("TripRestaurantID");
                entity.Property(e => e.CreatedTime)
                    .HasDefaultValueSql("(getdate())", "DF_TripRestaurant_CreatedTime")
                    .HasColumnType("datetime");
                entity.Property(e => e.Note).HasMaxLength(200);
                entity.Property(e => e.RestaurantId).HasColumnName("RestaurantID");
                entity.Property(e => e.TripId).HasColumnName("TripID");

                entity.HasOne(d => d.Restaurant).WithMany(p => p.TripRestaurants)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripRestaurant_Restaurant");

                entity.HasOne(d => d.Trip).WithMany(p => p.TripRestaurants)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TripRestaurant_Trip");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}