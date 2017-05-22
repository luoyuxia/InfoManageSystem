using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Service.IService;
using InfoManageSystem.Domain.Abstract;

namespace InfoManageSystem.Service.Service
{
    public class DealersService : IDealersService
    {
        private IDealersRespository dealersRespository;
        public DealersService(IDealersRespository dealersRespository)
        {
            this.dealersRespository = dealersRespository;
        }
        public IEnumerable<Dealers> GetAllDealers()
        {
            return dealersRespository.Dealers.AsEnumerable();
        }

        public IEnumerable<Dealers> GetAllDealers(int offest, int pageSize, string name, out int total)
        {
            total = dealersRespository.Dealers.Count();
            return dealersRespository.Dealers.Where(d => d.Name.Contains(name)).OrderBy(p => p.Id)
                .Skip(pageSize * (offest - 1)).Take(pageSize).AsEnumerable();
        }

        public Dealers GetSingleDealers(int dealersId)
        {
            return dealersRespository.GetDealersById(dealersId);
        }

        public bool SaveDealers(Dealers dealers)
        {
            return dealersRespository.SaveDealers(dealers);
        }
    }
}
