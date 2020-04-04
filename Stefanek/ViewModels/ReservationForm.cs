using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stefanek.Models;

namespace Stefanek.ViewModels
{
    public class ReservationForm
    {
        [Required(ErrorMessage = "Pole wymagane")]
        public int ReceptionCityId { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public int ReceptionLocationId { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public DateTime ReceptionDate { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public int ReturnCityId { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public int ReturnLocationId { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public DateTime ReturnDate { get; set; }

    }
}
