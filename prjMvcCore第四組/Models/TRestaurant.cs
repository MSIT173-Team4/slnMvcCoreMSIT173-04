using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TRestaurant
{
    public long FRestaurantId { get; set; }

    public string FGooglePlaceId { get; set; } = null!;

    public long FCategoryId { get; set; }

    public string FName { get; set; } = null!;

    public string FAddress { get; set; } = null!;

    public decimal FLatitude { get; set; }

    public decimal FLongitude { get; set; }

    public string? FPhone { get; set; }

    public string? FDescription { get; set; }

    public decimal? FGoogleRating { get; set; }

    public int FGoogleReviewCount { get; set; }

    public string FBusinessStatus { get; set; } = null!;

    public bool FIsRecommend { get; set; }

    public DateTime FCreatedTime { get; set; }

    public DateTime? FUpdatedTime { get; set; }

    public virtual TRestaurantCategory FCategory { get; set; } = null!;

    public virtual ICollection<TMapFavorite> TMapFavorites { get; set; } = new List<TMapFavorite>();

    public virtual ICollection<TRecommendation> TRecommendations { get; set; } = new List<TRecommendation>();

    public virtual ICollection<TRestaurantImage> TRestaurantImages { get; set; } = new List<TRestaurantImage>();

    public virtual ICollection<TTripRestaurant> TTripRestaurants { get; set; } = new List<TTripRestaurant>();
}
