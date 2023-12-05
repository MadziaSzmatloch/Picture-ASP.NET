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
    }
}
