using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApp.ViewModels
{
    public class GetWorkDayViewModel
    {
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Datetime { get; set; }
        public int DepartmentId { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public string DepartemtName { get; set; }

        public IEnumerable<Shift> Shifts { get; set; }




    }
}