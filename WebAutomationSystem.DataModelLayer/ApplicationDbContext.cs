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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUsers>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(e => e.Id).HasColumnName("UserID");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                
            });
            builder.Entity<ApplicationRoles>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
        }
    }
}