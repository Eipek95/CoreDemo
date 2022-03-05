
using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult CategoryChart()
        {
            List<Category> list = new List<Category>();

            list.Add(new Category { 
                categoryname="Teknoloji",
                categorycount=10
            });
            list.Add(new Category
            {
                categoryname = "Yazilim",
                categorycount = 14
            });
            list.Add(new Category
            {
                categoryname = "Spor",
                categorycount = 5
            });

            return Json(new { jsonlist=list});
        }
    }
}
