using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.ViewModel.Model;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.Service.Service
{
    public class StatisticInfoService:IStatisticInfoService
    {
        private IStatisticInfoRespository respository;
        public StatisticInfoService(IStatisticInfoRespository respository)
        {
            this.respository = respository;
        }

        public IEnumerable<DealersStatistic> getDealersShipmentRecordBySlot(int dealersId,DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT DealersId as DealersId,dealers.Name as DealersName " +
                        ", DATE_FORMAT(shipmentlist.ShipmentTime, '%Y-%m') as DateSlot " +
                        ",sum(shipmentlist.TotalPrice)" +
                        " as TotalMoney FROM shipmentlist, dealers" +
                        " WHERE shipmentlist.ShipmentTime>=@p1 AND shipmentlist.ShipmentTime<@p2 AND" 
                        +" shipmentlist.DealersId = @p0 AND shipmentlist.DealersId = dealers.Id" +
                        " GROUP BY DATE_FORMAT(shipmentlist.ShipmentTime, '%Y-%m'); ";
            object[] myParams = { dealersId, startDate, endDate };
            return respository.countDealersStatistic(sql, myParams);
        }

        public IEnumerable<DealersStock> getDealersStockStatistic(DateTime startDate, DateTime endDate, int top = 10)
        {
            string sql = "SELECT dealers.Id as DealersId " +
                        ", dealers.Name as DealersName " +
                        ",sum(shipmentlist.TotalPrice) as TotalMoney " +
                        " FROM shipmentlist, dealers" +
                        " WHERE shipmentlist.ShipmentTime >= @p0 AND shipmentlist.ShipmentTime < @p1" +
                        " AND shipmentlist.DealersId = dealers.Id " +
                        " GROUP BY dealers.Id,dealers.Name " +
                        " ORDER BY TotalMoney DESC LIMIT 0,@p2; ";
            object[] myParams = { startDate, endDate, top };
            return respository.countDealersStock(sql, myParams);
        }

        public IEnumerable<GoodsSale> getGoodsSaleStatistic(DateTime startDate, DateTime endDate, int top = 10)
        {
            string sql = "SELECT goods.Id as GoodsId,goods.Name as GoodsName,"+
                    " sum(shipmentitem.Quantity) as TotalQuantity," + 
                    " sum(shipmentitem.Quantity * shipmentitem.SellPrice) as TotalSaleMoney " + 
                    " FROM shipmentitem, shipmentlist, goods " +
                    " WHERE shipmentlist.ShipmentTime >= @p0 AND shipmentlist.ShipmentTime < @p1" +
                    " AND  goods.Id = shipmentitem.GoodsId "+ 
                    " AND shipmentitem.ShipmentList_Id = shipmentlist.Id"+
                    " GROUP BY goods.Id,goods.Name "+
                    " ORDER BY TotalQuantity DESC LIMIT 0, @p2 ; ";
            object[] myParams = { startDate, endDate, top };
            return respository.countGoodsSale(sql, myParams);
        }

        public IEnumerable<SaleDate> getSaleStatisticInfoByDay(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT DATE_FORMAT(shipmentlist.ShipmentTime,'%Y-%m-%d') " +
                        " as Date, sum(shipmentlist.TotalPrice) as TotalMoney " +
                        " FROM shipmentlist " +
                        " WHERE shipmentlist.ShipmentTime >=@p0 AND  shipmentlist.ShipmentTime <@p1" +
                        " GROUP BY DATE_FORMAT(shipmentlist.ShipmentTime, '%Y-%m-%d'); ";
            object[] myParams = { startDate, endDate };
            return respository.countSaleDateStatistic(sql, myParams);
        }

        public IEnumerable<SaleDate> getSaleStatisticInfoByMonth(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT DATE_FORMAT(shipmentlist.ShipmentTime,'%Y-%m') " +
                        " as Date, sum(shipmentlist.TotalPrice) as TotalMoney " +
                        " FROM shipmentlist " +
                        " WHERE shipmentlist.ShipmentTime >=@p0 AND  shipmentlist.ShipmentTime <@p1" +
                        " GROUP BY DATE_FORMAT(shipmentlist.ShipmentTime, '%Y-%m'); ";
            object[] myParams = { startDate, endDate };
            return respository.countSaleDateStatistic(sql, myParams);
        }

        public IEnumerable<TypeQuantity> getTypeQuantityByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT category.Name as GoodsType,sum(shipmentitem.Quantity) as totalQuantity" +
                        ",sum(shipmentitem.SellPrice * shipmentitem.Quantity) as totalMoney" +
                        " FROM shipmentlist, shipmentitem, goods, category " +
                        " WHERE shipmentlist.ShipmentTime >= @p0 AND shipmentlist.ShipmentTime < @p1 " +
                        " and shipmentitem.Id = shipmentitem.ShipmentList_Id" +
                        " AND shipmentitem.GoodsId = goods.Id and goods.CategoryId = category.Id" +
                        " GROUP BY category.Id,category.Name; ";
            object[] myparams = { startDate, endDate };
            return respository.countTypeQuantity(sql, myparams);
        }

        public IEnumerable<TypeQuantity> getTypeWareHousingStatistic(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT category.Name as GoodsType,sum(warehousingitem.Quantity) as totalQuantity" +
                        ",sum(warehousingitem.PurchasePrice * warehousingitem.Quantity) as totalMoney" +
                        " FROM category,warehousinglist,warehousingitem,goods " +
                        " WHERE warehousinglist.WareHousingTime >= @p0 AND warehousinglist.WareHousingTime < @p1 " +
                        " and category.Id = goods.CategoryId " +
                        " AND warehousinglist.Id = warehousingitem.WareHousingList_Id and warehousingitem.GoodsId = goods.Id " +
                        " GROUP BY category.Id,category.Name; ";
            object[] myParams = { startDate, endDate };
            return respository.countTypeQuantity(sql, myParams);
        }

    }
}
