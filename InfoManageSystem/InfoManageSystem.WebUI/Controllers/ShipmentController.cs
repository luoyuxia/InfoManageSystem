using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.WebUI.Controllers
{
    public class ShipmentController : Controller
    {
        private IWareHouseService wareHouseService;
        private IShipmentService shipmentService;
        public ShipmentController(IWareHouseService wareHouseService,IShipmentService shipmentService)
        {
            this.wareHouseService = wareHouseService;
            this.shipmentService = shipmentService;
        }
        // GET: Shipment
        public ActionResult Index()
        {
            return View();
        }


        //判断某商品在对应的仓库是否有足够的存量
        [HttpPost]
        public JsonResult CanShipmentFromWarehouse(int goodId,int wareHouseId,int quantity)
        {
            return Json(new { canShipment = wareHouseService.HasEnoughGoods(wareHouseId,goodId,quantity) });
        }

        [HttpPost]
        public JsonResult Shipment(List<ShipmentItem> shipmentItemList, int dealerId)
        {
            decimal TotalPrice = shipmentItemList.Sum(p => p.Quantity * p.SellPrice);
            ShipmentList shipmentList = new ShipmentList
            {
                DealersId = dealerId,
                ShipmentTime = DateTime.Now,
                ShipmentItems = shipmentItemList,
                TotalPrice = TotalPrice
            };
            return Json(shipmentService.SaveShipmentList(shipmentList));
        }
    }
}