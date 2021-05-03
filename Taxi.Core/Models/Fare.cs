using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi.Core.Models {
    public class Fare {
        public int Id { get; set; }
        public string Price { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
