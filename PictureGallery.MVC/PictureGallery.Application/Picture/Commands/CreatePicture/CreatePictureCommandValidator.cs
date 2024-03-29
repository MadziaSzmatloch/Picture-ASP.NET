﻿using FluentValidation;
using PictureGallery.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Picture.Commands.CreatePicture
{
    public class CreatePictureCommandValidator : AbstractValidator<CreatePictureCommand>
    {
        public CreatePictureCommandValidator(IPictureRepository repository)
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Title is required")
                .MinimumLength(2).WithMessage("Title must not be shorter than 2 characters")
                .MaximumLength(20).WithMessage("Title must not be longer than 20 characters");
                //.Custom((value, context) =>
                //{
                //    var exisitingPicture = repository.GetByTitle(value).Result;
                //    if (exisitingPicture != null)
                //    {
                //        context.AddFailure($"Title {value} already exists");
                //    }
                //});
            RuleFor(c => c.Description)
                .MinimumLength(2).WithMessage("Description must not be shorter than 2 characters")
                .MaximumLength(30).WithMessage("Description must not be longer than 30 characters");
            RuleFor(c => c.ImageFile)
                .NotEmpty().WithMessage("Image file is required");
        }
    }
}
