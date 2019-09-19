using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MVCBlog.Entity.Models;
using System.Web.Security;
using MVCBlog.Areas.Admin.Models.LoginVM;
using System.Data.Linq;
using MVCBlog.Repository.ModelRepository;
using MVCBlog.Areas.Admin.Models.ResultModel;

namespace MVCBlog.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        CommentRepository repoCom = new CommentRepository();
        [Authorize]
        public ActionResult Index()
        {

            InstanceResult<Comment> result = new InstanceResult<Comment>();

            result.resultList = repoCom.RepComList();
            return View(result.resultList.ProcessResult);
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {

                using (PersonalBlogEntities db=new PersonalBlogEntities())
                {
                    var user = db.Users.FirstOrDefault(x => x.Email == model.EMail && x.Password == model.Password && x.Role_ID==1);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.FullName, true);
                        return RedirectToAction("Index");
                    }
                    
                }
                
            }
            return Redirect("~/Home/Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Home/Index");
        }
    }
}