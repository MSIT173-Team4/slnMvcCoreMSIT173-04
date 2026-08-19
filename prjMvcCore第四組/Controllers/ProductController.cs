using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            List<CProductWrap> wrapList = query
        .ToList()
        .Select(t => new CProductWrap { product = t })
        .ToList();

            return View(wrapList);
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

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("ProductList");
            MidprjDb2Context db = new MidprjDb2Context();
            TProduct x = db.TProducts.FirstOrDefault(t => t.FProductId == id);
            if (x == null)
                return RedirectToAction("ProductList");
            CProductWrap pw = new CProductWrap();
            pw.product = x;
            pw.CategoryOptions = db.TProductsCategories//抓取下拉選單的值
                .Where(c => c.FParentCategoryId != null)
                .OrderBy(c => c.FCategoryId)
                .ToList()
                .Select(c => new SelectListItem
                {
                    Value = c.FCategoryId.ToString(),
                    Text = c.FCategoryId + "_" + c.FCategoriesName   
                })
                .ToList();
                    return View(pw);

                }

        [HttpPost]
        public ActionResult Edit(CProductWrap pw)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            TProduct prodDb = db.TProducts.FirstOrDefault(t => t.FProductId == pw.FProductId);
            //if (pw.photo != null)
            //{
            //    string photoName = Guid.NewGuid().ToString() + ".jpg";
            //    pw.photo.CopyTo(new FileStream(_enviro.WebRootPath + "//images//" + photoName, FileMode.Create));
            //    prodDb.FImagePath = photoName;
            //}
            prodDb.FProductNo = pw.FProductNo;
            prodDb.FSellerId = pw.FSellerId;
            prodDb.FProductsCategoryId = pw.FProductsCategoryId;
            prodDb.FProductname = pw.FProductname;
            prodDb.FDescription = pw.FDescription;
            prodDb.FStock = pw.FStock;
            prodDb.FPrice = pw.FPrice;
            prodDb.FBrandId = pw.FBrandId;
            prodDb.FManufacturingDate = pw.FManufacturingDate;
            prodDb.FExpirationDate = pw.FExpirationDate;
            prodDb.FProductDate = pw.FProductDate; 
            //prodDb.FAttributesJson = pw.FAttributesJson;
            prodDb.FProductStatus = pw.FProductStatus;
            prodDb.FReportCount = pw.FReportCount;
            db.SaveChanges();

            return RedirectToAction("ProductList");


        }

        public ActionResult Delete(int? id)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            TProduct x = db.TProducts.FirstOrDefault(t => t.FProductId == id);//FirstOrDefault當有找到符合條件的資料時，回傳第 1 筆
            if (x != null)
            {
                db.TProducts.Remove(x);
                db.SaveChanges();
            }

            return RedirectToAction("ProductList");
        }

       
    }
}
