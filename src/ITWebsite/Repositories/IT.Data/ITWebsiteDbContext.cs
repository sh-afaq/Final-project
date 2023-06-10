using IT.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT.Data
{
    public class ITWebsiteDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
       
        public ITWebsiteDbContext(DbContextOptions<ITWebsiteDbContext> options)
        : base(options)    
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }

    }
}