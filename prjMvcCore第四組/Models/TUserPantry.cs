using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TUserPantry
{
    public int FPantryItemId { get; set; }

    public int FUserId { get; set; }

    public int FIngredientId { get; set; }

    public decimal FStockQuantity { get; set; }

    public DateOnly FExpiryDate { get; set; }

    public virtual TIngredient FIngredient { get; set; } = null!;

    public virtual TUser FUser { get; set; } = null!;
}
