using EmployeeWirhDepartment.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWirhDepartment.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employess { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
