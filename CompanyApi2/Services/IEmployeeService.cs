using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Dtos;

namespace CompanyApi2.Services
{
    public interface IEmployeeService : IBaseService<Employee>
    {
        Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentAsync();
        Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsAsync();
        Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesAsync();

        Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentRawSqlAsync();
        Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsRawSqlAsync();
        Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesRawSqlAsync();
    }
}
