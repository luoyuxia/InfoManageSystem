using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFWarningRespository : IWarningRespository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Warning> Warnings
        {
            get
            {
                return context.Warning;
            }
        }
    }
}
