using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.WebUI.Controllers
{
    public class DealersController : Controller
    {
        private IDealersService dealersService;
        public DealersController(IDealersService dealersService)
        {
            this.dealersService = dealersService;
        }
        // GET: Dealers
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllDealersPageable(int pageIndex = 1, int pageSize = 10, string name = "")
        {
            int total = 0;
            IEnumerable<Dealers> dealersList = dealersService.GetAllDealers(pageIndex, pageSize, name, out total).ToList();
            var list = from dealers in dealersList
                       select new
                       {
                           Id = dealers.Id,
                           Name = dealers.Name,
                           Phone = dealers.Phone,
                           Address = dealers.Address
                       };
            return Json(new { rows = list, total = total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateDealers(Dealers dealers)
        {
            return Json(new { result = dealersService.SaveDealers(dealers) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllDealers()
        {
            IEnumerable<Dealers> dealersList = dealersService.GetAllDealers();
            var dealersInfo = from dealers in dealersList
                              select new
                              {
                                  Id = dealers.Id,
                                  Title = dealers.Name
                              };
            return Json(dealersInfo,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddDealers(List<Dealers> dealersList)
        {
            bool addSuccess = true;
            foreach(Dealers dealers in dealersList)
            {
                addSuccess = addSuccess && dealersService.SaveDealers(dealers);
            }
            return Json(new { result = addSuccess });
        }
    }
}