using IT.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace IT.Data
{
    public class ITWebsiteDbContext : DbContext
    {
       
        public ITWebsiteDbContext(DbContextOptions<ITWebsiteDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }

    }
}