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
    public class PassengersController : ControllerBase {
        private readonly PassengersService passengersService;
        
        public PassengersController(Taxi24DbContext context) {
            this.passengersService = new PassengersService(context);
        }
        // GET: api/<PassengersController
        [HttpGet]
        public List<Passenger> Get() {
            return this.passengersService.GetAll();
        }

        // GET api/<PassengersController>/5
        [HttpGet("{id}")]
        public Passenger Get(int id) {
            return this.passengersService.Get(id);
        }

        // POST api/<PassengersController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<PassengersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<PassengersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
