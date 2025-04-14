using CompanyApi2.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi2.Infrastructure.Seed
{
    public static class SeedData
    {
        public static void SeedAll(this ModelBuilder modelBuilder)
        {
            var dept1 = Guid.Parse("8f4f6a22-9b63-4e87-a8b2-1b2d1f3fa111");
            var dept2 = Guid.Parse("a3d9a977-2f9f-4a93-b19b-9c52c67e1c22");
            var dept3 = Guid.Parse("f97a9f88-64ab-4f19-b84c-6d344dcb4a33");
            var dept4 = Guid.Parse("d78f59ac-5d73-4f1c-b2f0-83c6fc5e8d44");
            var dept5 = Guid.Parse("e34a4b23-dbd0-4b0d-9a2c-bc1111111111");

            var proj1 = Guid.Parse("e0f183f6-7e7f-4cd5-81f6-a87fa1125a55");
            var proj2 = Guid.Parse("bc8c5a1e-6d46-4f25-8321-2d918b92c866");
            var proj3 = Guid.Parse("1e8e4bc9-45df-4f7e-a1cb-8b2bd2a3e9f7");
            var proj4 = Guid.Parse("d43103b7-d6ff-4b3c-a8b1-c22222222222");

            var emp1 = Guid.Parse("b1a965ea-ffb1-4458-abc1-6eac4ef73a99");
            var emp2 = Guid.Parse("cd8d3781-7ac0-44a4-a275-b68c5be4bb76");
            var emp3 = Guid.Parse("92eb6f1d-cd24-49b1-a5cd-c29a3c3c1b53");
            var emp4 = Guid.Parse("0346a97a-14e6-4c1e-83ae-2d0eabef41c0");
            var emp5 = Guid.Parse("f3333333-4b3f-4a3c-8e6d-9d3333333333");

            var salary1 = Guid.Parse("fed3c3de-ea2a-4b77-94dc-9940c72dfb01");
            var salary2 = Guid.Parse("4cb7d999-3a44-4204-81c4-08fb51bcdb7b");
            var salary3 = Guid.Parse("d4b8f14c-865f-41e1-b457-8a4ac3c3462e");
            var salary4 = Guid.Parse("ca6d2799-7f53-4d3d-91f1-44e56a3b55e4");
            var salary5 = Guid.Parse("e5555555-aaaa-4a3f-aaaa-955555555555");

            SeedDepartments(modelBuilder, dept1, dept2, dept3, dept4, dept5);
            SeedProjects(modelBuilder, proj1, proj2, proj3, proj4);
            SeedEmployees(modelBuilder, emp1, emp2, emp3, emp4, emp5, dept1, dept2, dept3, dept4, dept5);
            SeedProjectEmployees(modelBuilder, proj1, proj2, proj3, proj4, emp1, emp2, emp3, emp4, emp5);
            SeedSalaries(modelBuilder, salary1, salary2, salary3, salary4, salary5, emp1, emp2, emp3, emp4, emp5);
        }

        private static void SeedDepartments(ModelBuilder modelBuilder, Guid d1, Guid d2, Guid d3, Guid d4, Guid d5)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = d1, Name = "Software Development" },
                new Department { Id = d2, Name = "Finance" },
                new Department { Id = d3, Name = "Accountant" },
                new Department { Id = d4, Name = "HR" },
                new Department { Id = d5, Name = "Marketing" }
            );
        }

        private static void SeedProjects(ModelBuilder modelBuilder, Guid p1, Guid p2, Guid p3, Guid p4)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = p1, Name = "Website Redesign" },
                new Project { Id = p2, Name = "Accounting Automation" },
                new Project { Id = p3, Name = "Recruitment Portal" },
                new Project { Id = p4, Name = "Product Launch Campaign" }
            );
        }

        private static void SeedEmployees(ModelBuilder modelBuilder, Guid e1, Guid e2, Guid e3, Guid e4, Guid e5,
                                  Guid d1, Guid d2, Guid d3, Guid d4, Guid d5)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = e1, Name = "Alice", DepartmentId = d1, JoinedDate = new DateTime(2022, 1, 10) },
                new Employee { Id = e2, Name = "Bob", DepartmentId = d2, JoinedDate = new DateTime(2021, 11, 5) },
                new Employee { Id = e3, Name = "Charlie", DepartmentId = d3, JoinedDate = new DateTime(2024, 2, 20) },
                new Employee { Id = e4, Name = "Diana", DepartmentId = d4, JoinedDate = new DateTime(2020, 7, 15) },
                new Employee { Id = e5, Name = "Evan", DepartmentId = d5, JoinedDate = new DateTime(2023, 8, 1) }
            );
        }

        private static void SeedProjectEmployees(ModelBuilder modelBuilder, Guid p1, Guid p2, Guid p3, Guid p4,
                                         Guid e1, Guid e2, Guid e3, Guid e4, Guid e5)
        {
            modelBuilder.Entity<ProjectEmployee>().HasData(
                new ProjectEmployee { ProjectId = p1, EmployeeId = e1, Enable = true },
                new ProjectEmployee { ProjectId = p2, EmployeeId = e2, Enable = true },
                new ProjectEmployee { ProjectId = p3, EmployeeId = e4, Enable = true },
                new ProjectEmployee { ProjectId = p1, EmployeeId = e3, Enable = false },
                new ProjectEmployee { ProjectId = p4, EmployeeId = e5, Enable = true }
            );
        }

        private static void SeedSalaries(ModelBuilder modelBuilder, Guid s1, Guid s2, Guid s3, Guid s4, Guid s5,
                                 Guid e1, Guid e2, Guid e3, Guid e4, Guid e5)
        {
            modelBuilder.Entity<Salary>().HasData(
                new Salary { Id = s1, EmployeeId = e1, SalaryAmount = 3000000 },
                new Salary { Id = s2, EmployeeId = e2, SalaryAmount = 1500000 },
                new Salary { Id = s3, EmployeeId = e3, SalaryAmount = 2000000 },
                new Salary { Id = s4, EmployeeId = e4, SalaryAmount = 1000000 },
                new Salary { Id = s5, EmployeeId = e5, SalaryAmount = 2500000 }
            );
        }
    }
}
