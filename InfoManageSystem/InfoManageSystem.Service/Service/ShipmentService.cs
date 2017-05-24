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

        public IEnumerable<ShipmentList> GetAllShipmentByPage(QueryModel queryParam,out  int total)
        {
            IQueryable<ShipmentList> afterTimeQuery = shipmentRespository.ShipmentList.Where(s => s.ShipmentTime <= queryParam.EndDate && s.ShipmentTime >= queryParam.StartDate);
            total = afterTimeQuery.Count();
            IQueryable<ShipmentList> orderQuery = null;
            if (queryParam.SortField == "DealersId")
            {
                if (queryParam.Order == "desc")
                    orderQuery = afterTimeQuery.OrderByDescending(s => s.DealersId);
                else
                    orderQuery = afterTimeQuery.OrderBy(s => s.DealersId);
            }
            else if (queryParam.SortField == "ShipmentTime")
            {
                if (queryParam.Order == "desc")
                    orderQuery = afterTimeQuery.OrderByDescending(s => s.ShipmentTime);
                else
                    orderQuery = afterTimeQuery.OrderBy(s => s.ShipmentTime);
            }
            else if (queryParam.SortField == "TotalPrice")
            {
                if (queryParam.Order == "desc")
                    orderQuery = afterTimeQuery.OrderByDescending(s => s.TotalPrice);
                else
                    orderQuery = afterTimeQuery.OrderBy(s => s.TotalPrice);
            }
            else
            {
                if (queryParam.Order == "desc")
                    orderQuery = afterTimeQuery.OrderByDescending(s => s.Id);
                else
                    orderQuery = afterTimeQuery.OrderBy(s => s.Id);
            }
            return orderQuery.Skip((queryParam.pageIndex - 1) * queryParam.pageSize).Take(queryParam.pageSize);
        }


        public IEnumerable<ShipmentList> GetAllShipmentByPage(int offset, int pageSize, DateTime start, DateTime end,out int total)
        {
            var query = shipmentRespository.ShipmentList.Where(s => s.ShipmentTime < end && s.ShipmentTime > start);
            total = query.Count();
            return query.OrderBy(s=>s.Id).Skip((offset - 1) * pageSize).Take(pageSize);
        }

        public IEnumerable<ShipmentItem> GetShipmentItems(int shipmentListId)
        {
            ShipmentList shipmentList = shipmentRespository.ShipmentList.FirstOrDefault(s => s.Id == shipmentListId);
            //返回空的出货项列表
            if (shipmentList == null)
                return new List<ShipmentItem>();
            return shipmentList.ShipmentItems.AsEnumerable();
        }

        public bool SaveShipmentList(ShipmentList shipmentList)
        {
            return shipmentRespository.SaveShipmentList(shipmentList);
        }
    }
}
