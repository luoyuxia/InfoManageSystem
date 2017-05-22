using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.WebUI.Controllers
{
    public class StorageController : Controller
    {
        private IWareHousingListService wareHousingListService;
        public StorageController(IWareHousingListService wareHousingListService)
        {
            this.wareHousingListService = wareHousingListService;
        }
        // GET: Storage
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult StoreIntoWareHouse(List<WareHousingItem> wareHousingItems)
        {
            decimal totalPrice = 0.00M;
            totalPrice = wareHousingItems.Sum(item => item.PurchasePrice * item.Quantity);
            int employeeId = 1;
            WareHousingList wareHousingList = new WareHousingList
            {
                EmployeeId = employeeId,
                TotalPrice = totalPrice,
                WareHousingItems = wareHousingItems,
                WareHousingTime = DateTime.Now
            };
            return Json(wareHousingListService.SaveWareHousingList(wareHousingList),JsonRequestBehavior.AllowGet);

        }
    }
}