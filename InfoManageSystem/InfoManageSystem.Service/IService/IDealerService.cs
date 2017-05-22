using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;

namespace InfoManageSystem.Service.IService
{
    public interface IDealersService
    {
        bool SaveDealers(Dealers dealers);

        Dealers GetSingleDealers(int dealersId);

        IEnumerable<Dealers> GetAllDealers();

        IEnumerable<Dealers> GetAllDealers(int offest, int pageSize,string name, out int total);


    }
}
