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
    public class CommentRepository : Repository<Comment, int>
    {
        private static PersonalBlogEntities _db = Tools.GetConnection();
        ResultProcess<Comment> result = new ResultProcess<Comment>();
        public override Result<int> Delete(int id)
        {
            Comment delCom = _db.Comments.SingleOrDefault(t => t.Id == id);
            _db.Comments.Remove(delCom);
            return result.GetResult(_db);
        }

        public override Result<Comment> GetObjById(int id)
        {
            Comment com = _db.Comments.SingleOrDefault(t => t.Id == id);
            return result.GetT(com);
        }

        public override Result<int> Insert(Comment item)
        {
            item.CommentDate = DateTime.Now;
            _db.Comments.Add(item);
            return result.GetResult(_db);
        }

        public override Result<List<Comment>> List()
        {
            List<Comment> comList = _db.Comments.OrderBy(t => t.CommentDate).ToList();
            return result.GetListResult(comList);
        }
        public  Result<List<Comment>> RepComList()
        {
            List<Comment> comList = _db.Comments.Where(t => t.Replies.Count==0).ToList();
            return result.GetListResult(comList);
        }

        public override Result<int> Update(Comment item)
        {
            Comment com = _db.Comments.SingleOrDefault(t => t.Id == item.Id);
            com.Text = item.Text;
            return result.GetResult(_db);
        }
    }
}
