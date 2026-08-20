using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjMvcCore第四組.Helpers;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace prjMvcCore第四組.Controllers
{
    public class RecipeController : Controller
{
        private readonly MidprjDb2Context _context;
        private readonly FileUploadHelper _fileHelper;
        private readonly CRecipeService _recipeSaver;
        public RecipeController(MidprjDb2Context context, IWebHostEnvironment enviro)
        {
            _context = context;
            _fileHelper = new FileUploadHelper(enviro);
            _recipeSaver = new CRecipeService(context, _fileHelper);
        }
        public IActionResult List(CRecipeViewModel vm)
    {
            string? keyword = vm.txtKeyword;
            IEnumerable<TRecipe> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from t in _context.TRecipes
                        where t.FStatus == 1
                        select t;
            }
            else
            {
                datas = _context.TRecipes.Where(t => t.FTitle.Contains(keyword)||
                t.FDescription.Contains(keyword));
            }
            List<CRecipeWrap> list = new List<CRecipeWrap>();
            foreach(var data in datas)
            {
                CRecipeWrap rw = new CRecipeWrap(data);
                list.Add(rw);
            }
            return View(list);
    }
        [HttpPost]
        public IActionResult List(CRecipeViewModel vm, string? dummy = null)
        {
            return List(vm);
        }
        public IActionResult Create()
        {
            var vm =new CRecipeCreateViewModel();
            vm.Ingredients.Add(new RecipeIngredientItemVM());
            vm.Ingredients.Add(new RecipeIngredientItemVM());
            vm.Steps.Add(new RecipeStepItemVM { StepNumber = 1 });
            vm.Steps.Add(new RecipeStepItemVM { StepNumber = 2 });

            return View(vm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CRecipeCreateViewModel vm)
        {
             if (!ModelState.IsValid)
            {
                return View(vm);
            }

            string? coverPhotoName = _fileHelper.SaveFile(vm.CoverPhoto, "recipes");

            TRecipe recipe = new TRecipe
            {
                FAuthorUserId = 1, 
                FTitle = vm.FTitle,
                FDescription = vm.FDescription,
                FDefaultServings = vm.FDefaultServings,
                FTotalCookingMinutes = vm.FTotalCookingMinutes,
                FCoverImageUrl = coverPhotoName,
                FStatus = 1,       
                FViewCount = 0,
                FIsAiGenerated = false,
                FCreatedAt = DateTime.Now,
                FUpdatedAt = DateTime.Now
            };

            _context.TRecipes.Add(recipe);
            _context.SaveChanges(); 

            _recipeSaver.SaveIngredients(recipe.FRecipeId, vm.Ingredients);
            _recipeSaver.SaveSteps(recipe.FRecipeId, vm.Steps);

            // 5. 儲存完畢導回清單頁
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            TRecipe x = _context.TRecipes.FirstOrDefault(t => t.FRecipeId == id);
            if (x == null)
                return RedirectToAction("List");
            CRecipeWrap rw = new CRecipeWrap(x);
            return View(rw);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("List");

            TRecipe recipe = _context.TRecipes.FirstOrDefault(t => t.FRecipeId == id);
            if (recipe != null)
            {
                _context.TRecipes.Remove(recipe);
                _context.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}

