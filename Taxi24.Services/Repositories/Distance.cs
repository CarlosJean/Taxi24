using System;
using System.Collections.Generic;
using System.Text;

namespace Taxi24.Services.Repositories {
    public class Distance {
        public double DistanceBetweenPoints(double firstLatitude, double firstLongitude, double secondLatitude, double secondLongitude) {
            return Math.Sqrt((Math.Pow(firstLatitude - firstLongitude, 2) + Math.Pow(secondLatitude - secondLongitude, 2)));
        }
    }
}
