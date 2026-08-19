using Microsoft.EntityFrameworkCore;
using prjMvcCore第四組.Helpers;
using prjMvcCore第四組.Models;
using prjMvcCore第四組.ViewModels;
using Microsoft.AspNetCore.Http;

namespace prjMvcCore第四組
{
    public class CRecipeService
    {
        MidprjDb2Context _context = new MidprjDb2Context();
        private readonly FileUploadHelper _fileHelper;
        public CRecipeService(MidprjDb2Context context, FileUploadHelper fileHelper)
        {
            _context = context;
            _fileHelper = fileHelper;
        }
        public void SaveIngredients(int recipeId, List<RecipeIngredientItemVM> ingredients)
        {
            if (ingredients == null || !ingredients.Any()) return;

            foreach (var ing in ingredients.Where(i => !string.IsNullOrWhiteSpace(i.IngredientName)))
            {
                string name = ing.IngredientName.Trim();
                var ingredientDb = _context.TIngredients.FirstOrDefault(i => i.FName == name);

                if (ingredientDb == null)
                {
                    ingredientDb = new TIngredient
                    {
                        FName = name,
                        FCategory = "其他",
                        FStandardUnit = string.IsNullOrEmpty(ing.Unit) ? "份" : ing.Unit,
                        FCaloriesPerUnit = 0
                    };
                    _context.TIngredients.Add(ingredientDb);
                    _context.SaveChanges();
                }

                _context.TRecipeIngredients.Add(new TRecipeIngredient
                {
                    FRecipeId = recipeId,
                    FIngredientId = ingredientDb.FIngredientId,
                    FRequiredQuantity = ing.RequiredQuantity,
                    FUnit = string.IsNullOrEmpty(ing.Unit) ? "份" : ing.Unit
                });
            }
            _context.SaveChanges();
        }
        public void SaveSteps(int recipeId, List<RecipeStepItemVM> steps)
        {
            if (steps == null || !steps.Any()) return;

            int seq = 1;
            foreach (var step in steps.Where(s => !string.IsNullOrWhiteSpace(s.Instruction)))
            {
                string? stepPhotoName = null;
                if (step.StepPhoto != null && step.StepPhoto.Length > 0)
                {
                    stepPhotoName = _fileHelper.SaveFile(step.StepPhoto, "recipes");
                }

                _context.TRecipeSteps.Add(new TRecipeStep
                {
                    FRecipeId = recipeId,
                    FStepNumber = seq++,
                    FInstruction = step.Instruction,
                    FImageUrl = stepPhotoName,
                    FTimerSeconds = step.TimerSeconds
                });
            }
            _context.SaveChanges();
        }
    }
}
    

