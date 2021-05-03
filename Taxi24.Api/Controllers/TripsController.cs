using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Core.Models;
using Taxi24.Data;
using Taxi24.Services;

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

        // GET api/<TripsController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<TripsController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<TripsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<TripsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
