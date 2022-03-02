using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class AddProfileImage
    {
        public int WriteID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public IFormFile WriterImage { get; set; }
        public string WriterMail { get; set; }//dosyadan veri çekebilmek için tanımladık
        public string WriterPassword { get; set; }
        public string WriterPasswordAgain { get; set; }
        public bool WriterStatus { get; set; }
    }
}
