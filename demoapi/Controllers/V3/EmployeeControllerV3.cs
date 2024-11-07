// Controllers/V3/EmployeeControllerV3.cs
using Microsoft.AspNetCore.Mvc;
using DemoApi.Models;
using DemoApi.Data;
using System.Linq;

namespace DemoApi.Controllers.V3
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Employee")]
    [ApiVersion("3.0")]
    public class EmployeeControllerV3 : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = EmployeeDataCanada.GetEmployees()
                                             .Where(e => e.Id == id)
                                             .Select(e => new
                                             {
                                                 e.Id,
                                                 e.Name,
                                                 e.Position,
                                                 e.Department,
                                                 e.Province,
                                                 e.Language,
                                                 e.Experience,
                                                 e.Industry,
                                                 e.Certification
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
            var employees = EmployeeDataCanada.GetEmployees()
                                              .Where(e => e.Name.Contains(name))
                                              .Select(e => new
                                              {
                                                  e.Id,
                                                  e.Name,
                                                  e.Position,
                                                  e.Department,
                                                  e.Province,
                                                  e.Language,
                                                  e.Experience,
                                                  e.Industry,
                                                  e.Certification
                                              })
                                              .ToList();
            return Ok(employees);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = EmployeeDataCanada.GetEmployees()
                                              .Select(e => new
                                              {
                                                  e.Id,
                                                  e.Name,
                                                  e.Position,
                                                  e.Department,
                                                  e.Province,
                                                  e.Language,
                                                  e.Experience,
                                                  e.Industry,
                                                  e.Certification
                                              })
                                              .ToList();
            return Ok(employees);
        }

        // New endpoint: Get employees by position, including Salary
        [HttpGet("position/{position}")]
        public IActionResult GetByPosition(string position)
        {
            var employees = EmployeeDataCanada.GetEmployees()
                                              .Where(e => e.Position.Contains(position))
                                              .Select(e => new
                                              {
                                                  e.Id,
                                                  e.Name,
                                                  e.Position,
                                                  e.Department,
                                                  e.Salary,         // Including Salary in the response
                                                  e.Province,
                                                  e.Language,
                                                  e.Experience,
                                                  e.Industry,
                                                  e.Certification
                                              })
                                              .ToList();

            if (!employees.Any())
            {
                return NotFound($"No employees found with position containing '{position}'. Please try examples like 'Developer' or 'Teacher'.");
            }

            return Ok(employees);
        }

    }
}
