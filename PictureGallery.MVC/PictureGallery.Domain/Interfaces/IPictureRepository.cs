using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Domain.Interfaces
{
    public interface IPictureRepository
    {
        Task Create(Domain.Entities.Picture picture);
        Task<Domain.Entities.Picture?> GetByTitle(string title);
        Task<IEnumerable<Domain.Entities.Picture>> GetAll();
        Task<Domain.Entities.Picture> GetByEncodedTitle(string encodedTitle);
        Task Commit();
        Task Delete(Domain.Entities.Picture picture);
    }
}
