using CarPark.API.Services.Cars;
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
    public class CarController : ControllerBase
    {
        private readonly ICarServices _carServices;

        public CarController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddCar(Car car)
        {
            bool result = _carServices.AddCar(car);

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
                    message = "Invalid infomation!"
                });
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCars()
        {
            var result = _carServices.GetAllCars();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "There is no car to display!"
                });
            }

        }

        [HttpPut("{plate}")]
        public IActionResult EditCar(string plate, Car car)
        {
            int result = _carServices.UpdateCar(plate, car);

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
                    message = "License plate does not exist!"
                });
            }
            else if (result == -2)
            {
                return BadRequest(new
                {
                    message = "License plate you input does not match update car's plate!"

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
        [HttpDelete("{plate}")]
        public IActionResult DeleteCar(string plate)
        {
            int result = _carServices.DeleteCar(plate);
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
                    message = "License plate does not exist!"
                });
            }
            else
            {
                return BadRequest(new
                {
                    message = "Cannot delete this car!"
                });
            }
        }


        [Authorize]
        [HttpGet]
        [Route("SearchByPlate/{plate}")]

        public IActionResult FindCarByPlate(string plate)
        {
            Car result = _carServices.FindByPlate(plate);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 car found!"
                });
            }
        }
        

        [Authorize]
        [HttpGet]
        [Route("SearchByType/{type}")]
        public IActionResult FindCarByType(string type)
        {
           var result = _carServices.Find(new Car {CarType= type });
            if (result.Count>0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 car found!"
                });
            }
        }
        
        [Authorize]
        [HttpGet]
        [Route("SearchByColor/{color}")]
        public IActionResult FindCarByColor(string color)
        {
           var result = _carServices.Find(new Car {CarColor= color });
            if (result.Count>0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 car found!"
                });
            }
        }
        
        [Authorize]
        [HttpGet]
        [Route("SearchByCompany/{company}")]
        public IActionResult FindCarByCompany(string company)
        {
           var result = _carServices.Find(new Car {Company= company });
            if (result.Count>0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(new
                {
                    message = "0 car found!"
                });
            }
        }

        //[HttpGet("{parkid}")]
        //public IActionResult GetCarsInPark(long parkid)
        //{
        //    if (_context.Parks.Any(p => p.ParkId == parkid))
        //    {
        //        return Ok(_context.Cars.Where(c => c.ParkId == parkid).ToList());

        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
    }
}
