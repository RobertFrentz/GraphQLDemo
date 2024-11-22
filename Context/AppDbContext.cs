
using GettingStarted.Entities;
using Microsoft.EntityFrameworkCore;

namespace GettingStarted.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MedicalRecord>()
            .HasOne(r => r.Patient)
            .WithMany(p => p.MedicalRecords)
            .HasForeignKey(r => r.PatientId);
    }
}