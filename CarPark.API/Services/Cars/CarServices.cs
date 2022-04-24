using CarPark.API.Data.Cars;
using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Cars
{
    public class CarServices:ICarServices
    {
        private readonly ICarRepo _carRepo;

        public CarServices(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }

        public bool AddCar(Car car)
        {
            try
            {
                _carRepo.Add(car);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int DeleteCar(string plate)
        {
            if (_carRepo.IsExisted(plate))
            {
                try
                {
                    _carRepo.Remove(plate);
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

        public List<Car> Find(Car car)
        {
            return _carRepo.Find(car).ToList();
        }

        public Car FindByPlate(string plate)
        {
            return _carRepo.FindByPlate(plate);
        }

        public List<Car> GetAllCars()
        {
            return _carRepo.GetAll();
        }

        public int UpdateCar(string plate, Car car)
        {
            if (_carRepo.IsExisted(plate))
            {
                if (plate.ToLower().Equals(car.LicensePlate.ToLower()))
                {
                    try
                    {
                        _carRepo.Update(car);
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
         
    }
}
