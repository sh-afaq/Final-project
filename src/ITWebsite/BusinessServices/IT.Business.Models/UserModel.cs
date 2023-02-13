namespace IT.Business.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Password { get; set; }
    }
}