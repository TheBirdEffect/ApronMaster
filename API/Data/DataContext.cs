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
    /*
        This class describes the Models of the database
        On creating the database with command 
        "dotnet ef database update"
        this code will executed and the Databse will 
        be build   
    */
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options){}        

        public DbSet<AircraftType> AircraftTypes { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<GroundVehicle> GroundVehicles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<VehicleSchedule> VehicleSchedules { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<AircraftTurnarroundPreset> AircraftTurnarroundTemplates { get; set; }
        public DbSet<TurnarroundVehicleTimeOffset> TurnarroundVehicleTimeOffsets { get; set; }
        public DbSet<AircraftType_ATT> AircraftType_ATTs { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.seedDemoData();
            modelBuilder.configureDbRelationships();
        }
    }
}