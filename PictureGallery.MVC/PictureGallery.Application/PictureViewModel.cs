using PictureGallery.Application.ApplicationUser;
using PictureGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application
{
    public class PictureViewModel
    {
        public Domain.Entities.Picture Picture { get; set; }
        public CurrentUser? User { get; set; }
    }
}
