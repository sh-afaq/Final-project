using IT.Business.DataServices;
using IT.Business.Interfaces;
using IT.Data;
using IT.Data.Interfaces;
using IT.DependencyInjection.OptionModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IT.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetup(this IServiceCollection services, IConfiguration configuration)
        {
            
            //configure entity framework
            services.AddDbContext<ITWebsiteDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            
            services.AddScoped<DbContext,ITWebsiteDbContext>();



            //repositories configuration
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            //setting configuration for authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie((CookieOptions) =>
            {
                CookieOptions.LoginPath = "/Identity/Account/Login";
                CookieOptions.Cookie = new CookieBuilder
                {
                    Name = "TechStudio"
                };

            });

            // all of custom configuration

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();
            // automapper configuration
            services.AddAutoMapper(typeof(BusinessEntityMappings));
            //setting up all the option models
            services.Configure<AccountOptions>((option) =>
                {
                    //configure admin account for login to system
                    configuration.GetSection("Account").Bind(option);
                });
            //memory cache setup
            services.AddMemoryCache();
           


        }



    }
}