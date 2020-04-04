﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanek.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndTime { get; set; }

        public Car Car { get; set; }
    }
}
