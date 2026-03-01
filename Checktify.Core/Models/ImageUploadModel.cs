using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Core.Models
{
    public class ImageUploadModel
    {
        public string? Filename { get; set; }
        public string? Filetype { get; set; }
        public string? Error { get; set; }
    }
}
