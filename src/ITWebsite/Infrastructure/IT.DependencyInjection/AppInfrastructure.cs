using IT.Business.DataServices;
using IT.Business.Interfaces;
using IT.Data;
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
            // all of custom configuration
            services.AddScoped<IUserService, UserService>();

        }



    }
}