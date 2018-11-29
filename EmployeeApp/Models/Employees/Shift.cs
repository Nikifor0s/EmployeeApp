using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using EmployeeApp.Models.Employees;

namespace EmployeeApp.Models.Employees
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

        //Constractors

        public Shift()
        {
            Works = new Collection<Work>();
        }

        public Shift(DateTime dateTime, Shifts dayShift, int departmentId)
        {
            DateTime = dateTime;
            DayShift = dayShift;
            DepartmentId = departmentId;
            
        }
    }
}