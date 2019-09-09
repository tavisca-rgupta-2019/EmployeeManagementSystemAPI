using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMSPracticeAPI.Models;
using EMSPracticeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMSPracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    { private static EmployeeService employeeService = null;

        public CompanyInfoController()
        {
            employeeService = new EmployeeService();

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employeeService.GetAllEmployees());
        }
        [HttpGet("Managers/{id}")]
        public IActionResult GetEmployees(string id)
        {
            var employees = employeeService.GetEmployees(id);
            if (employees.Count == 0)
                return NotFound();
            return Ok(employees);
        }

        [HttpGet("Employees/{id}",Name ="GetEmployeeInfo")]
        public IActionResult Get(string id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);

        }
        [HttpPost("Employees")]
        public IActionResult Post([FromBody] EmployeeCreation employee)
        {
            var newEmployee = employeeService.AddEmployee(employee);
            if(newEmployee==null)
                return BadRequest();
            return CreatedAtRoute("GetEmployeeInfo", new { id = newEmployee.Id }, newEmployee);
            
        }
        [HttpPut("Employees")]
        public IActionResult Put([FromBody] Employee value)
        {
            if (employeeService.UpdateEmployee(value))
                return NoContent();
            return BadRequest();

        }

       

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
