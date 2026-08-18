using prjMvcCore第四組.ViewModels;

namespace prjMvcCore第四組.Services
{
    public interface IProductService
    {
        List<ProductListItemViewModel> GetProductList();
        ProductEditViewModel GetProductForEdit(int productId);
        bool UpdateProduct(ProductEditViewModel model);
    }
}
