using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Trips
{
    public class TripRepo:ITripRepo
    {
        private readonly CarParkDBContext _context;

        public TripRepo(CarParkDBContext context)
        {
            _context = context;
        }

        public void Add(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        public List<Trip> Find(Trip trip)
        {

            return _context.Trips.Where(t=>t.BookedTicketNumber==trip.BookedTicketNumber||
            t.CarType== trip.CarType ||
            t.Destination.Contains(trip.Destination)||
            t.Driver.Contains(trip.Driver)).ToList();
        }

        public Trip FindByID(long id)
        {
            return _context.Trips.Find(id);
        }

        public List<Trip> GetAll()
        {
            return _context.Trips.ToList();
        }

        public bool IsExisted(long id)
        {
            return _context.Trips.Any(t => t.TripId == id);
        }

        public void Remove(long id)
        {
            _context.Trips.Remove(new Trip { TripId=id});
            _context.SaveChanges();
        }

        public void Update(Trip trip)
        {
            _context.Entry(trip).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
