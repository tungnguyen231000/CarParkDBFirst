using CarPark.API.Data;
using CarPark.API.Data.BookingOffices;
using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.BookingOffices
{
    public class BookingOfficeServices : IBookingOfficeServices
    {
        private readonly IBookingOfficeRepo _bookingOfficeRepo;

        public BookingOfficeServices(IBookingOfficeRepo bookingOfficeRepo)
        {
            _bookingOfficeRepo = bookingOfficeRepo;
        }

        public bool AddOffice(BookingOffice office)
        {
            try
            {
                _bookingOfficeRepo.Add(office);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public int DeleteOffice(long id)
        {
            if (_bookingOfficeRepo.IsExisted(id))
            {
                try
                {
                    _bookingOfficeRepo.Delete(id);
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

        public List<BookingOffice> Find(BookingOffice bookingOffice)
        {
            return _bookingOfficeRepo.Find(bookingOffice);
        }
         

        public BookingOffice FindByID(long id)
        { 
           return _bookingOfficeRepo.FindByID(id);
        }

        public List<BookingOffice> GetAllOffices()
        {
            return _bookingOfficeRepo.GetAll();
        }

        public List<BookingOffice> GetOfficeByTripID()
        {
            throw new NotImplementedException();
        }

        public int UpdateOffice(long id, BookingOffice office)
        {
            if (_bookingOfficeRepo.IsExisted(id))
            {
                if (id == office.OfficeId)
                {
                    try
                    {
                        _bookingOfficeRepo.Update(office);
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
