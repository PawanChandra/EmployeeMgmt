using System.ComponentModel.DataAnnotations;

namespace EmployeeWirhDepartment.Models
{
    public class CreateEmployeeVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [EmailAddress(ErrorMessage = "Email should be valid")]
        public string? Email { get; set; }
        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
