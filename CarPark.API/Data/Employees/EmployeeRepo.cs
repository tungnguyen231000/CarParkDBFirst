using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Employees
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly CarParkDBContext _context;

        public EmployeeRepo(CarParkDBContext context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAlls()
        {
            return _context.Employees.ToList();
        }

        public void Delete(long id)
        {
            _context.Employees.Remove(new Employee { EmployeeId = id });
            _context.SaveChanges();
        }


        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool IsExist(long id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }


        public Employee FindByID(long id)
        {
            return _context.Employees.Find(id);
        }

        public List<Employee> Find(Employee employee)
        {

            return _context.Employees.Where(e => e.EmployeeId == employee.EmployeeId ||
           e.EmployeeName.Contains(employee.EmployeeName) ||
           e.EmployeeAddress.Contains(employee.EmployeeAddress )||
           e.Department == employee.Department).ToList();

        }

        public bool IsDuplicate(string account)
        {
            return _context.Employees.Any(e => e.Account == account);
        }

        public bool Login(string account, string password)
        {
            return _context.Employees.Any(e => e.Account == account && e.Password == password);
        }
    }
}
