using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
    }
}
