using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI
{
    public sealed class EmployeeDb
    {
       
        private static EmployeeDb Instance = null;
        public static EmployeeDb GetInstance
        {
            get
            {
                if (Instance == null)
                    Instance = new EmployeeDb();
                return Instance;
            }
        }

        public List<Employee> EmployeeList = null;
        private EmployeeDb()
        {
            EmployeeList = new List<Employee>()
            {
                new Employee("1","Rohit",25,150000),
                new Employee("2","Raj",23,45000,"1"),
                new Employee("3","Rahul",23,45000,"1"),
                new Employee("4","Varun",23,45000,"2"),
                new Employee("5","Rochit",23,45000,"2"),
            };
        }

        public bool UpdateEmployee(Employee employee)
        {
            var index = EmployeeList.FindIndex(e => e.Id == employee.Id);
            try
            {
                EmployeeList.Insert(index, employee);
            }
            catch(Exception e)
            {
                Console.WriteLine("Could Not Update");
                return false;

            }
            return true;

        }


            
    }
}

