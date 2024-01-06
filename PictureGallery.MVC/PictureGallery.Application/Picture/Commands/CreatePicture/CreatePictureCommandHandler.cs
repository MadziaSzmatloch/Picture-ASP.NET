using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using MediatR;
using PictureGallery.Domain.Interfaces;

namespace PictureGallery.Application.Picture.Commands.CreatePicture
{
    public class CreatePictureCommandHandler : IRequestHandler<CreatePictureCommand>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public CreatePictureCommandHandler(IPictureRepository pictureRepository, IMapper mapper, IUserContext userContext)
        {
            _pictureRepository = pictureRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(CreatePictureCommand request, CancellationToken cancellationToken)
        {
            var picture = _mapper.Map<Domain.Entities.Picture>(request);
            picture.EncodeTitle();
            picture.SetImageName();

            picture.CreatedById = _userContext.GetCurrentUser().Id;

            await _pictureRepository.Create(picture);

            return Unit.Value;
        }
    }
}
