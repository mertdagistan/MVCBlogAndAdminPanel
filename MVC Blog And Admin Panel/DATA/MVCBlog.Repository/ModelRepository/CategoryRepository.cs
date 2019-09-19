using MVCBlog.Common;
using MVCBlog.Common.Result;
using MVCBlog.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Repository.ModelRepository
{
    public class CategoryRepository : Repository<Category, int>
    {
        private static PersonalBlogEntities _db = Tools.GetConnection();
        ResultProcess<Category> result = new ResultProcess<Category>();
        public override Result<int> Delete(int id)
        {
            Category delCat = _db.Categories.SingleOrDefault(t => t.CategoryId == id);
            _db.Categories.Remove(delCat);
            return result.GetResult(_db);
        }

        public override Result<Category> GetObjById(int id)
        {
            Category c = _db.Categories.SingleOrDefault(t => t.CategoryId == id);
            return result.GetT(c);
        }

        public override Result<int> Insert(Category item)
        {
            item.CreateDate = DateTime.Now;
            _db.Categories.Add(item);
            return result.GetResult(_db);
        }
       
        public override Result<List<Category>> List()
        {
            List<Category> CatList = _db.Categories.OrderBy(t=>t.CategoryName).ToList();
            return result.GetListResult(CatList);
        }
        public  Result<List<Category>> PopularList()
        {
            List<Category> CatList = _db.Categories.OrderByDescending(t => t.Articles.Count()).ToList();
            return result.GetListResult(CatList);
        }
        public override Result<int> Update(Category item)
        {
            Category c = _db.Categories.SingleOrDefault(t => t.CategoryId == item.CategoryId);
            c.CategoryName = item.CategoryName;
            return result.GetResult(_db);
        }
    }
}
