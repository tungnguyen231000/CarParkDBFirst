using System;
using System.Collections.Generic;

#nullable disable

namespace CarPark.Data
{
    public partial class Employee
    {
        public long EmployeeId { get; set; }
        public string Account { get; set; }
        public string Department { get; set; }
        public string EmployeeAddress { get; set; }
        public DateTime? EmployeeBirthday { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePhone { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
    }
}
