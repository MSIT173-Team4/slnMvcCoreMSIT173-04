using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TProduct
    {
        public int FProductId { get; set; }

        public string FProductNo { get; set; } = null!;

        public int FSellerId { get; set; }

        public int FProductsCategoryId { get; set; }

        public string FProductname { get; set; } = null!;

        public string? FDescription { get; set; }

        public int FStock { get; set; }

        public decimal FPrice { get; set; }

        public int? FBrandId { get; set; }

        public DateOnly FManufacturingDate { get; set; }

        public DateOnly? FExpirationDate { get; set; }

        public DateTime FProductDate { get; set; }

        public string? FAttributesJson { get; set; }

        /// <summary>
        /// 商品狀態：0 審核中 / 1 架上商品 / 2 已售完 / 3 未上架 / 4 已違規
        /// </summary>
        public byte? FProductStatus { get; set; }

        public int FReportCount { get; set; }

        public virtual TBrand? FBrand { get; set; }

        public virtual TProductsCategory FProductsCategory { get; set; } = null!;

        public virtual ICollection<TOrderDetail> TOrderDetails { get; set; } = new List<TOrderDetail>();

        public virtual ICollection<TProductFavorite> TProductFavorites { get; set; } = new List<TProductFavorite>();

        public virtual ICollection<TProductImage> TProductImages { get; set; } = new List<TProductImage>();

        public virtual ICollection<TProductReview> TProductReviews { get; set; } = new List<TProductReview>();

        public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; } = new List<TShoppingCart>();
    }
}