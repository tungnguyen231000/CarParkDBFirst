using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Parks
{
    public interface IParkServices
    {
        List<Park> GetAllParks();
        bool AddPark(Park newPark);
        int EditPark(long id, Park park);
        int DeletePark(long id);
        List<Park> GetParkByPrice(Park park);
        List<Park> GetParkByStatus(Park park);
        List<Park> GetParkByName(Park park);
        List<Park> GetParkByArea(Park park);
        Park GetParkByID(long id);
        List<Park> GetParkByPlace(Park park);
    }
}
