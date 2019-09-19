using MVCBlog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Entity.ViewModel
{
    public class ArticleViewModel
    {
        public Article Article { get; set; }
        public Tag Tag { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> ActiveList { get; set; }
    }
}
