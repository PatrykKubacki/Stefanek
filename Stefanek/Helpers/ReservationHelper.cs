using Stefanek.Models;
using Stefanek.Repositories.Abstraction;
using Stefanek.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanek.Helpers
{
    public class ReservationHelper
    {
        readonly ICarRepository _carRepository;
        readonly IReservationRepository _reservationRepository;

        public ReservationHelper(ICarRepository carRepo,IReservationRepository reservationRepo)
        {
            _carRepository = carRepo;
            _reservationRepository = reservationRepo;
        }

        public IEnumerable<Car> GetAvailableCars(ReservationForm reservationForm)
        {
            var reservationStartDate = reservationForm.ReceptionDate;
            var reservationEndDate = reservationForm.ReturnDate;
            var reservationsIds = _reservationRepository.Reservations
                .Where(x => x.StartDate >= reservationStartDate && x.EndTime <= reservationEndDate ||
                            x.StartDate >= reservationStartDate && x.EndTime >= reservationEndDate ||
                            x.StartDate <= reservationStartDate && x.EndTime <= reservationEndDate)
                .Select(x => x.CarId);

            return !reservationsIds.Any()
                ? _carRepository.Cars
                : _carRepository.Cars.Where(x => !reservationsIds.Contains(x.CarId));
        }

        public void MakeReservation(int carId, DateTime startTime, DateTime endTime)
        {
            var reservation = new Reservation
            {
                CarId = carId,
                StartDate = startTime,
                EndTime = endTime,

            };
            _reservationRepository.Add(reservation);
        }
    }
}
