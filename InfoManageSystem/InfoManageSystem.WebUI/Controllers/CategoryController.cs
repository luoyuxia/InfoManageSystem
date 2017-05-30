using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.WebUI.Controllers
{

    [Authorize]
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

            var list = from category in categorys
                       select new
                       {
                           Id = category.Id,
                           Name = category.Name,
                           Description = category.Description
                       };

            var result = new { rows = list, total = total };
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCategory()
        {
            IEnumerable<Category> categorys = categoryService.getAllCategory();
            var result = from category in categorys
                         select new
                         {
                             ID = category.Id,
                             Name = category.Name
                         };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategory(List<int> categoryId)
        {
            bool deleteSuccess = true;
            foreach(int id in categoryId)
            {
                deleteSuccess = deleteSuccess && categoryService.deleteCategory(id);
            }
            return Json(new { result = deleteSuccess }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddCategory(List<Category> categorys)
        {
            bool addSuccess = true;
            foreach(Category c in categorys)
            {
                addSuccess = addSuccess && categoryService.saveCategory(c);
            }

            return Json(new { result = addSuccess }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateCategory(Category category)
        {
            return Json(new { result = categoryService.saveCategory(category) }, JsonRequestBehavior.AllowGet);
        }
    }
}