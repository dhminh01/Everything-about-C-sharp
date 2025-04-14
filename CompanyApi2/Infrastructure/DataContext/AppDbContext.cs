using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Seed;
using CompanyApi2.Infrastructure.Dtos;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi2.Infrastructure.DataContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<EmployeeDepartmentDto> EmployeeDepartmentDto { get; set; }
        public DbSet<EmployeeProjectDto> EmployeeProjectDto { get; set; }
        public DbSet<HighSalaryRecentEmployeeDto> HighSalaryRecentEmployeeDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureDepartment(modelBuilder);
            ConfigureProject(modelBuilder);
            ConfigureEmployee(modelBuilder);
            ConfigureProjectEmployee(modelBuilder);
            ConfigureSalary(modelBuilder);
            modelBuilder.Entity<EmployeeDepartmentDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<EmployeeProjectDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<HighSalaryRecentEmployeeDto>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.Salary).HasPrecision(18, 2);
            });

            modelBuilder.SeedAll();
        }

        private void ConfigureDepartment(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(d => d.Id);
                entity.Property(d => d.Id).ValueGeneratedNever();
                entity.Property(d => d.Name).IsRequired().HasMaxLength(100);
                entity.HasMany(d => d.Employees)
                      .WithOne(e => e.Department)
                      .HasForeignKey(e => e.DepartmentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureProject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).ValueGeneratedNever();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.HasMany(p => p.ProjectEmployees)
                      .WithOne(pe => pe.Project)
                      .HasForeignKey(pe => pe.ProjectId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.JoinedDate).IsRequired();

                entity.HasOne(e => e.Salary)
                      .WithOne(s => s.Employee)
                      .HasForeignKey<Salary>(s => s.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.ProjectEmployees)
                      .WithOne(pe => pe.Employee)
                      .HasForeignKey(pe => pe.EmployeeId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        private void ConfigureProjectEmployee(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEmployee>(entity =>
            {
                entity.HasKey(pe => new { pe.ProjectId, pe.EmployeeId });
                entity.Property(pe => pe.Enable).IsRequired();
            });
        }

        private void ConfigureSalary(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).ValueGeneratedNever();
                entity.Property(s => s.SalaryAmount)
                      .IsRequired()
                      .HasColumnType("decimal(18,2)");
            });
        }
    }
}
