using IT.Webapp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace IT.Webapp.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            //logic for user authentication from database
            if(!(model.Email=="sz@gmail.com" && model.Password=="szafaq"))
            {
                return RedirectToAction(nameof(Login));
            }

            try { 
            //creating list of claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
            };
            //claims identity
            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //creating claims principal object to pass to sig  in method
            var claimsprincipal=new ClaimsPrincipal(claimIdentity);
             //signing in  
            await HttpContext.SignInAsync(claimsprincipal);
            return RedirectToAction("Index", "Home");
            }
            catch (Exception ex) {
                return View(model);
            }
            
            
        }
        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Authentication");
            //return RedirectToAction(nameof(Login));
        }
    }
}
