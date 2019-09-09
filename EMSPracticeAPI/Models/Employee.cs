using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI.Models
{
    public class Employee
    {
        public string Id { get; }
        public string Name { get;}

        public int Age { get;}
        public Double Salary { get;}
        public string ManagerId { get;}
        public Employee(string Id, string Name, int Age, Double Salary, String ManagerId = null)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Salary = Salary;
            this.ManagerId = ManagerId;
        }

    }
}
