using Microsoft.EntityFrameworkCore;
using APBD_tutorial_10.Core.Data;

namespace APBD_tutorial_10.Core.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>()
            .HasKey(d => d.IdDoctor);

        modelBuilder.Entity<Medicament>()
            .HasKey(m => m.IdMedicament);

        modelBuilder.Entity<Patient>()
            .HasKey(p => p.IdPatient);

        modelBuilder.Entity<Prescription>()
            .HasKey(p => p.IdPrescription);

        modelBuilder.Entity<Prescription>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(p => p.IdPatient)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Prescription>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(p => p.IdDoctor)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne<Medicament>()
            .WithMany()
            .HasForeignKey(pm => pm.IdMedicament)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<PrescriptionMedicament>()
            .HasOne<Prescription>()
            .WithMany()
            .HasForeignKey(pm => pm.IdPrescription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
