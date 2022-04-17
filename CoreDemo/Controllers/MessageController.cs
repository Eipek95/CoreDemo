using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager message2Manager = new Message2Manager(new EfMessage2Repository());
        Context context = new Context();
        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writeID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriteID).FirstOrDefault();
            var values = message2Manager.GetInboxListByWriter(writeID);
            return View(values);
        }
        public IActionResult MessageDetails(int id)
        {
            var value = message2Manager.TGetById(id);
            return View(value);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writeID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriteID).FirstOrDefault();
            p.SenderID = writeID;
            p.RecieverID = 2;
            p.MessageStatus = true;
            p.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()) ;
            message2Manager.TAdd(p);
            return RedirectToAction("Inbox");
        }
        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writeID = context.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriteID).FirstOrDefault();
            var values = message2Manager.GetSendboxListByWriter(writeID);
            return View(values);
        }
    }
}
