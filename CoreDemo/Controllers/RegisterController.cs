using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            //deneme şehir çekme
            List<SelectListItem> cities = new()
            {
                new SelectListItem { Value = "1", Text = "Latur" },
                new SelectListItem { Value = "2", Text = "Solapur" },
                new SelectListItem { Value = "3", Text = "Nanded" },
                new SelectListItem { Value = "4", Text = "Nashik" },
                new SelectListItem { Value = "5", Text = "Nagpur" },
                new SelectListItem { Value = "6", Text = "Kolhapur" },
                new SelectListItem { Value = "7", Text = "Pune" },
                new SelectListItem { Value = "8", Text = "Mumbai" },
                new SelectListItem { Value = "9", Text = "Delhi" },
                new SelectListItem { Value = "10", Text = "Noida" }
            };
            ViewBag.cities = cities;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator vR = new WriterValidator();
            ValidationResult result = vR.Validate(p);
            if (result.IsValid)
            {
            p.WriterAbout = "Deneme Test";
            p.WriterStatus = true;
            writerManager.WriterAdd(p);
            return RedirectToAction("Index","Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
