using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stefanek.Data;
using Stefanek.Models;
using Stefanek.Repositories.Abstraction;

namespace Stefanek.Repositories.Implementation
{
    public class CarRepository : ICarRepository
    {
        readonly ApplicationContext _context;

        public CarRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Car> Cars => _context.Cars;

        public void Add(Car item)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Car item)
        {
            throw new NotImplementedException();
        }

        public void Update(Car item)
        {
            throw new NotImplementedException();
        }
    }
}
