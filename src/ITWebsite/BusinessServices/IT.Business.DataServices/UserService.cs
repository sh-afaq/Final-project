
using AutoMapper;
using IT.Business.Interfaces;
using IT.Business.Models;
using IT.Data;
using IT.Data.Interfaces;
using IT.Data.Models;

namespace IT.Business.DataServices
{
    public class UserService: GenericService<UserModel,User>,IUserService
    {
        private readonly IRepository<User> _repository;
       
        public UserService(IRepository<User>  repository,IMapper mapper):base (repository,mapper)
        {
            _repository=repository;
        }    
        public List<UserModel> Search(string searchTerm)
        {
            searchTerm = searchTerm.Trim().ToLower();
            var allusers = _repository.Get(x => x.Name.ToLower()
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
       

        
    }
}