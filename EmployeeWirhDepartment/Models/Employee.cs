namespace EmployeeWirhDepartment.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public Department? Department { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
