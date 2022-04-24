using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.BookingOffices
{
    public interface IBookingOfficeServices
    {
        List<BookingOffice> GetAllOffices();
        bool AddOffice(BookingOffice office);
        int DeleteOffice(long id);
        int UpdateOffice(long id, BookingOffice office);
        List<BookingOffice> GetOfficeByTripID(); 
        BookingOffice FindByID(long id);
        List<BookingOffice> Find(BookingOffice bookingOffice);
    }
}
