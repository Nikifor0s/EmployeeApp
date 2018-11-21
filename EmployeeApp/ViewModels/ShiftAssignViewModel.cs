using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModels
{
    public class ShiftAssignViewModel
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ShiftId { get; set; }
        public Shift Shift { get; set; }

        [Required]
        [FutureDate] //server-side
        public string Date { get; set; }

        [Required] //client-side
        [ValidTime] //server-side
        public string Time { get; set; }

        public IEnumerable<Shift> Shifts { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}