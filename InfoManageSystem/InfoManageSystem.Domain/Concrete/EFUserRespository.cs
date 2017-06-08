using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Abstract;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Domain.Concrete
{
    public class EFUserRespository : IUserRespository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Employee> Employee
        {
            get
            {
                return context.Employee;
            }
        }

        public Employee getEmployeeById(int id)
        {
            return context.Employee.Find(id);
        }

        public bool SaveEmployee(Employee e)
        {
            Employee entity = context.Employee.Find(e.Id);
            if (entity == null)
                context.Employee.Add(entity);
            else
            {
                context.Entry(entity).CurrentValues.SetValues(e);
            }
            context.SaveChanges();
            return true;
        }
    }
}
