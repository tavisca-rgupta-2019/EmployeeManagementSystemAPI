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

        public List<Employee> GetEmployees(string ManagerId)
        {
            return _employeesDb.EmployeeList.FindAll(m => m.ManagerId == ManagerId);
        }

        public Employee GetEmployee(string EmpId)
        {
            return _employeesDb.EmployeeList.FirstOrDefault(e => e.Id == EmpId);
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                _employeesDb.EmployeeList.Add(employee);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateEmployee(Employee employee)
        {
            return _employeesDb.UpdateEmployee(employee);
        }
    }
}
