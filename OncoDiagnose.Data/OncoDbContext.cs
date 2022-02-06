using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.Models;
using OncoDiagnose.Models.Technician;
using System;

namespace OncoDiagnose.DataAccess
{
    public class OncoDbContext : IdentityDbContext
    {
        public OncoDbContext(DbContextOptions<OncoDbContext> options) : base(options)
        {
        }

        public DbSet<Aliase> Aliases { get; set; }
        public DbSet<Alteration> Alterations { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<Gene> Genes { get; set; }
        public DbSet<CancerType> CancerTypes { get; set; }
        public DbSet<Consequence> Consequences { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Synonym> Synonyms { get; set; }
        public DbSet<DrugSynonym> DrugSynonyms { get; set; }
        public DbSet<GeneAliase> GeneAliases { get; set; }
        public DbSet<MutationArticle> MutationArticles { get; set; }
        public DbSet<TreatmentDrugs> TreatmentDrugs { get; set; }

        ////  Technician database
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Test> Tests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Tests)
                .WithOne(t => t.Patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Test)
                .WithMany(t => t.Results)
                .HasForeignKey(r => r.TestId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Run>()
                .HasOne(r => r.Test)
                .WithOne(t => t.Run)
                .HasForeignKey<Test>(t => t.RunId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Drug>()
                .HasMany(d => d.Synonyms)
                .WithMany(s => s.Drugs)
                .UsingEntity<DrugSynonym>(
                    j => j
                        .HasOne(ds => ds.Synonym)
                        .WithMany(s => s.DrugSynonyms)
                        .HasForeignKey(ds => ds.SynonymId),
                    j => j
                        .HasOne(ds => ds.Drug)
                        .WithMany(d => d.DrugSynonyms)
                        .HasForeignKey(ds => ds.DrugId),
                    j =>
                    {
                        j.HasKey(t => new { t.DrugId, t.SynonymId });
                    });

            modelBuilder.Entity<Gene>()
                .HasMany(g => g.Aliases)
                .WithMany(a => a.Genes)
                .UsingEntity<GeneAliase>(
                j => j
                    .HasOne(ga => ga.Aliase)
                    .WithMany(a => a.GeneAliases)
                    .HasForeignKey(ga => ga.AliaseId),
                j => j
                    .HasOne(ga => ga.Gene)
                    .WithMany(g => g.GeneAliases)
                    .HasForeignKey(ga => ga.GeneId),
                j =>
                {
                    j.HasKey(t => new { t.AliaseId, t.GeneId });
                });

            //Enum GeneName
            modelBuilder
                .Entity<Result>()
                .Property(r => r.GeneName)
                .HasConversion(
                    v => v.ToString(),
                    v => (GeneName)Enum.Parse(typeof(GeneName), v));

            modelBuilder.Entity<Test>()
                .HasOne(t => t.Patient)
                .WithMany(p => p.Tests)
                .HasForeignKey(t => t.PatientId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Run>()
                .HasOne(r => r.Test)
                .WithOne(t => t.Run)
                .HasForeignKey<Test>(t => t.RunId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Test>()
                .HasMany(t => t.Results)
                .WithOne(r => r.Test)
                .HasForeignKey(r => r.TestId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Consequence>()
                .HasMany(c => c.Alterations)
                .WithOne(a => a.Consequence)
                .HasForeignKey(a => a.ConsequenceId)
                .OnDelete(DeleteBehavior.ClientCascade);
                

            modelBuilder.Entity<Gene>()
                .HasMany(g => g.Alterations)
                .WithOne(a => a.Gene)
                .HasForeignKey(a => a.GeneId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Mutation>()
                .HasMany(m => m.Articles)
                .WithMany(a => a.Mutations)
                .UsingEntity<MutationArticle>(
                    j => j
                        .HasOne(ma => ma.Article)
                        .WithMany(a => a.MutationArticles)
                        .HasForeignKey(ma => ma.ArticleId),
                    j => j
                        .HasOne(ma => ma.Mutation)
                        .WithMany(m => m.MutationArticles)
                        .HasForeignKey(ma => ma.MutationId),
                    j =>
                    {
                        j.HasKey(t => new { t.ArticleId, t.MutationId });
                    });

            modelBuilder.Entity<Mutation>()
                .HasMany(m => m.Alterations)
                .WithOne(a => a.Mutation)
                .HasForeignKey(a => a.MutationId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Mutation>()
                .HasMany(m => m.Treatments)
                .WithOne(t => t.Mutation)
                .HasForeignKey(t => t.MutationId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Mutation>()
                .HasOne(m => m.CancerType)
                .WithMany(ct => ct.Mutations)
                .HasForeignKey(m => m.CancerTypeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Treatment>()
                .HasMany(t => t.Drugs)
                .WithMany(d => d.Treatments)
                .UsingEntity<TreatmentDrugs>(
                    j => j
                        .HasOne(td => td.Drug)
                        .WithMany(d => d.TreatmentDrugs)
                        .HasForeignKey(td => td.DrugId),
                    j => j
                        .HasOne(td => td.Treatment)
                        .WithMany(t => t.TreatmentDrugsList)
                        .HasForeignKey(td => td.TreatmentId),
                    j =>
                    {
                        j.HasKey(t => new { t.DrugId, t.TreatmentId });
                    }
                );

        }
    }
}