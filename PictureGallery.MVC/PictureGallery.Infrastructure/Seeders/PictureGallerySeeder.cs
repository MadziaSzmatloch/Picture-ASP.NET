using PictureGallery.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Infrastructure.Seeders
{
    public class PictureGallerySeeder
    {
        private readonly PictureDbContext _dbContext;

        public PictureGallerySeeder(PictureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if(!_dbContext.Pictures.Any())
                {
                    var pic1 = new Domain.Entities.Picture()
                    {
                        Title = "Tree",
                        Description = "Cute fall tree",
                        ImageName = "tree.jpg",
                    };
                    pic1.EncodeTitle();
                    _dbContext.Pictures.Add(pic1);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
