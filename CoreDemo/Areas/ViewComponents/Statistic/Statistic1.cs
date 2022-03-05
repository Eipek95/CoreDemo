using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreDemo.Areas.ViewComponents.Statistic
{
    public class Statistic1:ViewComponent
    {
        BlogManager blogManager = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = blogManager.GetList().Count();
            ViewBag.v2 = context.Contacts.Count();
            ViewBag.v3 = context.Comments.Count();
            string api = "510d7084d91e4235a37b8fcc6f820273";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Konya&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
