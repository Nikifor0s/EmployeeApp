using EmployeeApp.Models.Employees;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        //YELLOW
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

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public virtual PersonalDetails PersonalDetails { get; set; }

        public virtual ContactDetails ContactDetails { get; set; }

        public ICollection<Work> Works { get; set; }

        public ICollection<Request> Requests { get; set; }

        public Employee()
        {
            Works = new Collection<Work>();
            Requests = new Collection<Request>();
        }
    }
}