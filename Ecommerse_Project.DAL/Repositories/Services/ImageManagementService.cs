using Ecommerse_Project.BLL.Services;
using Ecommerse_Project.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerse_Project.DAL.Repositories.Services
{
    public class ImageManagementService : IImageManagementService
    {
        private readonly IFileProvider _fileProvider;
        public ImageManagementService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
            
        }

        public async Task<List<string>> AddImageAsync(IFormFileCollection files, string mainCategory, string subCategory, int productId)
        {
            //create directory
            List<string> SaveImageSrc = new List<string>();
            var ImageDirectory = Path.Combine("wwwroot", "Images", mainCategory, subCategory, productId.ToString());
            if(Directory.Exists(ImageDirectory) is not true)
            {
                Directory.CreateDirectory(ImageDirectory);
            }
            foreach(var file in files)
            {
                if(file.Length > 0)
                {
                    var ImageName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";            //create a unique name for each image
                    var ImageSrc = $"/Images/{mainCategory}/{subCategory}/{productId}/{ImageName}";  //place of the image inside the wwwroot
                    var root = Path.Combine(ImageDirectory, ImageName);
                    using (FileStream stream = new FileStream(root, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    SaveImageSrc.Add(ImageSrc);
                }
            }
            return SaveImageSrc;
        }

       

        public void DeleteImageAsync(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                throw new ArgumentNullException(nameof(imageUrl), "Image URL cannot be null or empty.");
            }

            var imageInfo = _fileProvider.GetFileInfo(imageUrl);
            if (!imageInfo.Exists)
            {
                throw new FileNotFoundException($"Image not found at {imageUrl}");
            }
           
            if (!imageInfo.Exists)
            {
              
                throw new FileNotFoundException($"Image not found at {imageUrl}");
            }

            var root = imageInfo.PhysicalPath;
            
             File.Delete(root);
        }
    }
}
