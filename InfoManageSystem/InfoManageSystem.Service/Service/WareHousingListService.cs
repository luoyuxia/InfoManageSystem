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
        public bool SaveWareHousingList(WareHousingList wareHousingList)
        {
            return wareHousingListRespository.SaveWareHousingList(wareHousingList);
        }
    }
}
