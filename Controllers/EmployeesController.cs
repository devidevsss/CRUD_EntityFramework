using CRUD_EF.Data;
using CRUD_EF.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext dbContext;

        public EmployeesController(EmployeeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //Get all employees in db
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = dbContext.Employees.ToList();

            return Ok(employees);
        }

        //Get specific employee baed on id
        [HttpGet("{id}")]
        
        public IActionResult GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            return Ok(employee);
        }

        //Add new employee data
        [HttpPost]
        public IActionResult AddEmployee(string name, string pass)
        {
            var newEmployee = new Employee
            {
                Name = name,
                Password = pass
            };

            var employee = dbContext.Employees.Add(newEmployee);
            dbContext.SaveChanges();

            return Ok(newEmployee);
        }

        //Update employee data
        [HttpPut]
        public IActionResult UpdateEmployee(int id, string name, string pass)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                employee.Name = name;
                employee.Password = pass;

                dbContext.SaveChanges();
                return Ok(employee);
            }

            return NotFound("Employee cannot be updated.");
        }

        //Delete employee data
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.FirstOrDefault(x => x.Id == id);

            if (employee != null)
            {
                dbContext.Remove(employee);
                dbContext.SaveChanges();
                return Ok(employee);
            }

            return NotFound("Employee not found.");
        }

    }
}
