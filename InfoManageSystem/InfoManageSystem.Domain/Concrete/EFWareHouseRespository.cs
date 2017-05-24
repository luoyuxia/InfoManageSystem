using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFWareHouseRespository : IWareHouseRespository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<GoodsStorage> GoodsStorage
        {
            get
            {
                return context.GoodsStorage;
            }
        }

        public IQueryable<WareHouse> WareHouse
        {
            get
            {
                return context.WareHouse;
            }
        }

        public bool DeleteWareHouse(int wareHouseId)
        {
            WareHouse wareHouse = context.WareHouse.Find(wareHouseId);
            if (wareHouse == null)
                return false;
            context.WareHouse.Remove(wareHouse);
            context.SaveChanges();
            return true;
        }

        public WareHouse GetWareHouseById(int wareHouseId)
        {
            return context.WareHouse.Find(wareHouseId);
        }

        public bool SaveWareHosue(WareHouse wareHouse)
        {
            WareHouse entry = context.WareHouse.Find(wareHouse.Id);
            if (entry == null)
            {
                context.WareHouse.Add(wareHouse);
            }
            else
            {
                context.Entry(entry).CurrentValues.SetValues(wareHouse);
            }
            context.SaveChanges();
            return true;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
