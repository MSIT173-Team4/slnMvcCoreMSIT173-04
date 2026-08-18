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
        IEnumerable<TProduct> datas = null;
        if (string.IsNullOrEmpty(vm.txtKeyword))
        {
            datas = from t in db.TProducts select t;
        }
        else
            datas = db.TProducts.Where(t => t.FProductname.Contains(vm.txtKeyword));
        return View(datas);
    }
}
}
