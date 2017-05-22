using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;
namespace InfoManageSystem.Domain.Concrete
{
    public class EFShipmentRespository : IShipmentRespository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<ShipmentList> ShipmentList
        {
            get
            {
                return context.ShipmentList;
            }
        }

        public bool SaveShipmentList(ShipmentList shipmentList)
        {
            ShipmentList s = context.ShipmentList.Find(shipmentList.Id);
            if(s==null)
            {
                context.ShipmentList.Add(shipmentList);
            }
            else
            {
                context.Entry(shipmentList).CurrentValues.SetValues(shipmentList);
            }
            context.SaveChanges();
            return true;
        }
    }
}
