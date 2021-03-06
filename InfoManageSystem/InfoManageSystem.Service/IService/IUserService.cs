﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoManageSystem.Domain.Entities;

namespace InfoManageSystem.Service.IService
{
    public interface IUserService
    {
        Employee getEmployeeByAccount(string account, string password);

        bool saveEmployee(Employee e);

        bool updateEmployeePassword(int employeeId, string password);
    }
}
