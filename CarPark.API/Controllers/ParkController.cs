using CarPark.API.Services.Parks;
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
    public class ParkController : ControllerBase
    {
        private readonly IParkServices _parkServices;

        public ParkController(IParkServices parkServices)
        {
            _parkServices = parkServices;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddPark(Park newPark)
        {
            bool result = _parkServices.AddPark(newPark);
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
        public IActionResult GetAllParks()
        {
            List<Park> result = _parkServices.GetAllParks();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "There is no parking lot to display!"
                });
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult EditPark(long id, Park park)
        {
            int result = _parkServices.EditPark(id, park);
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
                    message = "parking lot ID you input does not match update parking lot's ID!"
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
        public IActionResult DeletePark(long id)
        {
            int result = _parkServices.DeletePark(id);
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
                    message = "Cannot delete this parking lot!"
                });
            }

        }

        [Authorize]
        [HttpGet("SearchParkByID/{id}")]
        public IActionResult GetParkByPlace(long id)
        {
            Park result = _parkServices.GetParkByID(id);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 parking lot found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchParkByArea/{area}")]
        public IActionResult GetParkByArea(long area)
        {
            List<Park> result = _parkServices.GetParkByArea(new Park { ParkArea = area });

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 parking lot found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchParkByName/{name}")]
        public IActionResult GetParkByName(string name)
        {
            List<Park> result = _parkServices.GetParkByName(new Park { ParkName = name });

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 parking lot found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchParkByPlace/{place}")]
        public IActionResult GetParkByPlace(string place)
        {
            List<Park> result = _parkServices.GetParkByPlace(new Park { ParkPlace = place });

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 parking lot found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchParkByStatus/{status}")]
        public IActionResult GetParkByStatus(string status)
        {
            List<Park> result = _parkServices.GetParkByStatus(new Park { ParkStatus = status });

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 parking lot found!"
                });
            }
        }

        [Authorize]
        [HttpGet("SearchParkByPrice/{price}")]
        public IActionResult GetParkByPrice(long price)
        {
            List<Park> result = _parkServices.GetParkByPrice(new Park { ParkPrice = price });

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 parking lot found!"
                });
            }
        }

    }
}
