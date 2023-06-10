namespace IT.Webapp.Models
{
    public class AppUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsLoggedIn { get; private set; }

        public void Login()
        {
            // Simulate login functionality
            IsLoggedIn = true;
            Console.WriteLine($"User {Username} is now logged in.");
        }

        public void Logout()
        {
            // Simulate logout functionality
            IsLoggedIn = false;
            Console.WriteLine($"User {Username} is now logged out.");
        }
    }
}
