
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
            var userModels = allusers.Select(x => new UserModel 
            { id = x.id, Name = x.Name ,Email=x.Email, Password=x.Password
            }).ToList();
            return userModels;

        }
        public List<UserModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allusers = _dbContext.users.Where(x => x.Name.ToLower()
                .Contains(searchTerm) ||
                x.Email.ToLower().Contains(searchTerm)).ToList();
            var userModels = allusers.Select(x => new UserModel
            {
                id = x.id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password
            }).ToList();
            return userModels;
        }
        public void Add(UserModel model)
        {
            _dbContext.users.Add(new User
            { id=model.id,Name=model.Name,Email=model.Email,Password=model.Password});
            _dbContext.SaveChanges();
        }
        public void Update(UserModel model)
        {
            var entity = _dbContext.users.FirstOrDefault(x => x.id == model.id);
            if (entity != null)
            {
                entity.Name = model.Name;
                entity.Email= model.Email;
                entity.Password = model.Password;
                _dbContext.SaveChanges();
            }
            
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