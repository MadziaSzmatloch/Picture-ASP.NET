using PictureGallery.Domain.Entities;
using PictureGallery.Domain.Interfaces;
using PictureGallery.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Infrastructure.Repositories
{
    internal class PictureRepository : IPictureRepository
    {
        private readonly PictureDbContext _dbContext;

        public PictureRepository(PictureDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Create(Picture picture)
        {
            _dbContext.Add(picture);
            await _dbContext.SaveChangesAsync();
        }
    }
}
