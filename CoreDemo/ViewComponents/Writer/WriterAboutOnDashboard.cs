using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
    WriterManager writerManager = new WriterManager(new EfWriterRepository());
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            var usermail = User.Identity.Name;
            var writeID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriteID).FirstOrDefault();
            var values = writerManager.GetWriterById(writeID);
            return View(values);
        }
    }
}
