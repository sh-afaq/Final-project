using IT.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Business.Interfaces
{
    public interface IUserService:IGenericService<UserModel>
    {
        public List<UserModel> Search(string searchTerm);
    }
}
