using Microsoft.AspNetCore.Mvc.Rendering;
using prjMvcCore第四組.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCore第四組.Models
{
    public class CRestaurantWrap
    {

        private TRestaurant _restaurant;

        public TRestaurant Restaurant
        {
            get { return _restaurant; }
            set { _restaurant = value; }
        }
        public CRestaurantWrap()
        {
            _restaurant = new TRestaurant();
        }
        [Key]
        public long FRestaurantId
        {
            get { return _restaurant.FRestaurantId; }
            set { _restaurant.FRestaurantId = value; }
        }

        public string FGooglePlaceId
        {
            get;
            set;
        }

        public long FCategoryId
        {
            get { return _restaurant.FCategoryId; }
            set { _restaurant.FCategoryId = value; }
        }

        [DisplayName("商家名稱")]
        public string FName
        {
            get { return _restaurant.FName; }
            set { _restaurant.FName = value; }
        }
        [DisplayName("地址")]
        public string FAddress
        {
            get { return _restaurant.FAddress; }
            set { _restaurant.FAddress = value; }
        }

        public decimal FLatitude
        {
            get { return _restaurant.FLatitude; }
            set { _restaurant.FLatitude = value; }
        }

        public decimal FLongitude
        {
            get { return _restaurant.FLongitude; }
            set { _restaurant.FLongitude = value; }
        }
        [DisplayName("電話")]
        public string? FPhone
        {
            get { return _restaurant.FPhone; }
            set { _restaurant.FPhone = value; }
        }
        [DisplayName("店家描述")]
        public string? FDescription
        {
            get { return _restaurant.FDescription; }
            set { _restaurant.FDescription = value; }
        }

        public decimal? FGoogleRating
        {
            get { return _restaurant.FGoogleRating; }
            set { _restaurant.FGoogleRating = value; }
        }

        public int FGoogleReviewCount
        {
            get { return _restaurant.FGoogleReviewCount; }
            set { _restaurant.FGoogleReviewCount = value; }
        }
        [DisplayName("營業狀況")]
        public string FBusinessStatus
        {
            get { return _restaurant.FBusinessStatus; }
            set { _restaurant.FBusinessStatus = value; }
        }
        [DisplayName("是否推薦")]
        public bool FIsRecommend
        {
            get { return _restaurant.FIsRecommend; }
            set { _restaurant.FIsRecommend = value; }
        }


        [DisplayName("建立時間")]
        public DateTime FCreatedTime
        {
            get { return _restaurant.FCreatedTime; }
            set { _restaurant.FCreatedTime = value; }
        }

        public DateTime? FUpdatedTime
        {
            get { return _restaurant.FUpdatedTime; }
            set { _restaurant.FUpdatedTime = value; }
        }

        [DisplayName("商家種類")]
        public virtual TRestaurantCategory FCategory
        {
            get { return _restaurant.FCategory; }
            set { _restaurant.FCategory = value; }
        }

        public virtual ICollection<TMapFavorite> TMapFavorites { get; set; }
         = new List<TMapFavorite>();

        public virtual ICollection<TRecommendation> TRecommendations { get; set; } = new List<TRecommendation>();

        public virtual ICollection<TRestaurantImage> TRestaurantImages { get; set; } = new List<TRestaurantImage>();

        public virtual ICollection<TTripRestaurant> TTripRestaurants { get; set; } = new List<TTripRestaurant>();

        public List<SelectListItem>? CategoryOptions { get; set; }


    }
}


