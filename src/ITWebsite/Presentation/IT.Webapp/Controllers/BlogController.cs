using IT.Business.Interfaces;
using IT.Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT.Webapp.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService= blogService;
        }
        // GET: BlogController
        public ActionResult Index(string? search)
        {

            //var models = _blogService.GetAll();

            //return View(models);
            List<BlogModel> blogs;
            if (search == null)
            {
               blogs = _blogService.GetAll();
            }
            else
            {
               blogs = _blogService.Search(search).ToList();
            }
            return View(blogs);

        }

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BlogModel model)
        {
            try
            {
                _blogService.Add(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            var blogmodel = _blogService.GetById(id);
            return View(blogmodel);
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BlogModel model)
        {
            try
            {
                _blogService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _blogService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
           
        }

        
    }
}
