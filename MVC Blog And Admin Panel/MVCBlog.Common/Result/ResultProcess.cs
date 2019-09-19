using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCBlog.Entity.Models;

namespace MVCBlog.Common.Result
{
    public class ResultProcess<T>
    {
        public Result<int> GetResult(PersonalBlogEntities db)
        {
            Result<int> result = new Result<int>();
            //int save = db.SaveChanges();

            int save = db.SaveChanges();
            if (save > 0)
            {
                result.UserMessage = "Successful";
                result.IsSucceeded = true;
                result.ProcessResult = save;
            }
            else
            {
                result.UserMessage = "Unsuccessful";
                result.IsSucceeded = false;
                result.ProcessResult = save;
            }
            return result;
        }
        public Result<List<T>> GetListResult(List<T> data)
        {
            Result<List<T>> result = new Result<List<T>>();
            if (data!=null)
            {
                result.UserMessage = "Successful";
                result.IsSucceeded = true;
                result.ProcessResult = data;
            }
            else
            {
                result.UserMessage = "Unsuccessful";
                result.IsSucceeded = false;
                result.ProcessResult = data;
            }
            return result;
        }
        public Result<T> GetT(T data)
        {
            Result<T> result = new Result<T>();
            if (data != null)
            {
                result.IsSucceeded = true;
                result.UserMessage = "Successful";
                result.ProcessResult = data;
            }
            else
            {
                result.IsSucceeded = false;
                result.UserMessage = "Unsuccessful";
                result.ProcessResult = data;
            }
            return result;

        }
    }
}
