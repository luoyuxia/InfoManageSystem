using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.ViewModel.Model;
namespace InfoManageSystem.Service.IService
{
    public interface IStatisticInfoService
    {
        IEnumerable<TypeQuantity> getTypeQuantityByDate(DateTime startDate, DateTime endDate);

        //商品类别进货的统计信息
        IEnumerable<TypeQuantity> getTypeWareHousingStatistic(DateTime startDate, DateTime endDate);

        IEnumerable<GoodsSale> getGoodsSaleStatistic(DateTime startDate, DateTime endDate,int top = 10);

        //经销商的进货统计排行
        IEnumerable<DealersStock> getDealersStockStatistic(DateTime startDate, DateTime endDate, int top = 10);

        //得到经销商某段时间内的进货总额
        IEnumerable<DealersStatistic> getDealersShipmentRecordBySlot(int dealersId,DateTime startDate, DateTime endDate);

        //得到仓库的销售额，按日计算
        IEnumerable<SaleDate> getSaleStatisticInfoByDay(DateTime startDate, DateTime endDate);

        //得到仓库的销售额，按月计算
        IEnumerable<SaleDate> getSaleStatisticInfoByMonth(DateTime startDate, DateTime endDate);
    }
}
