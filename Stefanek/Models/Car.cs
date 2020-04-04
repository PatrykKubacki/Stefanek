using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanek.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Modele { get; set; }
        public string Year { get; set; }
        public decimal PriceADay { get; set; }
        public double EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public double FuelUrbanConsumption { get; set; }
        public double Fuel90KmPerHConsumption { get; set; }
        public string TypeOfFuel { get; set; }
    }
}
