using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        /// <summary>
        /// //
        /// </summary>
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

        //Kostas Pull
        //KostAS commit 2
        //Kostas Commit 3
    }
}