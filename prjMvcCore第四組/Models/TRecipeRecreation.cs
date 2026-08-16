using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TRecipeRecreation
    {
        public int FRecreationId { get; set; }

        public int FRecipeId { get; set; }

        public int FUserId { get; set; }

        public string FRecreationImageUrl { get; set; } = null!;

        public string? FNotes { get; set; }

        public int FServingsCooked { get; set; }

        public DateTime FCreatedAt { get; set; }

        public virtual TRecipe FRecipe { get; set; } = null!;
    }
}