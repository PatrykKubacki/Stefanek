using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stefanek.Data;
using Stefanek.Models;
using Stefanek.Repositories.Abstraction;

namespace Stefanek.Repositories.Implementation
{
    public class CityRepostiory : ICityRepository
    {
        readonly ApplicationContext _context;

        public CityRepostiory(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<City> Cities => _context.Cities;

        public void Add(City item)
        {
            throw new NotImplementedException();
        }

        public City GetById(int id) 
            => _context.Cities.FirstOrDefault(city => city.CityId == id);

        public void Remove(City item)
        {
            throw new NotImplementedException();
        }

        public void Update(City item)
        {
            throw new NotImplementedException();
        }
    }
}
