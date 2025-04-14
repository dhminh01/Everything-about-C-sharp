using CompanyApi2.Models;
using CompanyApi2.Infrastructure.Repositories;

namespace CompanyApi2.Services
{
    public class ProjectEmployeeService : BaseService<ProjectEmployee>, IProjectEmployeeService
    {
        private readonly IProjectEmployeeRepository _projectEmployeeRepository;

        public ProjectEmployeeService(IProjectEmployeeRepository projectEmployeeRepository) : base(projectEmployeeRepository)
        {
            _projectEmployeeRepository = projectEmployeeRepository;
        }


        public async Task<ProjectEmployee?> GetByIdAsync(Guid projectId, Guid employeeId)
        {
            return await _projectEmployeeRepository.GetByIdAsync(projectId, employeeId);
        }

        public async Task DeleteAsync(Guid projectId, Guid employeeId)
        {
            await _projectEmployeeRepository.DeleteAsync(projectId, employeeId);
        }
    }
}
