﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection")!;
            this.Database.SetConnectionString(_connectionString);
            this.Database.EnsureCreated();
        }
        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId, a.Booking });

            modelBuilder.Entity<Doctor>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Patient>()
                      .HasKey(p => p.Id);

            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>()
            .HasData(
                new List<Patient>
                {
                    new Patient { Id = 1, FullName = "bob" },
                    new Patient { Id = 2, FullName = "Son of bob" }
                }

             );
            modelBuilder.Entity<Doctor>()
           .HasData(
           new List<Doctor>
           {
                new Doctor { Id = 1, FullName= "John the ripper" },
                new Doctor { Id = 2, FullName = "Dexter" }
            }
           );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
