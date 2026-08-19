using System.ComponentModel.DataAnnotations;

namespace prjMvcCore第四組.ViewModels
{
    public class ProductEditViewModel
    {
        public int ProductID { get; set; }

        [Required, StringLength(50)]
        public string ProductNo { get; set; }

        public int SellerId { get; set; }

        [Required]
        public int ProductsCategoryID { get; set; }

        [Required, StringLength(100)]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public int BrandId { get; set; }
        public DateOnly? ManufacturingDate { get; set; }
        public DateOnly? ExpirationDate { get; set; }
        public DateTime ProductDate { get; set; }
        public string AttributesJson { get; set; }
        public int ProductStatus { get; set; }
    }
}
