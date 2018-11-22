using System;

namespace EmployeeApp.Models
{
    public class Shift
    {
        public enum Shifts
        {
            Morning = 1,
            Evening,
            Night
        }

        public int Id { get; set; }

        public Shifts DayShift { get; set; }

        public DateTime DateTime { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}