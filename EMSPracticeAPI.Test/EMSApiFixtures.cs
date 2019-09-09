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
            var expeectedEmployeeCount = EmployeeDb.GetInstance.EmployeeList.Count;
            Assert.Equal(expeectedEmployeeCount, CountOfEmployees);

        }
        [Fact]
        public void Should_Be_Able_To_Return_All_Employees_Working_Under_A_Manager()
        {
            var CountOfEmployees = employeeService.GetEmployees("1").Count;
            var expeectedEmployeeCount = EmployeeDb.GetInstance.EmployeeList.FindAll(e=>e.ManagerId=="1").Count;
            Assert.Equal(expeectedEmployeeCount,CountOfEmployees);
        }
        [Fact]
        public void Should_Be_Able_To_Return_An_Employee()
        {
            var EmpId = employeeService.GetEmployee("3").Id;
            Assert.Equal("3",EmpId);
        }
        [Fact]
        public void Should_Be_Able_To_Add_An_Employee_Successfully()
        {
            var AddedSuccesfully = employeeService.AddEmployee(new Employee("6", "Shree", 24, 54000, "2"));
            Assert.True(AddedSuccesfully);
        }
        [Fact]
        public void Should_Be_Able_To_Update_An_Employee_Successfully()
        {
            var UpdatedSuccesfully = employeeService.UpdateEmployee(new Employee("3", "ShreeRam", 24, 40000, "1"));
            Assert.Equal(true, UpdatedSuccesfully);


        }





    }
}
