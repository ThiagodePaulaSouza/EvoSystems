using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using EvoSystems.Models;
using EvoSystems.DataContext;

namespace EvoSystems.Repository;

class DepartamentRepository : Repository<Departament>
{
    public DepartamentRepository(AppDBContext context) : base(context)
    {
    }
}