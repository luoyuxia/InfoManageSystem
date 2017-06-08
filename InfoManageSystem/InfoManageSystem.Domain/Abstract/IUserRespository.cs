using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;
namespace InfoManageSystem.Domain.Abstract
{
    public interface IUserRespository
    {
        Employee getEmployeeById(int id);

        IQueryable<Employee> Employee { get;  }

        bool SaveEmployee(Employee e);
    }
}
