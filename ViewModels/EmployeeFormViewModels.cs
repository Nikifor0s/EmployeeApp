using EmployeeApp.Models;
using System.Collections.Generic;

namespace EmployeeApp.ViewModels
{
    public class EmployeeFormViewModels
    {
        public Employee Employee { get; set; }

        public IEnumerable<Shift> Shifts { get; set; }

        //public int DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; }

        //public int RoleId { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}