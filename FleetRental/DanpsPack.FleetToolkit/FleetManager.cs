using DanpsPack.FleetToolkit.Interfaces;
using DanpsPack.FleetToolkit.Models;
using Microsoft.Win32;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace DanpsPack.FleetToolkit
{
    public class FleetManager : IFleetManager
    {
        private readonly List<Car> _cars;
        private readonly List<Reservation> _reservations;

        public FleetManager()
        {
            _cars = new List<Car>
           {
               new Car
               {
                   Id = "CAR001",
                   Model = "Toyota Corolla",
                   DailyRate = 45.00m,
                   LastMaintenance = DateTime.Today.AddMonths(-1),
                   Mileage = 15000
               },
               new Car
               {
                   Id = "CAR002",
                   Model = "Honda Civic",
                   DailyRate = 50.00m,
                   LastMaintenance = DateTime.Today.AddMonths(-2),
                   Mileage = 22000
               },
               new Car
               {
                   Id = "CAR003",
                   Model = "Ford Focus",
                   DailyRate = 42.50m,
                   LastMaintenance = DateTime.Today.AddMonths(-3),
                   Mileage = 30000
               },
               new Car
               {
                   Id = "CAR004",
                   Model = "Chevrolet Cruze",
                   DailyRate = 48.75m,
                   LastMaintenance = DateTime.Today.AddMonths(-4),
                   Mileage = 27000
               },
               new Car
               {
                   Id = "CAR005",
                   Model = "Volkswagen Golf",
                   DailyRate = 55.00m,
                   LastMaintenance = DateTime.Today.AddMonths(-1),
                   Mileage = 18000
               },
               new Car
               {
                   Id = "CAR006",
                   Model = "Renault Sandero",
                   DailyRate = 40.00m,
                   LastMaintenance = DateTime.Today.AddMonths(-5),
                   Mileage = 35000
               }
           };

            _reservations = new List<Reservation>();
        }
        // Implementado pelo Copilot 

        public decimal CalculateRentalCost(string carId, int days)
        {
            var car = _cars.FirstOrDefault(c => c.Id == carId);
            if (car == null) throw new ArgumentException("Car not found.");
            return car.DailyRate * days;
        }

        public IEnumerable<Car> GetAvailableCars(DateTime from, DateTime to)
        {
            return _cars.Where(car => !_reservations.Any(res => res.CarId == car.Id &&
                (from < res.To && to > res.From)));
        }

        public IEnumerable<Car> GetOverdueReturns(DateTime asOf)
        {
            return _cars.Where(car => _reservations.Any(res => res.CarId == car.Id && res.To < asOf));
        }

        public DateTime PredictMaintenanceDate(Car car)
        {
            var monthsSinceLastMaintenance = (DateTime.Today - car.LastMaintenance).Days / 30;
            var mileageUntilNextMaintenance = 10000 - car.Mileage % 10000;
            var daysUntilNextMaintenance = Math.Min(mileageUntilNextMaintenance / 50, monthsSinceLastMaintenance * 30);
            return DateTime.Today.AddDays(daysUntilNextMaintenance);
        }

        public void ReserveCar(string carId, DateTime from, DateTime to)
        {
            if (!_cars.Any(c => c.Id == carId)) throw new ArgumentException("Car not found.");
            if (_reservations.Any(res => res.CarId == carId && (from < res.To && to > res.From)))
                throw new InvalidOperationException("Car is already reserved for the given period.");

            _reservations.Add(new Reservation
            {
                CarId = carId,
                From = from,
                To = to
            });
        }

        public int GetGasConsumption()
        {
            var random = new Random();
            return random.Next(8, 25);
        }
    }
}