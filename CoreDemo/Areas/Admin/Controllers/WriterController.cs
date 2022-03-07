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
        public IActionResult GetWriterByID(int controllerInId)
        {
            var findWriter = writers.FirstOrDefault(x=>x.ID==controllerInId);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(Writer w)
        {
            writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }
        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.ID==id);
            writers.Remove(writer);
            return Json(writer);
        }
        public IActionResult UpdateWriter(Writer w)
        {
            var writer = writers.FirstOrDefault(x => x.ID == w.ID);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
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
