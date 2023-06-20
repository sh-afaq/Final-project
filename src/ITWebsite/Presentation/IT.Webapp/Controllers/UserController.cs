
using IT.Business.Interfaces;
using IT.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;


namespace IT.Webapp.Controllers
{
    [Authorize]
   
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        //cache
        private readonly IMemoryCache _memoryCache;
        public UserController (IUserService userService, IMemoryCache memoryCache)
        {
            _userService = userService;
            _memoryCache = memoryCache;
        }
        // GET: UserController
        public ActionResult Index(string? search)
        {
            List<UserModel> users ;
           if(search==null)
            {
               users= _userService.GetAll();
                _ = _memoryCache.Set("services", users);
            }
            else
            {
                users = _userService.Search(search).ToList();
            }
            return View(users);
        }



        // GET: UserController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel model)
        {
            try
            {
                _userService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {

           var user= _userService.GetAll().Where(x => x.id==id).FirstOrDefault();
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserModel model)
        {
            try
            {
                _userService.Update(model);
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
