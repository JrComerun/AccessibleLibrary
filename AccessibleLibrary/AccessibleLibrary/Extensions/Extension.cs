using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Extensions
{
    public static class Extension
    {
        public enum Roles { Admin, Member }
        public static bool IsImage(this IFormFile photo)
        {
            return photo.ContentType.Contains("image/");
        }
        //public static bool MaxSize(this IFormFile photo, int kb)
        //{
        //    return photo.Length / 1024 <= kb;
        //}
        public static string SaveImagesAsync(this IFormFile photo, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + photo.FileName;
            string path = Path.Combine(root, folder, fileName);
            Image image = Image.FromStream(photo.OpenReadStream(), true, true);
            var newImage = new Bitmap(312, 416);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, 312, 416);
            }
            newImage.Save(path);
            return fileName;
        }
        public static string SaveProfileImageAsync(this IFormFile photo, string root, string folder)
        {
            string fileName = Guid.NewGuid().ToString() + photo.FileName;
            string path = Path.Combine(root, folder, fileName);
            Image image = Image.FromStream(photo.OpenReadStream(), true, true);
            var newImage = new Bitmap(200, 200);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, 200, 200);
            }
            newImage.Save(path);
            return fileName;
        }

    }
}
