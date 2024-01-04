using MediatR;
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

        public EditPictureCommandHandler(IPictureRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(EditPictureCommand request, CancellationToken cancellationToken)
        {
            var picture = await _repository.GetByEncodedTitle(request.EncodedTitle);

            picture.Title = request.Title;
            picture.Description = request.Description;

            await _repository.Commit();

            return Unit.Value;

        }
    }
}
