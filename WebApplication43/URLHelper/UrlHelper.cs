using System;
using System.IO;

namespace WebApplication43.URLHelper
{
    public static class UrlHelper
    {
        public static string GetUrl(string fileName)
        {
            var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images");
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + fileName;
            return Path.Combine(pathBuilt, uniqueFileName);
        }
    }
}
