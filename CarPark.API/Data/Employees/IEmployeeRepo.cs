using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Employees
{
    public interface IEmployeeRepo
    {
        void Add(Employee employee);

        List<Employee> GetAlls();

        void Delete(long id);
         

        void UpdateEmployee(Employee employee);

        bool IsExist(long id);
        Employee FindByID(long id);
        List<Employee> Find(Employee employee);
        bool IsDuplicate(string account);
        bool Login(string account, string password);
    }
}
