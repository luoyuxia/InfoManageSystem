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
    public class GoodsController : Controller
    {
        private IGoodsService goodsService;
        public GoodsController(IGoodsService goodsService)
        {
            this.goodsService = goodsService;
        }
        // GET: Goods
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllGoods(int pageIndex=1, int pageSize=10, string name="")
        {
            int totalCount = 0;
            IEnumerable<Goods> allGoods = goodsService.GetAllGoodsPageableByName(pageIndex, pageSize, name, out totalCount).ToList();
            var list = from goods in allGoods
                       select new
                       {
                           Id = goods.Id,
                           Name = goods.Name,
                           minNum = goods.minNum,
                           Price = goods.Price,
                           CategoryId = goods.CategoryId
                       };
            return Json(new { rows = list, total = totalCount }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult UpdateGoods(Goods goods)
        {
            return Json(goodsService.SaveGoods(goods), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddGoods(List<Goods> goodsList)
        {
            bool addSuccess = true;
            foreach(Goods goods in goodsList)
            {
                addSuccess = addSuccess && goodsService.SaveGoods(goods);
            }
            return Json(new { result = addSuccess }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteGoods(List<int> goodsIdList)
        {
            bool deleteSuccess = true;
            foreach(int id in goodsIdList)
            {
                deleteSuccess = deleteSuccess && goodsService.DeleteGoods(id);
            }
            return Json(new { result = deleteSuccess }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGoodsInfo()
        {
            IEnumerable<Goods> allGoods = goodsService.GetAllGoodsByName("");
            var goodsInfo = from goods in allGoods
                            select new
                            {
                                Id = goods.Id,
                                Title = goods.Name
                            };
            return Json(goodsInfo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult HasGoods(int GoodsId)
        {
            return Json(goodsService.GetSingleGoods(GoodsId) != null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSingleGoods(int GoodsId)
        {
            Goods goods = goodsService.GetSingleGoods(GoodsId);
            return Json(new { Id = goods.Id, SellPrice = goods.Price }, JsonRequestBehavior.AllowGet);
        }


    }
}