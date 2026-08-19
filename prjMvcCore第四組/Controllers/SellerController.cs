using Microsoft.AspNetCore.Mvc;
using prjMvcCore第四組.Models;

namespace prjMvcCoreMSIC173.Controllers
{
    public class SellerController : Controller
{
    public IActionResult Index()
    {
        MidprjDb2Context db=new MidprjDb2Context();

        return View();
    }
}
}
