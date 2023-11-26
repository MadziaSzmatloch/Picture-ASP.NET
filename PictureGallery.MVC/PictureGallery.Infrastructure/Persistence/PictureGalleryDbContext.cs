using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Infrastructure.Persistence
{
    public class PictureGalleryDbContext : DbContext
    {
        public PictureGalleryDbContext(DbContextOptions<PictureGalleryDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.Picture> Pictures { get; set; }

    }
}
