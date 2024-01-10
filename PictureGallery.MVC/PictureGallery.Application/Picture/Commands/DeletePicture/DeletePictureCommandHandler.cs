using MediatR;
using PictureGallery.Application.ApplicationUser;
using PictureGallery.Domain.Entities;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.DeletePicture
{
    public class DeletePictureCommandHandler : IRequestHandler<DeletePictureCommand>
    {
        private readonly IPictureRepository _repository;
        private readonly IUserContext _userContext;

        public DeletePictureCommandHandler(IPictureRepository repository, IUserContext userContext)
        {
            _repository = repository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(DeletePictureCommand request, CancellationToken cancellationToken)
        {
            var pictureToDelete = await _repository.GetByEncodedTitle(request.EncodedTitle);

            var user = _userContext.GetCurrentUser();
            bool isEditable = user != null && pictureToDelete.CreatedById == user.Id;
            if (!isEditable)
            {
                return Unit.Value;
            }

            await _repository.Delete(pictureToDelete);
            return Unit.Value;
        }
    }
}
