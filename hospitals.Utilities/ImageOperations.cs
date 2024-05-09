using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace hospitals.Utilities
{
    public class ImageOperations
    {
        private readonly IWebHostEnvironment _env;

        public ImageOperations(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> ImageUploadAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            string fileDirectory = Path.Combine(_env.WebRootPath, "Images");
            Directory.CreateDirectory(fileDirectory); // Tạo thư mục nếu nó chưa tồn tại
            string filename = Guid.NewGuid() + "-" + file.FileName;
            string filepath = Path.Combine(fileDirectory, filename);

            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fs);
            }

            return filename;
        }
    }
}
