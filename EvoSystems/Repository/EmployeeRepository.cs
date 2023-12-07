using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EvoSystems.Models;
using EvoSystems.DataContext;

namespace EvoSystems.Repository;

class EmployeeRepository : Repository<Employee>
{
    public EmployeeRepository(AppDBContext context) : base(context)
    {
    }
}