using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stefanek.Data;
using Stefanek.Models;
using Stefanek.Repositories.Abstraction;

namespace Stefanek.Repositories.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        readonly ApplicationContext _context;

        public ReservationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> Reservations 
            => _context.Reservations.Include(x => x.Car);

        public void Add(Reservation item)
        {
            _context.Reservations.Add(item);
            _context.SaveChanges();
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Reservation item)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservation item)
        {
            throw new NotImplementedException();
        }
    }
}
