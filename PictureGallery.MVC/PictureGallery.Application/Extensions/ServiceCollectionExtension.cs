using CarWorkshop.Application.ApplicationUser;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PictureGallery.Application.Mappings;
using PictureGallery.Application.Picture.Commands.CreatePicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
            services.AddMediatR(typeof(CreatePictureCommand));

            services.AddAutoMapper(typeof(PictureMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreatePictureCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
