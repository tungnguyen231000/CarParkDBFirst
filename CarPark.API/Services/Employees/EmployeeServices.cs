using CarPark.API.Data.Cars;
using CarPark.API.Data.Employees;
using CarPark.Data;
using System;
using System.Collections.Generic;

namespace CarPark.API.Services.Employees
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeServices(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo; 
        }

        public int AddEmployee(Employee employee)
        {
            if (_employeeRepo.IsDuplicate(employee.Account))
            {
                return -1;
            }
            else
            {
                try
                {
                    _employeeRepo.Add(employee);
                    return 1;

                }
                catch (Exception)
                {
                    return 0;
                }
            }
           
        }

        public List<Employee> GetAllEmployees()
        { 
            return _employeeRepo.GetAlls();
        }

        public int DeleteEmployee(long id)
        {
            if (_employeeRepo.IsExist(id))
            {
                try
                {
                    _employeeRepo.Delete(id);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            else
            {

                return -1;
            }
          
        }

        public int UpdateEmployee(long id, Employee employee)
        {
            
            if (_employeeRepo.IsExist(id))
            {
                if (id == employee.EmployeeId)
                {
                    try
                    {
                        _employeeRepo.UpdateEmployee(employee);
                        return 1;

                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
                else
                {
                    return -2;
                }
                
            }
            else
            { 
                return -1;
            }

           
        }
         
        public Employee FindById(long id)
        {

            return _employeeRepo.FindByID(id);
        }

        public List<Employee> Find(Employee employee)
        { 
            return _employeeRepo.Find(employee);
        }

        public bool IsAuthen(string account, string password)
        {
            return _employeeRepo.Login(account, password);
        }
    }
}
