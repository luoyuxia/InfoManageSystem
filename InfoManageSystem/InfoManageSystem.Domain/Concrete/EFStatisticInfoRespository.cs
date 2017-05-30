using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.ViewModel.Model;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFStatisticInfoRespository : IStatisticInfoRespository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<DealersStatistic> countDealersStatistic(string sql, object[] myParams)
        {
            return context.Database.SqlQuery<DealersStatistic>(sql, myParams);
        }

        public IEnumerable<DealersStock> countDealersStock(string sql, object[] myParams)
        {
            return context.Database.SqlQuery<DealersStock>(sql, myParams);
        }

        public IEnumerable<GoodsSale> countGoodsSale(string sql, object[] myParams)
        {
            return context.Database.SqlQuery<GoodsSale>(sql, myParams);
        }

        public IEnumerable<SaleDate> countSaleDateStatistic(string sql, object[] myParams)
        {
            return context.Database.SqlQuery<SaleDate>(sql, myParams);
        }

        public IEnumerable<TypeQuantity> countTypeQuantity(string sql, object[] myParams)
        {
            return context.Database.SqlQuery<TypeQuantity>(sql, myParams);
        }
    }
}
