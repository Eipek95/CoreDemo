using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            
            return Json(jsonWriters);
        }
        public static List<Writer> writers = new List<Writer>
        {
            new Writer
            {
                ID=1,
                Name="Ayse"
            },
            new Writer
            {
                ID=2,
                Name="Ferhat"
            },
            new Writer
            {
                ID=3,
                Name="Buse"
            },
        };
    }
}
