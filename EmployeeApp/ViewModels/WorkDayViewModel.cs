using EmployeeApp.Controllers;
using EmployeeApp.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.ViewModels
{
    public class WorkDayViewModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime WorkDate { get; set; }

        public int DepartmentId { get; set; }

        public IEnumerable<Department> Departments { get; set; }

        public int NumberOfWorkDays { get; set; }
        
        public int NumbersOfShifts { get; set; }

        
    }
}