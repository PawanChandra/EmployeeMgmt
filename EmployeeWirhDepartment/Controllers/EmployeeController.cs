using EmployeeWirhDepartment.DataContext;
using EmployeeWirhDepartment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EmployeeWirhDepartment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeController(ILogger<EmployeeController> logger, ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
             _logger = logger;
        }

        public IActionResult Index()
        {
            var getDepartments = _applicationDbContext.Departments.Select(d => new { d.DepartmentId, d.Name }).ToList();

            ViewBag.Departments = new SelectList(getDepartments, "DepartmentId", "Name");

            var getEmployess = _applicationDbContext.Employess.Include(e=> e.Department).ToList();
            return View(getEmployess);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var getDepartments = _applicationDbContext.Departments.Select(d=> new {d.DepartmentId,d.Name}).ToList();
            
            ViewBag.Departments = new SelectList(getDepartments, "DepartmentId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateEmployeeVM employeeRequest)
        {
            if(employeeRequest.Name !=null && employeeRequest.Email != null && employeeRequest.DepartmentId != null)
            {
                Employee employeeCreate = new Employee
                {
                    Id=Guid.NewGuid(),
                    Name=employeeRequest.Name,
                    Mobile=employeeRequest.Mobile,
                    Email=employeeRequest.Email,
                    DepartmentId=employeeRequest.DepartmentId.Value

                };
                _applicationDbContext.Employess.Add(employeeCreate);
                _applicationDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetFilteredEmployee(Guid id)
        {
            var employees = _applicationDbContext.Employess.Where(e => e.DepartmentId == id).Include(e=>e.Department).ToList();

            return PartialView("_GetEmployeeList", employees);
        }
    }
}
