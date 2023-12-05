using PictureGallery.Domain.Entities;

namespace PictureGallery.Application.Services
{
    public interface IPictureService
    {
        Task Create(Picture picture);
    }
}