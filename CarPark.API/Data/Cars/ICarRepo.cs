
using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Cars
{
    public interface ICarRepo
    {
        List<Car> GetAll();
        void Add(Car car);
        void Remove(string plate);
        bool IsExisted(string plate);
        void Update(Car car);
        Car FindByPlate(string plate);
        List<Car> Find(Car car);
    }
}
