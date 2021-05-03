using System;
using System.Collections.Generic;
using System.Linq;
using Taxi.Core.Models;
using Taxi24.Data;

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
    }
}
