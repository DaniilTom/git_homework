﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    public interface IServiceEmployeeData
    {
        IEnumerable<Employee> Employees { get; }

        Employee GetById(int id);

        void AddNew(Employee employee);

        void Delete(int id);

        void SaveChanges();
    }
}
