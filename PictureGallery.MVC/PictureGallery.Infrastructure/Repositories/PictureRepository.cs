using PictureGallery.Domain.Entities;
using PictureGallery.Domain.Interfaces;
using PictureGallery.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PictureGallery.Infrastructure.Repositories
{
    internal class PictureRepository : IPictureRepository
    {
        private readonly PictureDbContext _dbContext;
        private readonly IHostingEnvironment _hostEnvironment;

        public PictureRepository(PictureDbContext dbContext, IHostingEnvironment hostEnvironment )
        {
            _dbContext = dbContext;
            _hostEnvironment = hostEnvironment;
        }

        public Task Commit()
         => _dbContext.SaveChangesAsync();

        public async Task Create(Picture picture)
        {
            _dbContext.Add(picture);

            string path = Path.Combine(_hostEnvironment.WebRootPath + "/images/", picture.ImageName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await picture.ImageFile.CopyToAsync(fileStream);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Picture picture)
        {
            _dbContext.Pictures.Remove(picture);

            string path = Path.Combine(_hostEnvironment.WebRootPath + "/images/", picture.ImageName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Picture>> GetAll()
         =>  await _dbContext.Pictures.ToListAsync();

        public async Task<Picture> GetByEncodedTitle(string encodedTitle)
         => await _dbContext.Pictures.FirstAsync(c => c.EncodedTitle == encodedTitle);

        public Task<Domain.Entities.Picture?> GetByTitle(string title)
            => _dbContext.Pictures.FirstOrDefaultAsync(p => p.Title.ToLower() == title.ToLower());
    }
}
