using CarPark.API.Data.Trips;
using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Trips
{
    public class TripServices:ITripServices
    {
        private readonly ITripRepo _tripRepo;

        public TripServices(ITripRepo tripRepo)
        {
            _tripRepo = tripRepo;
        }

        public bool AddTrip(Trip trip)
        {
            try
            {
                _tripRepo.Add(trip);
                return true;
            }
            catch (Exception)
            { 
                return false;
            }
        }

        public int DeleteTrip(long id)
        {
            if (_tripRepo.IsExisted(id))
            {
                try
                {
                    _tripRepo.Remove(id);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            else
            {
                return -1;
            }
           
        }

        public int EditPark(long id, Trip trip)
        {
            if (_tripRepo.IsExisted(id))
            {
                if (id==trip.TripId)
                {
                    try
                    {
                        _tripRepo.Update(trip);
                        return 1;
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
                else
                {
                    return -2;
                }
                
            }
            else
            {
                return -1;
            }
        }

        public List<Trip> GetAllTrips()
        {
            return _tripRepo.GetAll();
        }

        public List<Trip> GetTripByBookedTicketNumber(Trip trip)
        {
            return _tripRepo.Find(trip);
        }

        public List<Trip> GetTripByCarType(Trip trip)
        {
            return _tripRepo.Find(trip);
        }

        public List<Trip> GetTripByDestination(Trip trip)
        {
            return _tripRepo.Find(trip);
        }

        public List<Trip> GetTripByDriver(Trip trip)
        {
            return _tripRepo.Find(trip);
        }

        public Trip GetTripByID(long id)
        {
            return _tripRepo.FindByID(id);
        }
    }
}
