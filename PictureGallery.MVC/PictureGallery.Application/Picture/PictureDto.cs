using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture
{
    public class PictureDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public IFormFile ImageFile { get; set; } = default!;

        public string? EncodedName { get; set; }

    }
}
