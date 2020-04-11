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
        public IActionResult Reservation(ReservationForm reservationForm)
        {
            if (!ModelState.IsValid)
                return View("Index", reservationForm);

            ViewData["availableCars"] = _reservationHelper.GetAvailableCars(reservationForm);

            var model = new AvailableCarsForm
            {
                ReservationForm = reservationForm
            };

            return View("AvailableCars", model);
        }

        [HttpPost]
        public IActionResult AvailableCars(
            int id,
            string receptionDate,
            string returnDate,
            int receptionCityId,
            int receptionLocationId,
            int returnCityId,
            int returnLocationId
            )
        {
            var model = new ConfirmReservation
            {
                Car = _carRepository.GetById(id),
                ReservationForm = new ReservationForm
                {
                    ReceptionDate = Convert.ToDateTime(receptionDate),
                    ReturnDate = Convert.ToDateTime(returnDate),
                    ReceptionCityId = receptionCityId,
                    ReceptionLocationId = receptionLocationId,
                    ReturnCityId = returnCityId,
                    ReturnLocationId = returnLocationId
                },
                ReservationDetails = new ReservationDetails
                {
                    ReceptionCity = _cityRepository.GetById(receptionCityId).Name,
                    ReceptionLocation = _locationRepository.GetById(receptionLocationId).Name,
                    ReturnCity = _cityRepository.GetById(returnCityId).Name,
                    ReturnLocation = _locationRepository.GetById(returnLocationId).Name,
                }
            };

            return View("ConfirmReservation", model);
        }

        [HttpPost]
        public IActionResult ConfirmReservation(
            int id,
            string receptionDate,
            string returnDate)
        {
            var startDate = Convert.ToDateTime(receptionDate);
            var endDate = Convert.ToDateTime(returnDate);
            _reservationHelper.MakeReservation(id, startDate, endDate);
            return View("SummaryReservation");
        }

        public IActionResult About()
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