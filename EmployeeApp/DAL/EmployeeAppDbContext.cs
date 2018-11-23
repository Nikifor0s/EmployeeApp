using EmployeeApp.Models;
using System;
using System.Data.Entity;

namespace EmployeeApp.DAL
{
    public class EmployeeAppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PersonalDetails> PersonalDetails { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Work> Works { get; set; }

        internal object Include()
        {
            throw new NotImplementedException();
        }

        public EmployeeAppDbContext() : base("EmployeeAppContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shift>()
                .HasMany(e => e.Works)
                .WithRequired(e => e.Shift)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}