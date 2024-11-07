using Microsoft.AspNetCore.Mvc;
using DemoApi.Models;
using DemoApi.Data;
using System.Linq;

namespace DemoApi.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Employee")]
    [ApiVersion("1.0")]
    public class EmployeeControllerV1 : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = EmployeeData.GetEmployees().FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var employees = EmployeeData.GetEmployees().Where(e => e.Name.Contains(name)).ToList();
            return Ok(employees);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = EmployeeData.GetEmployees();
            return Ok(employees);
        }
    }
}
