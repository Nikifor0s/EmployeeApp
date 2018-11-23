using EmployeeApp.Models;
using System.Collections.Generic;

namespace EmployeeApp.ViewModels
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}