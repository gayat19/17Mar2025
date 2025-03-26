using ClinicApplication.Contexts;
using ClinicApplication.Interfaces;
using ClinicApplication.Models;
using ClinicApplication.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ClinicContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();
            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Doctor}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
