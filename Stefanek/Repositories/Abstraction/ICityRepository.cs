using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stefanek.Data;
using Stefanek.Models;

namespace Stefanek.Repositories.Abstraction
{
    public interface ICityRepository : IRepository<City>
    {
        IEnumerable<City> Cities { get; }
    }
}
