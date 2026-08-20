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
        private IWebHostEnvironment _env;
        public MemberController(IWebHostEnvironment env)
        {
            _env = env;
        }
    public IActionResult Index(string? txtKeyword,string? searchType)
    {
            
            MidprjDb2Context db=new MidprjDb2Context();
            IEnumerable<TUser> data = null;
            if (string.IsNullOrEmpty(txtKeyword))
            {
                data = from t in db.TUsers select t;
            }
            else
            {
                if (searchType == "Nickname")
                {
                    data = db.TUsers.Where(t => t.FNickname.Contains(txtKeyword));
                }
                else if (searchType == "Username")
                {
                    data = db.TUsers.Where(t => t.FUsername.Contains(txtKeyword));
                }
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
            if (u == null) return RedirectToAction("Create");
            
            TUser user = new TUser();
            if (u.img!=null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(u.img.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "image","User", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    u.img.CopyTo(stream);
                }
                u.FProfilePicture = "/image/User/" + fileName;
            }
            user.FUsername = u.FUsername;
            user.FPassword = HashPassword(u.FPassword);
            user.FEmail = u.FEmail;
            user.FNickname = u.FNickname;
            user.FAddress = u.FAddress;
            user.FIdNum = u.FIdNum;
            user.FPhone = u.FPhone;
            user.FProfileImg = u.FProfilePicture;
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
            var pdata = db.TPostTables.Where(t => t.FUserId == id).ToList();
            var rdata = db.TRecipes.Where(t=>t.FAuthorUserId == id).ToList();
            if (data == null) return RedirectToAction("Index");
            ViewBag.User = data;
            ViewBag.Post = pdata;
            ViewBag.Recipe = rdata;
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
