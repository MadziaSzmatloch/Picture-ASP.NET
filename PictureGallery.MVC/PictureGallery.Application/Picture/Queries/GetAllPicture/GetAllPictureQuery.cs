using MediatR;

namespace PictureGallery.Application.Picture.Queries.GetAllPicture
{
    public class GetAllPictureQuery : IRequest<IEnumerable<Domain.Entities.Picture>>
    {
    }
}
