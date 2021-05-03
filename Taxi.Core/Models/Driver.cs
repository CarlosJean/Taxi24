using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Taxi.Core.Models {
    public class Driver {
        public int Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        [StringLength(1)]
        public string Available { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}
