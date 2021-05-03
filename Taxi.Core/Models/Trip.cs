using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Taxi.Core.Models {
    public class Trip {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int PassengerId { get; set; }
        public DateTime DemandDate { get; set; }
        public DateTime? FinishDate { get; set; }
        [StringLength(1)]
        public string Cancelled { get; set; }
        public int FareId { get; set; }
        public decimal OriginLatitude { get; set; }
        public decimal OriginLongitude { get; set; }
        public decimal DestinationLatitude { get; set; }
        public decimal DestinationLongitude { get; set; }

        public Driver Driver { get; set; }
        public Passenger Passenger { get; set; }
        public Fare Fare { get; set; }

    }
}
