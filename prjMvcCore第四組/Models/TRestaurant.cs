using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCore第四組.Models
{

    public partial class TRestaurant
    {
        [Key]
        public long FRestaurantId { get; set; }

        public string FGooglePlaceId { get; set; } = null!;

        public long FCategoryId { get; set; }

        [DisplayName("商家名稱")]
        public string FName { get; set; } = null!;
        [DisplayName("地址")]
        public string FAddress { get; set; } = null!;

        public decimal FLatitude { get; set; }

        public decimal FLongitude { get; set; }
        [DisplayName("電話")]
        public string? FPhone { get; set; }
        [DisplayName("店家描述")]
        public string? FDescription { get; set; }

        public decimal? FGoogleRating { get; set; }

        public int FGoogleReviewCount { get; set; }
        [DisplayName("營業狀況")]
        public string FBusinessStatus { get; set; } = null!;
        [DisplayName("是否推薦")]
        public bool FIsRecommend { get; set; }

        public DateTime FCreatedTime { get; set; }

        public DateTime? FUpdatedTime { get; set; }

        [DisplayName("商家種類")]
        public virtual TRestaurantCategory FCategory { get; set; } = null!;

        public virtual ICollection<TMapFavorite> TMapFavorites { get; set; } = new List<TMapFavorite>();

        public virtual ICollection<TRecommendation> TRecommendations { get; set; } = new List<TRecommendation>();

        public virtual ICollection<TRestaurantImage> TRestaurantImages { get; set; } = new List<TRestaurantImage>();

        public virtual ICollection<TTripRestaurant> TTripRestaurants { get; set; } = new List<TTripRestaurant>();
    }
}