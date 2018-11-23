using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public enum Shifts
    {
        Morning = 1,
        Evening,
        Night
    }

    public class Shift
    {
        public int Id { get; set; }

        public Shifts DayShift { get; set; }

        public DateTime DateTime { get; set; }

        public ICollection<Work> Works { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public Shift()
        {
            Works = new Collection<Work>();
        }
    }
}