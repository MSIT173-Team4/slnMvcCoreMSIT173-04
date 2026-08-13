using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class ShoppingCart
    {
        public int CartItemId { get; set; }

        public int UsersId { get; set; }

        public int SellerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Product Product { get; set; } = null!;

        public virtual TSeller Seller { get; set; } = null!;

        public virtual TUser Users { get; set; } = null!;
    }
}