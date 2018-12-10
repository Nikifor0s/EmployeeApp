using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeApp.Models.Employees
{
    public class Assignment
    {
        [Key]
        [Column(Order = 1)]
        public int WorkId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProjectId { get; set; }

        public Work Work { get; set; }

        public Project Project { get; set; }
    }
}