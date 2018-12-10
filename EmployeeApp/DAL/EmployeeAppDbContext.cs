using EmployeeApp.Models.Employees;
using EmployeeProject.Models.Employees;
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
        public DbSet<Request> Requests { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }

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

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Leave>()
                .HasMany(l => l.Requests)
                .WithRequired(l => l.Leave)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.Project)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}