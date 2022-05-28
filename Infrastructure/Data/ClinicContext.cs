using Microsoft.EntityFrameworkCore;
using justice_technical_assestment.Infrastructure.Models;

namespace justice_technical_assestment.Infrastructure.Data
{
    public class ClinicContext : DbContext
    {
        public string DbPath { get; }
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "clinic.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
     => options.UseSqlite($"Data Source={DbPath}");

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(p => p.Id);
            modelBuilder.Entity<Patient>().ToTable("Patient").HasKey(p => p.Id);
        }
    }
}