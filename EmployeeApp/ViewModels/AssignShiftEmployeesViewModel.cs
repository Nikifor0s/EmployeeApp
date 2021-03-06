﻿using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApp.ViewModels
{
    public class AssignShiftEmployeesViewModel
    {
        public Shift Shift { get; set; }

        public int EmployeeId { get; set; }

        public ICollection<Employee> Employees { get; set; }

        public ICollection<Employee> WorkingEmployees { get; set; }

        
    }
}