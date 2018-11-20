using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Shift
    {
        public int Id { get; set; }

        public string DayShift { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }
    }
}