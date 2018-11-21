using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        //[FutureDate]
        public string Date { get; set; }

        [Required]
        //[ValidTime]
        public string Time { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}