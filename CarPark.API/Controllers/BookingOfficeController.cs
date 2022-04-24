using CarPark.API.Services.BookingOffices;
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
    public class BookingOfficeController : ControllerBase
    {
        private readonly IBookingOfficeServices _officeServices;

        public BookingOfficeController(IBookingOfficeServices officeServices)
        {
            _officeServices = officeServices;
        }


        [Authorize]
        [HttpGet]
        public IActionResult GetOffices()
        {
            var result = _officeServices.GetAllOffices();
            if (result.Count > 0)
            {

                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "There is no booking office to display!"
                });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddOffice(BookingOffice office)
        {
            bool result = _officeServices.AddOffice(office);

            if (result)
            {
                return Ok(new
                {
                    message = "Add office successfully!!"
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
        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(long id)
        {
            int result = _officeServices.DeleteOffice(id);

            if (result==1)
            {
                return Ok(new
                {
                    message = "Delete successfully!!"
                });
            }
            else if (result == -1)
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
                    message = "Cannot delete this office!"
                });
            }

        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditOffice(long id, BookingOffice office)
        {
            int result = _officeServices.UpdateOffice(id, office);

            if (result == 1)
            {
                return Ok(new
                {
                    message = "Update successfully!!"
                });
            }
            else if (result == -1)
            {
                return BadRequest(new
                {
                    message = "ID does not exist!"
                });
            }
            else if (result == -2)
            {
                return BadRequest(new
                {
                    message = "ID you input does not match office's ID!"
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

        //[Authorize]
        //[HttpGet("{tripid}")]
        //public IActionResult GetOfficeOfTrip(long tripid)
        //{
        //    int result = _officeServices.GetOfficeByTripID();

        //    if (result.Count > 0)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(new
        //        {
        //            message = "There is no booking office to display!"
        //        });
        //    }
        //}

        [Authorize]
        [HttpGet]
        [Route("SearchByID/{id}")]
        public IActionResult GetOfficeByID(long id)
        {
            BookingOffice result = _officeServices.FindByID(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                { 
                    message = "0 booking office found!!"
                });
            }
        }

        [Authorize]
        [HttpGet] 
        [Route("SearchByName/{name}")]
        public IActionResult GetOfficeByName(string name)
        {
            var result = _officeServices.Find(new BookingOffice { OfficeName = name });

            if (result.Count>0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 booking office found!!"
                });
            }
        }

    }
}
