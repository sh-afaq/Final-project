using IT.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IT.Data
{
    public class ITWebsiteDbContext : IdentityDbContext
    {
       
        public ITWebsiteDbContext(DbContextOptions<ITWebsiteDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }

    }
}