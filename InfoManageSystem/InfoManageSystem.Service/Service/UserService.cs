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

        public bool saveEmployee(Employee e)
        {
            return userRespository.SaveEmployee(e);
        }

        public bool updateEmployeePassword(int employeeId, string password)
        {
            Employee e = userRespository.Employee.FirstOrDefault(p => p.Id == employeeId);
            if (e == null)
                return false;
            e.Password = password;
           return userRespository.SaveEmployee(e);
        }
    }
}
