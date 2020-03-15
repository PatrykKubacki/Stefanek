using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stefanek.Models;

namespace Stefanek.ViewModels
{
    public class ReservationForm
    {
        public int ReceptionCityId { get; set; }
        public int ReceptionLocationId { get; set; }
        public DateTime ReceptionDate { get; set; }

        public int ReturnCityId { get; set; }
        public int ReturnLocationId { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
