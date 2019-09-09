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
                new Employee(){Id="1",Name="Rohit",Age=25,Salary=150000 },
                new Employee(){Id="2",Name="Raj",Age=23,Salary=45000,ManagerId="1" },
                new Employee(){Id="3",Name="Rahul",Age=23,Salary=45000,ManagerId="1" },
                new Employee() {Id="4",Name="Varun",Age=23,Salary=45000,ManagerId="2" },
                new Employee(){Id="5",Name="Rochit",Age=23,Salary=45000,ManagerId="2" }
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

