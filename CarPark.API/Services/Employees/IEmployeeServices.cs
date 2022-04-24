using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Employees
{
    public interface IEmployeeServices
    {
        int AddEmployee(Employee employee);
         
        List<Employee> GetAllEmployees();

        int DeleteEmployee(long id);

        int UpdateEmployee(long id, Employee employee);
        Employee FindById(long id);
        
        List<Employee> Find(Employee employee);
        bool IsAuthen(string account, string password);
    }
}
