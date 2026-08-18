using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace prjMvcCore第四組.Models
{
    public class CRecipeWrap
{
        private TRecipe _recipe;
        public TRecipe recipe 
        {
            get{ return _recipe; }
            set { _recipe = value; } 
        }
        public CRecipeWrap()
        {
            _recipe = new TRecipe();
        }
        public CRecipeWrap(TRecipe recipe)
        {
            _recipe = recipe;
        }
        [Key]
        public int FRecipeId
        {
            get { return _recipe.FRecipeId; }
            set { _recipe.FRecipeId = value; }
        }
        public int FAuthorUserId
        {
            get { return _recipe.FAuthorUserId; }
            set { _recipe.FAuthorUserId = value; }
        }
        [DisplayName("食譜名稱")]
        [Required(ErrorMessage = "請輸入食譜名稱")]
        [StringLength(100, ErrorMessage ="名稱長度不能超過100字")]
        public string FTitle
        {
            get { return _recipe.FTitle; }
            set { _recipe.FTitle = value; }
        }
        [DisplayName("食譜簡介")]
        public string? FDescription
        {
            get { return _recipe.FDescription; }
            set { _recipe.FDescription = value; }
        }
        [DisplayName("預設份量")]
        [Range(1,50,ErrorMessage ="份量需介於1到50之間")]
        public int FDefaultServings
        {
            get { return _recipe.FDefaultServings; }
            set { _recipe.FDefaultServings = value;}
        }
        [DisplayName("封面圖檔名")]
        public string? FCoverImageUrl
        {
            get { return _recipe.FCoverImageUrl; }
            set { _recipe.FCoverImageUrl = value; }
        }
        [DisplayName("烹飪時間(分鐘)")]
        [Range(1, 600, ErrorMessage ="烹飪時間需大於 0 分鐘")]
        public int FTotalCookingMinutes
        {
            get { return _recipe.FTotalCookingMinutes; }
            set { _recipe.FTotalCookingMinutes = value; }
        }
        public int FViewCount
        {
            get { return _recipe.FViewCount; }
            set { _recipe.FViewCount = value; }
        }
        public int FStatus
        {
            get { return _recipe.FStatus; }
            set { _recipe.FStatus = value; }
        }
        public bool FIsAiGenerated
        {
            get { return _recipe.FIsAiGenerated; }
            set { _recipe.FIsAiGenerated = value; }
        }
        public DateTime FCreatedAt
        {
            get { return _recipe.FCreatedAt; }
            set { _recipe.FCreatedAt = value; }
        }
        public DateTime FUpdatedAt
        {
            get { return _recipe.FUpdatedAt; }
            set { _recipe.FUpdatedAt = value; }
        }
        [DisplayName("上傳封面圖片")]
        public IFormFile? Photo
        {
            get;
            set;
        }
    }

}
