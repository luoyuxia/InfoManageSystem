using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;
namespace InfoManageSystem.Domain.Concrete
{
    public class EFDealerRepository : IDealersRespository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Dealers> Dealers
        {
            get
            {
                return context.Dealers;
            }
        }

        public bool DeleteDealers(int dealersId)
        {
            Dealers dealers = context.Dealers.Find(dealersId);
            if (dealers == null)
                return false;
            context.Dealers.Remove(dealers);
            context.SaveChanges();
            return true;
        }

        public Dealers GetDealersById(int dealerId)
        {
            return context.Dealers.Find(dealerId);
        }

        public bool SaveDealers(Dealers dealers)
        {
            Dealers entry = context.Dealers.Find(dealers.Id);
            if(entry==null)
            {
                context.Dealers.Add(dealers);
            }
            else
            {
                context.Entry(entry).CurrentValues.SetValues(dealers);
            }
            context.SaveChanges();
            return true;
        }
    }
}
