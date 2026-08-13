using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class Recommendation
    {
        public long RecommendationId { get; set; }

        public long RestaurantId { get; set; }

        public string Title { get; set; } = null!;

        public string? Content { get; set; }

        public int Priority { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public bool IsActive { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}