using Microsoft.AspNetCore.Mvc;
using prjMvcCoreMSIC173.ViewModels;
using prjMvcCore第四組.Models;
using System.Security.Cryptography;
using System.Text;
using System.Timers;


namespace prjMvcCore第四組.Controllers
{
    public class MemberController : Controller
{
    public IActionResult Index(string? txtKeyword)
    {
            
            MidprjDb2Context db=new MidprjDb2Context();
            IEnumerable<TUser> data = null;
            if (string.IsNullOrEmpty(txtKeyword))
            {
                data = from t in db.TUsers select t;
            }
            else
            {
                data = db.TUsers.Where(t=>t.FNickname.Contains(txtKeyword));
            }
            return View(data);
    }
    public IActionResult Create()
    {
        return View();
    }
        [HttpPost]
        public IActionResult Create(RegisterViewModel u)
        {
            MidprjDb2Context db = new MidprjDb2Context();
            TUser user = new TUser();
            user.FUsername = u.FUsername;
            user.FPassword = HashPassword(u.FPassword);
            user.FEmail = u.FEmail;
            user.FNickname = u.FNickname;
            user.FAddress = u.FAddress;
            user.FIdNum = u.FIdNum;
            user.FPhone = u.FPhone;
            user.FGender = u.FGender;
            user.FCreateDate = DateTime.Now;
            
            db.Add(user);
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
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
