using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Abstract
{
    public interface IWareHouseRespository
    {
        IQueryable<WareHouse> WareHouse { get; }

        IQueryable<GoodsStorage> GoodsStorage { get; }

        WareHouse GetWareHouseById(int wareHouseId);

        bool SaveWareHosue(WareHouse wareHouse);

        bool DeleteWareHouse(int  wareHouseId);

        //保存更改
        void SaveChanges();
    }
}
