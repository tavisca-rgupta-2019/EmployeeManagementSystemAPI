using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI
{
    public interface IEmployeeDAL
    {
        List<EmployeeDTO> GetEmployeesList();
       


        bool UpdateEmployee(EmployeeDTO employee);

    }
}
