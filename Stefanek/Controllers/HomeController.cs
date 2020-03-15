using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Stefanek.Models;
using Stefanek.Repositories.Abstraction;
using Stefanek.ViewModels;

namespace Stefanek.Controllers
{
    public class HomeController : Controller
    {
        readonly ILocationRepository _locationRepository;
        readonly ICityRepository _cityRepository;

        public HomeController(ILocationRepository locationRepo, ICityRepository cityRepo)
        {
            _locationRepository = locationRepo;
            _cityRepository = cityRepo;
        }
        public IActionResult Index()
        {
            ViewData["cities"] = new SelectList(_cityRepository.Cities, "CityId", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult CheckCarAvailability(ReservationForm reservationFormform)
        {
            return null;
        }

        public JsonResult GetLocationByCity(int cityId)
        {
            List<Location> list = new List<Location>();
            list = _locationRepository.Locations.Where(x=>x.CityId == cityId).ToList();
            return Json(new SelectList(list, "LocationId", "Name"));
        }
    }
}