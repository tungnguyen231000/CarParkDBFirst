using CarPark.API.Data.Tickets;
using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Tickets
{
    public class TicketServices:ITicketServices
    {
        private readonly ITicketRepo _ticketRepo;

        public TicketServices(ITicketRepo ticketRepo)
        {
            _ticketRepo = ticketRepo;
        }

        public bool AddTicket(Ticket newTicket)
        {
            try
            {
                _ticketRepo.Add(newTicket);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int DeleteTicket(long id)
        {
            if (_ticketRepo.IsExisted(id))
            {
                try
                {
                    _ticketRepo.Remove(id);
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

        public int EditTicket(long id, Ticket ticket)
        {
            if (_ticketRepo.IsExisted(id))
            {
                if (id==ticket.TicketId)
                {
                    try
                    {
                        _ticketRepo.Update(ticket);
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

        public List<Ticket> GetAllTickets()
        {
            return _ticketRepo.GetAll();
        }

        public List<Ticket> GetTicketByCustomerName(Ticket ticket)
        {
            return _ticketRepo.Find(ticket);
        }

        public Ticket GetTicketByID(long id)
        {
            return _ticketRepo.FindByID(id);
        }

        public List<Ticket> GetTicketByLicensePlate(Ticket ticket)
        {
            return _ticketRepo.Find(ticket);
        }

        public List<Ticket> GetTicketByTripID(Ticket ticket)
        {
            return _ticketRepo.Find(ticket);
        }
         
    }
}
