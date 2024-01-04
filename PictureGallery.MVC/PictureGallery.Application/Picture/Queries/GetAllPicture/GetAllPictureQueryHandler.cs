using MediatR;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Queries.GetAllPicture
{
    public class GetAllPictureQueryHandler : IRequestHandler<GetAllPictureQuery, IEnumerable<Domain.Entities.Picture>>
    {
        private readonly IPictureRepository _pictureRepository;

        public GetAllPictureQueryHandler(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Picture>> Handle(GetAllPictureQuery request, CancellationToken cancellationToken)
        {
            var pictures = await _pictureRepository.GetAll();
            return pictures;
        }
    }
}
