using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Service.IService;

namespace InfoManageSystem.Service.Service
{
    public class WareHousingListService : IWareHousingListService
    {
        private IWareHousingListRespository wareHousingListRespository;
        public WareHousingListService(IWareHousingListRespository wareHousingListRespository)
        {
            this.wareHousingListRespository = wareHousingListRespository;
        }

        public IEnumerable<WareHousingList> GetAllShipmentByPage(QueryModel queryModel,out int total)
        {
            var afterTimeQuery = wareHousingListRespository.WareHousingList.Where(l => l.WareHousingTime <= queryModel.EndDate && l.WareHousingTime >= queryModel.StartDate);
            total = afterTimeQuery.Count();
            IQueryable<WareHousingList> afterOrderQuery = null;
            if(queryModel.SortField == "EmployeeId")
            {
                if (queryModel.Order == "desc")
                    afterOrderQuery = afterTimeQuery.OrderByDescending(p => p.EmployeeId);
                else
                    afterOrderQuery = afterTimeQuery.OrderBy(p => p.EmployeeId);
            }
            else if(queryModel.SortField == "WareHousingTime")
            {
                if (queryModel.Order == "desc")
                    afterOrderQuery = afterTimeQuery.OrderByDescending(p => p.WareHousingTime);
                else
                    afterOrderQuery = afterTimeQuery.OrderBy(p => p.WareHousingTime);
            }
            else if(queryModel.SortField == "TotalPrice")
            {
                if (queryModel.Order == "desc")
                    afterOrderQuery = afterTimeQuery.OrderByDescending(p => p.TotalPrice);
                else
                    afterOrderQuery = afterTimeQuery.OrderBy(p => p.TotalPrice);
            }
            else
            {
                if (queryModel.Order == "desc")
                    afterOrderQuery = afterTimeQuery.OrderByDescending(p => p.TotalPrice);
                else
                    afterOrderQuery = afterTimeQuery.OrderBy(p => p.TotalPrice);
            }
            return afterOrderQuery.Skip((queryModel.pageIndex - 1) * queryModel.pageSize).Take(queryModel.pageSize);
        }

        public IEnumerable<WareHousingItem> GetWareHousingItems(int wareHousingId)
        {
            WareHousingList wareHousingList = wareHousingListRespository.WareHousingList.FirstOrDefault(p => p.Id == wareHousingId);
            if (wareHousingList == null)
                return new List<WareHousingItem>();
            return wareHousingList.WareHousingItems;
        }

        public bool SaveWareHousingList(WareHousingList wareHousingList)
        {
            return wareHousingListRespository.SaveWareHousingList(wareHousingList);
        }
    }
}
