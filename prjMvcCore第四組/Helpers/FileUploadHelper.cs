using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace prjMvcCore第四組.Helpers
{
     public class FileUploadHelper
    {
        private readonly IWebHostEnvironment _enviro;
       public FileUploadHelper(IWebHostEnvironment enviro)
        {
            _enviro = enviro;
        }

        public string? SaveFile(IFormFile? file, string subFolder = "recipes")
        {
            if (file == null || file.Length == 0)
                return null;
            string targetFolder = Path.Combine(_enviro.WebRootPath, "images", subFolder);
            Directory.CreateDirectory(targetFolder); // 💡 Directory.CreateDirectory 本身就內建防呆，若資料夾已存在它會自動忽略，完全不用寫 if !Directory.Exists！
            string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string fullPhysicalPath = Path.Combine(targetFolder, uniqueFileName);
            using var stream = new FileStream(fullPhysicalPath, FileMode.Create);
            file.CopyTo(stream);
            return uniqueFileName;
        }
        public List<string> SaveFiles(List<IFormFile>? files, string subFolder = "recipes")
        {
            var savedNames = new List<string>();
            if (files == null || files.Count == 0)
                return savedNames;

            foreach (var file in files)
            {
                string? fileName = SaveFile(file, subFolder);
                if (!string.IsNullOrEmpty(fileName))
                {
                    savedNames.Add(fileName);
                }
            }

            return savedNames;
        }
    }
}