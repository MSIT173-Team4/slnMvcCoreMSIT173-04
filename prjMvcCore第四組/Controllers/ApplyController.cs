using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCoreMSIC173.ViewModels;
using prjMvcCore第四組.Models;

namespace prjMvcCoreMSIC173.Controllers
{
    public class ApplyController : Controller
{
        private IWebHostEnvironment _env;
        public ApplyController(IWebHostEnvironment env)
        {
            _env = env;
        }
    public IActionResult Index()
    {

            MidprjDb2Context db = new MidprjDb2Context();

            var data = db.TApplies.Include(x => x.FUser).ToList();
            var statuses = db.TStatuses.ToDictionary(x => x.FId, x => x.FName);

            ViewBag.status = statuses;

            return View(data);
        }
    public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
    public IActionResult Create(AddApplyViewModel a)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            if (a == null) return RedirectToAction("Create");
            if(a.img != null && a.img.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(a.img.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "image","Apply", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    a.img.CopyTo(stream);
                }
                a.FIdCard = "/image/Apply/" + fileName;
            }
            TApply apply = new TApply();
            apply.FUserId = a.FUserId;
            apply.FStoreName = a.FStoreName;
            apply.FStoreDescription = a.FStoreDescription;
            apply.FIdNum = a.FIdNum;
            apply.FIdCard = a.FIdCard;
            apply.FStatus = a.FStatus;
            apply.FApplyDate = DateTime.Now;
            db.TApplies.Add(apply);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            MidprjDb2Context db = new MidprjDb2Context();

            var apply = db.TApplies
                .Include(x => x.FUser)
                .FirstOrDefault(x => x.FId == id);

            if (apply == null)
            {
                return NotFound();
            }

            var status = db.TStatuses.ToList();

            ViewBag.status = status;

            return View(apply);
        }
        public IActionResult Reject(int id)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            var apply = db.TApplies.FirstOrDefault(x => x.FId == id);

            if (apply != null)
            {
                apply.FStatus = 3;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Approve(int id)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            var apply = db.TApplies.FirstOrDefault(x => x.FId == id);

            if (apply == null)
            {
                return NotFound();
            }

            apply.FStatus = 2;
            db.SaveChanges();
            
            TSeller seller = new TSeller();
            seller.FUserId = apply.FUserId;
            seller.FName = apply.FStoreName;
            seller.FDescription = apply.FStoreDescription;
            seller.FStatus = 4;
            seller.FApplyDate = DateTime.Now;
            db.TSellers.Add(seller);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
