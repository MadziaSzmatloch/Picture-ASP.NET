using System;
using System.Collections.Generic;
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
        public void EncodeTitle() => EncodedTitle = Title.ToLower().Replace(" ", "-");

    }
}
