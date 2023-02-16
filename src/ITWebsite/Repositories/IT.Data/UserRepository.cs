using IT.Data.Interfaces;
using IT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Data
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(ITWebsiteDbContext context):base(context)
        {
        }
    }
}
