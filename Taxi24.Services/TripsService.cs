using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Core.Models;
using Taxi24.Data;
using Taxi24.Services.Models;
using Taxi24.Services.Repositories;

namespace Taxi24.Services {
    public class TripsService {
        private readonly Taxi24DbContext _db;
        public TripsService(Taxi24DbContext context) {
            this._db = context;
        }

        public List<Trip> Availables() {
            return this._db.Trip.Where(t=>t.FinishDate == null).ToList();
        }

        public InvoiceDTO FinishTrip(int tripId) {
            try {
                var entity = this._db.Trip.Where(t => t.Id == tripId).FirstOrDefault();
                if (entity != null) { 
                    entity.FinishDate = DateTime.Now;
                    this._db.Trip.Update(entity);
                    this._db.SaveChanges();   
                }

                return this.Invoice(entity.Id);

            } catch (Exception) {

                throw;

            }        
        }

        public bool CreateTrip(Trip trip) {

            try {

                var fareId = this._db.Fare
                    .Where(f => f.RegistrationDate <= DateTime.Now)
                    .OrderByDescending(f => f.RegistrationDate)
                    .FirstOrDefault()
                    .Id;
                
                this._db.Trip.Add(new Trip { 
                    DriverId = trip.DriverId,
                    PassengerId = trip.PassengerId,
                    OriginLatitude = trip.OriginLatitude,
                    OriginLongitude = trip.OriginLongitude,
                    DestinationLatitude = trip.DestinationLatitude,
                    DestinationLongitude = trip.DestinationLongitude,
                    DemandDate = DateTime.Now,
                    FareId = fareId,
                    Cancelled = "N"
                });
                this._db.SaveChanges();
                return true;
            } catch (Exception) {

                return false;
                //throw;
            }
        }


        private InvoiceDTO Invoice(int tripId) {

            //Buscamos el viaje.
            var trip = this._db.Trip.Where(t=>t.Id == tripId).FirstOrDefault();

            if (trip == null) {
                return new InvoiceDTO() { };
            }

            //Buscamos al pasajero
            var passenger = this._db.Passenger.Where(p => p.Id == trip.PassengerId).FirstOrDefault();

            //Armamos el objeto con los datos del pasajero
            var passengerDto = new PassengerDTO() {
                Names = passenger.Names,
                surnames = passenger.Surnames
            };

            //Obtenemos al conductor del viaje y armamos el DTO.
            var driver = this._db.Driver.Where(d => d.Id == trip.DriverId).FirstOrDefault();
            var driverDto = new DriverDTO() {
                Fullname = driver.Names + " " + driver.Surnames
            };

            //Buscamos la tarifa actual
            var currentFare = this._db.Fare.OrderByDescending(f => f.RegistrationDate).FirstOrDefault().Price;

            var distance = new Distance().DistanceBetweenPoints((double)trip.OriginLatitude, (double)trip.OriginLongitude, (double)trip.DestinationLatitude, (double)trip.DestinationLongitude);

            var price = Convert.ToDouble(currentFare) * distance;
            return new InvoiceDTO() {
                id = new Random().Next(100000),
                Date = DateTime.Now,
                Passenger = passengerDto,
                Driver = driverDto,
                Price = price
            };
        }

    }
}
