using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Service.IService
{
    public interface IShipmentService
    {
        bool SaveShipmentList(ShipmentList shipmentList);


        IEnumerable<ShipmentList> GetAllShipmentByPage(QueryModel queryParam, out int total);

        IEnumerable<ShipmentList> GetAllShipmentByPage(int offset, int pageSize,DateTime start,DateTime end,out int total);

        IEnumerable<ShipmentItem> GetShipmentItems(int shipmentListId);
    }
}
