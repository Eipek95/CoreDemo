using CoreDemo.Models;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]// authorize işlemlerinden geçersiz olan yerler 
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserSignInViewModel appUser)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(appUser.username, appUser.userpassword, false, true);//true ->sisteme 5 defa yanlış girilirse ban yesin.false->çerez
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }            
            return View();
        } 
        //[HttpPost]
        //public async Task<IActionResult> Index(Writer p)
        //{
        //    Context context = new Context();
        //    var dataValue = context.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
        //    x.WriterPassword==p.WriterPassword);
        //    if (dataValue != null)
        //    {
        //        //claims--->talepler
        //        var claims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name,p.WriterMail)
        //        };
        //        var userIdentity = new ClaimsIdentity(claims,"a");
        //        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
        //        await HttpContext.SignInAsync(principal);
        //        return RedirectToAction("Index","Dashboard");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //    //Context context = new Context();
        //    //var dataValue = context.Writers.FirstOrDefault(x=>x.WriterMail==p.WriterMail &&
        //    //x.WriterPassword==p.WriterPassword);
        //    //if (dataValue !=null)
        //    //{
        //    //    HttpContext.Session.SetString("username",p.WriterMail);
        //    //    return RedirectToAction("Index", "Writer");
        //    //}
        //    //else
        //    //{
        //    //return View();
        //    //}
        //}
    }
}
