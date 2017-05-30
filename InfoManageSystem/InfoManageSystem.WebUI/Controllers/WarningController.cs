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
    public class WarningController : Controller
    {
        private IWarningService warningService;
        public WarningController(IWarningService warningService)
        {
            this.warningService = warningService;
        }
        // GET: Warning
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetWarnings()
        {
            IEnumerable<Warning> warnList = warningService.GetWarning().ToList();
            var warning = from warn in warnList
                          select new
                          {
                              GoodsId = warn.GoodsId,
                              GoodName = warn.Goods.Name,
                              MinStorage = warn.Goods.minNum,
                              CurrentStorage = warn.Goods.GoodsStorages.Sum(g => g.Quantity)
                          };
            return Json(warning, JsonRequestBehavior.AllowGet);
        }
    }
}