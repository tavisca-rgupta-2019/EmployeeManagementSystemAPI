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
        
        [HttpGet("Employees/{id}")]
        public IActionResult Get(string id)
        {
            var employee = employeeService.GetEmployee(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);

        }
        [HttpPost("Employees")]
        public IActionResult Post([FromBody] Employee value)
        {
            if (employeeService.AddEmployee(value))
                return StatusCode(201);
            return StatusCode(209);
        }
        [HttpPut("Employees")]
        public IActionResult Put([FromBody] Employee value)
        {
            if (employeeService.UpdateEmployee(value))
                return StatusCode(201);
            return StatusCode(209);

        }

        // GET api/values/5
       
        [HttpGet("Managers/{id}")]
        public IActionResult GetEmployees(string id)
        {
            var employees = employeeService.GetEmployees(id);
            if (employees == null)
                return NotFound();
            return Ok(employees);
        }



       

        // POST api/values
       

        // PUT api/values/5
     

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
