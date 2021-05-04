using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Core.Models;
using Taxi24.Data;
using Taxi24.Services.Repositories;

namespace Taxi24.Services {
    public class DriverService {
        private readonly Taxi24DbContext _db;
        public DriverService(Taxi24DbContext context){
            this._db = context;
        }

        public List<Driver> GetAll() {
            return this._db.Driver.ToList();
        }

        public List<Driver> GetAvailables() {
            return this._db.Driver.Where(d=>d.Available == "S").ToList();
        }

        public Driver Get(int id) {
            return this._db.Driver.Where(d => d.Id == id).FirstOrDefault();
        }

        public List<Driver> GetNearDrivers(double passengersLatitude, double passengersLongitude) {

            var drivers = this._db.Driver.Where(d=>d.Available == "S").ToList();
            var nearDrivers = new List<Driver>();
            foreach (var driver in drivers) {
                if (driver.Latitude == null && driver.Longitude == null) {
                    continue;
                }
                var driversLatitude = (double)driver.Latitude;
                var driversLongitude = (double)driver.Longitude;
                var distance = new Distance().DistanceBetweenPoints(passengersLatitude, passengersLongitude, driversLatitude, driversLongitude);
                if (distance <= 3 ) {
                    nearDrivers.Add(driver);
                }
            }

            return nearDrivers.OrderByDescending(e=>new { e.Latitude, e.Longitude}).Take(3).ToList();
        }
    }
}
