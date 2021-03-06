using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriteID { get; set; }
        public string WriterName { get; set; }
        public string WriterAbout { get; set; }
        public string WriterImage { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterPasswordAgain { get; set; }
        public bool WriterStatus { get; set; }
        public List<Blog> Blogs { get; set; }
        public virtual ICollection<Message2>  WriterSender { get; set; }
        public virtual ICollection<Message2> WriterReciever { get; set; }
    }
}
