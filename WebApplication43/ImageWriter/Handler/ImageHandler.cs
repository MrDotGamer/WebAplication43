﻿using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebApplication43.ImageWriter.Interface;

namespace WebApplication43.ImageWriter.Handler
{
    public interface IImageHandler
    {
        Task<string> UploadImage(IFormFile file);
    }
    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }
        public async Task<string> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return result;
        }
    }
}
