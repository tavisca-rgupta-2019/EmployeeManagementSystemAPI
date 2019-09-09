using EMSPracticeAPI.Services;
using EMSPracticeAPI.Models;
using System;
using Xunit;

namespace EMSPracticeAPI.Test
{
    public class EMSApiFixtures
    {
        EmployeeService employeeService = new EmployeeService();
        [Fact]
        public void Should_Be_Able_To_Return_All_Employees_In_The_Company()
        {
            var CountOfEmployees = employeeService.GetAllEmployees().Count;
            var ActualCount = employeeService.EmployeesDb.EmployeeList.Count;
            Assert.Equal(CountOfEmployees, ActualCount);
           
        }
        [Fact]
        public void Should_Be_Able_To_Return_All_Employees_Working_Under_A_Manager()
        {
            var CountOfEmployees = employeeService.GetEmployees("1").Count;
            var ActualCount = employeeService.EmployeesDb.EmployeeList.FindAll(e=>e.ManagerId=="1").Count;
            Assert.Equal(CountOfEmployees,ActualCount);
        }
        [Fact]
        public void Should_Be_Able_To_Return_An_Employee()
        {
            var EmpId = employeeService.GetEmployee("3").Id;
            Assert.Equal(EmpId,"3");
        }
        [Fact]
        public void Should_Be_Able_To_Add_An_Employee_Successfully()
        {
            var AddedSuccesfully = employeeService.AddEmployee(new Employee("6", "Shree", 24, 54000, "2"));
            Assert.Equal(AddedSuccesfully,true);
        }
        [Fact]
        public void Should_Be_Able_To_Update_An_Employee_Successfully()
        {
            var UpdatedSuccesfully = employeeService.UpdateEmployee(new Employee("3", "ShreeRam", 24, 40000, "1"));
            Assert.Equal(UpdatedSuccesfully, true);


        }





    }
}
