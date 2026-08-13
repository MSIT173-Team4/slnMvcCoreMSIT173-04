using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class Product
    {
        public int ProductId { get; set; }

        public string ProductNo { get; set; } = null!;

        public int SellerId { get; set; }

        public int ProductsCategoryId { get; set; }

        public string Productname { get; set; } = null!;

        public string? Description { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int? BrandId { get; set; }

        public DateOnly ManufacturingDate { get; set; }

        public DateOnly? ExpirationDate { get; set; }

        public DateTime ProductDate { get; set; }

        public string? AttributesJson { get; set; }

        /// <summary>
        /// 商品狀態：0 審核中 / 1 架上商品 / 2 已售完 / 3 未上架 / 4 已違規
        /// </summary>
        public byte? ProductStatus { get; set; }

        public int ReportCount { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

        public virtual ProductsCategory ProductsCategory { get; set; } = null!;

        public virtual TSeller Seller { get; set; } = null!;

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    }
}