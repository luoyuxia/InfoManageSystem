using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFWareHousingListRespository : IWareHousingListRespository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<WareHousingList> WareHousingList
        {
            get
            {
                return context.WareHousingList.AsQueryable();
            }
        }

        public bool SaveWareHousingList(WareHousingList wareHouseList)
        {
            context.WareHousingList.Add(wareHouseList);
            context.SaveChanges();
            return true;
        }
    }
}
