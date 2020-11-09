using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApplication43.ImageWriter.Interface;

namespace WebApplication43.ImageWriter
{
    public class ImagesWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }
            return "Invalid image file";
        }
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }
            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }
        public async Task<string> WriteFile(IFormFile file)
        {
            string uniqueFileName;
            try
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName + ".jpg";
                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory().Replace("WebApi", "ProductWithPics"), "wwwroot\\images");
                var path = Path.Combine(pathBuilt, uniqueFileName);
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return uniqueFileName;
        }
    }
}
