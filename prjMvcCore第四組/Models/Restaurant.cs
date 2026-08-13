using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class Restaurant
    {
        public long RestaurantId { get; set; }

        public string GooglePlaceId { get; set; } = null!;

        public long CategoryId { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string? Phone { get; set; }

        public string? Description { get; set; }

        public decimal? GoogleRating { get; set; }

        public int GoogleReviewCount { get; set; }

        public string BusinessStatus { get; set; } = null!;

        public bool IsRecommend { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public virtual RestaurantCategory Category { get; set; } = null!;

        public virtual ICollection<MapFavorite> MapFavorites { get; set; } = new List<MapFavorite>();

        public virtual ICollection<Recommendation> Recommendations { get; set; } = new List<Recommendation>();

        public virtual ICollection<RestaurantImage> RestaurantImages { get; set; } = new List<RestaurantImage>();

        public virtual ICollection<TripRestaurant> TripRestaurants { get; set; } = new List<TripRestaurant>();
    }
}