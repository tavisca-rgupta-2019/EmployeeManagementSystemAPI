using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMSPracticeAPI
{
    public sealed class EmployeeDAL:IEmployeeDAL
    {
       
       
      

        public static List<EmployeeDTO> EmployeeList = null;
        public EmployeeDAL()
        {
            EmployeeList = new List<EmployeeDTO>()
            {
                new EmployeeDTO(){Id=1,Name="Rohit",Age=25,Salary=150000 },
                new EmployeeDTO(){Id=2,Name="Raj",Age=23,Salary=45000,ManagerId=1 },
                new EmployeeDTO(){Id=3,Name="Rahul",Age=23,Salary=45000,ManagerId=1 },
                new EmployeeDTO() {Id=4,Name="Varun",Age=23,Salary=45000,ManagerId=2 },
                new EmployeeDTO(){Id=5,Name="Rochit",Age=23,Salary=45000,ManagerId=2 }
            };
        }

        public List<EmployeeDTO> GetEmployeesList()
        {
            return EmployeeList;
        }

        public bool UpdateEmployee(EmployeeDTO employee)
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

