using EmployeeApp.Models;
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
        public DbSet<ShiftAssign> ShiftAssigns { get; set; }

        public EmployeeAppDbContext() : base("EmployeeAppContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShiftAssign>()
                .HasRequired(s => s.Shift)
                .WithMany()
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}