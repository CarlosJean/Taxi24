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

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Fare>().HasData(new Fare() { Id = 10, Price = "70", RegistrationDate = DateTime.Now});
            modelBuilder.Entity<Passenger>().HasData(new { 
                Id = 100,
                Names = "Jhanssel",
                Surnames = "Berihuete",
                RegistrationDate = DateTime.Now
            },
            new {
                Id = 102,
                Names = "Karen",
                Surnames = "Then",
                RegistrationDate = DateTime.Now
            },
            new {
                Id = 103,
                Names = "Oel",
                Surnames = "De La Rosa",
                RegistrationDate = DateTime.Now
            });
            modelBuilder.Entity<Driver>().HasData(new Driver() { 
                Id = 101,
                Names = "Jean Carlos",
                Surnames = "Holguin Berihuete",
                Available = "S",
                Latitude = (decimal)18.494749709524456,
                Longitude = (decimal)-69.80455398559572                
            },
            new Driver() {
                Id = 102,
                Names = "Fanny",
                Surnames = "Guerrero",
                Available = "S",
                Latitude = (decimal)18.525189768078093,
                Longitude = (decimal)-69.91527557373048
            },
            new Driver() {
                Id = 103,
                Names = "Maria",
                Surnames = "Alcantara",
                Available = "N",
            });
        }
    }
}
