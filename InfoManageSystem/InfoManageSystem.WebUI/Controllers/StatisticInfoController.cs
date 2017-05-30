using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InfoManageSystem.Service.IService;
using InfoManageSystem.ViewModel.Model;

namespace InfoManageSystem.WebUI.Controllers
{
    [Authorize]
    public class StatisticInfoController : Controller
    {
        private IStatisticInfoService statisticInfoService;
        public StatisticInfoController(IStatisticInfoService statisticInfoService)
        {
            this.statisticInfoService = statisticInfoService;
        }
        // GET: StatisticInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DealersStatistic()
        {
            return View();
        }

        [HttpPost]
        public JsonResult TypeStatistic(string startDate,string endDate)
        {
            DateTime start = startDate == "" ? DateTime.MinValue : DateTime.Parse(startDate);
            DateTime end = endDate == "" ? DateTime.MaxValue : DateTime.Parse(endDate);
            return Json(statisticInfoService.getTypeQuantityByDate(start, end));
            
        }

        //商品类别的入库统计信息

        [HttpPost]
        public JsonResult TypeWareHousing(string startDate,string endDate)
        {
            DateTime start = startDate == "" ? DateTime.MinValue : DateTime.Parse(startDate);
            DateTime end = endDate == "" ? DateTime.MaxValue : DateTime.Parse(endDate);
            return Json(statisticInfoService.getTypeWareHousingStatistic(start, end));
        }

        [HttpPost]
        public JsonResult GoodsSaleStatistic(string startDate="",string endDate="",int top = 10)
        {
            DateTime start = startDate == "" ? DateTime.MinValue : DateTime.Parse(startDate);
            DateTime end = endDate == "" ? DateTime.MaxValue : DateTime.Parse(endDate);
            return Json(statisticInfoService.getGoodsSaleStatistic(start, end, top));
        }

        [HttpPost]
        public JsonResult DealersStatistic(string startDate="",string endDate="",int top = 10)
        {
            DateTime start = startDate == "" ? DateTime.MinValue : DateTime.Parse(startDate);
            DateTime end = endDate == "" ? DateTime.MaxValue : DateTime.Parse(endDate);
            return Json(statisticInfoService.getDealersStockStatistic(start, end, top));
        }

        [HttpPost]
        public JsonResult GetDealersSaticByTimeSlot(int dealerId,string startDate="",string endDate="")
        {
            DateTime start = startDate == "" ? DateTime.MinValue : DateTime.Parse(startDate);
            DateTime end = endDate == "" ? DateTime.MaxValue : DateTime.Parse(endDate);
            return Json(statisticInfoService.getDealersShipmentRecordBySlot(dealerId, start, end));
        }

        public ActionResult SaleStatistic()
        {
            return View();
        }

        //得到销售时间-销售总额的统计

        [HttpPost]
        public JsonResult GetSaleDateStatistic(string type = "day",string startDate="",string endDate="")
        {
            DateTime start = startDate == "" ? DateTime.MinValue : DateTime.Parse(startDate);
            DateTime end = endDate == "" ? DateTime.MaxValue : DateTime.Parse(endDate);
            if (type == "day")
            {
                return Json(statisticInfoService.getSaleStatisticInfoByDay(start, end));
            }
            else
                return Json(statisticInfoService.getSaleStatisticInfoByMonth(start, end));
        }
    }
}