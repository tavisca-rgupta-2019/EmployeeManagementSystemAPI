﻿using EMSPracticeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace EMSPracticeAPI.Services
{
    public class EmployeeService :IEmployeeService
    {
        private IEmployeeDAL _employeesDb;

        public EmployeeService(IEmployeeDAL employeeDb)
        {
            _employeesDb = employeeDb;
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            return _employeesDb.GetEmployeesList();
        }

        public EmployeeDTO GetManager(int managerId)
        {
            var employeeList=_employeesDb.GetEmployeesList();
            var isManager=employeeList.Any(e => e.ManagerId == managerId);
            if(isManager)
               return employeeList.FirstOrDefault(e => e.Id == managerId);
            return null;
        }

        public List<EmployeeDTO> GetEmployeesWorkingUnderSpecificManager(int managerId)
        {
            var isManager = _employeesDb.GetEmployeesList().Any(e => e.ManagerId == managerId);
            if (isManager)
                return _employeesDb.GetEmployeesList().FindAll(e => e.ManagerId == managerId);
            return null;
        }

        public EmployeeDTO GetEmployee(int empId)
        {
            return _employeesDb.GetEmployeesList().FirstOrDefault(e => e.Id == empId);
        }

        public EmployeeDTO AddEmployee(EmployeeDTO employee)
        {
            
            
            
            return employee;
            //var maxEmployeeId = _employeesDb.GetEmployeesList().Max(e =>e.Id);
            //var newEmployee = new EmployeeDTO()
            //{
            //    Id = ++maxEmployeeId,
            //    Name = employee.Name,
            //    Age = employee.Age,
            //    Salary = employee.Salary,
            //    ManagerId = employee.ManagerId
            //};
            //try
            //{
            //    _employeesDb.GetEmployeesList().Add(newEmployee);
            //}
            //catch (Exception e)
            //{
            //return null;
            //}
            //return newEmployee;
        }
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            var employeeFromStore = _employeesDb.GetEmployeesList().FirstOrDefault(e => e.Id == employee.Id);
            if (employeeFromStore == null)
                return false;
            return _employeesDb.UpdateEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            var index = _employeesDb.GetEmployeesList().FindIndex(e => e.Id == id);
           
            _employeesDb.GetEmployeesList().RemoveAt(index);

        }
    }
}
