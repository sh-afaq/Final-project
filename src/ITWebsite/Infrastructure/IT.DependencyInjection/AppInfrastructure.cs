using IT.Business.DataServices;
using IT.Business.Interfaces;
using IT.Data;
using IT.Data.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace IT.DependencyInjection
{
    public static class AppInfrastructure
    {
        public static void AppDISetup(this IServiceCollection services, IConfiguration configuration)
        {
            
            //configure entity framework
            services.AddDbContext<ITWebsiteDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            //repositories configuration
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            //setting configuration for authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie((CookieOptions) =>
            {
                CookieOptions.LoginPath = "/Authentication/Login";
                CookieOptions.Cookie = new CookieBuilder {
                    Name= "TechStudio" };

            });

            // all of custom configuration
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBlogService, BlogService>();
            // automapper configuration
            services.AddAutoMapper(typeof(BusinessEntityMappings));

        }



    }
}