using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stefanek.Models;

namespace Stefanek.ViewModels
{
    public class ConfirmReservation
    {
        public Car Car { get; set; }
        public ReservationForm ReservationForm { get; set; }
        public ReservationDetails ReservationDetails { get; set; }
        public decimal TotalPrice {
            get
            {
                var daysOfReservation = (ReservationForm.ReturnDate - ReservationForm.ReceptionDate).Days;
                return Car.PriceADay * daysOfReservation;
            }
        }
    }

    public class ReservationDetails
    {
        public string ReceptionCity { get; set; }
        public string ReceptionLocation { get; set; }

        public string ReturnCity { get; set; }
        public string ReturnLocation { get; set; }

    }
}
