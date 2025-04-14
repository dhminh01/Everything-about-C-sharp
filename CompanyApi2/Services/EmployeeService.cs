using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Dtos;
using CompanyApi2.Infrastructure.Repositories;

namespace CompanyApi2.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
            : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentAsync()
        {
            return await _employeeRepository.GetEmployeesWithDepartmentAsync();
        }

        public async Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsAsync()
        {
            return await _employeeRepository.GetEmployeesWithProjectsAsync();
        }

        public async Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesAsync()
        {
            return await _employeeRepository.GetHighSalaryRecentEmployeesAsync();
        }

        public async Task<IEnumerable<EmployeeDepartmentDto>> GetEmployeesWithDepartmentRawSqlAsync()
        {
            return await _employeeRepository.GetEmployeesWithDepartmentRawSqlAsync();
        }

        public async Task<IEnumerable<EmployeeProjectDto>> GetEmployeesWithProjectsRawSqlAsync()
        {
            return await _employeeRepository.GetEmployeesWithProjectsRawSqlAsync();
        }

        public async Task<IEnumerable<HighSalaryRecentEmployeeDto>> GetHighSalaryRecentEmployeesRawSqlAsync()
        {
            return await _employeeRepository.GetHighSalaryRecentEmployeesRawSqlAsync();
        }
    }
}
