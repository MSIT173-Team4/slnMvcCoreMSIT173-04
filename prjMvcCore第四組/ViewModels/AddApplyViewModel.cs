using Microsoft.AspNetCore.Mvc;
using System.Web;
namespace prjMvcCoreMSIC173.ViewModels
{
    public class AddApplyViewModel
{
        public int FUserId { get; set; }
        public string FStoreName { get; set; }
        public string FStoreDescription { get; set; }
        public string FIdNum { get; set; }
        public string FIdCard { get; set; }
        public int FStatus { get; set; }
        public IFormFile img { get; set; }
    }
}
