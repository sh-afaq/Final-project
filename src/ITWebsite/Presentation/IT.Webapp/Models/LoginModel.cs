﻿namespace IT.Webapp.Models
{
    public class LoginModel
    {
        public string Email { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;  
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
