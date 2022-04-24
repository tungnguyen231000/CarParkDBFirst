using CarPark.API.Services.Employees;
using CarPark.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var result = _employeeServices.GetAllEmployees();
            if (result.Count > 0)
            {

                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "There is no employee to display"
                });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddEmployee(Employee newEmployee)
        {
            var result = _employeeServices.AddEmployee(newEmployee);

            if (result==1)
            {
                return Ok(new
                {
                    message = "Add successfully!"
                });
            }
            else if (result==-1)
            {
                return BadRequest(new
                {
                    message = "Account already existed!"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Invalid infomation!"
                });
            }

        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(long id, Employee employee)
        {

            var result = _employeeServices.UpdateEmployee(id, employee);

            if (result == 1)
            {
                return Ok(new
                {
                    message = "Update successfully!"
                });
            }
            else if(result == -1)
            {
                return BadRequest(new
                {
                    message = "ID does not exist!"
                });
            }
            else if(result == -2)
            {
                return BadRequest(new
                { 
                    message = "ID you input does not match employee's ID!"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Invalid information!"
                });
               

            }

        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(long id)
        {
            int result = _employeeServices.DeleteEmployee(id);
            if (result==1)
            {
                return Ok(new
                {
                    message="Delete successfully!"
                });
            }
            else if(result==-1)
            {
                return BadRequest(new
                {
                    message = "ID does not exist!"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Cannot delete this employee!"
                });
            }
        }

        [Authorize] 
        [HttpGet]
        [Route("SearchByID/{id}")]
        public IActionResult GetEmployeeByID(long id)
        {
            Employee result = _employeeServices.FindById(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 employee found!!"
                });
            }
        }

        [Authorize]
        [HttpGet] 
        [Route("SearchByName/{name}")]
        public IActionResult GetEmployeeByName(string name)
        {
            var result = _employeeServices.Find(new Employee { EmployeeName=name});

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 employee found!!"
                });
            }
        }

        [Authorize] 
        [HttpGet]
        [Route("SearchByAddress/{address}")]
        public IActionResult GetEmployeeByAddress(string address)
        {
            var result = _employeeServices.Find(new Employee { EmployeeAddress = address });

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 employee found!!"
                });
            }
        }
        
        [Authorize] 
        [HttpGet]
        [Route("SearchByDepartment/{department}")]
        public IActionResult GetEmployeeByDepartment(string department)
        {
            var result = _employeeServices.Find(new Employee { Department = department });

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 employee found!!"
                });
            }
        }

    }
}
