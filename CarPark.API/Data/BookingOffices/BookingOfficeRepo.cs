using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.BookingOffices
{
    public class BookingOfficeRepo : IBookingOfficeRepo
    {
        private readonly CarParkDBContext _context;

        public BookingOfficeRepo(CarParkDBContext context)
        {
            _context = context;
        }

        public void Add(BookingOffice office)
        {
            _context.BookingOffices.Add(office);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            _context.BookingOffices.Remove(new BookingOffice { OfficeId=id});
            _context.SaveChanges();
        }

        public List<BookingOffice> Find(BookingOffice bookingOffice)
        {
            return _context.BookingOffices.Where(b=> b.OfficeName==bookingOffice.OfficeName).ToList();
        }

        public BookingOffice FindByID(long id)
        {
            return _context.BookingOffices.Find(id);
        }

        public List<BookingOffice> GetAll()
        {
            return _context.BookingOffices.ToList();
        }

        public bool IsExisted(long id)
        {
            return _context.BookingOffices.Any(b => b.OfficeId == id);
        }

        public void Update(BookingOffice office)
        {
            _context.Entry(office).State = EntityState.Modified;
            _context.SaveChanges();
        }
         
    }
}
