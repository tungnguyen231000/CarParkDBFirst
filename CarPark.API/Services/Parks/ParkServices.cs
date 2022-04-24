using CarPark.API.Data.Parks;
using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Parks
{
    public class ParkServices : IParkServices
    {
        private readonly IParkRepo _parkRepo;

        public ParkServices(IParkRepo parkRepo)
        {
            _parkRepo = parkRepo;
        }

        public bool AddPark(Park newPark)
        {
            try
            {
                _parkRepo.Add(newPark);
                return true;
            }
            catch (Exception)
            {


                return false;
            }
        }

        public int DeletePark(long id)
        {
            if (_parkRepo.IsExisted(id))
            {
                try
                {
                    _parkRepo.Remove(id);
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

        public int EditPark(long id, Park park)
        {
            if (_parkRepo.IsExisted(id))
            {
                if (id == park.ParkId)
                {
                    _parkRepo.Update(park);
                    return 1;
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

        public List<Park> GetAllParks()
        {
            return _parkRepo.GetAll();
        }

        public List<Park> GetParkByArea(Park park)
        {
            return _parkRepo.Find(park);
        }

        public Park GetParkByID(long id)
        {
            return _parkRepo.FindByID(id);
        }

        public List<Park> GetParkByName(Park park)
        {

            return _parkRepo.Find(park);
        }

        public List<Park> GetParkByPlace(Park park)
        {
            return _parkRepo.Find(park);
        }

        public List<Park> GetParkByPrice(Park park)
        {
            return _parkRepo.Find(park);
        }

        public List<Park> GetParkByStatus(Park park)
        {
            return _parkRepo.Find(park);
        }
    }
}
