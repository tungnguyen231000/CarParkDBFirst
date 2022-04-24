using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Cars
{
    public class CarRepo : ICarRepo
    {
        private readonly CarParkDBContext _context;

        public CarRepo(CarParkDBContext context)
        {
            _context = context;
        }

        public List<Car> GetAll()
        {
            return _context.Cars.ToList();
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Remove(string plate)
        {
            _context.Cars.Remove(new Car { LicensePlate = plate });
            _context.SaveChanges();
        }

        public bool IsExisted(string plate)
        {
            return _context.Cars.Any(c => c.LicensePlate.ToLower().Equals(plate.ToLower()));
        }

        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Car FindByPlate(string plate)
        {
            return _context.Cars.Find(plate);
        }

        public List<Car> Find(Car car)
        {
            return _context.Cars.Where(c => c.CarType == car.CarType ||
            c.CarColor == car.CarColor ||
            c.Company.Contains(car.Company)||
            c.ParkId == car.ParkId
            ).ToList();
        }
    }
}
