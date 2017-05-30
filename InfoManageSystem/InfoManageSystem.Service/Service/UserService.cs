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
    public class UserService : IUserService
    {
        private IUserRespository userRespository;
        public UserService(IUserRespository userRespository)
        {
            this.userRespository = userRespository;
        }
        public Employee getEmployeeByAccount(string account, string password)
        {
            return userRespository.Employee.Where(e => e.Account == account && e.Password == password).FirstOrDefault();
        }
    }
}
