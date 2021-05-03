using Microsoft.EntityFrameworkCore;
using System;
using Taxi.Core.Models;

namespace Taxi24.Data {
    public class Taxi24DbContext : DbContext{
        public Taxi24DbContext(DbContextOptions<Taxi24DbContext> options) : base(options) {

        }

        public DbSet<Driver> Driver { get; set; }
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Fare> Fare { get; set; }
        public DbSet<Trip> Trip { get; set; }
    }
}
