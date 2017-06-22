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
            string sql = "SELECT DealersId as DealersId,Dealers.Name as DealersName " +
                        ", DATE_FORMAT(ShipmentList.ShipmentTime, '%Y-%m') as DateSlot " +
                        ",sum(ShipmentList.TotalPrice)" +
                        " as TotalMoney FROM ShipmentList, Dealers" +
                        " WHERE ShipmentList.ShipmentTime>=@p1 AND ShipmentList.ShipmentTime<@p2 AND"
                        + " ShipmentList.DealersId = @p0 AND ShipmentList.DealersId = Dealers.Id" +
                        " GROUP BY DATE_FORMAT(ShipmentList.ShipmentTime, '%Y-%m'); ";
            object[] myParams = { dealersId, startDate, endDate };
            return respository.countDealersStatistic(sql, myParams);
        }

        public IEnumerable<DealersStock> getDealersStockStatistic(DateTime startDate, DateTime endDate, int top = 10)
        {
            string sql = "SELECT Dealers.Id as DealersId " +
                        ", Dealers.Name as DealersName " +
                        ",sum(ShipmentList.TotalPrice) as TotalMoney " +
                        " FROM ShipmentList, Dealers" +
                        " WHERE ShipmentList.ShipmentTime >= @p0 AND ShipmentList.ShipmentTime < @p1" +
                        " AND ShipmentList.DealersId = Dealers.Id " +
                        " GROUP BY Dealers.Id,Dealers.Name " +
                        " ORDER BY TotalMoney DESC LIMIT 0,@p2; ";
            object[] myParams = { startDate, endDate, top };
            return respository.countDealersStock(sql, myParams);
        }

        public IEnumerable<GoodsSale> getGoodsSaleStatistic(DateTime startDate, DateTime endDate, int top = 10)
        {
            string sql = "SELECT Goods.Id as GoodsId,Goods.Name as GoodsName," +
                    " sum(ShipmentItem.Quantity) as TotalQuantity," +
                    " sum(ShipmentItem.Quantity * ShipmentItem.SellPrice) as TotalSaleMoney " +
                    " FROM ShipmentItem, ShipmentList, Goods " +
                    " WHERE ShipmentList.ShipmentTime >= @p0 AND ShipmentList.ShipmentTime < @p1" +
                    " AND  Goods.Id = ShipmentItem.GoodsId " +
                    " AND ShipmentItem.ShipmentList_Id = ShipmentList.Id" +
                    " GROUP BY Goods.Id,Goods.Name " +
                    " ORDER BY TotalQuantity DESC LIMIT 0, @p2 ; ";
            object[] myParams = { startDate, endDate, top };
            return respository.countGoodsSale(sql, myParams);
        }

        public IEnumerable<SaleDate> getSaleStatisticInfoByDay(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT DATE_FORMAT(ShipmentList.ShipmentTime,'%Y-%m-%d') " +
                        " as Date, sum(ShipmentList.TotalPrice) as TotalMoney " +
                        " FROM ShipmentList " +
                        " WHERE ShipmentList.ShipmentTime >=@p0 AND  ShipmentList.ShipmentTime <@p1" +
                        " GROUP BY DATE_FORMAT(ShipmentList.ShipmentTime, '%Y-%m-%d'); ";
            object[] myParams = { startDate, endDate };
            return respository.countSaleDateStatistic(sql, myParams);
        }

        public IEnumerable<SaleDate> getSaleStatisticInfoByMonth(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT DATE_FORMAT(ShipmentList.ShipmentTime,'%Y-%m') " +
                        " as Date, sum(ShipmentList.TotalPrice) as TotalMoney " +
                        " FROM ShipmentList " +
                        " WHERE ShipmentList.ShipmentTime >=@p0 AND  ShipmentList.ShipmentTime <@p1" +
                        " GROUP BY DATE_FORMAT(ShipmentList.ShipmentTime, '%Y-%m'); ";
            object[] myParams = { startDate, endDate };
            return respository.countSaleDateStatistic(sql, myParams);
        }

        public IEnumerable<TypeQuantity> getTypeQuantityByDate(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT Category.Name as GoodsType,sum(ShipmentItem.Quantity) as totalQuantity" +
                        ",sum(ShipmentItem.SellPrice * ShipmentItem.Quantity) as totalMoney" +
                        " FROM ShipmentList, ShipmentItem, Goods, Category " +
                        " WHERE ShipmentList.ShipmentTime >= @p0 AND ShipmentList.ShipmentTime < @p1 " +
                        " and ShipmentList.Id = ShipmentItem.ShipmentList_Id" +
                        " AND ShipmentItem.GoodsId = Goods.Id and Goods.CategoryId = Category.Id" +
                        " GROUP BY Category.Id,Category.Name; ";
            object[] myparams = { startDate, endDate };
            return respository.countTypeQuantity(sql, myparams);
        }

        public IEnumerable<TypeQuantity> getTypeWareHousingStatistic(DateTime startDate, DateTime endDate)
        {
            string sql = "SELECT Category.Name as GoodsType,sum(WareHousingItem.Quantity) as totalQuantity" +
                        ",sum(WareHousingItem.PurchasePrice * WareHousingItem.Quantity) as totalMoney" +
                        " FROM Category,WareHousingList,WareHousingItem,Goods " +
                        " WHERE WareHousingList.WareHousingTime >= @p0 AND WareHousingList.WareHousingTime < @p1 " +
                        " and Category.Id = Goods.CategoryId " +
                        " AND WareHousingList.Id = WareHousingItem.WareHousingList_Id and WareHousingItem.GoodsId = Goods.Id " +
                        " GROUP BY Category.Id,Category.Name; ";
            object[] myParams = { startDate, endDate };
            return respository.countTypeQuantity(sql, myParams);
        }

    }
}
