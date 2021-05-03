using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Core.Models {
    public class Passenger {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
