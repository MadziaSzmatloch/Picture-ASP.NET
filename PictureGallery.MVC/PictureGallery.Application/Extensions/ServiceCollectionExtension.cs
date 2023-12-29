using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using PictureGallery.Application.Mappings;
using PictureGallery.Application.Picture;
using PictureGallery.Application.Services;
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
            services.AddScoped<IPictureService, PictureService>();

            services.AddAutoMapper(typeof(PictureMappingProfile));

            services.AddValidatorsFromAssemblyContaining<PictureDtoValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}
