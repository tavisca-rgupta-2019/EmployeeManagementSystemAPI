using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI.Models
{
    public class EmployeeCreation
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public Double Salary { get; set; }
        public string ManagerId { get; set; } 
    }
}
