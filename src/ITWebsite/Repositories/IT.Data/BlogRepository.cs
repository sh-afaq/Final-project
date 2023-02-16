using IT.Data.Interfaces;
using IT.Data.Models;


namespace IT.Data
{
    public class BlogRepository:Repository<Blog>,IBlogRepository
    {
        public BlogRepository(ITWebsiteDbContext context):base(context)
        {
        }
    }
}
