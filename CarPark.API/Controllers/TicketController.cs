using CarPark.API.Services.Tickets;
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
    public class TicketController : ControllerBase
    {
        private readonly ITicketServices _ticketServices;

        public TicketController(ITicketServices ticketServices)
        {
            _ticketServices = ticketServices;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddNewTicket(Ticket newTicket)
        {
            bool result = _ticketServices.AddTicket(newTicket);

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
        public IActionResult GetAllTicket()
        {
            List<Ticket> result = _ticketServices.GetAllTickets();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "There is no ticket to display!"
                });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditTicket(long id, Ticket ticket)
        {
            int result = _ticketServices.EditTicket(id, ticket);
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
                    message = "Ticket ID you input does not match update ticket's ID!" 

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
        public IActionResult DeleteTicket(long id)
        {
            int result = _ticketServices.DeleteTicket(id);
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
                    message = "Cannot delete this ticket!"
                });
            }
        }



        [Authorize]
        [HttpGet("SearchByID/{id}")]
        public IActionResult GetTicketByID(long id)
        {
           Ticket result = _ticketServices.GetTicketByID(id);
            if (result !=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 ticket found!"
                });
            }
        }


        [Authorize]
        [HttpGet("SearchByCustomerName/{cname}")]
        public IActionResult GetTicketByCustomerName(string cname)
        {
            List<Ticket> result = _ticketServices.GetTicketByCustomerName(new Ticket {CustomerName= cname });
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 ticket found!"
                });
            }
        }
        
        [Authorize]
        [HttpGet("SearchByLicensePlate/{plate}")]
        public IActionResult GetTicketByLicensePlate(string plate)
        {
            List<Ticket> result = _ticketServices.GetTicketByLicensePlate(new Ticket { LicensePlate = plate });
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 ticket found!"
                });
            }
        }
         
        [Authorize]
        [HttpGet("SearchByTripID/{tripid}")]
        public IActionResult GetTicketByTripID(long tripid)
        {
            List<Ticket> result = _ticketServices.GetTicketByTripID(new Ticket { TripId = tripid });
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 ticket found!"
                });
            }
        }

    }
}
