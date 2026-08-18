namespace prjMvcCore第四組.ViewModels
{
    public class ProductListItemViewModel
    {
        public int ProductID { get; set; }
        public string ProductNo { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? BrandName { get; set; } // 預留關聯名稱
        public string? CategoryName { get; set; }
        public int ProductStatus { get; set; }
        public DateTime ProductDate { get; set; }
    }
}
