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

        WareHouse GetWareHouseById(int wareHouseId);

        bool SaveWareHosue(WareHouse wareHouse);

        bool DeleteWareHouse(int  wareHouseId);
    }
}
