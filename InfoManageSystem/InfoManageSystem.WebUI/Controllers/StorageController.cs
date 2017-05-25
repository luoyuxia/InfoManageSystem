using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;
using System.Threading;

namespace InfoManageSystem.WebUI.Controllers
{
    public class StorageController : Controller
    {
        private IWareHousingListService wareHousingListService;
        private IWarningService warningService;
        public StorageController(IWareHousingListService wareHousingListService,IWarningService warningService)
        {
            this.wareHousingListService = wareHousingListService;
            this.warningService = warningService;
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
            bool result = wareHousingListService.SaveWareHousingList(wareHousingList);
            new Thread(delegate()
            {
                WSController.SendWarnings(warningService);
            }).Start();
            return Json(result,JsonRequestBehavior.AllowGet);

        }

        //商品入库查询视图
        public ActionResult Query()
        {
            return View();
        }

        //商品的入库清单查询

        public JsonResult QueryWarehousingList(int pageIndex=1,int pageSize=10, string Order = "asc",string SortField = "Id",
            string startDate =null,string endDate=null)
        {
            int total = 0;
            QueryModel queryModel = new QueryModel
            {
                pageIndex = pageIndex,
                pageSize = pageSize,
                SortField = SortField,
                Order = Order,
                StartDate = startDate == null ? DateTime.MinValue : DateTime.Parse(startDate),
                EndDate = endDate == null ? DateTime.MaxValue : DateTime.Parse(endDate)
            };
            IEnumerable<WareHousingList> wareHousingLists = wareHousingListService.GetAllShipmentByPage(queryModel, out total).ToList();
            var rows = from wareHousingList in wareHousingLists
                       select new
                       {
                           Id = wareHousingList.Id,
                           EmployeeId = wareHousingList.EmployeeId,
                           Employee = wareHousingList.Employee.Name,
                           WareHousingTime = wareHousingList.WareHousingTime,
                           TotalQuantity = wareHousingList.WareHousingItems.Sum(p => p.Quantity),
                           TotalPrice = wareHousingList.TotalPrice
                       };
            return Json(new { rows = rows, total = total }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWareHousingListDetail(int WareHousingListId)
        {
            IEnumerable<WareHousingItem> wareHousingItems =
                wareHousingListService.GetWareHousingItems(WareHousingListId);
            var result = from wareHousingItem in wareHousingItems
                         select new
                         {
                             WareHousingItemID = wareHousingItem.Id,
                             GoodsId = wareHousingItem.GoodsId,
                             GoodsName = wareHousingItem.Goods.Name,
                             WareHouseId = wareHousingItem.WareHouseId,
                             WareHouse = wareHousingItem.WareHouse.Name,
                             PurchasePrice = wareHousingItem.PurchasePrice,
                             Quantity = wareHousingItem.Quantity
                         };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}