using ClinicApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApplication.Contexts
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions options):base(options)//constructor chaining
        {
            
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creation of Primary key
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientNumber).HasName("PK_Patients");


            //Creating the foreign key with one to one relation
            modelBuilder.Entity<Patient>().HasOne(p => p.User)
                                          .WithOne(u => u.Patient)
                                          .HasForeignKey<Patient>(p => p.Email)
                                          .HasConstraintName("FK_Patients_Users_Email");

            //Creating the foreign key with one to many relation
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient)
                                             .WithMany(p => p.Appointments)
                                             .HasForeignKey(a => a.PatientNumber)
                                             .OnDelete(DeleteBehavior.Restrict)
                                             .HasConstraintName ("FK_Appointments_Patients_PatientNumber");

            //Creating the foreign key with one to many relation
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor)
                                             .WithMany(d => d.Appointments)
                                             .HasForeignKey(a => a.DoctorId)
                                             .OnDelete(DeleteBehavior.Restrict)
                                             .HasConstraintName("FK_Appointments_Doctors_DoctorId");
        }
    }
}
