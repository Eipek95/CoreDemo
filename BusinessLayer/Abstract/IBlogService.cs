using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {

        List<Blog> GetBlogListWİthCategory(); 
        List<Blog> GetBlogListWithWriter(int id); 
    }
}
