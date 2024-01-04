using AutoMapper;
using MediatR;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.CreatePicture
{
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        public CreatePictureCommandHandler(IPictureRepository pictureRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var picture = _mapper.Map<Domain.Entities.Picture>(request);
            picture.EncodeTitle();
            picture.SetImageName();

            await _pictureRepository.Create(picture);

            return Unit.Value;
        }
    }
}
