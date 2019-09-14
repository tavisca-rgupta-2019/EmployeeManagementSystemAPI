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
    { private static IEmployeeService _employeeService;

        public CompanyInfoController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeService.GetAllEmployees());
        }
        [HttpGet("Managers/{id}")]
        public IActionResult GetManager(string id)
        {
            var manager = _employeeService.GetManager(id);
            if (manager == null)
                return NotFound();
            return Ok(manager);
        }
        [HttpGet("Managers/{managerId}/Employees")]
        public IActionResult GetEmployeesUnderSpeicificManager(string managerId)
        {
            var employees = _employeeService.GetEmployeesWorkingUnderSpecificManager(managerId);
            if (employees == null)
                return NotFound();
            return Ok(employees);

        }

        [HttpGet("Employees/{id}",Name ="GetEmployeeInfo")]
        public IActionResult Get(string id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);

        }
        [HttpPost("Employees")]
        public IActionResult Post([FromBody] EmployeeCreationDTO employee)
        {
            var newEmployee = _employeeService.AddEmployee(employee);
            if(newEmployee==null)
                return BadRequest();
            return CreatedAtRoute("GetEmployeeInfo", new { id = newEmployee.Id }, newEmployee);
            
        }
        [HttpPut("Employees")]
        public IActionResult Put([FromBody] EmployeeDTO value)
        {
            if (_employeeService.UpdateEmployee(value))
                return NoContent();
            return BadRequest();

        }

       

        // DELETE api/values/5
        [HttpDelete("Employees/{id}")]
        public IActionResult Delete(string id)
        {
            var employee = _employeeService.GetEmployee(id);
            if (employee == null)
                return BadRequest();
            _employeeService.DeleteEmployee(id);
            return StatusCode(204);


        }
    }
}
