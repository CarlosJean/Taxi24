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
    public class DriversController : ControllerBase {

        private readonly DriverService driverService;
        public DriversController(Taxi24DbContext context) {
            this.driverService = new DriverService(context);
        }

        // GET: api/<DriversController>
        [HttpGet]
        public IEnumerable<Driver> Get() {
            return this.driverService.GetAll();
        }

        // GET: api/<DriversController>
        [HttpGet]
        [Route("available")]
        public IEnumerable<Driver> Available() {
            return this.driverService.GetAvailables();
        }

        // GET api/<DriversController>/5
        [HttpGet("{id}")]
        public Driver Get(int id) {
            return this.driverService.Get(id);
        }

        [HttpGet("lat={lat}&lng={lng}")]
        public List<Driver> Get(double lat, double lng) {
            return this.driverService.GetNearDrivers(lat, lng);
        }
    }
}
