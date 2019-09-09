using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI.Services
{
    public class EmployeeService
    {
        public EmployeeDb EmployeesDb = EmployeeDb.GetInstance;

        public List<Employee> GetAllEmployees()
        {
            return EmployeesDb.EmployeeList;
        }

        public List<Employee> GetEmployees(string ManagerId)
        {
            return EmployeesDb.EmployeeList.FindAll(m => m.ManagerId == ManagerId);
        }

        public Employee GetEmployee(string EmpId)
        {
            return EmployeesDb.EmployeeList.FirstOrDefault(e => e.Id == EmpId);
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                EmployeesDb.EmployeeList.Add(employee);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
        public bool UpdateEmployee(Employee employee)
        {
            return EmployeesDb.UpdateEmployee(employee);
        }
    }
}
