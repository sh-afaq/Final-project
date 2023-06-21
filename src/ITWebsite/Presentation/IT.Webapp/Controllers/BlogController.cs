using IT.Business.Interfaces;
using IT.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using NuGet.ContentModel;
using System.Reflection.Metadata;
using System;

namespace IT.Webapp.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlogService blogService, IWebHostEnvironment webHostEnvironment)
        {
            _blogService= blogService;
            _webHostEnvironment = webHostEnvironment;

        }
        // GET: BlogController
        //public ActionResult Index(string? search)
        //{
        //    //this logic says get all page info and show it
        //    //var models = _blogService.GetAll();
        //    //return View(models);

        //    // this logic will be used if you want to implement search feature so if a person is searching
        //    // only searched one to be shown otherwise the whole page is shown
        //    List<BlogModel> blogs;

        //    if (search == null)
        //    {
        //       blogs = _blogService.GetAll();

        //    }
        //    else
        //    {
        //       blogs = _blogService.Search(search).ToList();
        //    }
        //    return View(blogs);

        //}
        public IActionResult Index(string search)
        {
            List<BlogModel> blogs;

            if (string.IsNullOrEmpty(search))
            {
                blogs = _blogService.GetAll();
            }
            else
            {
                blogs = _blogService.Search(search);
            }

            var blogModels = blogs.Select(blog => new BlogModel
            {
                Id = blog.Id,
                Name = blog.Name,
                Description = blog.Description,
                ImageUrl = blog.ImageUrl ?? string.Empty
            }).ToList();
            return View(blogModels);
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
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    // Generate a unique filename or use the original filename if desired
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;

                    // Save the uploaded image to a directory
                    string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    // Update the ImageUrl property of the model with the image path
                    model.ImageUrl = "/images/" + uniqueFileName;
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
