using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models.Employees
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }


    }
}