using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Service.IService
{
    public interface IWareHousingListService
    {
        bool SaveWareHousingList(WareHousingList wareHousingList);

        IEnumerable<WareHousingList> GetAllShipmentByPage(QueryModel queryModel,out int total);

        IEnumerable<WareHousingItem> GetWareHousingItems(int wareHousingId);
    }
}
