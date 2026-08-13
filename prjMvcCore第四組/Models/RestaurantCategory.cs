using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class RestaurantCategory
    {
        public long CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}