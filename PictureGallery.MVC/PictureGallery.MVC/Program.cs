using Microsoft.EntityFrameworkCore;
using PictureGallery.Infrastructure.Persistence;
using PictureGallery.Infrastructure.Extensions;
using PictureGallery.Infrastructure.Seeders;
using PictureGallery.Application.Extensions;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("PictureDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PictureDbContextConnection' not found.");

//builder.Services.AddDbContext<PictureDbContext>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PictureDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddAplication();

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<PictureGallerySeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
