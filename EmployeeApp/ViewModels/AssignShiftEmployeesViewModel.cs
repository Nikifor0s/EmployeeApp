using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace EmployeeApp.ViewModels
{
    public class AssignShiftEmployeesViewModel
    {
        public Shift Shift { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public AssignShiftEmployeesViewModel()
        {
            Employees = new Collection<Employee>();
        }


    }
}