using IT.Business.Models;


namespace IT.Business.Interfaces
{
    public interface IUserService:IGenericService<UserModel>
    {
        public List<UserModel> Search(string searchTerm);
    }
}
