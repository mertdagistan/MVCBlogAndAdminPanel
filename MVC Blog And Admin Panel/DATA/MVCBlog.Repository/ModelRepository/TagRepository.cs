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
    public class TagRepository : Repository<Tag, int>
    {
        private static PersonalBlogEntities _db = Tools.GetConnection();
        ResultProcess<Tag> result = new ResultProcess<Tag>();
        public override Result<int> Delete(int id)
        {
            Tag delTag = _db.Tags.SingleOrDefault(t => t.Id == id);
            _db.Tags.Remove(delTag);
            return result.GetResult(_db);
        }

        public override Result<Tag> GetObjById(int id)
        {
            return result.GetT(_db.Tags.SingleOrDefault(t => t.Id == id));
        }

        public override Result<int> Insert(Tag item)
        {
            _db.Tags.Add(item);
            return result.GetResult(_db);
        }

        public override Result<List<Tag>> List()
        {
            return result.GetListResult(_db.Tags.ToList());
        }

        public override Result<int> Update(Tag item)
        {
            Tag upTag = _db.Tags.SingleOrDefault(t => t.Id == item.Id);
            upTag.TagName = item.TagName;
            return result.GetResult(_db);
        }
    }
}
