using EMSPracticeAPI.Services;
using EMSPracticeAPI.Models;
using System;
using Xunit;
using Moq;
using System.Collections.Generic;

namespace EMSPracticeAPI.Test
{
    public class EMSApiFixtures
    {
       
        [Fact]
        public void Should_Be_Able_To_Return_All_Employees_In_The_Company()
        {
            Mock<IEmployeeDAL> EmployeeDALMock = new Mock<IEmployeeDAL>();
            var employeeService = new EmployeeService(EmployeeDALMock.Object);
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id=1,
                    Name="Rohit Gupta",
                    Age=21,
                    Salary=150000
                },
                new EmployeeDTO()
                {
                    Id=2,
                    Name="Vishal",
                    Age=21,
                    Salary=150000
                }

            };
            EmployeeDALMock.Setup(e => e.GetEmployeesList()).Returns(employeeList);

            var CountOfEmployees = employeeService.GetAllEmployees().Count;
            
            Assert.Equal(2,CountOfEmployees);

        }
        [Fact]
        public void Should_Be_Able_To_Return_All_Employees_Working_Under_A_Manager()
        {
            Mock<IEmployeeDAL> EmployeeDALMock = new Mock<IEmployeeDAL>();
            var employeeService = new EmployeeService(EmployeeDALMock.Object);
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id=1,
                    Name="Rohit Gupta",
                    Age=21,
                    Salary=150000
                },
                new EmployeeDTO()
                {
                    Id=2,
                    Name="Vishal",
                    Age=21,
                    Salary=150000,
                    ManagerId=1
                }

            };
            EmployeeDALMock.Setup(e => e.GetEmployeesList()).Returns(employeeList);
            var CountOfEmployees = employeeService.GetEmployeesWorkingUnderSpecificManager(1).Count;
           
            Assert.Equal(1, CountOfEmployees);
        }
        [Fact]
        public void Should_Be_Able_To_Return_An_Employee()
        {
            Mock<IEmployeeDAL> EmployeeDALMock = new Mock<IEmployeeDAL>();
            var employeeService = new EmployeeService(EmployeeDALMock.Object);
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id=1,
                    Name="Rohit Gupta",
                    Age=21,
                    Salary=150000
                },
                new EmployeeDTO()
                {
                    Id=2,
                    Name="Vishal",
                    Age=21,
                    Salary=150000,
                    ManagerId=1
                }

            };
            EmployeeDALMock.Setup(e => e.GetEmployeesList()).Returns(employeeList);
            var EmpId = employeeService.GetEmployee(2).Id;
            Assert.Equal(2, EmpId);
        }
        [Fact]
        /*public void Should_Be_Able_To_Add_An_Employee_Successfully()
        {
            Mock<IEmployeeDAL> EmployeeDALMock = new Mock<IEmployeeDAL>();
            var employeeService = new EmployeeService(EmployeeDALMock.Object);
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id=1,
                    Name="Rohit Gupta",
                    Age=21,
                    Salary=150000
                },
                new EmployeeDTO()
                {
                    Id=2,
                    Name="Vishal",
                    Age=21,
                    Salary=150000,
                    ManagerId=1
                }

            };
            EmployeeDALMock.Setup(e => e.GetEmployeesList()).Returns(employeeList);
            var newEmployee = employeeService.AddEmployee(new EmployeeCreationDTO() { Name = "Shree", Age = 24, Salary = 54000, ManagerId = 2 });
            Assert.Equal("Shree",newEmployee.Name);
        }*/
        
        public void should_be_able_to_update_an_employee_successfully()
        {
            Mock<IEmployeeDAL> EmployeeDALMock = new Mock<IEmployeeDAL>();
            var employeeService = new EmployeeService(EmployeeDALMock.Object);
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>()
            {
                new EmployeeDTO()
                {
                    Id=1,
                    Name="Rohit Gupta",
                    Age=21,
                    Salary=150000
                },
                new EmployeeDTO()
                {
                    Id=2,
                    Name="Vishal",
                    Age=21,
                    Salary=150000,
                    ManagerId=1
                }

            };
            var updatedInfo = new EmployeeDTO() { Id = 2, Name = "Vishal", Age = 20, Salary = 150000, ManagerId = 1 };
            EmployeeDALMock.Setup(e => e.GetEmployeesList()).Returns(employeeList);
            EmployeeDALMock.Setup(e => e.UpdateEmployee(It.IsAny<EmployeeDTO>())).Returns(true);
            var updatedsuccesfully = employeeService.UpdateEmployee(updatedInfo);
            
            Assert.True(updatedsuccesfully);


        }





    }
}
