using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace web.Data
{
    public class ParkingContext : IdentityDbContext<ApplicationUser>
    {
        public ParkingContext(DbContextOptions<ParkingContext> options) : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Bus> Bus {get;set;}
        public DbSet<Spot> Spot { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().ToTable("car");
            modelBuilder.Entity<Enrollment>().ToTable("enrollment");
            modelBuilder.Entity<User>().ToTable("user");
            modelBuilder.Entity<Spot>().ToTable("spot");
            modelBuilder.Entity<Bus>().ToTable("bus");
        }
    }
}