using IT.DataModels;
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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}