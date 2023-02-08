using IT.Business.Models;


namespace IT.Business.DataServices.Interfaces
{
    public interface IUserServices
    {
        
       public List<UserModel> GetAll();
        public void Add(UserModel model);
        public void Delete(int id);
    }
}
