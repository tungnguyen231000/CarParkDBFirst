using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Parks
{
    public interface IParkRepo
    {
        List<Park> GetAll();
        void Add(Park newPark);
        bool IsExisted(long id);
        void Update(Park park);
        void Remove(long id);
        List<Park> Find(Park park);
        Park FindByID(long id);
    }
}
