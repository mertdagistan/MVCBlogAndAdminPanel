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
    public class ArticleRepository : Repository<Article, int>
    {
        private static PersonalBlogEntities _db = Tools.GetConnection();
        ResultProcess<Article> result = new ResultProcess<Article>();

        public override Result<int> Delete(int id)
        {
            Article delArt = _db.Articles.SingleOrDefault(t => t.Id == id);

            _db.Articles.Remove(delArt);
            //var tagDelete = from arTag in _db.Tags
            //                where arTag.Article_ID == id
            //                select arTag;

            //foreach (var tag in tagDelete)
            //{
            //    _db.Tags.Remove(tag);
            //}
            return result.GetResult(_db);
        }

        public override Result<Article> GetObjById(int id)
        {
            return result.GetT(_db.Articles.SingleOrDefault(t => t.Id == id));
        }

        public override Result<int> Insert(Article item)
        {
            item.CreateDate = DateTime.Now;
            _db.Articles.Add(item);
            return result.GetResult(_db);
        }

        public override Result<List<Article>> List()
        {
            return result.GetListResult(_db.Articles.ToList());
        }

        public  Result<List<Article>> ActiveList()
        {
            var activeList = _db.Articles.Where(x => x.IsActive == true).ToList();

            return result.GetListResult(activeList);
        }
        public Result<List<Article>> InActiveList()
        {
            var InActiveList = _db.Articles.Where(x => x.IsActive == false).ToList();

            return result.GetListResult(InActiveList);
        }

        public Result<List<Article>> ArtList(int id)
        {
            List<Article> artList = _db.Articles.Where(t => t.Category_ID == id).ToList();
            return result.GetListResult(artList);
        }
        //TODO: EDIT LIST
        public Result<List<Article>> PopularList()
        {
            var popList = _db.Articles.OrderByDescending(x => x.Views).Take(2).ToList();
            return result.GetListResult(popList);
        }
        public Result<List<Article>> RecentList()
        {
            var popList = _db.Articles.OrderBy(x => x.CreateDate).Take(2).ToList();
            return result.GetListResult(popList);
        }
        public override Result<int> Update(Article item)
        {
            Article updArt = _db.Articles.SingleOrDefault(t => t.Id == item.Id);
            updArt.Tags = item.Tags;
            
            updArt.Text = item.Text;
            updArt.Title = item.Title;
            updArt.MediaUrl = item.MediaUrl;
            updArt.IsActive = item.IsActive;
            updArt.Category_ID = item.Category_ID;
            return result.GetResult(_db);
        }
    }
}
