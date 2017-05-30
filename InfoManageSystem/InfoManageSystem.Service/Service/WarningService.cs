using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Service.IService;
using InfoManageSystem.Domain.Entities;
using InfoManageSystem.Domain.Abstract;
namespace InfoManageSystem.Service.Service
{
    public class WarningService : IWarningService
    {
        private IWarningRespository warningRespository;
        public WarningService(IWarningRespository warningRespository)
        {
            this.warningRespository = warningRespository;
        }
        public IEnumerable<Warning> GetWarning()
        {
            return warningRespository.Warnings;
        }
    }
}
