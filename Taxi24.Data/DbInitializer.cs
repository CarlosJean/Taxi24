using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taxi.Core.Models;

namespace Taxi24.Data {
    public static class DbInitializer {
        public static void Initialize(Taxi24DbContext context) {
            context.Database.EnsureCreated();

            //Datos de conductores.
            if (context.Driver.Any()) {
                return;   
            }

            //Datos de pasajeros
            if (context.Passenger.Any()) {
                return;
            }          
        }
    }
}
