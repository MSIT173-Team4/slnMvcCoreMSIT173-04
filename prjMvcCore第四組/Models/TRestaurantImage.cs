using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCore第四組.Models
{
    public partial class TRestaurantImage
    {
        [Key]
        public long FImageId { get; set; }

        public long FRestaurantId { get; set; }

        public string FImageUrl { get; set; } = null!;

        public string FImageType { get; set; } = null!;

        public virtual TRestaurant FRestaurant { get; set; } = null!;
    }
}