
using IT.Business.Interfaces;
using IT.Business.Models;
using IT.Data;
using IT.Data.Interfaces;
using IT.Data.Models;

namespace IT.Business.DataServices
{
    public class UserService: IUserService
    {
        private readonly IRepository<User> _dbContext;
        public UserService(IRepository<User>  dbContext)
        {
            _dbContext=dbContext;
        }    
        public List<UserModel> GetAll()
        {
            var allusers = _dbContext.GetAll();
            var userModels = allusers.Select(x => new UserModel 
            { id=x.Id, Name = x.Name ,Email=x.Email, Password=x.Password
            }).ToList();
            return userModels;

        }
        public List<UserModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allusers = _dbContext.Get(x => x.Name.ToLower()
                .Contains(searchTerm) ||
                x.Email.ToLower().Contains(searchTerm)).ToList();
            var userModels = allusers.Select(x => new UserModel
            {
                id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password
            }).ToList();
            return userModels;
        }
        public void Add(UserModel model)
        {
            _dbContext.Save(new User
            { Id=model.id,Name=model.Name,Email=model.Email,Password=model.Password});
            //_dbContext.SaveChanges();
        }
        public void Update(UserModel model)
        {
            _dbContext.Save(new User
            { Id = model.id, Name = model.Name, Email = model.Email, Password = model.Password });
            
            
        }
        public void Delete(int id)
        {
            var userToDelete= _dbContext.Get(x => x.Id == id).FirstOrDefault();
            if(userToDelete != null)
            {
                _dbContext.Delete(userToDelete);
               
            }
           
        }

        
    }
}