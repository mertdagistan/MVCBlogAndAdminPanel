using MVCBlog.Areas.Admin.Models.ResultModel;
using MVCBlog.Entity.Models;
using MVCBlog.Repository.ModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.Entity.ViewModel;
using System.IO;

namespace MVCBlog.Areas.Admin.Controllers
{
    
    public class ArticleController : Controller
    {
        
        // GET: Admin/Article

        InstanceResult<Article> result = new InstanceResult<Article>();
        ArticleRepository repoArt = new ArticleRepository();
        CategoryRepository repoCat = new CategoryRepository();
        TagRepository repoTag = new TagRepository();
        ArticleViewModel avml = new ArticleViewModel();

        [Authorize]
        public ActionResult ActiveList()
        {
            result.resultList = repoArt.ActiveList();
            return View(result.resultList.ProcessResult);
        }
        [Authorize]
        public ActionResult InActiveList()
        {
            result.resultList = repoArt.InActiveList();
            return View(result.resultList.ProcessResult);
        }

        [Authorize]
        [HttpGet, ValidateInput(false)]
        public ActionResult AddArticle()
        {
            ArticleViewModel avm = new ArticleViewModel();
            List<SelectListItem> CatList = new List<SelectListItem>();
            List<SelectListItem> actListt = new List<SelectListItem>();
            foreach (Category item in repoCat.List().ProcessResult)
            {
                CatList.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            actListt.Add(new SelectListItem { Value = "True", Text = "Active" });
            actListt.Add(new SelectListItem { Value = "False", Text = "Inactive" });

            avm.CategoryList = CatList;
            avm.Article = null;
            avm.ActiveList = actListt;
            return View(avm);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AddArticle(ArticleViewModel model, HttpPostedFileBase photo)
        {
            
            string PhotoName = null;
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    PhotoName = Path.GetFileNameWithoutExtension(photo.FileName);
                    string extension = Path.GetExtension(photo.FileName);
                    PhotoName = DateTime.Now.ToString("yyyyMMddHHmm") + PhotoName + extension;
                    string path = Server.MapPath("~/Upload/" + PhotoName);
                    photo.SaveAs(path);
                }
            }
            

           

            model.Article.User_ID = 1;
            model.Article.MediaUrl = PhotoName;
            result.resultint = repoArt.Insert(model.Article);
            if (result.resultint.ProcessResult > 0)
            {
                if (model.Article.IsActive==true)
                {
                    return RedirectToAction("ActiveList");
                }
                else
                {
                    return RedirectToAction("InActiveList");
                }
                
            }
            return View(model);
        }

        
        public ActionResult Edit(int id)
        {
            ArticleViewModel avm = new ArticleViewModel();
            List<SelectListItem> CatList = new List<SelectListItem>();
            List<SelectListItem> actListt = new List<SelectListItem>();
            foreach (Category item in repoCat.List().ProcessResult)
            {
                CatList.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.CategoryName });
            }
            actListt.Add(new SelectListItem { Value = "True", Text = "Active" });
            actListt.Add(new SelectListItem { Value = "False", Text = "Inactive" });

            avm.CategoryList = CatList;
            avm.ActiveList = actListt;
            avm.Article = repoArt.GetObjById(id).ProcessResult;
            
            return View(avm);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(ArticleViewModel model, HttpPostedFileBase photo)
        {
            string PhotoName = model.Article.MediaUrl;
            if (photo != null)
            {
                if (photo.ContentLength > 0)
                {
                    PhotoName = Path.GetFileNameWithoutExtension(photo.FileName);
                    string extension = Path.GetExtension(photo.FileName);
                    PhotoName = DateTime.Now.ToString("yyyyMMddHHmm") + PhotoName + extension;
                    string path = Server.MapPath("~/Upload/" + PhotoName);
                    photo.SaveAs(path);
                    
                }
            }
            model.Article.MediaUrl = PhotoName;
            model.Article.User_ID = 1;
            
            result.resultint = repoArt.Update(model.Article);
            if (result.resultint.ProcessResult > 0)
            {
                if (model.Article.IsActive == true)
                {
                    return RedirectToAction("ActiveList");
                }
                else
                {
                    return RedirectToAction("InActiveList");
                }

            }
            return View(model);

        }

        public ActionResult Active(int id)
        {
            Article article = repoArt.GetObjById(id).ProcessResult;
            article.IsActive = true;
            repoArt.Update(article);
            return RedirectToAction("ActiveList");
        }
        public ActionResult Inactive(int id)
        {
            Article article= repoArt.GetObjById(id).ProcessResult;
            article.IsActive = false;
            repoArt.Update(article);
            return RedirectToAction("InActiveList");
        }

        public ActionResult Delete(int id)
        {
            //TODO: Tag' Delete Code

            result.resultint = repoArt.Delete(id);
            return RedirectToAction("InActiveList");
        }

        public ActionResult ArtList(int id)
        {
            result.resultList = repoArt.ArtList(id);
            return View(result.resultList.ProcessResult);
        }

    }
}