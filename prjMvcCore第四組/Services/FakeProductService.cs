using prjMvcCore第四組.ViewModels;
namespace prjMvcCore第四組.Services
{
    public class FakeProductService : IProductService
    {
        public List<ProductListItemViewModel> GetProductList()
        {
            return new List<ProductListItemViewModel>
            {
                new ProductListItemViewModel { ProductID = 1, ProductName = "測試商品A", Price = 100, Stock = 10 },
                new ProductListItemViewModel { ProductID = 2, ProductName = "測試商品B", Price = 200, Stock = 5 },
            };
        }

        public ProductEditViewModel GetProductForEdit(int productId)
        {
            return new ProductEditViewModel { ProductID = productId, ProductName = "測試商品A" };
        }

        public bool UpdateProduct(ProductEditViewModel model)
        {
            return true;  // 假裝更新成功
        }
    }
}
