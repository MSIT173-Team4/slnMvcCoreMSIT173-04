using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TRecipeIngredient
{
    public int FRecipeId { get; set; }

    public int FIngredientId { get; set; }

    public decimal FRequiredQuantity { get; set; }

    public string FUnit { get; set; } = null!;

    public virtual TIngredient FIngredient { get; set; } = null!;

    public virtual TRecipe FRecipe { get; set; } = null!;
}
