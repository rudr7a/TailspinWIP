using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Tailspin.Surveys.Data.DataModels
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tenant>()
                 .HasKey(t => t.Id);

            modelBuilder.Entity<User>()
                 .HasKey(u => new { u.Id, u.TenantId });

            modelBuilder.Entity<Survey>()
                .HasKey(s => new { s.Id, s.TenantId });

            modelBuilder.Entity<Question>()
                .HasKey(q => new { q.Id, q.SurveyId, q.TenantId });

            modelBuilder.Entity<SurveyContributor>()
                .HasKey(sc => new { sc.Id, sc.SurveyId, sc.TenantId });

            modelBuilder.Entity<ContributorRequest>()
                .HasKey(cr => new { cr.Id, cr.SurveyId, cr.TenantId });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Tenant)
                .WithMany(t => t.Users)
                .HasForeignKey(u => u.TenantId);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.Owner)
                .WithMany(u => u.OwnedSurveys)
                .HasForeignKey(s => new { s.OwnerId, s.TenantId });

            modelBuilder.Entity<Survey>()
                  .HasOne(s => s.Tenant)
                  .WithMany(u => u.Surveys)
                  .HasForeignKey(s => new { s.TenantId, s.OwnerId });

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Survey)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => new { q.SurveyId, q.TenantId });

            modelBuilder.Entity<SurveyContributor>()
                .HasOne(sc => sc.Survey)
                .WithMany(s => s.Contributors)
                .HasForeignKey(sc => new { sc.SurveyId, sc.TenantId });

            modelBuilder.Entity<ContributorRequest>()
                .HasOne(cr => cr.Survey)
                .WithMany(s => s.ContributerRequests)
                .HasForeignKey(cr => new { cr.SurveyId, cr.TenantId });
        }
        public DbSet<Tenant> Tenants { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<SurveyContributor> SurveyContributors { get; set; }

        public DbSet<ContributorRequest> ContributorRequests { get; set; }


    }


}



