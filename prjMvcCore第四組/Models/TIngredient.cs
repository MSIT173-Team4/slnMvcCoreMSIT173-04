using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TIngredient
{
    public int FIngredientId { get; set; }

    public string FName { get; set; } = null!;

    public string FCategory { get; set; } = null!;

    public decimal FCaloriesPerUnit { get; set; }

    public string FStandardUnit { get; set; } = null!;

    public virtual ICollection<TRecipeIngredient> TRecipeIngredients { get; set; } = new List<TRecipeIngredient>();

    public virtual ICollection<TUserPantry> TUserPantries { get; set; } = new List<TUserPantry>();
}
