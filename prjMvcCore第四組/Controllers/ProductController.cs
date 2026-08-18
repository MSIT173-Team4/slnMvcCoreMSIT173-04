using Microsoft.AspNetCore.Mvc;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;

namespace prjMvcCore第四組.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList(CProductKeywordViewModels vm)
        {

            MidprjDb2Context db = new MidprjDb2Context();
            IQueryable<TProduct> query = db.TProducts;

            if (!string.IsNullOrEmpty(vm.txtKeyword))
            {
                switch (vm.SearchType)
                {
                    case "merchantId":
                        if (int.TryParse(vm.txtKeyword, out int sellerId))
                        {
                            query = query.Where(t => t.FSellerId == sellerId);
                        }
                        break;

                    case "productId":
                        query = query.Where(t => t.FProductNo.Contains(vm.txtKeyword));
                        break;

                    case "productName":
                        query = query.Where(t => t.FProductname.Contains(vm.txtKeyword));
                        break;
                }
            }

            if (vm.MinStock.HasValue)
            {
                query = query.Where(t => t.FStock >= vm.MinStock.Value);
            }
            if (vm.MaxStock.HasValue)
            {
                query = query.Where(t => t.FStock <= vm.MaxStock.Value);
            }
            if (vm.StatusFilter.HasValue)
            {
                query = query.Where(t => t.FProductStatus == vm.StatusFilter.Value);
            }

            return View(query.ToList());
        }

        [HttpPost]

        public IActionResult ToggleStatus(int id)
        {
            using var db = new MidprjDb2Context();
            var product = db.TProducts.FirstOrDefault(p => p.FProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            if (product.FProductStatus == 1)
            {
                product.FProductStatus = 3;
            }
            else if (product.FProductStatus == 3)
            {
                product.FProductStatus = 1;
            }
            // 其他狀態（審核中/已售完/已違規）不處理，維持原樣

            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}
