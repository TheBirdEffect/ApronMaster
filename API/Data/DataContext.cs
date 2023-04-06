using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Migrations;
using API.DTOs;
using API.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<GroundVehicle> GroundVehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VehicleSchedule> VehicleSchedules { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AircraftTurnarroundTemplate> AircraftTurnarroundTemplates { get; set; }
        public DbSet<TurnarroundVehicleTimeOffset> TurnarroundVehicleTimeOffsets { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.seedDemoData();
        }
    }
}