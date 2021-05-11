using FitnessClubManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FitnessClubManagementSystem.DAL
{
    public class FitnessClubContext : DbContext
    {

        public FitnessClubContext() : base("FitnessClubContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserLogin> userLogins { get; set; }
        public DbSet<Customer> customers { get; set; } 
        public DbSet<Club> clubs { get; set; }
        public DbSet<MembershipPackages> membershipPackages { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Slots> slots { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

     
    }
}