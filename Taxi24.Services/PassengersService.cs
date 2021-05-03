using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Core.Models;
using Taxi24.Data;

namespace Taxi24.Services {
    public class PassengersService {
        private readonly Taxi24DbContext _db;
        public PassengersService(Taxi24DbContext context) {
            this._db = context;
        }

        public List<Passenger> GetAll() {
            return this._db.Passenger.ToList();
        }

        public Passenger Get(int id) {
            return this._db.Passenger.Where(p=>p.Id == id).FirstOrDefault();
        }
    }
}
