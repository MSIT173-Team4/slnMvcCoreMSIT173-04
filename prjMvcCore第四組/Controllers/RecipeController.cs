using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;

namespace prjMvcCore第四組.Controllers
{
    public class RecipeController : Controller
{
        private readonly MidprjDb2Context _context;
        private readonly IWebHostEnvironment _enviro;
        public RecipeController(MidprjDb2Context context, IWebHostEnvironment enviro)
        {
            _context = context;
            _enviro = enviro;
        }
        public IActionResult List(CRecipeViewModel vm)
    {
            string? keyword = vm.txtKeyword;
            IEnumerable<TRecipe> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from t in _context.TRecipes select t;
            }
            else
            {
                datas = _context.TRecipes.Where(t => t.FTitle.Contains(keyword)||
                (t.FDescription !=null && t.FDescription.Contains(keyword)));
            }
            List<CRecipeWrap> list = new List<CRecipeWrap>();
            foreach(var data in datas)
            {
                CRecipeWrap Rp = new CRecipeWrap(data);
                list.Add(Rp);
            }
            return View(list);
    }
}
}
