using Microsoft.EntityFrameworkCore;
using PROGRESSTRACKER.CONFIGURATION;
using PROGRESSTRACKER.ENTITIES;
using System;

namespace PROGRESSTRACKER.DATACONTEXT
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<DailyReport> DailyReports { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }
        public DbSet<TimeTrackerTagRelation> TimeTrackerTag { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRelation> UserRelations { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Work> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 1, GenderName = "Male" });
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 2, GenderName = "Female" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Privilege = "Admin" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 2, Privilege = "Owner" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 3, Privilege = "Employee" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 4, Privilege = "Trainee" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 5, Privilege = "Customer" });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.LocalConnectionString);
        }
    }
}
