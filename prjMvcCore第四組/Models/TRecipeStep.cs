using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{
    public partial class TRecipeStep
    {
        public int FStepId { get; set; }

        public int FRecipeId { get; set; }

        public int FStepNumber { get; set; }

        public string FInstruction { get; set; } = null!;

        public string? FImageUrl { get; set; }

        public int? FTimerSeconds { get; set; }

        public virtual TRecipe FRecipe { get; set; } = null!;
    }
}