using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Domain.Entities
{
    public class Picture
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public string ImageName { get; set;} = default!;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public string EncodedTitle { get; private set; } = default!;
        
        public string? CreatedById { get; set; }
        public IdentityUser? CreatedBy { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; } = default!;

        public void EncodeTitle()
        {
            var name = Path.GetFileNameWithoutExtension(ImageFile.FileName) + DateTime.Now.ToString("yymmssfff");
            EncodedTitle = name.ToLower().Replace(" ", "-");
        }
        public void SetImageName()
        {
            ImageName = Path.GetFileNameWithoutExtension(ImageFile.FileName) + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(ImageFile.FileName);
        }

    }
}
