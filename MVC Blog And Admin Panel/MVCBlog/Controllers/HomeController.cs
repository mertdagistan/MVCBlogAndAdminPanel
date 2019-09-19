using MVCBlog.Areas.Admin.Models.ResultModel;
using MVCBlog.Entity.Models;
using MVCBlog.Entity.ViewModel;
using MVCBlog.Repository.ModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        InstanceResult<Article> result = new InstanceResult<Article>();
        ArticleRepository repoArt = new ArticleRepository();
        ArticleViewModel avm = new ArticleViewModel();
        
        public ActionResult Index()
        {


            result.resultList = repoArt.ActiveList();
            return View(result.resultList.ProcessResult);
        }

        public ActionResult Details(int id)
        {
            Article article= repoArt.GetObjById(id).ProcessResult;
            return View(article);
        }

        
    }
}