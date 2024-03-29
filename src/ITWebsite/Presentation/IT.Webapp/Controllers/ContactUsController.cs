﻿
using Microsoft.AspNetCore.Mvc;
using IT.Business.Models;
using Microsoft.AspNetCore.Authorization;

namespace IT.Webapp.Controllers
{
    public class ContactUsController : Controller
    {
        [Authorize]
        // GET: ContactUsController
        public ActionResult Index()
        {
            List<ContactUsModel> contact = new List<ContactUsModel>();
            contact.Add(new ContactUsModel { Id = 1, Name = "Ali Khan", Email = "ALIKHAN23@gmail.com",
                Message="Want to apply for HR internship" });
            return View(contact);
        }

        // GET: ContactUsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactUsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactUsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
