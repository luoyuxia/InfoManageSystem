using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
namespace InfoManageSystem.Domain.Abstract
{
    public interface IDealersRespository
    {
        IQueryable<Dealers> Dealers { get; }

        bool SaveDealers(Dealers dealers);

        bool DeleteDealers(int dealersId);

        Dealers GetDealersById(int dealerId);
    }
}
