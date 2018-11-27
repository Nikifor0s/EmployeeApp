using EmployeeApp.Models;
using EmployeeApp.Models.Employees;
using System.Collections.Generic;

namespace EmployeeApp.ViewModels
{
    public class ShiftFormViewModel
    {
        public Shift Shift { get; set; }
        //public DateTime DateTime { get; set; }

        //public Shifts DayShift { get; set; }

        //public int DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }
    }
}