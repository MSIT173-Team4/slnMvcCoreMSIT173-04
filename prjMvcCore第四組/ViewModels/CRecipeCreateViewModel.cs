using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace prjMvcCore第四組.ViewModels
{
    public class CRecipeCreateViewModel
    {
        [DisplayName("食譜標題")]
        [Required(ErrorMessage = "請輸入食譜標題")]
        [StringLength(20, ErrorMessage = "標題不能超過 20 字")]
        public string FTitle { get; set; } = string.Empty;

        [DisplayName("簡介")]
        [StringLength(200, ErrorMessage = "簡介不能超過 200 字")]
        public string? FDescription { get; set; }

        [DisplayName("份量(人份)")]
        [Range(1, 50, ErrorMessage = "份量需在 1 到 50 之間")]
        public int FDefaultServings { get; set; } = 2;
        [DisplayName("烹飪時間(分鐘)")]
        [Range(1, 600, ErrorMessage = "時間需大於 0 分鐘")]
        public int FTotalCookingMinutes { get; set; } = 30;
        [DisplayName("封面照片")]
        public IFormFile? CoverPhoto { get; set; }

        [DisplayName("食譜影片")]
        public IFormFile? VideoFile { get; set; }

        [DisplayName("小撇步")]
        [StringLength(200, ErrorMessage = "小撇步不能超過 200 字")]
        public string? FTips { get; set; }
        //清單
        public List<RecipeIngredientItemVM> Ingredients { get; set; } = new List<RecipeIngredientItemVM>();
        //步驟
        public List<RecipeStepItemVM> Steps { get; set; } = new List<RecipeStepItemVM>();

    }
    public class RecipeIngredientItemVM
    {
        public string? IngredientName { get; set; } // 食材名稱 (如: 鮭魚、檸檬)
        public decimal RequiredQuantity { get; set; } // 份量數值 (如: 200)
        public string? Unit { get; set; } // 單位 (如: 公克、顆、匙)
    }
    public class RecipeStepItemVM
    {
        public int StepNumber { get; set; }
        public string? Instruction { get; set; }
        public int? TimerSeconds { get; set; }
        public IFormFile? StepPhoto { get; set; } 
    }

}
