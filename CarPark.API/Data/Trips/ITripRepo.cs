using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Trips
{
    public interface ITripRepo
    {
        bool IsExisted(long id);
        void Add(Trip trip);
        void Remove(long id);
        void Update(Trip trip);
        List<Trip> GetAll();
        Trip FindByID(long id);
        List<Trip> Find(Trip trip);
    }
}
