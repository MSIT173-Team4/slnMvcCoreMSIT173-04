using Microsoft.AspNetCore.Mvc;
using prjMvcCore第四組.Models;

namespace prjMvcCore第四組.Controllers
{
    public class MemberController : Controller
{
    public IActionResult Index()
    {
        MidprjDb2Context db=new MidprjDb2Context();
            var data = from t in db.TUsers select t;
        return View(data);
    }
    public IActionResult Create()
    {
        return View();
    }
        [HttpPost]
        public IActionResult Create(TUser u)
        {
            MidprjDb2Context db = new MidprjDb2Context();

            db.Add(u);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    public IActionResult Details(int? id)
     {
            if (id == null) return RedirectToAction("Index");
            MidprjDb2Context db = new MidprjDb2Context();
            TUser data = db.TUsers.FirstOrDefault(t => t.FId == id);
            TPostTable pdata = db.TPostTables.FirstOrDefault(t => t.FUserId == id);
            TRecipe rdata = db.TRecipes.FirstOrDefault(t => t.FAuthorUserId == id);
            if (data == null||pdata==null||rdata==null) return RedirectToAction("Index");
            ViewBag.user = data;
            ViewBag.post = pdata;
            ViewBag.recipe = rdata;
            return View();
    }


}
}
