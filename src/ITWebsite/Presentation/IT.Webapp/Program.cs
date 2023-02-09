using IT.Business.DataServices;

using IT.Business.Interfaces;
using IT.Data;
using Microsoft.EntityFrameworkCore;

namespace IT.Webapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //configure entity framework
            builder.Services.AddDbContext<ITWebsiteDbContext>(
            options => options.UseSqlServer("Data Source=localhost;Database=ITWebsite;Integrated Security=SSPI;TrustServerCertificate=True;"));
            // all of custom configuration
            builder.Services.AddSingleton<IUserService,UserService>();
            var app = builder.Build();

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

            app.Run();
        }
    }
}