using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModels
{
    public class ShiftFormViewModel
    {
        public Shift Shift { get; set; }

        public int EmployeeId { get; set; }

        public IEnumerable<Shift> Shifts { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }
    }
}