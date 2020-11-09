using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApplication43.ImageWriter.Interface
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
    }
}
