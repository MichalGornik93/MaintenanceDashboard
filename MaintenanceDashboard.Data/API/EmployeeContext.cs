﻿using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Common;

namespace MaintenanceDashboard.Data.API
{
    public class EmployeeContext 
    {
        private readonly DataContext context;

        public EmployeeContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void Create(Employee employee)
        {
            Validator.RequireString(employee.FirstName);
            Validator.RequireString(employee.LastName);

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            var entity = context.Employees.Find(employee.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design. ");
            }

            context.Entry(entity).CurrentValues.SetValues(employee);

            context.SaveChanges();
        }

        public void Remove(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public ICollection<Employee> GetAll()
        {
            return context.Employees.OrderBy(p => p.Id).ToArray();
        }
    }
}
