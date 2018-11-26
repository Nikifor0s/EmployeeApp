using System;
using System.Collections.Generic;

namespace EmployeeApp.Models.Employees
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}