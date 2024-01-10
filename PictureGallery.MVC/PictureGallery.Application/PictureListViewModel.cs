using PictureGallery.Application.ApplicationUser;
using PictureGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application
{
    public class PictureListViewModel
    {
        public IEnumerable<Domain.Entities.Picture> Pictures { get; set; }
        public CurrentUser? User { get; set; }
    }
}
