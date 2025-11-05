using Entity.Infrastructure.DataInit;
using Entity.Infrastructure.DataInit.Implements;
using Entity.Models.Implements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SensorReading>()
                .HasOne(sr => sr.SensorDevice)
                .WithMany(sd => sd.sensorReadings)
                .HasForeignKey(sr => sr.SensorDeviceId)
                .OnDelete(DeleteBehavior.Restrict); // ❌ Evita cascada

            modelBuilder.Entity<SensorReading>()
                .HasOne(sr => sr.UserPlant)
                .WithMany(up => up.SensorReadings)
                .HasForeignKey(sr => sr.UserPlantId)
                .OnDelete(DeleteBehavior.Restrict); // ❌ Evita cascada

            modelBuilder.ApplyConfiguration(new PlantCategorySeeder());
            modelBuilder.ApplyConfiguration(new PlantSpeciesSeeder());
            modelBuilder.ApplyConfiguration(new UserSeeder());
            modelBuilder.ApplyConfiguration(new SensorDeviceSeeder());
            modelBuilder.ApplyConfiguration(new UserPlantSeeder());
            modelBuilder.ApplyConfiguration(new SensorReadingSeeder());
            modelBuilder.ApplyConfiguration(new NotificationSeeder());
        }

        public DbSet<PlantCategory> PlantCategory { get; set; }
        public DbSet<SensorDevice> SensorDevice { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<UserPlant> UserPlant { get; set; }
        public DbSet<PlantSpecies> PlantSpecies { get; set; }
        public DbSet<SensorReading> sensorReading { get; set; }
        
    }
}
