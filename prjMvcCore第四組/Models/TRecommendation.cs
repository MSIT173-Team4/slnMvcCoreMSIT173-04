using System;
using System.Collections.Generic;
namespace prjMvcCore第四組.Models
{

    public partial class TRecommendation
    {
        public long FRecommendationId { get; set; }

        public long FRestaurantId { get; set; }

        public string FTitle { get; set; } = null!;

        public string? FContent { get; set; }

        public int FPriority { get; set; }

        public DateOnly? FStartDate { get; set; }

        public DateOnly? FEndDate { get; set; }

        public bool FIsActive { get; set; }

        public virtual TRestaurant FRestaurant { get; set; } = null!;
    }
}