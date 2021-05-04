using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Core.Models;
using Taxi24.Data;
using Taxi24.Services;
using Taxi24.Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxi24.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase {
        private readonly TripsService tripsService;
        public TripsController(Taxi24DbContext context) {
            this.tripsService = new TripsService(context);
        }
        // GET: api/<TripsController>
        [HttpGet]
        public List<Trip> Get() {
            return this.tripsService.Availables();
        }

        // POST api/<TripsController>
        [HttpPost]
        public void Post([FromBody] Trip trip) {
            this.tripsService.CreateTrip(trip);
        }

        [HttpPost("Complete")]
        public InvoiceDTO Complete([FromBody] Trip trip) {
            return this.tripsService.FinishTrip(trip.Id);
        }
    }
}
