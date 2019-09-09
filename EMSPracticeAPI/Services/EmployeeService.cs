using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI.Services
{
    public class EmployeeService
    {
        private EmployeeDb _employeesDb = EmployeeDb.GetInstance;

        public List<Employee> GetAllEmployees()
        {
            return _employeesDb.EmployeeList;
        }

        public List<Employee> GetEmployees(string managerId)
        {
            return _employeesDb.EmployeeList.FindAll(m => m.ManagerId == managerId);
        }

        public Employee GetEmployee(string empId)
        {
            return _employeesDb.EmployeeList.FirstOrDefault(e => e.Id == empId);
        }

        public Employee AddEmployee(EmployeeCreation employee)
        {
            var maxEmployeeId = _employeesDb.EmployeeList.Max(e => Int32.Parse(e.Id));
            var newEmployee = new Employee()
            {
                Id = (++maxEmployeeId).ToString(),
                Name = employee.Name,
                Age = employee.Age,
                Salary = employee.Salary,
                ManagerId = employee.ManagerId
            };
            try
            {
                _employeesDb.EmployeeList.Add(newEmployee);
            }
            catch (Exception e)
            {
                return null;
            }
            return newEmployee;
        }
        public bool UpdateEmployee(Employee employee)
        {
            var employeeFromStore = _employeesDb.EmployeeList.FirstOrDefault(e => e.Id == employee.Id);
            if (employeeFromStore == null)
                return false;
            return _employeesDb.UpdateEmployee(employee);
        }
    }
}
