
using IT.Business.Interfaces;
using IT.Business.Models;
using IT.Data;
using IT.Data.Models;
using System.Reflection;

namespace IT.Business.DataServices
{
    public class UserService: IUserService
    {
        private readonly ITWebsiteDbContext _dbContext;
        public UserService(ITWebsiteDbContext dbContext)
        {
            _dbContext=dbContext;
        }    
        public List<UserModel> GetAll()
        {
            var allusers = _dbContext.users.ToList();
            var userModels = allusers.Select(x => new UserModel { id = x.id, Name = x.Name }).ToList();
            return userModels;

        }
        public void Add(UserModel model)
        {
            _dbContext.users.Add(new User { id=model.id,Name=model.Name});
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var userToDelete= _dbContext.users.Where(x => x.id == id).FirstOrDefault();
            if(userToDelete != null)
            {
                _dbContext.users.Remove(userToDelete);
                _dbContext.SaveChanges();
            }
           
        }

    }
}