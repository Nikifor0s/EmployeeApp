using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models.Employees
{
    public class ShiftType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}