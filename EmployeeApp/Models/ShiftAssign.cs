using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    public class ShiftAssign
    {
        [Key]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ShiftId { get; set; }

        public Shift Shift { get; set; }

        public DateTime DateTime { get; set; }
    }
}