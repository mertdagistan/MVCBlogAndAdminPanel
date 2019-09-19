using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.Areas.Admin.Models.ResultModel;
using MVCBlog.Entity.Models;
using MVCBlog.Repository.ModelRepository;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        InstanceResult<User> result = new InstanceResult<User>();
        UserRepository repoUser = new UserRepository();
        

        public ActionResult List()
        {
            result.resultList = repoUser.List();
            return View(result.resultList.ProcessResult.Where(x=>x.Role_ID==2));
        }
       





        
        [HttpPost]
        public ActionResult guestComment(Comment com,User user)
        {
            CommentRepository repoCom = new CommentRepository();

            user.Role_ID = 2;
            repoUser.Insert(user);

            com.User_ID = user.Id;
            repoCom.Insert(com);
            return Redirect("~/Home/Details/"+com.Article_ID);
        }

        [HttpPost]
        public ActionResult AdminReply(Reply reply)
        {
            
            ReplyRepository repoRep = new ReplyRepository();
            reply.User_ID = 1;
            repoRep.Insert(reply);
            return Redirect("~/Home/Details" + reply.Article_ID);
        }
    }
}