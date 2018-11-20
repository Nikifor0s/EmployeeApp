﻿using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        //[Required]
        //public int ShiftId { get; set; }

        //public Shift Shift { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public virtual PersonalDetails PersonalDetails { get; set; }

        public virtual ContactDetails ContactDetails { get; set; }

        public virtual Account Account { get; set; }
    }
}