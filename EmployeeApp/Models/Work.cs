﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models
{
    public class Work
    {
        [Key]
        [Column(Order = 1)]
        public int EmployeeID { get; set; }

        public Employee Employee { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ShiftId { get; set; }

        public Shift Shift { get; set; }
    }
}