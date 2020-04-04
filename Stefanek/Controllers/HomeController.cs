using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stefanek.Helpers;
using Stefanek.Models;
using Stefanek.Repositories.Abstraction;
using Stefanek.ViewModels;

namespace Stefanek.Controllers
{
    public class HomeController : Controller
    {
        readonly ILocationRepository _locationRepository;
        readonly ICityRepository _cityRepository;
        readonly ICarRepository _carRepository;
        readonly IReservationRepository _reservationRepository;
        readonly ReservationHelper _reservationHelper;

        public HomeController(ILocationRepository locationRepo,
            ICityRepository cityRepo,
            ICarRepository carRepo,
            IReservationRepository reservationRepo,
            ReservationHelper reservationHelper)
        {
            _locationRepository = locationRepo;
            _cityRepository = cityRepo;
            _carRepository = carRepo;
            _reservationRepository = reservationRepo;
            _reservationHelper = reservationHelper;
        }
        public IActionResult Index()
        {
            ViewData["cities"] = new SelectList(_cityRepository.Cities, "CityId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CheckCarAvailability(ReservationForm reservationForm)
        {
            if (!ModelState.IsValid)
                return View("Index", reservationForm);

            var availableCars = _reservationHelper.GetAvailableCars(reservationForm);

            return View("AvailableCars", availableCars);
        }

        [HttpPost]
        public IActionResult ConfirmReservation(int id)
        {
            return View();
        }

        public JsonResult GetLocationByCity(int cityId)
        {
            List<Location> list = new List<Location>();
            list = _locationRepository.Locations.Where(x=>x.CityId == cityId).ToList();
            return Json(new SelectList(list, "LocationId", "Name"));
        }
    }
}