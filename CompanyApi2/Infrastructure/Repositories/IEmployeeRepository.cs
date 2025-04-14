using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Dtos;

namespace CompanyApi2.Infrastructure.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentAsync();
        Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsAsync();
        Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesAsync();

        Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentRawSqlAsync();
        Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsRawSqlAsync();
        Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesRawSqlAsync();
    }
}
