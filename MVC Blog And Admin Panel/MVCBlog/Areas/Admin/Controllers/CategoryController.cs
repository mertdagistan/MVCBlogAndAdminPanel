using MVCBlog.Areas.Admin.Models.ResultModel;
using MVCBlog.Entity.Models;
using MVCBlog.Repository.ModelRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBlog.Areas.Admin.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        InstanceResult<Category> result = new InstanceResult<Category>();
        CategoryRepository repoCat = new CategoryRepository();
        public ActionResult List()
        {
            result.resultList = repoCat.List();
            return View(result.resultList.ProcessResult);
        }

        
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost,ValidateInput(false)]
        public ActionResult AddCategory(Category model)
        {
            result.resultint = repoCat.Insert(model);
            return View("List");
        }

        public ActionResult Edit(int id)
        {
            result.TResult = repoCat.GetObjById(id);
            return View(result.TResult.ProcessResult);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Category model)
        {
            result.resultint = repoCat.Update(model);
            return View();
        }

        public ActionResult Delete(int id)
        {
            result.resultint = repoCat.Delete(id);
            return RedirectToAction("List");
        }

        
    }
}