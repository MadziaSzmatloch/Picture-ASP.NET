using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PictureGallery.Domain.Interfaces;
using PictureGallery.Infrastructure.Persistence;
using PictureGallery.Infrastructure.Repositories;
using PictureGallery.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureGallery.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<PictureDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("PictureGallery")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<PictureDbContext>();

            services.AddScoped<PictureGallerySeeder>();
            services.AddScoped<IPictureRepository, PictureRepository>();

        }

    }
}
