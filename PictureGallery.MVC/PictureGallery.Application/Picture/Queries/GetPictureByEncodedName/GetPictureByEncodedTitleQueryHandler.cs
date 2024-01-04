using MediatR;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Queries.GetPictureByEncodedName
{
    public class GetPictureByEncodedTitleQueryHandler : IRequestHandler<GetPictureByEncodedTitleQuery, Domain.Entities.Picture>
    {
        private readonly IPictureRepository _pictureRepository;

        public GetPictureByEncodedTitleQueryHandler(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }
        public async Task<Domain.Entities.Picture> Handle(GetPictureByEncodedTitleQuery request, CancellationToken cancellationToken)
        {
            var picture = await _pictureRepository.GetByEncodedTitle(request.EncodedTitle);
            return picture;
        }
    }
}
