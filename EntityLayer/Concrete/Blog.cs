using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }


        //category
        public int CategoryID { get; set; }
        public  Category Category{ get; set; }

        //writer
        public int WriterID { get; set; }
        public Writer Writer { get; set; }

        //comment
        public List<Comment> Comments { get; set; }//bir bloga birden fazla yorum yapılabilir

    }
}
