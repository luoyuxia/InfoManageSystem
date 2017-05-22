using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Abstract
{
    public interface IWareHousingListRespository
    {
        bool SaveWareHousingList(WareHousingList wareHouseList);

        IQueryable<WareHousingList> WareHousingList { get; }
    }
}
