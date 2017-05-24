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


        //保存出货单
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

        //出货记录查询视图
        public ActionResult Query()
        {
            return View();
        }

        [HttpPost]
        public JsonResult QueryShipmentRecord(int pageIndex=1,int pageSize=10,string Order = "asc",string SortField="Id",
            string startDate=null,string endDate = null)
        {
            int total = 0;
            QueryModel queryModel = new QueryModel
            {
                StartDate = startDate == null ? DateTime.MinValue : DateTime.Parse(startDate),
                EndDate = endDate == null ? DateTime.MaxValue : DateTime.Parse(endDate),
                pageIndex = pageIndex,
                pageSize = pageSize,
                SortField = SortField,
                Order = Order
            };
            var list = shipmentService.GetAllShipmentByPage(queryModel, out total).ToList();
            var result = from shipmentList in list
                         select new
                         {
                             Id = shipmentList.Id,
                             DealersId = shipmentList.DealersId,
                             Dealers = shipmentList.Dealers.Name,
                             ShipmentTime = shipmentList.ShipmentTime.ToString(),
                             TotalPrice = shipmentList.TotalPrice
                         };
            return Json(new { rows = result, total = total },JsonRequestBehavior.AllowGet);
        }

        //得到一条出货记录的详细信息,每一条出货项以及出货数量
        public JsonResult GetShipmentDetail(int shipmentListId)
        {
            var shipmentItemList = shipmentService.GetShipmentItems(shipmentListId).ToList();
            var result = from shipmentItem in shipmentItemList
                         select new
                         {
                             ShipmentItemId = shipmentItem.Id,
                             GoodsId = shipmentItem.GoodsId,
                             GoodsName = shipmentItem.Goods.Name,
                             WareHouseId = shipmentItem.WareHouseId,
                             WareHouse = shipmentItem.WareHouse.Name,
                             SellPrice = shipmentItem.SellPrice,
                             Quantity = shipmentItem.Quantity
                         };
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}