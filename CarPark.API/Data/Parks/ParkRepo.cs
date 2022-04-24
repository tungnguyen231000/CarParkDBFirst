using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Parks
{
    public class ParkRepo:IParkRepo
    {
        private readonly CarParkDBContext _context;

        public ParkRepo(CarParkDBContext context)
        {
            _context = context;
        }

        public void Add(Park newPark)
        {
            _context.Parks.Add(newPark);
            _context.SaveChanges();
        }

        public List<Park> Find(Park park)
        {
            return _context.Parks.Where(p => p.ParkArea == park.ParkArea ||
            p.ParkPrice == park.ParkPrice ||
            p.ParkName.Contains(park.ParkName) ||
            p.ParkStatus==park.ParkStatus||
            p.ParkPlace.Contains(park.ParkPlace)
            ).ToList();
        }

        public Park FindByID(long id)
        {

            return _context.Parks.Find(id);
        }

        public List<Park> GetAll()
        {
            return _context.Parks.ToList();
        }

        public bool IsExisted(long id)
        {
            return _context.Parks.Any(p => p.ParkId == id);
        }

        public void Remove(long id)
        {
            _context.Parks.Remove(new Park {ParkId=id });
            _context.SaveChanges();
        }

        public void Update(Park park)
        {
            _context.Entry(park).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
