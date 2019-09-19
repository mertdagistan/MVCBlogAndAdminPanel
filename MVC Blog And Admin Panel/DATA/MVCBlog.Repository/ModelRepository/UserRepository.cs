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
    public class UserRepository : Repository<User, int>
    {
        private static PersonalBlogEntities _db = Tools.GetConnection();
        ResultProcess<User> result = new ResultProcess<User>();
        public override Result<int> Delete(int id)
        {
            User delUser = _db.Users.SingleOrDefault(t => t.Id == id);
            _db.Users.Remove(delUser);
            return result.GetResult(_db);
        }

        public override Result<User> GetObjById(int id)
        {
            User user = _db.Users.SingleOrDefault(t => t.Id == id);
            return result.GetT(user);
        }

        public override Result<int> Insert(User item)
        {
            _db.Users.Add(item);
            return result.GetResult(_db);
        }

        public override Result<List<User>> List()
        {
            List<User> AcList = _db.Users.ToList();
            return result.GetListResult(AcList);
        }

        public override Result<int> Update(User item)
        {
            User user = _db.Users.SingleOrDefault(t => t.Id == item.Id);
            user.FullName = item.FullName;
            user.Email = item.Email;
            user.Role_ID = item.Role_ID;
            user.Password = item.Password;
            return result.GetResult(_db);
        }
    }
}
