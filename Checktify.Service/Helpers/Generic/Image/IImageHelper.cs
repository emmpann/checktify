using Checktify.Core.Enumerators;
using Checktify.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Service.Helpers.Generic.Image
{
    public interface IImageHelper
    {
        Task<ImageUploadModel> ImageUplaod(IFormFile imageFile, ImageType imageType, string? folderName);
        string DeleteImage(string imageName);
    }
}
