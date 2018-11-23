using EmployeeApp.Models;
using System.Collections.Generic;

namespace EmployeeApp.ViewModels
{
    public class EmployeesAssignToShiftViewModel
    {
        public Shift Shift { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}