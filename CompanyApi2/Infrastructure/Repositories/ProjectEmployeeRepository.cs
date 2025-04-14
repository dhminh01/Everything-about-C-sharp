using CompanyApi2.Models;
using CompanyApi2.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi2.Infrastructure.Repositories
{
    public class ProjectEmployeeRepository : BaseRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        public ProjectEmployeeRepository(AppDbContext context) : base(context) { }

        public async Task<ProjectEmployee?> GetByIdAsync(Guid projectId, Guid employeeId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(pe => pe.ProjectId == projectId && pe.EmployeeId == employeeId);
        }

        public async Task DeleteAsync(Guid projectId, Guid employeeId)
        {
            var entity = await GetByIdAsync(projectId, employeeId);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await SaveChangesAsync();
            }
        }
    }
}
