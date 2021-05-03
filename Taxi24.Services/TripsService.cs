using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Core.Models;
using Taxi24.Data;

namespace Taxi24.Services {
    public class TripsService {
        private readonly Taxi24DbContext _db;
        public TripsService(Taxi24DbContext context) {
            this._db = context;
        }

        public List<Trip> Availables() {
            return this._db.Trip.Where(t=>t.FinishDate == null).ToList();
        }

        public bool FinishTrip(int tripId) {
            try {
                var entity = this._db.Trip.Where(t => t.Id == tripId).FirstOrDefault();
                entity.FinishDate = DateTime.Now;
                this._db.SaveChanges();
                return true;

            } catch (Exception) {

                //throw;
                return false;

            }        
        }

        public bool CreateTrip(Trip trip) {

            try {
                this._db.Trip.Add(trip);
                return true;
            } catch (Exception) {

                return false;
                //throw;
            }
        }

    }
}
