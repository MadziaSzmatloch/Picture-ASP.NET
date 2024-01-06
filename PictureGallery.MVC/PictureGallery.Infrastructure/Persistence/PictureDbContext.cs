using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Infrastructure.Persistence
{
    public class PictureDbContext : IdentityDbContext
    {
        public PictureDbContext(DbContextOptions<PictureDbContext> options) : base(options)
        {
            
        }
        public DbSet<Domain.Entities.Picture> Pictures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
