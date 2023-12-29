using PictureGallery.Application.Picture;
using PictureGallery.Domain.Entities;

namespace PictureGallery.Application.Services
{
    public interface IPictureService
    {
        Task Create(PictureDto picture);
    }
}