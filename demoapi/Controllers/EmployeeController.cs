// Controllers/EmployeeController.cs
using Microsoft.AspNetCore.Mvc;
using DemoApi.Data;
using System.Linq;

namespace DemoApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDataSource _employeeDataSource;

        public EmployeeController(IEmployeeDataSource employeeDataSource)
        {
            _employeeDataSource = employeeDataSource;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeDataSource.GetEmployees().FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var employees = _employeeDataSource.GetEmployees().Where(e => e.Name.Contains(name)).ToList();
            return Ok(employees);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeDataSource.GetEmployees();
            return Ok(employees);
        }
    }
}
