using Checktify.Entity.Identity.Entities;
using Checktify.Entity.WebApplication.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Checktify.Repository.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public AppDbContext()
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<OfficeLocation> OfficeLocations { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
