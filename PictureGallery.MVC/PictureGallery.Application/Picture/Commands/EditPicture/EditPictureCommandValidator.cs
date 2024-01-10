using FluentValidation;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.EditPicture
{
    public class DeletePictureCommandValidator : AbstractValidator<EditPictureCommand>
    {
        public DeletePictureCommandValidator(IPictureRepository repository)
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(2).WithMessage("Title must not be shorter than 2 characters")
                .MaximumLength(20).WithMessage("Title must not be longer than 20 characters");
            RuleFor(c => c.Description)
                .MinimumLength(2).WithMessage("Description must not be shorter than 2 characters")
                .MaximumLength(100).WithMessage("Description must not be longer than 100 characters");
        }
    }
}
