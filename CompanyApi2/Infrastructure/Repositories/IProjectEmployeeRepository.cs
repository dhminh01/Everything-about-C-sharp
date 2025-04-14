using CompanyApi2.Models;

namespace CompanyApi2.Infrastructure.Repositories
{
    public interface IProjectEmployeeRepository : IBaseRepository<ProjectEmployee>
    {
        Task<ProjectEmployee?> GetByIdAsync(Guid projectId, Guid employeeId);
        Task DeleteAsync(Guid projectId, Guid employeeId);
    }
}