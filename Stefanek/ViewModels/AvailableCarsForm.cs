using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stefanek.Models;

namespace Stefanek.ViewModels
{
    public class AvailableCarsForm
    {
        public ReservationForm ReservationForm { get; set; }
        public int CarId { get; set; }  
    }
}
