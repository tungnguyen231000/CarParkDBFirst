using CarPark.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Tickets
{
    public class TicketRepo:ITicketRepo
    {
        private readonly CarParkDBContext _context;

        public TicketRepo(CarParkDBContext context)
        {
            _context = context;
        }

        public void Add(Ticket newTicket)
        {
            _context.Tickets.Add(newTicket);
            _context.SaveChanges();
        }

        public List<Ticket> Find(Ticket ticket)
        {
            return _context.Tickets.Where(t=>t.TripId==ticket.TripId||
            t.CustomerName.Contains(ticket.CustomerName)||
            t.LicensePlate==ticket.LicensePlate).ToList();
        }

        public Ticket FindByID(long id)
        {
            return _context.Tickets.Find(id);
        }

        public List<Ticket> GetAll()
        {
            return _context.Tickets.ToList();
        }

        public bool IsExisted(long id)
        {
            return _context.Tickets.Any(t => t.TicketId == id);
        }

        public void Remove(long id)
        {
            _context.Tickets.Remove(new Ticket { TicketId=id});
            _context.SaveChanges();

        }

        public void Update(Ticket ticket)
        {
            _context.Entry(ticket).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
