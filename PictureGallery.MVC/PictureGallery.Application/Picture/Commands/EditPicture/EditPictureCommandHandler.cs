using MediatR;
using PictureGallery.Application.ApplicationUser;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.EditPicture
{
    public class EditPictureCommandHandler : IRequestHandler<EditPictureCommand>
    {
        private readonly IPictureRepository _repository;
        private readonly IUserContext _userContext;

        public EditPictureCommandHandler(IPictureRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }
        public async Task<Unit> Handle(EditPictureCommand request, CancellationToken cancellationToken)
        {
            var picture = await _repository.GetByEncodedTitle(request.EncodedTitle);

            var user = _userContext.GetCurrentUser();
            bool isEditable = user != null && picture.CreatedById == user.Id;
            if (!isEditable)
            {
                return Unit.Value;
            }

            picture.Title = request.Title;
            picture.Description = request.Description;

            await _repository.Commit();

            return Unit.Value;

        }
    }
}
