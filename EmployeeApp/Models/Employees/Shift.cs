using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models.Employees
{
    public class Shift
    {
        public int Id { get; set; }

        [Required]
        public int ShiftTypeId { get; set; }

        public ShiftType DayShift { get; set; }

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

        public Shift(DateTime dateTime, int dayShiftId, int departmentId)
        {
            DateTime = dateTime;
            ShiftTypeId = dayShiftId;
            DepartmentId = departmentId;

            Works = new Collection<Work>();
        }
    }
}