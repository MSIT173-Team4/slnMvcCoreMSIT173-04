using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class RestaurantImage
    {
        public long ImageId { get; set; }

        public long RestaurantId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string ImageType { get; set; } = null!;

        public virtual Restaurant Restaurant { get; set; } = null!;
    }
}