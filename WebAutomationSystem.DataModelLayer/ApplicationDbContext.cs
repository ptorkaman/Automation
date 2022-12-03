using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAutomationSystem.DataModelLayer.Entities;

namespace WebAutomationSystem.DataModelLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUsers, ApplicationRoles, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
              
        }

        public DbSet<JobsChart> JobsCharts { get; set; }
        public DbSet<UserJob> UserJobs { get; set; }
        public DbSet<Reminder>  Reminders { get; set; }
        public DbSet<RolePattern> RolePatterns { get; set; }
        public DbSet<RolePatternDetails> RolePatternDetails { get; set; }
        public DbSet<Letters> Letters { get; set; }
        public DbSet<AdministrativeForm> AdministrativeForms { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUsers>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                
            });
            builder.Entity<ApplicationRoles>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
        }
    }
}