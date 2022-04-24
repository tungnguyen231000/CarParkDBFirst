using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Cars
{
    public interface ICarServices
    {
        List<Car> GetAllCars();
        bool AddCar(Car car);
        int DeleteCar(string plate);
        int UpdateCar(string plate, Car car);
        Car FindByPlate(string plate);
        List<Car> Find(Car car);
    }
}
