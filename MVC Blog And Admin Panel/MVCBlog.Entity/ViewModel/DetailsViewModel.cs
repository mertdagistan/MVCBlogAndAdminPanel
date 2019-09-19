using MVCBlog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Entity.ViewModel
{
    public class DetailsViewModel
    {
        public Article Article { get; set; }
        public User User { get; set; }
        public Comment Comment { get; set; }
        public Reply Reply { get; set; }
        public Tag Tag { get; set; }
    }
}
