using IT.Business.DataServices.Interfaces;
using IT.Business.Models;
using System.Reflection;

namespace IT.Business.DataServices
{
    public class UserService: IUserServices
    {
        private List<UserModel> user = new List<UserModel>();
        public List<UserModel> GetAll()
        {
            user.Add(new UserModel { id = 1, Name = "Azam Sherazi" });
            user.Add(new UserModel { id = 2, Name = "Faris Sherazi" });
            user.Add(new UserModel { id = 3, Name = "Hamad Sherazi" });
            user.Add(new UserModel { id = 4, Name = "Haroon Sherazi" });
            user.Add(new UserModel { id = 5, Name = "Jameela Sherazi" });
            return user;

        }
        public void Add(UserModel model)
        {
            user.Add(model);
        }
        public void Delete(int id)
        {
            var userToDelete= user.Where(x => x.id == id).FirstOrDefault();
            if(userToDelete != null)
            {
                user.Remove(userToDelete);
            }
           
        }

    }
}