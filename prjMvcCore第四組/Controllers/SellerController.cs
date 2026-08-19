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
            MidprjDb2Context db = new MidprjDb2Context();

            var seller = db.TSellers
                .Include(x => x.FUser)
                .FirstOrDefault(x => x.FId == id);

            if (seller == null)
            {
                return NotFound();
            }

            // 商家可以使用的狀態
            ViewBag.Status = db.TStatuses
                .Where(x => x.FId == 4 || x.FId == 5)
                .ToList();

            // 這裡查這個 Seller 的商品
            // 下面假設 TProduct 有 FUserId 可以對應商家
            ViewBag.Products = db.TProducts
                .Where(x => x.FSellerId == seller.FId)
                .ToList();

            return View(seller);
        }
        [HttpPost]
        public IActionResult ChangeStatus(int id, int status)
        {
            MidprjDb2Context db = new MidprjDb2Context();

            var seller = db.TSellers
                .FirstOrDefault(x => x.FId == id);

            if (seller == null)
            {
                return NotFound();
            }

            // 只允許 4、5
            if (status != 4 && status != 5)
            {
                return BadRequest();
            }

            seller.FStatus = status;

            db.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

    }
}
