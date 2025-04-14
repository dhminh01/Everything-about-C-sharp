using CompanyApi2.Models;
using CompanyApi2.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using CompanyApi2.Infrastructure.Dtos;

namespace CompanyApi2.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        { }

        public async Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Select(e => new EmployeeDepartmentDto
                {
                    Name = e.Name,
                    DepartmentName = e.Department != null ? e.Department.Name : "No Department"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsAsync()
        {
            return await _context.Employees
                .Select(e => new EmployeeProjectDto
                {
                    EmployeeName = e.Name,
                    ProjectNames = string.Join(", ",
                        e.ProjectEmployees
                            .Where(pe => pe.Enable && pe.Project != null)
                            .Select(pe => pe.Project!.Name))
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesAsync()
        {
            return await _context.Employees
                .Where(e => e.Salary != null &&
                            e.Salary.SalaryAmount > 100 &&
                            e.JoinedDate >= new DateTime(2024, 1, 1))
                .Select(e => new HighSalaryRecentEmployeeDto
                {
                    Name = e.Name,
                    Salary = e.Salary!.SalaryAmount,
                    JoinedDate = e.JoinedDate
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentRawSqlAsync()
        {
            string sql = @"
            SELECT e.Name AS Name, d.Name AS DepartmentName
            FROM Employees e
            INNER JOIN Departments d ON e.DepartmentId = d.Id
            ";

            return await _context.EmployeeDepartmentDto.FromSqlRaw(sql).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsRawSqlAsync()
        {
            string sql = @"
            SELECT e.Name AS EmployeeName, p.Name AS ProjectNames
            FROM Employees e
            LEFT JOIN ProjectEmployees pe ON e.Id = pe.EmployeeId
            LEFT JOIN Projects p ON pe.ProjectId = p.Id
            ";

            return await _context.Set<EmployeeProjectDto>().FromSqlRaw(sql).ToListAsync();
        }

        public async Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesRawSqlAsync()
        {
            string sql = @"
            SELECT e.Name, s.SalaryAmount AS Salary, e.JoinedDate
            FROM Employees e
            INNER JOIN Salaries s ON e.Id = s.EmployeeId
            WHERE s.SalaryAmount > 100 AND e.JoinedDate >= '2024-01-01'
            ";

            return await _context.HighSalaryRecentEmployeeDto.FromSqlRaw(sql).ToListAsync();
        }
    }
}
