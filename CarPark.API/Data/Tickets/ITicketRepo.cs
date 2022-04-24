using CarPark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.API.Data.Tickets
{
    public interface ITicketRepo
    {
        List<Ticket> GetAll(); 
        bool IsExisted(long id);
        void Update(Ticket ticket);
        void Remove(long id);
        void Add(Ticket newTicket);
        Ticket FindByID(long id);
        List<Ticket> Find(Ticket ticket);
    }
}
