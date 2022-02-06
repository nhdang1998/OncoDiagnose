using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.Models.Technician;

namespace OncoDiagnose.DataAccess.TechnicianData
{
    public class TechnicianDbContext : IdentityDbContext
    {
        public TechnicianDbContext(DbContextOptions<TechnicianDbContext> options) : base(options)
        {
            
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Result>()
                .Property(r => r.GeneName)
                .HasConversion(
                    v => v.ToString(),
                    v => (GeneName)Enum.Parse(typeof(GeneName), v));

            modelBuilder.Entity<Test>()
                .HasOne(t => t.Patient)
                .WithMany(p => p.Tests);
        }

    }
}
