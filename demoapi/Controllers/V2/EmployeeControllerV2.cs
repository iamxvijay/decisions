using Microsoft.AspNetCore.Mvc;
using DemoApi.Models;
using DemoApi.Data;
using System.Linq;
using Asp.Versioning;

namespace DemoApi.Controllers.V2
{
    [ApiController]
    [Route("api/v2/employee")]
    [ApiVersion("2.0")]
    public class EmployeeControllerV2 : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = EmployeeData.GetEmployees()
                                       .Where(e => e.Id == id)
                                       .Select(e => new
                                       {
                                           e.Id,
                                           e.Name,
                                           e.Position,
                                           e.Department
                                       })
                                       .FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var employees = EmployeeData.GetEmployees()
                                        .Where(e => e.Name.Contains(name))
                                        .Select(e => new
                                        {
                                            e.Id,
                                            e.Name,
                                            e.Position,
                                            e.Department
                                        })
                                        .ToList();
            return Ok(employees);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = EmployeeData.GetEmployees()
                                        .Select(e => new
                                        {
                                            e.Id,
                                            e.Name,
                                            e.Position,
                                            e.Department
                                        })
                                        .ToList();
            return Ok(employees);
        }
    }
}
