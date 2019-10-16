using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetManager(int managerId);
        List<EmployeeDTO> GetEmployeesWorkingUnderSpecificManager(int managerId);
        EmployeeDTO GetEmployee(int empId);
        EmployeeDTO AddEmployee(EmployeeDTO employee);
        bool UpdateEmployee(EmployeeDTO employee);
        void DeleteEmployee(int id);

    }
}
