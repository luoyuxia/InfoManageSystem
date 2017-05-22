using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.Service.Service
{
    public class ShipmentService : IShipmentService
    {
        private IShipmentRespository shipmentRespository;
        public ShipmentService(IShipmentRespository shipmentRespository)
        {
            this.shipmentRespository = shipmentRespository;
        }
        public bool SaveShipmentList(ShipmentList shipmentList)
        {
            return shipmentRespository.SaveShipmentList(shipmentList);
        }
    }
}
