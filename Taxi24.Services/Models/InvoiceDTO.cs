using System;
using System.Collections.Generic;
using System.Text;
using Taxi.Core.Models;

namespace Taxi24.Services.Models {
    public class InvoiceDTO {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public PassengerDTO Passenger { get; set; }
        public DriverDTO Driver { get; set; }
        public double Price { get; set; }
    }
}
