using CarPark.API.Services.Trips;
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
    public class TripController : ControllerBase
    {
        private readonly ITripServices _tripServices;

        public TripController(ITripServices tripServices)
        {
            _tripServices = tripServices;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddNewTrip(Trip trip)
        {
            bool result = _tripServices.AddTrip(trip);

            if (result)
            {
                return Ok(new
                {
                    message = "Add successfully!"
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
        [HttpGet]
        public IActionResult GetAllTrips()
        {
            List<Trip> result = _tripServices.GetAllTrips();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "There is no trip to display!"
                });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditTrip(long id, Trip trip)
        {
            int result = _tripServices.EditPark(id, trip);
            if (result == 1)
            {
                return Ok(new
                {
                    message = "Update successfully!"
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
                    message = "Trip ID you input does not match update trip's ID!"  
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Ivalid information!"
                });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteTrip(long id)
        {
            int result = _tripServices.DeleteTrip(id);
            if (result == 1)
            {
                return Ok(new
                {
                    message = "Delete successfully!"
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
                    message = "Cannot delete this trip!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchByTripID/{id}")]
        public IActionResult GetTripByDestination(long id)
        {
             Trip result = _tripServices.GetTripByID(id);
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 trip found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchByDestination/{destination}")]
        public IActionResult GetTripByDestination(string destination)
        {
            List<Trip> result = _tripServices.GetTripByDestination(new Trip { Destination=destination});
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 trip found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchByDriver/{driver}")]
        public IActionResult GetTripByDriver(string driver)
        {
            List<Trip> result = _tripServices.GetTripByDriver(new Trip { Driver= driver });
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 trip found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchByCarType/{cartype}")]
        public IActionResult GetTripByCarType(string cartype)
        {
            List<Trip> result = _tripServices.GetTripByCarType(new Trip { CarType= cartype });
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 trip found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchByBookedTicketNumber/{number}")]
        public IActionResult GetTripByBookedTicketNumber(int number)
        {
            List<Trip> result = _tripServices.GetTripByBookedTicketNumber(new Trip { BookedTicketNumber = number });
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 trip found!"
                });
            }
        }
    }



}
