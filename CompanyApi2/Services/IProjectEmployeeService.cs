using CompanyApi2.Models;

namespace CompanyApi2.Services
{
    public interface IProjectEmployeeService : IBaseService<ProjectEmployee>
    {
        Task<ProjectEmployee?> GetByIdAsync(Guid projectId, Guid employeeId);
        Task DeleteAsync(Guid projectId, Guid employeeId);
    }
}
