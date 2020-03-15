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
    public class LocationRepository : ILocationRepository
    {
        readonly ApplicationContext _context;
        public IEnumerable<Location> Locations 
            => _context.Locations.Include(e=>e.City);

        public LocationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Location item)
        {
            throw new NotImplementedException();
        }

        public Location GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Location item)
        {
            throw new NotImplementedException();
        }

        public void Update(Location item)
        {
            throw new NotImplementedException();
        }
    }
}
