using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Services.Tickets
{
    public interface ITicketServices
    {
        bool AddTicket(Ticket newTicket);
        List<Ticket> GetAllTickets();
        int EditTicket(long id, Ticket ticket);
        int DeleteTicket(long id);

        Ticket GetTicketByID(long id); 
        List<Ticket> GetTicketByTripID(Ticket ticket);
        List<Ticket> GetTicketByLicensePlate(Ticket ticket);
        List<Ticket> GetTicketByCustomerName(Ticket ticket);
    }
}
