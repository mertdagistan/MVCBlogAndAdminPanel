using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlog.Entity.Models;

namespace MVCBlog.Common
{
    public class Tools
    {
        public static PersonalBlogEntities db = null;

        public static PersonalBlogEntities GetConnection()
        {
            if (db == null)
                db = new PersonalBlogEntities();

            return db;
        }

    }
}
