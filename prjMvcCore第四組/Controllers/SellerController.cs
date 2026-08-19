using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCore第四組.Models;

namespace prjMvcCoreMSIC173.Controllers
{
    public class SellerController : Controller
{
    public IActionResult Index()
    {
        MidprjDb2Context db=new MidprjDb2Context();
            var data = db.TSellers.Include(x => x.FUser).ToList();
            var statuses = db.TStatuses.ToDictionary(x => x.FId, x => x.FName);

        ViewBag.status = statuses;
        return View(data);
    }
    public IActionResult Details(int id) 
        {

            return View();
        }
}
}
