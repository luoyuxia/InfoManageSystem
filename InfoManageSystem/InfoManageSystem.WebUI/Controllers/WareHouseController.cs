using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Service.IService;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.WebUI.Controllers
{
    [Authorize]
    public class WareHouseController : Controller
    {
        private IGoodsService goodService;
        private IWareHouseService wareHouseService;

        public WareHouseController(IWareHouseService wareHouseService,IGoodsService goodService)
        {
            this.wareHouseService = wareHouseService;
            this.goodService = goodService;
        }
        // GET: WareHouse
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllWareHouse(int pageIndex=1,int pageSize = 10)
        {
            int total = 0;
            IEnumerable<WareHouse> wareHouseList = wareHouseService.GetAllWareHouse(pageIndex, pageSize, out total).ToList();
            var list = from wareHouse in wareHouseList
                       select new
                       {
                           Id = wareHouse.Id,
                           Name = wareHouse.Name,
                           Location = wareHouse.Location,
                           Capacity = wareHouse.Capacity,
                           //该仓库的总共存货量
                           totalStorage = wareHouse.GoodsStorages.Sum(s => s.Quantity)
                       };
            return Json(new { rows = list, total = total },JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetWareHosueTypeList()
        {
            List<object> wareHouseTypes = new List<object>();
            string[] houseTypesLocal ={ "小容量", "中等容量", "大容量" };
            int i = 0;
            foreach(WareHouseCapacity wareHouseCapacity in Enum.GetValues(typeof(WareHouseCapacity)))
            {
                wareHouseTypes.Add(new { Id = wareHouseCapacity, Title = houseTypesLocal[i]});
                i++;
            }
            return Json(wareHouseTypes, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateWareHouse(WareHouse wareHouse)
        {
            return Json(new { result = wareHouseService.SaveWareHosue(wareHouse) }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddWareHosue(List<WareHouse> wareHouseList)
        {
            bool addSuccess = true;
            foreach(WareHouse wareHouse in wareHouseList)
            {
                addSuccess = addSuccess && wareHouseService.SaveWareHosue(wareHouse);
            }
            return Json(new { result = addSuccess }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteWareHouse(List<int> wareHouseIdList)
        {
            bool deleteSuccess = true;
            foreach(int id in wareHouseIdList)
            {
                deleteSuccess = deleteSuccess && wareHouseService.DeleteWareHosue(id);
            }
            return Json(new { result = deleteSuccess }, JsonRequestBehavior.AllowGet);
        }


        //以key value 的形式返回仓库的简要信息
        public JsonResult GetWareHouseInfo()
        {
            IEnumerable<WareHouse> wareHouseList = wareHouseService.GetAllWareHouse();
            var wareHouseInfo = from warehouse in wareHouseList
                                select new
                                {
                                    Id = warehouse.Id,
                                    Title = warehouse.Name
                                };
            return Json(wareHouseInfo, JsonRequestBehavior.AllowGet);
            
        }

        //返回商品在仓库的存储详情的视图
        public ActionResult WareHouseStorage()
        {
            return View();
        }

        //返回商品在仓库的存储情况
        public JsonResult GetGoodsWareHouseStorage(int pageIndex=1,int pageSize = 10,string name="")
        {
            int total = 0;
            IEnumerable<GoodsStorageInfo> info = goodService.GetGoodsWareHouseStorage(pageIndex, pageSize, name, out total);
            return Json(new { rows = info, total = total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateGoodsStorage(int wareHouseId,int goodsId,int quantity)
        {
            bool isUpdateSuccess = wareHouseService.UpdateGoodsStorage(wareHouseId, goodsId, quantity);
            return Json(isUpdateSuccess);
        }


    }
}