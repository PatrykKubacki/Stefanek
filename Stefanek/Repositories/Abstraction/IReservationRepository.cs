using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stefanek.Models;

namespace Stefanek.Repositories.Abstraction
{
    public interface IReservationRepository: IRepository<Reservation>
    {
        IEnumerable<Reservation> Reservations { get; }
    }
}
