using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROGRESSTRACKER.API.Helpers.Shared
{
    public class ImageUploader
    {
        public string Upload(IFormFile image, string path, int userId)
        {
            if (image == null || image.Length == 0)
                return null;

            var folderName = Path.Combine("Documents", path);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            string extension = Path.GetExtension(image.FileName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string nameToUse = DateTime.Now.Ticks.ToString();
            nameToUse = nameToUse.Replace(" ", String.Empty);

            var uniqueFileName = $"{nameToUse}_Avatar_{userId}_{image.Name}{extension}";
            var dbPath = Path.Combine(folderName, uniqueFileName);

            using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            var Url = $"{dbPath}";

            return Url.Replace("\\", "/");
        }
    }
}
