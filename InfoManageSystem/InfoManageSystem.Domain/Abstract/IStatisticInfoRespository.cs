using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.ViewModel.Model;

namespace InfoManageSystem.Domain.Abstract
{
    public interface IStatisticInfoRespository
    {
        IEnumerable<TypeQuantity> countTypeQuantity(string sql,object[] myParams);

        IEnumerable<GoodsSale> countGoodsSale(string sql, object[] myParams);

        IEnumerable<DealersStock> countDealersStock(string sql, object[] myParams);

        IEnumerable<DealersStatistic> countDealersStatistic(string sql, object[] myParams);

        IEnumerable<SaleDate> countSaleDateStatistic(string sql, object[] myParams);
    }
}
