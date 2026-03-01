using Checktify.Core.Enumerators;
using Checktify.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Checktify.Service.Helpers.Generic.Image
{
    public class ImageHelper : IImageHelper
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly string wwwRoot;
        private const string imageFolder = "images";
        private const string identityFolder = "user";

        public ImageHelper(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            wwwRoot = _hostEnvironment.ContentRootPath + "/wwwroot/";
        }

        public async Task<ImageUploadModel> ImageUplaod(IFormFile imageFile, ImageType imageType, string? folderName)
        {
            if (folderName == null)
            {
                switch (imageType)
                {
                    case ImageType.identity:
                        folderName = identityFolder;
                        break;
                    default:
                        folderName = identityFolder;
                        break;
                }
            }

            if (!Directory.Exists($"{wwwRoot}/{imageFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwRoot}/{imageFolder}/{folderName}");
            }

            string fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
            if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
            {
                return new ImageUploadModel { Error = "Invalid image format. Only .jpg, .jpeg, and .png are allowed." };
            }

            DateTime dateTime = DateTime.Now;
            var newFileName = $"{folderName}_{dateTime.Microsecond.ToString()}{fileExtension}";

            string path = Path.Combine($"{wwwRoot}/{imageFolder}/{folderName}", newFileName);

            await using var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024*1024, useAsync:false);
            await imageFile.CopyToAsync(stream);
            await stream.FlushAsync();

            return new ImageUploadModel { Filename = $"{folderName}/{newFileName}", Filetype = imageFile.ContentType };
        }

        public string DeleteImage(string imageName)
        {
            var fileToDelete = Path.Combine($"{wwwRoot}/{imageFolder}/{imageName}");
            if (File.Exists(fileToDelete))
            {
                File.Delete(fileToDelete);
            }

            return "Image Is Deleted";
        }
    }
}
