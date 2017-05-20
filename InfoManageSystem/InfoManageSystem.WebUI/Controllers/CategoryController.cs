using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.WebUI.Controllers
{

    public class CategoryController : Controller
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        // GET: GoodsType
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetCategory(int pageIndex=1,int pageSize=5,string name="")
        {
            int total = 0;
            IEnumerable<Category> categorys = categoryService.getCategoryByName(pageIndex, pageSize, name,out total);

            var result = new { rows = categorys, total = total };
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory(int cateGoryId)
        {
            return Json(new { result = categoryService.deleteCategory(cateGoryId) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCategory(Category category)
        {
            return Json(new { result = categoryService.saveCategory(category) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCategory(Category category)
        {
            return Json(new { result = categoryService.saveCategory(category) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditCategory(Category category)
        {
            string name = category.Name;
            return Json(new {name = 2});
        }
    }
}