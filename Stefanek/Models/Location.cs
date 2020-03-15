using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanek.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}
