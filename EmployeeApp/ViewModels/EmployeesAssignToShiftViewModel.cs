using EmployeeApp.Models;
using EmployeeApp.Models.Employees;
using System.Collections.Generic;

namespace EmployeeApp.ViewModels
{
    public class EmployeesAssignToShiftViewModel
    {
        public Shift Shift { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}