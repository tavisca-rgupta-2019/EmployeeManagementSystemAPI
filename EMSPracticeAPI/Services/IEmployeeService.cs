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
        EmployeeDTO GetManager(string managerId);
        List<EmployeeDTO> GetEmployeesWorkingUnderSpecificManager(string managerId);
        EmployeeDTO GetEmployee(string empId);
        EmployeeDTO AddEmployee(EmployeeCreationDTO employee);
        bool UpdateEmployee(EmployeeDTO employee);
        void DeleteEmployee(string id);

    }
}
