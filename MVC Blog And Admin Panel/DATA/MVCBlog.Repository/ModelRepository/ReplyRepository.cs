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
    public class ReplyRepository:Repository<Reply,int>
    {
        private static PersonalBlogEntities _db = Tools.GetConnection();
        ResultProcess<Reply> result = new ResultProcess<Reply>();

        public override Result<int> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Result<Reply> GetObjById(int id)
        {
            throw new NotImplementedException();
        }

        public override Result<int> Insert(Reply item)
        {
            
            item.ReplyDate = DateTime.Now;
            _db.Replies.Add(item);
            return result.GetResult(_db);
        }

        public override Result<List<Reply>> List()
        {
            List<Reply> ReplList = _db.Replies.ToList();
            return result.GetListResult(ReplList);
        }

        public override Result<int> Update(Reply item)
        {
            throw new NotImplementedException();
        }
    }
}
