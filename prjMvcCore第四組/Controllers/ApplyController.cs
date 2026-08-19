using Microsoft.AspNetCore.Mvc;
using prjMvcCore第四組.Models;

namespace prjMvcCoreMSIC173.Controllers
{
    public class ApplyController : Controller
{
    public IActionResult Index()
    {
        MidprjDb2Context db = new MidprjDb2Context();
        var data = from t in db.TApplies select t;
        return View(data);
    }
    public IActionResult Create()
        {
            return View();
        }
}
}
