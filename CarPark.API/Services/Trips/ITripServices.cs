using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Trips
{
    public interface ITripServices
    {
        List<Trip> GetAllTrips();
        bool AddTrip(Trip trip);
        int EditPark(long id, Trip trip);
        int DeleteTrip(long id);
        Trip GetTripByID(long id);
        List<Trip> GetTripByDestination(Trip trip);
        List<Trip> GetTripByDriver(Trip trip);
        List<Trip> GetTripByCarType(Trip trip);
        List<Trip> GetTripByBookedTicketNumber(Trip trip);
    }
}
