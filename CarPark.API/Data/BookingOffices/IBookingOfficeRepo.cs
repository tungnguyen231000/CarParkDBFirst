using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.BookingOffices
{
    public interface IBookingOfficeRepo
    {
        List<BookingOffice> GetAll();
        void Add(BookingOffice office);
        void Delete(long id);
        bool IsExisted(long id);
        void Update(BookingOffice office);
        BookingOffice FindByID(long id);
        List<BookingOffice> Find(BookingOffice bookingOffice);
    }
}
