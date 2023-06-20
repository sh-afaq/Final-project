using IT.Business.Interfaces;
using IT.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace IT.Webapp.Controllers
{
    [Authorize]
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
            //this logic says get all page info and show it
            //var models = _blogService.GetAll();
            //return View(models);

            // this logic will be used if you want to implement search feature so if a person is searching
            // only searched one to be shown otherwise the whole page is shown
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(BlogModel model)
        //{
        //    try
        //    {
        //        _blogService.Add(model);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> Create(BlogModel model, IFormFile ImageFile)
        {
            if (ModelState.IsValid)
            {
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    // Validate file extension or other requirements if needed

                    // Generate a unique file name or use the original file name
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);

                    // Specify the destination path to save the uploaded file
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                    // Save the uploaded file to the specified path
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(fileStream);
                    }

                    // Set the ImageUrl property of the model to the saved file path
                    model.ImageUrl = "/Images/" + fileName;
                }

                // Add the model to the database through the _blogService
                _blogService.Add(model);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }



        // GET: BlogController/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
