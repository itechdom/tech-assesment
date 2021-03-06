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

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Kin> Kins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User").HasKey(p => p.Id);
            modelBuilder.Entity<Doctor>().ToTable("Doctor").HasKey(p => p.DoctorId);
            modelBuilder.Entity<Doctor>().ToTable("Doctor").HasData(
                new Doctor
                {
                    DoctorId = 1,
                    Code = 428101981,
                    Initialis = "o.s.",
                    MobileNumber = "+966501987111",
                    Surname = "Almali"
                }
            );
            modelBuilder.Entity<Kin>().ToTable("Kin").HasKey(p => p.Id);
            modelBuilder.Entity<Kin>().ToTable("Kin").HasData(
                new Kin
                {
                    Id = 1,
                    FirstName = "Mohammed",
                    LastName = "Ali",
                    AddressLineOne = "Address test 1",
                    AddressLineTwo = "Address test two",
                    AddressLineThree = "Address test 3",
                    AddressLineFour = "Address test 4",
                    PostalCode = "123321",
                    Relation = Relationship.Mother
                }
            );
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder.Entity<Patient>().ToTable("Patient").HasData(
                new Patient
                {
                    Id = 1,
                    DoctorId = 1,
                    FirstName = "Osama",
                    LastName = "Alghanmi",
                    DateOfBirth = new DateTime(1989, 11, 11),
                    Gender = GenderCode.M,
                    MobileNumber = "0501977200",
                    PassNo = "XYZ190222"
                }
            );
        }
    }
}